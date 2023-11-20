using System.Data.Common;

namespace Hulk
{
    public class iDExpresions : Expressions
    {
        public Token token;
        public iDExpresions(Token token)
        {
            this.token = token;
        }

        public override Token.DataType CheckSemantic()
        {
            if (!Convert.ToBoolean(Token.Global.ContainsKey(token))) return Token.DataType.number;
            Error error = new TypeError(ErrorCode.SemanticError, "The variable is not previously created");
            App.Error(error.Text());
            return Token.DataType.error;
        }

        public override object Evaluate()
        {
            foreach (var item in Token.Global.Keys)
            {
                if (token.Value == item.Value) return Token.Global[item].Evaluate();
            }
            throw new Exception();
        }
    }
}