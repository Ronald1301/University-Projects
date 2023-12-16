using System.Data.Common;

namespace Hulk
{
    public class iDExpresions : Expressions
    {
        public Token token;
        public Expressions value;
        public iDExpresions(Token token, Expressions value)
        {
            this.token = token;
            this.value = value;
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

/*
            foreach (var item in Here!.Corpus_Values.Keys)
            {
                if (item.Value == ID.Value)
                {
                    return Here.Corpus_Values[item];
                }
            }

*/

            if (Additional.call_func)
            {
                foreach (var item in Additional.Func_Call_Params.Keys)
                {
                   if (token.Value == item.Value) return Additional.Func_Call_Params[item];
                }
            }



            //viejos pincha
            else
                foreach (var item in Additional.Global_variables.Keys)
                {
                    if (token.Value == item.Value) return Additional.Global_variables[item].Evaluate();
                }
            throw new Exception();
        }
    }
}