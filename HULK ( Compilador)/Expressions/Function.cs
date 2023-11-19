namespace Hulk
{/*
    public class Function : Expressions
    {
        public string Name; //Function's name
        public List<Token> Args; //Params
        public Expressions Body; //Body
        //public Scope? scope_funtion = new(Utils.Global, new(), new()); //Scope

        public Function(string name, List<Token> args, Expressions body)
        {
            Name = name;
            Args = args;
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

        public override void GetScope(Scope actual)
        {
            foreach (var item in Args)
            {
                actual.Declared_Type.Add(item, Scope.Declared.NoAsig);
            }
            Scope next = new Scope(actual, new(), new());
            Body.GetScope(next);
            scope_function = actual;
        }

        public override Scope.Declared Semantic_Walk()
        {
            return Scope.Declared.NoAsig;
        }
    }







    public class FunCallExpression : Expressions
    {
        Function function;
        List<Expressions> expressions; //Args for the function
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
            Dictionary<Token, string> temp = function.scope_function!.Corpus_Values;
            Dictionary<Token, string> ParamsFunction = new();
            int index = 0;
            foreach (var item in expressions)
            {
                ParamsFunction.Add(function.Args[index], item.Evaluate());
                index += 1;
            }
            function.scope_function.Corpus_Values = ParamsFunction;
            string final = function.Body.Evaluate();
            function.scope_function.Corpus_Values = temp;
            return final;
        }

        public override void GetScope(Scope actual)
        {
            foreach (var item in expressions)
            {
                item.GetScope(actual);
            }
            return;
        }

        public override Scope.Declared Semantic_Walk()
        {
            if (funtion.Args.Count == expressions.Count)
            {
                foreach (var item in expressions)
                {
                    item.Semantic_Walk();
                }
                return Scope.Declared.NoAsig;
            }
            Error error = new TypeError(ErrorCode.SemanticError, "Invalid arguments count");
            App.Error(error.Text());
            return Token.DataType.error;
            
        }
    }
    */
}