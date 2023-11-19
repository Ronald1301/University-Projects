namespace Hulk
{
    public abstract class Expressions
    {
        public abstract object Evaluate();

        public abstract Token.DataType CheckSemantic();

    }
}