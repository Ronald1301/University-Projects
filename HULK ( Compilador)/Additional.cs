namespace Hulk
{

    public class Additional
    {
        // Diccionario donde asocio algunos tipos de token con las expresiones que conforman
        public static Dictionary<Token, Expressions> Global_variables = new Dictionary<Token, Expressions>();
        //public static List<FunctionDeclarations> functionDeclarations = new List<FunctionDeclarations>();
        public static Dictionary<string, FunctionDeclarations> Functions_global = new Dictionary<string, FunctionDeclarations>();
        public static Dictionary<Token, object> Func_Call_Params = new Dictionary<Token, object>();
        //public static Dictionary<string, Expressions> FuncDeclaredBody = new Dictionary<string, Expressions>();
        public static string error = "";
        public static bool declared_func;
        public static bool call_func;

        public static bool Check_Exist_Func(string name, int count)
        {
            if (Additional.Functions_global.ContainsKey(name) && Additional.Functions_global[name].Params.Count == count) return true;
            return false;
        }
        public static bool Search_LINQ(List<Token> tokens, int actual)
        {
            for (int i = actual; i < tokens.Count; i++)
            {
                if (tokens[i].Type == Token.TokenType.Token_LINQ) return true;
            }
            return false;
        }

        public static bool Func_Predef(Token predef)
        {
            if (predef.Type == Token.TokenType.Token_Log) return true;
            if (predef.Type == Token.TokenType.Token_Cos) return true;
            if (predef.Type == Token.TokenType.Token_Sen) return true;
            if (predef.Type == Token.TokenType.Token_Cot) return true;
            if (predef.Type == Token.TokenType.Token_Tan) return true;

            return false;
        }
        public enum DataType
        {
            number, word, boolean, ID, function, error,
        }
    }
}