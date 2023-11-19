using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Hulk
{
    public static class LexicalAnalyzer
    {
        // este método analiza la cadena de entrada y la convierte en una lista de token
        public static List<Token> Tokenize(string line)
        {
            List<Token> tokens = new List<Token>();

            string aux = "";

            // un ciclo para ir iterando por la entrada
            for (int i = 0; i < line.Length; i++)
            {
                //si es un espacio en blanco,cambia el caracter a analizar de la entrada
                if (line[i] == ' ' && aux == "") continue;

                //si el caracter que analizo es vacio o es final de linea y la variable auxiliar no es vacia 
                //entonces analiza lo que hay en aux si es un token 
                if ((line[i] == ' ' || line[i] == ';') && aux != "")
                {
                    tokens.Add(GetToken(aux));
                    aux = "";
                    if (i != line.Length - 1) continue;
                }

                // esto analizara cuando el caracter es un digito para poder obtener un token de tipo numero
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

                //si el caracter son comillas,analiza si hay un token de tipo string
                if (line[i] == '\"' || line[i] == '"')
                {
                    //si la variable auxiliar no es vacia,analiza si es un token y guardalo en la lista
                    if (aux != "") tokens.Add(GetToken(aux));

                    // analizo el caracter como string
                    (int, string) string_result = GetString(i + 1, line);
                    tokens.Add(new Token(Token.TokenType.Chain_Literals, string_result.Item2));
                    i = string_result.Item1 - 1;
                    aux = "";
                    continue;
                }

                //si no es una letra y no es algun tipo de lo anterior,entonces es un simbolo y analizara si es un token de tipo operador
                if (!char.IsLetter(line[i]))
                {
                    //si la variable auxiliar no es vacia,analiza si es un token y guardalo en la lista
                    if (aux != "") tokens.Add(GetToken(aux));
                    // analizo el caracter como operador 
                    (int, string) symbol = GetOperator(i, line);
                    //cambio el indice para analizar el siguiente caracter
                    i = symbol.Item1;
                    //analizo los(el) caracteres(caracter) devueltos(devuelto) para formar un token y lo guardo en la lista
                    tokens.Add(GetToken(symbol.Item2));
                    //reinicio la variable auxiliar y cambio el indice para analizar el pr{oximo caracterf
                    aux = "";
                    continue;
                }

                //aqui guardo el caracter en la variable auxiliar
                aux += line[i];
            }

            //obtengo como resultado una lista de tokenF
            return tokens;
        }

        //metodo para saber si es un token existente,si no ,crea un token de tipo identificador
        public static Token GetToken(string id)
        {
            try
            {
                //verifico si es un tipo de token que tengo en el diccionario
                return Token.AllTokens[id];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                // si no se cumple lo anteior creo un token tipo identificador
                return new Token(Token.TokenType.Identifier, id);
            }
        }

        //método para analizar el número dado en la cadena
        static (int, string) GetNumber(int start, string line)
        {
            string number = "";

            // ciclo para obtener el numero completo,ya que el numero puede estar compuesto por mas de un caracter 
            while (Char.IsLetterOrDigit(line[start]) || line[start] == 'e' || line[start] == '.')
            {
                // si el caracter es una letra entonces el token es inválido
                if (char.IsLetter(line[start]))
                {
                    Error error = new TypeError(ErrorCode.LexicalError, number + line[start]);
                    App.Error(error.Text());
                }
                number += line[start++];
                if (start == line.Length) break;
            }
            return (start, number);
        }

        //metodo para analizar un string encontrado en la cadena 
        static (int, string) GetString(int start, string line)
        {
            string result = "";
            try
            {
                while (line[start] != '"' || line[start] != '\"')
                {
                    result += line[start];
                    start += 1;
                }
                start++;
            }
            catch (System.IndexOutOfRangeException)
            {
                Error error = new TypeError(ErrorCode.LexicalError, result + line[start]);
                App.Error(error.Text());
            }

            return (start, result);
        }

        //metodo para analizar un simbolo dado en la cadena
        static (int, string) GetOperator(int start, string line)
        {
            string opera = $"{line[start]}";
            //si con el caracter siguiente coincide con un operador,entonces me da esos caraccteres que forman un token
            if (start < line.Length - 1)
            {
                if (Token.AllTokens.ContainsKey(opera + line[start + 1])) return (start + 1, opera += line[start + 1]);
            }
            //si no se cumple lo anterior devuelvo el mismo caracter que corresponde a un token
            return (start, opera);
        }
    }
}