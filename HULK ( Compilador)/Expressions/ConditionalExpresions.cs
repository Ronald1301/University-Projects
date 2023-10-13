namespace Hulk
{
    public class ConditionalExpresions : Expressions
    {
        public Expressions condition;
        public Expressions body;
        public Expressions alternative;

        public ConditionalExpresions(Expressions condition, Expressions body, Expressions alternative)
        {
            this.condition=condition;
            this.body=body;
            this.alternative=alternative; 
        }

        public override double Evaluate()
        {
            if(condition.Evaluate()==1)return body.Evaluate();
            return alternative.Evaluate();
        }
    }
}