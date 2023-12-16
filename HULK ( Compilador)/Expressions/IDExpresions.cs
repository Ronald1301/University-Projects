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

        public override Additional.DataType CheckSemantic()
        {
            if (!Convert.ToBoolean(Additional.Global_variables.ContainsKey(token))) return Additional.DataType.number;
            Error error = new TypeError(ErrorCode.SemanticError, "The variable is not previously created");
            App.Error(error.Text());
            return Additional.DataType.error;
        }

        public override object Evaluate()
        {
            foreach (var item in Additional.Global_variables.Keys)
            {
                if (token.Value == item.Value) return Additional.Global_variables[item].Evaluate();
            }
            throw new Exception();
        }
    }
}