namespace Hulk
{
    public class TypeError : Error
    {
        public ErrorCode Code { get; }

        public string argument { get; }

        /*
                public CodeLocation Location { get; }

                public struct CodeLocation
                {
                    public string File;
                    public int Line;
                    public int Column;
                }
        */

        public TypeError(/*CodeLocation location,*/ ErrorCode code, string argument)
        {
            this.Code = code;
            this.argument = argument;
            //  Location = location;
        }

        public override string Text()
        {
            switch (this.Code)
            {
                case ErrorCode.LexicalError:
                    return "! Lexical Error : " + argument;
                case ErrorCode.SyntacticError:
                    return "!! Syntactic Error : " + argument;
                case ErrorCode.SemanticError:
                    return "!!! Semantic Error : " + argument;
                default:
                    return "!!!! Unknown Error : " + argument;
            }
            throw new NotImplementedException();
        }
    }

    public enum ErrorCode
    {
        LexicalError,
        SyntacticError,
        SemanticError,
        Unknown,
    }
}
