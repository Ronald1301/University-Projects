using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Hulk
{
    //En este clase analizo la linea de entrada y asocio cada cadena con su tipo de token 
    public static class LexicalAnalyzer
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
                    continue;
                }

                if (Char.IsDigit(line[i]))
                {
                    if (aux == "")
                    {
                        (int, string) number = GetNumber(i, line);
                        i = number.Item1 - 1;
                        tokens.Add(new Token(Token.TokenType.Number_Literal, number.Item2));
                    }
                    else aux += line[i];
                    continue;
                }
                if (line[i] == '\"')
                {
                    if (aux != "") tokens.Add(GetToken(aux));

                    (int, string) string_result = GetString(i + 1, line);
                    tokens.Add(new Token(Token.TokenType.Chain_Literals, string_result.Item2));
                    i = string_result.Item1 - 1;
                    aux = "";
                    continue;
                }
                if (!char.IsLetter(line[i]))
                {
                    if (aux != "") tokens.Add(GetToken(aux));

                    (int, string) symbol = GetOperator(i, line);
                    i = symbol.Item1;
                    tokens.Add(GetToken(symbol.Item2));
                    aux = "";
                    continue;
                }
                aux += line[i];
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
            string number = "";

            if (char.IsLetter(line[start]))
            {
                throw new Lexical_Error("Invalid Token");
            }

            while (Char.IsDigit(line[start]) || line[start] == 'e' || line[start] == '.')
            {
                number += line[start++];
            }
            return (start, number);
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
            if (start < line.Length - 1)
            {
                if (Token.AllTokens.ContainsKey(opera + line[start + 1])) return (start++, opera += line[start + 1]);
            }
            return (start, opera);
        }
    }
}