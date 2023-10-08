namespace Hulk
{
    public class Unarias : Expressions
    {
          public enum Operators
        {
           Log, Sen, Cos, Tan, Cot, Sqrt, Not,
        }
        public Expressions argument;
        Operators operators;

        public Unarias(Expressions argument, Operators operators)
        {
            this.argument = argument;
            this.operators= operators;

        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}