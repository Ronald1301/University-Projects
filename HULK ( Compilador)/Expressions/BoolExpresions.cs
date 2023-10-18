namespace Hulk
{
    public class BoolExpresions : Expressions
    {
        public enum Operators
        {
            Less, More, LessOrEqual, MoreOrEqual, DoubleEqual, NoEqual, And, Or,

        }
        public Expressions left;
        public Expressions right;
        Operators operators;

        public BoolExpresions(Expressions left, Expressions right, Operators operators)
        {
            this.left = left;
            this.right = right;
            this.operators = operators;
        }
/*
        public override bool CheckSemantic()
        {
            
        }*/

        public override double Evaluate()
        {
            double a = left.Evaluate();
            double b = right.Evaluate();
            switch (this.operators)
            {
                case Operators.DoubleEqual:
                    return a == b ? 1 : 0;
                case Operators.Less:
                    return a < b ? 1 : 0;
                case Operators.LessOrEqual:
                    return a <= b ? 1 : 0;
                case Operators.More:
                    return a > b ? 1 : 0;
                case Operators.MoreOrEqual:
                    return a >= b ? 1 : 0;
                /*  
                case Operators.And:
                      return (a == true) && (b == true) ? 1 : 0;
                  case Operators.Or:
                      return (a == true) || (b == true) ? 1 : 0;
                */
                default:
                    return a != b ? 1 : 0;
            }
        }
    }
}
