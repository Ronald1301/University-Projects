using System.Data.Common;

namespace Hulk
{
    public class Atomic: Expressions
    {
        public Token token;
        public Expressions id;

        public Atomic(Token token,Expressions id=null)
        {
            this.token = token;
            this.id= id;
        }

        public override double Evaluate()
        {
             //id.Evaluate();
            return double.Parse(token.Value);
        }
    }
}