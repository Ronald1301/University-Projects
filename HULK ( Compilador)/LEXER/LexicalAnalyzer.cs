using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Hulk
{
public class LexicalAnalyzer
{
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

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public static List<string> List_Keyword = new List<string> { "let", "in", "if", "else", "function", "print" };
        public static List<string> List_Operator = new List<string> { "+", "-", "*", "/" };


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
            WhiteSpace, Open_Paren, Close_Paren, Open_Block, Close_Block, Open_Key, Close_Key, EndLine, Coma,

            //Booleans
            Token_True, Token_False,

            Number,
            Chain_Literals, Number_Literal,//entero

            //Functions
            Token_Log, Token_Sen, Token_Cos, Token_Tan, Token_Cot, Token_Sqrt, Token_Pow, Token_PI,

            String,

            Token_SpaceLine, Token_LINQ, Token_Concat,

        }

        public static Dictionary<string, Token> AllTokens = new Dictionary<string, Token>()
        {
            //Keyword
            {"let", new Token(TokenType.Token_Let, "let")},
            {"if", new Token(TokenType.Token_If, "if")},
            {"else", new Token(TokenType.Token_Else, "else")},
            {"in", new Token(TokenType.Token_In, "in")},
            {"then", new Token(TokenType.Token_Then, "then")},
            {"while", new Token(TokenType.Token_While, "while")},
            {"print", new Token(TokenType.Print, "print")},
            {"function", new Token(TokenType.Token_Function, "function")},

            //Operator
            {"+", new Token(TokenType.Token_Sum, "+")},
            {"-", new Token(TokenType.Token_Dif, "-")},
            {"*", new Token(TokenType.Token_Multi, "*")},
            {"/", new Token(TokenType.Token_Div, "/")},
            {"=", new Token(TokenType.Token_Equal, "=")},
            {"%", new Token(TokenType.Token_Mod, "%")},

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
            {",", new Token(TokenType.Coma,",")},

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
            {"print", new Token(TokenType.Print,"print")},
            {"PI", new Token(TokenType.Token_PI, "PI")},
            
            //Otros
            {",", new Token(TokenType.Token_SpaceLine, ",")},
            {"=>", new Token(TokenType.Token_LINQ, "=>")},
            {"@", new Token(TokenType.Token_Concat, "@")},

            {"string", new Token(TokenType.String, "")},

        };
    }


    public static class Tokenizer
    {

        public static List<Token> Tokenize(string line)

        {

            List<Token> tokens = new List<Token>();

            string aux = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ' && aux == "") continue;

                if ((line[i] == ' ' || line[i] == ';') && aux != "")
                {
                    tokens.Add(GetToken(aux));
                    aux = "";
                }

                if (Char.IsDigit(line[i]))
                {
                    if (line[i - 1] == ' ')
                    {
                        (int, string) number = GetNumber(i, line);
                        i = number.Item1;
                        tokens.Add(new Token(Token.TokenType.Number_Literal, number.Item2));
                        aux = "";
                    }
                    else aux += line[i];
                }

                if (Char.IsLetterOrDigit(line[i]))
                {
                    if (line[i - 1] == ' ' || i == 0)
                    {
                        (int, string) word = GetKeywordOrIdentifier(i, line);
                        i = word.Item1;
                        tokens.Add(GetToken(word.Item2));
                        aux = "";
                    }
                    else continue;
                }

                if (line[i] == '"')
                {
                    if (aux != "")
                    {
                        tokens.Add(GetToken(aux));
                        aux = "";
                    }
                    else
                    {
                        while (line[i] != '"')
                        {
                            if(line[i]==line.Length)throw new Lexical_Error("Invalid Token");
                            aux += line[i];
                            i++;
                        }
                        tokens.Add(new Token(Token.TokenType.String, aux += line[i]));
                        aux = "";
                        i++;
                    }

                }
                if (line[i] == '\"')
                {
                    (int, string) string_result = GetString(i + 1, line);
                    aux = string_result.Item2;
                    tokens.Add(new Token(Token.TokenType.Chain_Literals, aux));
                    i = string_result.Item1;
                    aux = "";
                    continue;
                }

                else
                {
                    (int, string) symbol = GetOperator(i, line);
                    i = symbol.Item1;
                    tokens.Add(GetToken(symbol.Item2));
                    aux = "";

                }

            }

            return tokens;

        }

        public static Token GetToken(string id)
        {
            try
            {
                return Token.AllTokens[id];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                return new Token(Token.TokenType.Identifier, id);
            }
        }

        static (int, string) GetNumber(int start, string line)
        {
            string number = $"{line[start]}";

            if (char.IsLetter(line[start]))
            {
                throw new Lexical_Error("Invalid Token");
            }

            /*
                         if ((line[i] == 'e' && IsE) || (line[i] == '.' && Is_Come))
                            {
                                throw new Lexical_Error("Invalid Token");
                            }
            */


            while (Char.IsDigit(line[start]) || line[start] == 'e' || line[start] == '.')
            {
                number += line[start++];
            }
            return (start, number);

            /* // Recursivo
            int count;
            if (Char.IsDigit(line[start++]))
            {
                count++;
                return number +=
            }
            else return (count, number);
            */
        }

        static (int, string) GetKeywordOrIdentifier(int start, string line)
        {
            string temp = $"{line[start]}";
            while (Char.IsLetter(line[start++]))
            {
                temp += line[start++];
            }
            return (start, temp);
        }

        static (int, string) GetString(int start, string line)
        {
            string result = "";
            while (line[start] != '\"')
            {
                result += line[start];
                start += 1;
            }
            return (start, result);
        }

        static (int, string) GetOperator(int start, string line)
        {
            string opera = $"{line[start]}";
            if (Token.AllTokens.ContainsKey(opera += line[start + 1])) return (start++, opera += line[start + 1]);
            else return (start, opera);
        }

    }

}
}