using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheoryOfCompilators.Lexer
{
    public class Lexer : ILexer
    { 
        private StringBuilder _currentBuffer;
        private List<Lex> _allLexes;
        private  readonly List<char> _delimeters = new List<char>() {' ', ',', ';', '.', '=','{','[',']','}',':','(',')'};
        private  readonly List<string> _keyword = new List<string>() {"Begin", "Node_places", "Lines","val","new"};
        private  LexerState _state;

        public List<Lex> AllLexes
        {
            get => _allLexes;
            private set => _allLexes = value;
        }

        public Lexer()
        {
            _allLexes = new List<Lex>();
        }

        public void FindLex(char[] chars)
       {
           _currentBuffer = new StringBuilder("");
           for (int i = 0; i < chars.Length; i++)
           {
               char curChar = chars[i];
               switch (_state)
               {
                   case LexerState.START :
                       if (_delimeters.Contains(curChar))
                       {
                           if (curChar == ' ')
                           {
                               continue;
                           }
                           PushLex(new Lex(_allLexes.Count+1,LexType.DELIMETER,curChar.ToString()));
                           
                       }else if (Char.IsDigit(curChar))
                       {
                           _state = LexerState.NUM;
                           _currentBuffer.Append(curChar);
                       }else if (Char.IsLetter(curChar))
                       {
                           _state = LexerState.WORD;
                           _currentBuffer.Append(curChar);

                       }else if (curChar == '"')
                       {
                           _state = LexerState.STRING;
                           _currentBuffer.Append(curChar);
                       }
                       break;
                   
                   case LexerState.WORD :
                       if (Char.IsLetter(curChar))
                       {
                           _currentBuffer.Append(curChar);
                           _state = LexerState.WORD;
                       }
                       else
                       {
                           List<string> allTypes = System.Enum.GetNames(typeof(VarType)).ToList();
                           
                           if (allTypes.Contains(_currentBuffer.ToString()))
                           {
                               PushLex(new Lex(_allLexes.Count + 1 , LexType.TYPE , _currentBuffer.ToString()));
                           }
                           else
                           {
                               int keyword = _keyword.IndexOf(_currentBuffer.ToString());
                               if (keyword != -1)
                                   PushLex(new Lex(_allLexes.Count + 1, LexType.KEYWORD, _currentBuffer.ToString()));
                               else PushLex(new Lex(_allLexes.Count + 1, LexType.IDENTIFIER, _currentBuffer.ToString()));
                           }
                           _currentBuffer.Clear();
                           _state = LexerState.START;
                       }
                       break;
                   case LexerState.STRING :
                       if (Char.IsLetter(curChar))
                       {
                           _currentBuffer.Append(curChar);
                       }else if (curChar == '"')
                       {
                           _currentBuffer.Remove(0, 1);
                           PushLex(new Lex(_allLexes.Count + 1, LexType.STRING, _currentBuffer.ToString()));
                           _currentBuffer.Clear();
                           _state = LexerState.START;
                       }
                       else
                       {
                           _currentBuffer.Append(curChar);
                           PushLex(new Lex(_allLexes.Count + 1, LexType.ERR, _currentBuffer.ToString()));
                           _currentBuffer.Clear();
                           _state = LexerState.START;
                       }
                       break;
                   case LexerState.NUM :
                       if (Char.IsDigit(curChar))
                       {
                           _currentBuffer.Append(curChar);
                       }
                       else
                       {
                           _currentBuffer.Append(curChar);
                           PushLex(new Lex(_allLexes.Count + 1, LexType.NUMBER, _currentBuffer.ToString()));
                           _currentBuffer.Clear();
                           _state = LexerState.START;
                       }
                       break;
               }
           }
       }

       public void PushLex(Lex lex)
       { 
           _allLexes.Add(lex);
       }

       public void PrintLexems()
       {
           for (int i = 0; i < _allLexes.Count; i++)
           {
               Console.WriteLine("ID : " + _allLexes[i].Id + " LEX_TYPE : " + _allLexes[i].LexType + " VALUE : " + _allLexes[i].Value);
           }
       }
    }
}