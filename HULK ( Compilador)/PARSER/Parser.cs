namespace Hulk
{
    public static class Parser
    {
        public static (int, Expressions) L(List<LexicalAnalyzer.Token> tokens, int actual)
        {
            var result = M(tokens, actual);
            if (result.Item1 == tokens.Count - 1 && tokens[result.Item1].Type == LexicalAnalyzer.Token.TokenType.EndLine) return result;
            throw new Exception();
        }
        public static (int, Expressions) M(List<LexicalAnalyzer.Token> tokens, int actual)
        {
            if (tokens[actual].Type == LexicalAnalyzer.Token.TokenType.Print)
            {
                if (tokens[actual + 1].Type == LexicalAnalyzer.Token.TokenType.Open_Paren)
                {
                    var result = M(tokens, actual+1);
                    if (tokens[result.Item1].Type == LexicalAnalyzer.Token.TokenType.Close_Paren)
                    {
                        return (result.Item1 + 1,result.Item2);
                    }
                    throw new Exception();
                }
                throw new Exception();
                if()
                if()
                
            }
            
            return A();
        }
        public static (int, Expressions) A(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) Z(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) B(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) E(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) W(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) X(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) F(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) P(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
        public static (int, Expressions) T(List<LexicalAnalyzer.Token> tokens, int actual)
        {

        }
    }
}