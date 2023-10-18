namespace Hulk
{
    public class iDExpresions : Expressions
    {
        public Token token;
        public iDExpresions(Token token)
        {
            this.token = token;
        }

        public override bool CheckSemantic()
        {
            throw new NotImplementedException();
        }

        public override double Evaluate()
        {
            foreach (var item in Token.Global.Keys)
            {
                if (token.Value == item.Value) return Token.Global[item].Evaluate();
            }
            throw new Exception();
        }
    }
}