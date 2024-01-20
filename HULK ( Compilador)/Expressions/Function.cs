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
            Additional.Functions_global.Add(Name, this);
            Params = param;
            Body = body;
        }

        public override Additional.DataType CheckSemantic()
        {
            //throw new NotImplementedException();
            return Additional.DataType.function;
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
        readonly List<Expressions> Arguments;
        public FunCall(FunctionDeclarations function, List<Expressions> arguments)
        {
            this.Function = function;
            this.Arguments = arguments;
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
            int Count = 0;
            foreach (var item in Arguments)
            {
                if (!Additional.created_stack)
                {
                    Additional.Func_Call_Params[Function.Params[Count]] = new Stack<object>();
                   // Additional.created_stack = true;
                } 

                Additional.Func_Call_Params[Function.Params[Count]].Push(item.Evaluate());
                Count += 1;
            }

            return Function.Body.Evaluate();
        }
    }

}