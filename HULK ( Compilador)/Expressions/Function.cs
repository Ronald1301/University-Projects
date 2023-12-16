namespace Hulk
{
    public class FunctionDeclarations : Expressions
    {
        public string Name; //FunctionDeclarations name
        public List<Token> Params; //Params
        public Expressions Body; //Body


        public FunctionDeclarations(string name, List<Token> param, Expressions body)
        {
            Name = name;
            Params = param;
            Body = body;
        }

        public override Additional.DataType CheckSemantic()
        {
            throw new NotImplementedException();
        }

        public override object Evaluate()
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    public class FunCall : Expressions
    {
        readonly FunctionDeclarations Function;
        readonly List<Expressions> Arguments; //Arg for the function
        public FunCall(FunctionDeclarations function, List<Expressions> arguments)
        {
            this.Arguments = arguments;
            this.Function = function;
        }

        public override Additional.DataType CheckSemantic()
        {
            if (Function.Params.Count == Arguments.Count)
            {
                foreach (var item in Arguments)
                {
                    item.CheckSemantic();
                }
                return Additional.DataType.function;
            }
            Error error = new TypeError(ErrorCode.SemanticError, " Invalid arguments count");
            App.Error(error.Text());
            return Additional.DataType.error;
        }

        public override object Evaluate()
        {
            Dictionary<Token, object> ParamsFunction = new();
            int Count = 0;
            foreach (var item in Arguments)
            {
                ParamsFunction.Add(Function.Params[Count], item.Evaluate());
                Count += 1;
            }

            return Function.Body.Evaluate();
        }
    }

}