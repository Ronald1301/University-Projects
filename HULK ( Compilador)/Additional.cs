namespace Hulk
{

    public class Additional
    {
        // Diccionario donde asocio algunos tipos de token con las expresiones que conforman
        public static Dictionary<Token, Expressions> Global_variables = new Dictionary<Token, Expressions>();
        //public static List<FunctionDeclarations> functionDeclarations = new List<FunctionDeclarations>();
        public static Dictionary<string, FunctionDeclarations> Functions_global = new Dictionary<string, FunctionDeclarations>();
        //public static Dictionary<string, List<Token>> FuncDeclaredParams = new Dictionary<string, List<Token>>();
        //public static Dictionary<string, Expressions> FuncDeclaredBody = new Dictionary<string, Expressions>();
        public static string error = "";
        public static bool declared_func;

        public static bool Check_Exist_Func(string name, int count)
        {
            if (Additional.Functions_global.ContainsKey(name) && Additional.Functions_global[name].Params.Count == count) return true;

            return false;
        }
        public enum DataType
        {
            number, word, boolean, ID, function, error,
        }
    }
}