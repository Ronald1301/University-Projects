namespace Hulk
{
    public class BoolExpresions : Expressions
    {
          public enum Operators
        {
         Less, More, LessOrEqual, MoreOrEqual, DoubleEqual, NoEqual,  And, Or,
          
        }
        public Expressions left;
        public Expressions right;
        Operators operators;

        public BoolExpresions (Expressions left, Expressions right, Operators operators)
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