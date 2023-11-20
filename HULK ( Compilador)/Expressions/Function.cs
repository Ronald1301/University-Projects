namespace Hulk
{
    public class Function : Expressions
    {
        public string Name; //Function's name
        public List<Token> Arg; //Params
        public Expressions Body; //Body


        public Function(string name, List<Token> arg, Expressions body)
        {
            Name = name;
            Arg = arg;
            Body = body;
        }

        public override Token.DataType CheckSemantic()
        {
            throw new NotImplementedException();
        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }
    }







    public class FunCallExpression : Expressions
    {
        Function function;
        List<Expressions> expressions; //Arg for the function
        public FunCallExpression(Function function, List<Expressions> expressions)
        {
            this.expressions = expressions;
            this.function = function;
        }

        public override Token.DataType CheckSemantic()
        {
            throw new NotImplementedException();
        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
            /*
            Dictionary<Token, string> temp = function.scope_function!.Corpus_Values;
            Dictionary<Token, string> ParamsFunction = new();
            int index = 0;
            foreach (var item in expressions)
            {
                ParamsFunction.Add(function.Arg[index], item.Evaluate());
                index += 1;
            }
            function.scope_function.Corpus_Values = ParamsFunction;
            string final = function.Body.Evaluate();
            function.scope_function.Corpus_Values = temp;
            return final;
*/
        }
    }

}