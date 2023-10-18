namespace Hulk
{
public class Error
{
    public ErrorCode Code { get; }

    public string Argument { get; }

    //public CodeLocation Location { get; }

     public Error(/*CodeLocation location,*/ ErrorCode code, string argument)
    {
        this.Code = code;
        this.Argument = argument;
      //  Location = location;
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
