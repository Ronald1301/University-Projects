namespace Hulk
{
    // clase token en la cual declaro la forma de los token
    public class Token
    {
        /*
        Tipos de Tokens
        1- Keyword: let, in, if, while, then, else, function
        2- Identifier: The name of any variable, class, function
        3- Operators
        3.1-- Math (+, =, -, *, /, %)
        3.2-- Relationship (<, >, <=, >=, !=, ==)
        3.3-- Logic (&&, ||, !)
        3.4-- Increment (++, --)
        4- Separators: whitespace, \t, \n, signers(. , ; () {} [])
        5- Literals
        5.1-- Entero: 5,4,3,-1,0
        5.2-- Flotante: 34.2, 10e23, -90.8
        5.3-- Cadena: "Hola",'H'
        */

        public TokenType Type { get; set; }
        public string Value { get; set; }

        //Constructor de la clase Token
        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        // Aquí declaro todos los tipos de token que pueden existir en el lenguaje
        public enum TokenType
        {
            //Keyword
            Token_Let, Token_Else, Token_If, Token_In, Token_Function, Token_Then, Token_While, Print,

            Identifier,

            //Operator
            Token_Sum, Token_Dif, Token_Multi, Token_Div, Token_Equal, Token_Mod,
            Token_Less, Token_More, Token_LessOrEqual, Token_MoreOrEqual, Token_DoubleEqual, Token_NoEqual,

            //Operadores Lógicos
            Token_Not, Token_And, Token_Or,

            //Caracteres Especiales
            WhiteSpace, Open_Paren, Close_Paren, Open_Block, Close_Block, Open_Key, Close_Key, EndLine, Comma,

            //Booleans
            Token_True, Token_False,

            Number,
            Chain_Literals, Number_Literal,//entero

            //Functions
            Token_Log, Token_Sen, Token_Cos, Token_Tan, Token_Cot, Token_Sqrt, Token_Pow, Token_PI,

            String,

            Token_SpaceLine, Token_LINQ, Token_Concat,

        }

        // Esto es un diccionario de cada cadena en la entrada con el tipo de token que representa
        public static Dictionary<string, Token> AllTokens = new Dictionary<string, Token>()
        {
            //Keyword
            {"let", new Token(TokenType.Token_Let, "let")},
            {"if", new Token(TokenType.Token_If, "if")},
            {"else", new Token(TokenType.Token_Else, "else")},
            {"in", new Token(TokenType.Token_In, "in")},
            {"then", new Token(TokenType.Token_Then, "then")},
            //{"while", new Token(TokenType.Token_While, "while")},
            {"print", new Token(TokenType.Print, "print")},
            {"function", new Token(TokenType.Token_Function, "function")},

            //Operadores aritméticos
            {"+", new Token(TokenType.Token_Sum, "+")},
            {"-", new Token(TokenType.Token_Dif, "-")},
            {"*", new Token(TokenType.Token_Multi, "*")},
            {"/", new Token(TokenType.Token_Div, "/")},
            {"=", new Token(TokenType.Token_Equal, "=")},
            {"%", new Token(TokenType.Token_Mod, "%")},

            //Operadores de comparación
            {"<", new Token(TokenType.Token_Less,"<")},
            {">", new Token(TokenType.Token_More,">")},
            {"<=", new Token(TokenType.Token_LessOrEqual,"<=")},
            {">=", new Token(TokenType.Token_MoreOrEqual,">=")},
            {"==", new Token(TokenType.Token_DoubleEqual,"==")},
            {"!=", new Token(TokenType.Token_NoEqual,"!=")},

           //Operadores Lógicos
            {"!", new Token(TokenType.Token_Not,"!")},
            {"&", new Token(TokenType.Token_And,"&")},
            {"|", new Token(TokenType.Token_Or,"|")},

            //Caracteres Especiales
            {" ", new Token(TokenType.WhiteSpace," ")},
            {"(", new Token(TokenType.Open_Paren,"(")},
            {")", new Token(TokenType.Close_Paren,")")},
            {"[", new Token(TokenType.Open_Block,"[")},
            {"]", new Token(TokenType.Close_Block,"]")},
            {"{", new Token(TokenType.Open_Key,"{")},
            {"}",new Token(TokenType.Close_Key,"}")},
            {";",new Token(TokenType.EndLine,";")},
            {",", new Token(TokenType.Comma,",")},

            //Booleans
            {"true", new Token(TokenType.Token_True, "true")},
            {"false", new Token(TokenType.Token_False, "false")},

            //Functions
            {"log",new Token(TokenType.Token_Log,"log")},
            {"sin", new Token(TokenType.Token_Sen,"sin")},
            {"cos", new Token(TokenType.Token_Cos,"cos")},
            {"tan", new Token(TokenType.Token_Tan,"tan")},
            {"cot", new Token(TokenType.Token_Cot,"cot")},
            {"^",new Token(TokenType.Token_Pow,"^")},
            {"sqrt", new Token(TokenType.Token_Sqrt,"sqrt")},
            {"pi", new Token(TokenType.Token_PI, "PI")},
            
            //Otros
            {"=>", new Token(TokenType.Token_LINQ, "=>")},
            {"@", new Token(TokenType.Token_Concat, "@")},
        };

        // Diccionario donde asocio algunos tipos de token con las expresiones que conforman
        public static Dictionary<Token, Expressions> Global = new Dictionary<Token, Expressions>();
        public static string error = "";
    }
}