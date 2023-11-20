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

        public override Token.DataType CheckSemantic()
        {
            /*
            foreach (var item in where!.Declared_Type.Keys)
            {
                if (item.Value == token.Value)
                {
                    where.Declared_Type[item] = argument.CheckSemantic();
                    return where.Declared_Type[item];
                }
            }
            */
            return 0;
            throw new();
        }

        public override object Evaluate()
        {
            Token.Global.Add(token,argument);
            return 0;
        }
    }
}