namespace Hulk
{
    public class Unary : Expressions
    {
        public enum Operators
        {
            Log, Sen, Cos, Tan, Cot, Sqrt, Not,
        }
        public Expressions argument;
        Operators operators;

        public Unary(Expressions argument, Operators operators)
        {
            this.argument = argument;
            this.operators = operators;

        }

        public override bool CheckSemantic()
        {
            throw new NotImplementedException();
        }
        
        public override double Evaluate()
        {
            switch (this.operators)
            {
                case Operators.Log:
                    return Math.Log10(argument.Evaluate());
                case Operators.Sen:
                    return Math.Sin(argument.Evaluate());
                case Operators.Cos:
                    return Math.Cos(argument.Evaluate());
                case Operators.Tan:
                    return Math.Tan(argument.Evaluate());
                case Operators.Cot:
                    return 1/Math.Tan(argument.Evaluate());
                case Operators.Sqrt:
                    return Math.Sqrt(argument.Evaluate());
                default:
                    return argument.Evaluate();
            }
        }
    }
}
