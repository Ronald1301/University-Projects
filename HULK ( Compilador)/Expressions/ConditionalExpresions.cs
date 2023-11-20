namespace Hulk
{
    public class ConditionalExpresions : Expressions
    {
        public Expressions condition;
        public Expressions body;
        public Expressions alternative;

        public ConditionalExpresions(Expressions condition, Expressions body, Expressions alternative)
        {
            this.condition = condition;
            this.body = body;
            this.alternative = alternative;
        }

        public override Token.DataType CheckSemantic()
        {
            if (condition.CheckSemantic() == Token.DataType.boolean) return Token.DataType.number;
            Error error = new TypeError(ErrorCode.SemanticError, "The expression is not of type boolean");
            App.Error(error.Text());
            return Token.DataType.error;
        }

        public override object Evaluate()
        {
            if ((bool)condition.Evaluate()) return body.Evaluate();
            return alternative.Evaluate();
        }
    }
}