namespace Hulk
{
    public class ArithmeticBinary : Expressions
    {
        public enum Operators
        {
            add, multi, dif, div, Pow, Mod, Concat,
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

        public override Token.DataType CheckSemantic()
        {
            if (left.CheckSemantic() == Token.DataType.number && right.CheckSemantic() == Token.DataType.number)
            {
                return Token.DataType.number;
            }
            Error error = new TypeError(ErrorCode.SemanticError, "The expression is not of type number");
            App.Error(error.Text());
            return Token.DataType.error;
        }

        public override object Evaluate()
        {
            switch (this.operators)
            {
                case Operators.add:
                    return Convert.ToDouble(left.Evaluate()) + Convert.ToDouble(right.Evaluate());

                case Operators.multi:
                    return Convert.ToDouble(left.Evaluate()) * Convert.ToDouble(right.Evaluate());

                case Operators.dif:
                    return Convert.ToDouble(left.Evaluate()) - Convert.ToDouble(right.Evaluate());

                case Operators.div:
                    return Convert.ToDouble(left.Evaluate()) / Convert.ToDouble(right.Evaluate());

                case Operators.Mod:
                    return Convert.ToDouble(left.Evaluate()) % Convert.ToDouble(right.Evaluate());

                case Operators.Pow:
                    return Math.Pow(Convert.ToDouble(left.Evaluate()), Convert.ToDouble(right.Evaluate()));

                default:
                    return left.Evaluate().ToString() + right.Evaluate().ToString();

            }
        }

    }
}