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

        public override Additional.DataType CheckSemantic()
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
            return Additional.DataType.ID;
            throw new();
        }

        public override object Evaluate()
        {
            Additional.Global_variables.Add(token,argument);
            return 0;
        }
    }
}