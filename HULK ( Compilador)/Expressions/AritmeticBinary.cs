namespace Hulk
{
    public class AritmeticBinary : Expressions
    {
        public enum Operators
        {
            add, mult, dif, div, Pow, Mod,
        }
        public Expressions left;
        public Expressions right;
        Operators operators;

        public AritmeticBinary(Expressions left, Expressions right, Operators operators)
        {
            this.left = left;
            this.right = right;
            this.operators = operators;

        }

        public override double Evaluate()
        {
            switch (this.operators)
            {
                case Operators.add:
                    return left.Evaluate() + right.Evaluate();

                case Operators.mult:
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