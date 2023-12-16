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
            return Additional.DataType.ID;
            throw new();
        }

        public override object Evaluate()
        {
            Additional.Global_variables.Add(token, argument);
            return 0;

            /*
                         foreach (var item in  Additional.Global_variables)
                        {
                            if (item.Value == token.Value)
                            {
                                var result = argument.Evaluate();
                                where.Corpus_Values.Add(token, result);
                                return result;
                            }
                        }
                        throw new();
                        */
        }

    }
}