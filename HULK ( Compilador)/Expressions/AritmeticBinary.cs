namespace Hulk
{
    public class AritmeticBinary: Expressions
    {
        public enum Operators
        {
            add, mult, dif, div,Pow, Mod,
        }
        public Expressions left;
        public Expressions right;
        Operators operators;

        public AritmeticBinary(Expressions left, Expressions right, Operators operators)
        {
            this.left = left;
            this.right= right;
            this.operators= operators;

        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}