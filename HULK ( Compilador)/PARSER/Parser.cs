﻿using System.Linq.Expressions;

namespace Hulk
{
    public static class Parser
    {
        public static (int, Expressions) L(List<Token> tokens, int actual)
        {
            var result = M(tokens, actual);
            if (result.Item1 == tokens.Count - 1 && tokens[result.Item1].Type == Token.TokenType.EndLine) return result;
            throw new Exception();
        }
        public static (int, Expressions) M(List<Token> tokens, int actual, Expressions last = null!)
        {
            if (tokens[actual].Type == Token.TokenType.Print)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Open_Paren)
                {
                    var result = M(tokens, actual + 1, last);
                    if (tokens[result.Item1].Type == Token.TokenType.Close_Paren)
                    {
                        return (result.Item1 + 1, result.Item2);
                    }
                    throw new Exception();
                }
                throw new Exception();
            }
            if (tokens[actual].Type == Token.TokenType.Token_If)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Open_Paren)
                {
                    var if_part = M(tokens, actual + 2, last);
                    var body = M(tokens, if_part.Item1, last);
                    if (tokens[if_part.Item1].Type == Token.TokenType.Close_Paren)
                    {
                        var part2 = M(tokens, if_part.Item1 + 1);
                        if (tokens[part2.Item1].Type == Token.TokenType.Token_Else)
                        {
                            var else_part = M(tokens, body.Item1);
                            return (else_part.Item1, new ConditionalExpresions(if_part.Item2, body.Item2, else_part.Item2));
                        }
                        throw new Exception();
                    }
                    throw new Exception();
                }
                throw new Exception();
            }
            if (tokens[actual].Type == Token.TokenType.Token_Let)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Identifier)
                {
                    if (tokens[actual + 2].Type == Token.TokenType.Token_Equal)
                    {
                        var result_let = M(tokens, actual + 3);
                        Expressions id = new Assignment(tokens[actual + 1], result_let.Item2);

                        if (tokens[result_let.Item1 + 1].Type == Token.TokenType.Coma)
                        {
                            tokens.Insert(result_let.Item1 + 2, new Token(Token.TokenType.Token_Let, "let"));
                            var result = M(tokens, result_let.Item1 + 3);
                            Expressions second=new LetExpresions(id,result.Item2);
                            return (result.Item1,second);
                        }
                        if (tokens[result_let.Item1].Type == Token.TokenType.Token_In)
                        {
                            var result = M(tokens, result_let.Item1 + 1);
                            Expressions second=new LetExpresions(id,result.Item2);
                            return (result.Item1,second);
                        }
                      //  Expressions let_in= new LetExpresions(id,second);
                        throw new Exception();
                    }
                    throw new Exception();
                }
                throw new Exception();
            }
            //if (tokens[actual].Type == Token.TokenType.Token_Function)

            return A(tokens, actual, last);
        }
        public static (int, Expressions) A(List<Token> tokens, int actual, Expressions last)
        {
            (int, Expressions) result_z;
            if (tokens[actual].Type == Token.TokenType.Token_Not)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions notexpresion = new Unary(result_B.Item2, Unary.Operators.Not);
                result_z = Z(tokens, result_B.Item1, notexpresion);
            }
            else
            {
                var result_B = B(tokens, actual, last);
                result_z = Z(tokens, result_B.Item1, result_B.Item2);
            }
            return result_z;
        }
        public static (int, Expressions) Z(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_And)
            {
                var result_A = A(tokens, actual + 1, last);
                Expressions andexpresions = new BoolExpresions(last, result_A.Item2, BoolExpresions.Operators.And);
                return (result_A.Item1, andexpresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Or)
            {
                var result_A = A(tokens, actual + 1, last);
                Expressions orexpresions = new BoolExpresions(last, result_A.Item2, BoolExpresions.Operators.Or);
                return (result_A.Item1, orexpresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) B(List<Token> tokens, int actual, Expressions last)
        {
            var result_W = W(tokens, actual, last);
            var result_E = E(tokens, result_W.Item1, result_W.Item2);
            return result_E;
        }
        public static (int, Expressions) E(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_And)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions doubleequalexpresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.Operators.DoubleEqual);
                return (result_B.Item1, doubleequalexpresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_LessOrEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions LessOrEquallexpresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.Operators.LessOrEqual);
                return (result_B.Item1, LessOrEquallexpresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_MoreOrEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions MoreOrEqualexpresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.Operators.MoreOrEqual);
                return (result_B.Item1, MoreOrEqualexpresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_NoEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions NoEqualexpresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.Operators.NoEqual);
                return (result_B.Item1, NoEqualexpresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_Less)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions Lessexpresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.Operators.Less);
                return (result_B.Item1, Lessexpresions);
            }


            if (tokens[actual].Type == Token.TokenType.Token_More)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions Moreexpresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.Operators.More);
                return (result_B.Item1, Moreexpresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) W(List<Token> tokens, int actual, Expressions last)
        {
            var result_F = F(tokens, actual, last);
            var result_X = X(tokens, result_F.Item1, result_F.Item2);
            return result_X;
        }
        public static (int, Expressions) X(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_Sum)
            {
                var result_W = W(tokens, actual + 1, last);
                Expressions sumexpresions = new AritmeticBinary(last, result_W.Item2, AritmeticBinary.Operators.add);
                return (result_W.Item1, sumexpresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Dif)
            {
                var result_W = W(tokens, actual + 1, last);
                Expressions difexpresions = new AritmeticBinary(last, result_W.Item2, AritmeticBinary.Operators.dif);
                return (result_W.Item1, difexpresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) F(List<Token> tokens, int actual, Expressions last)
        {
            var result_T = T(tokens, actual, last);
            var result_P = P(tokens, result_T.Item1, result_T.Item2);
            return result_P;
        }
        public static (int, Expressions) P(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_Multi)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions multexpresions = new AritmeticBinary(last, result_F.Item2, AritmeticBinary.Operators.mult);
                return (result_F.Item1, multexpresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Div)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions divexpresions = new AritmeticBinary(last, result_F.Item2, AritmeticBinary.Operators.div);
                return (result_F.Item1, divexpresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Pow)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions powexpresions = new AritmeticBinary(last, result_F.Item2, AritmeticBinary.Operators.Pow);
                return (result_F.Item1, powexpresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Mod)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions porcentexpresions = new AritmeticBinary(last, result_F.Item2, AritmeticBinary.Operators.Mod);
                return (result_F.Item1, porcentexpresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) T(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Number_Literal)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Chain_Literals)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_False)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_True)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Sen)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Sen));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Cos)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Cos));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Tan)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Tan));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Cot)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Cot));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Sqrt)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Sqrt));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Log)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Log));
            }
            if (tokens[actual].Type == Token.TokenType.Open_Paren)
            {
                var result_M = M(tokens, actual + 1, last);
                if (tokens[result_M.Item1].Type == Token.TokenType.Close_Paren)
                {
                    return (result_M.Item1 + 1, result_M.Item2);
                }
                else throw new Exception();
            }
            throw new Exception();
        }
    }
}