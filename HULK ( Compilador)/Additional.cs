
namespace Hulk
{

    public class Additional
    {
        // Diccionario donde asocio algunos tipos de token con las expresiones que conforman
        public static Dictionary<Token, Expressions> Global_variables = new Dictionary<Token, Expressions>();

        //Diccionario donde asocio el nombre de la función con  con las expresiones de tipo declaracion de funciones 
        public static Dictionary<string, FunctionDeclarations> Functions_global = new Dictionary<string, FunctionDeclarations>();

        //Diccionario donde asocio el nombre de la función con  con los parámetros de las expresiones de tipo llamada de función
        public static Dictionary<Token, Stack<object>> Func_Call_Params = new Dictionary<Token, Stack<object>>();


        public static int cant_vaces_variables_en_func;
        public static string error = "";
        public static bool declared_func;
        public static bool call_func;
        public static bool if_expression_active;
        public static bool created_stack;
        public static bool func_recursive;


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

        public static List<Token> Insert_params_recursivos(List<Token> tokens, int actual)
        {
            for (int a = Convert.ToInt32(tokens[actual].Value); a >= 0; a--)
            {
                if (a == Convert.ToInt32(tokens[actual].Value)) continue;
                tokens.Insert(actual + 1, new Token(Token.TokenType.Comma, ","));
                tokens.Insert(actual + 2, new Token(Token.TokenType.Number_Literal, a.ToString()));
                actual+=2;
            }
            return tokens;
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