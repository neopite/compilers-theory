namespace TheoryOfCompilators.Syntaxer
{
    public interface AbstractTokenParser<T>
    {
        public T CreateToken();
    }
}