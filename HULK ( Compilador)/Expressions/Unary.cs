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

        public override Token.DataType CheckSemantic()
        {
            //revisar el operador  not
            if (argument.CheckSemantic() == Token.DataType.number)
            {
                return Token.DataType.number;
            }
            if (argument.CheckSemantic() == Token.DataType.boolean)
            {
                return Token.DataType.number;
            }
            Error error = new TypeError(ErrorCode.SemanticError, "The expression is not of type number or boolean");
            App.Error(error.Text());
            return Token.DataType.error;
        }

        public override object Evaluate()
        {
            try
            {
                switch (this.operators)
                {
                    case Operators.Log:
                        return Math.Log10(Convert.ToDouble(argument.Evaluate()));
                    case Operators.Sen:
                        return Math.Sin(Convert.ToDouble(argument.Evaluate()));
                    case Operators.Cos:
                        return Math.Cos(Convert.ToDouble(argument.Evaluate()));
                    case Operators.Tan:
                        return Math.Tan(Convert.ToDouble(argument.Evaluate()));
                    case Operators.Cot:
                        return 1 / Math.Tan(Convert.ToDouble(argument.Evaluate()));
                    case Operators.Sqrt:
                        return Math.Sqrt(Convert.ToDouble(argument.Evaluate()));
                    default:
                        return argument.Evaluate();
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Error error = new TypeError(ErrorCode.Unknown, e.Message);
                App.Error(error.Text());
            }
            return null!;
        }
    }
}
