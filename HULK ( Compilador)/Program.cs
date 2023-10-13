namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
            string line  = "let x=3 in x+1;";
            var exp = Parser.L(LexicalAnalyzer.Tokenize(line),0);
            System.Console.WriteLine(exp.Item2.Evaluate());
        }
    }
}