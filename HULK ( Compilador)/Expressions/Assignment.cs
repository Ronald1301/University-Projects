namespace Hulk
{
    public class Assignment : Expressions
    {
        public Token token;
        public Expressions argument;
        public Assignment(Token token, Expressions argument)
        {
            this.token = token;
            this.argument = argument;
        }
        
        public override double Evaluate()
        {
            Token.Global.Add(token,argument);
            return 0;
        }
    }
}