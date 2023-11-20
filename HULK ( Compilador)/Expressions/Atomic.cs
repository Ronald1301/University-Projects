using System.Data.Common;

namespace Hulk
{
    public class Atomic : Expressions
    {
        public Token token;
        // public Expressions id;

        public Atomic(Token token/*,Expressions id=null!*/)
        {
            this.token = token;
            // this.id= id;
        }

        public override Token.DataType CheckSemantic()
        {
            if(token.Type==Token.TokenType.Number||token.Type==Token.TokenType.Number_Literal||token.Type==Token.TokenType.Token_Cos||token.Type==Token.TokenType.Token_Cot||token.Type==Token.TokenType.Token_Dif||token.Type==Token.TokenType.Token_Div||token.Type==Token.TokenType.Token_Log||token.Type==Token.TokenType.Token_Mod||token.Type==Token.TokenType.Token_Multi||token.Type==Token.TokenType.Token_PI||token.Type==Token.TokenType.Token_Pow||token.Type==Token.TokenType.Token_Sen||token.Type==Token.TokenType.Token_Sqrt||token.Type==Token.TokenType.Token_Sum||token.Type==Token.TokenType.Token_Tan) return Token.DataType.number;
            if(token.Type==Token.TokenType.Chain_Literals||token.Type==Token.TokenType.String||token.Type==Token.TokenType.Token_Concat)return Token.DataType.number;
            if(token.Type==Token.TokenType.Identifier)return Token.DataType.number;
            if(token.Type==Token.TokenType.Token_False||token.Type==Token.TokenType.Token_And||token.Type==Token.TokenType.Token_True||token.Type==Token.TokenType.Token_DoubleEqual||token.Type==Token.TokenType.Token_Less||token.Type==Token.TokenType.Token_LessOrEqual||token.Type==Token.TokenType.Token_More||token.Type==Token.TokenType.Token_MoreOrEqual||token.Type==Token.TokenType.Token_NoEqual||token.Type==Token.TokenType.Token_Or||token.Type==Token.TokenType.Token_Not)return Token.DataType.number;
            throw new();
        }

        public override object Evaluate()
        {
            //id.Evaluate();
            if (token.Type == Token.TokenType.Token_PI) return Math.PI;
            return token.Value;
        }
    }
}