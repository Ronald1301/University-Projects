namespace Hulk
{
    public class LetExpresions : Expressions
    {
        public Expressions let_part;
        public Expressions in_part;
        public LetExpresions(Expressions let_part,Expressions in_part)
        {
           this.let_part=let_part;
           this.in_part=in_part;
        }

        public override Token.DataType CheckSemantic()
        {
             let_part.CheckSemantic();
            return in_part.CheckSemantic();
        }

        public override object Evaluate()
        {
            let_part.Evaluate();
            return in_part.Evaluate();
        }
    }
}