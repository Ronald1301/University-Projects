namespace Hulk
{
    public class ArithmeticBinary : Expressions
    {
        public enum Operators
        {
            add, multi, dif, div, Pow, Mod,
        }
        public Expressions left;
        public Expressions right;
        Operators operators;

        public ArithmeticBinary(Expressions left, Expressions right, Operators operators)
        {
            this.left = left;
            this.right = right;
            this.operators = operators;

        }

        public override bool CheckSemantic()
        {
            //throw new NotImplementedException();
            if (left.CheckSemantic())
            {
                if (right.CheckSemantic())
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        public override double Evaluate()
        {
            switch (this.operators)
            {
                case Operators.add:
                    return left.Evaluate() + right.Evaluate();

                case Operators.multi:
                    return left.Evaluate() * right.Evaluate();

                case Operators.dif:
                    return left.Evaluate() - right.Evaluate();

                case Operators.div:
                    return left.Evaluate() / right.Evaluate();

                case Operators.Mod:
                    return left.Evaluate() % right.Evaluate();

                default:
                    return Math.Pow(left.Evaluate(), right.Evaluate());
            }
        }

    }
}