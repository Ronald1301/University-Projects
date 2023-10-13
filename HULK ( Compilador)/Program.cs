namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
            string line  = "let x=5,y=3 in x+y;";
            //string line  = "if(2<3) 1 else 0;";
            var exp = Parser.L(LexicalAnalyzer.Tokenize(line),0);
            System.Console.WriteLine(exp.Item2.Evaluate());
        }
    }
}