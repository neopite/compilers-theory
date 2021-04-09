using System;
using System.Collections.Generic;
using System.IO;
using TheoryOfCompilators.Lexer;

namespace TheoryOfCompilators.Syntaxer.Token
{
    public class SyntaxParser
    {
        private static List<Lex> _lexes;
        public static int _currentLex;

        public SyntaxParser(List<Lex> lexes)
        {
            _lexes = lexes;
        }
        
        public static Lex Parse(string value, LexType lexType)
        {
            if (_currentLex >= _lexes.Count)
            {
                throw new Exception("Lexes is ended up");
            }

            var token = _lexes[_currentLex];
            if ((value == null || token.Value == value) && (lexType == null || token.LexType == lexType))
            {
                _currentLex++;
                return token;
            }
            else throw new Exception("Error");
        }

        public static Lex GetCurrentLex()
        {
            return _lexes[_currentLex];
        }
    }
}