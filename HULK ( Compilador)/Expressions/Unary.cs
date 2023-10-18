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
                    return argument.Evaluate();
                case Operators.Sen:
                    return argument.Evaluate();
                case Operators.Cos:
                    return argument.Evaluate();
                case Operators.Tan:
                    return argument.Evaluate();
                case Operators.Cot:
                    return argument.Evaluate();
                case Operators.Sqrt:
                    return argument.Evaluate();
                default:
                    return argument.Evaluate();
            }
        }
    }
}
