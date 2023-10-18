namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
            //me falta cerrar un parentesis
           string line  = "let x=10 , y=5 in x+y;";
           //string line  = "let x=10 in let y=5 in x+y;";
          // string line  = "sin();";
            var exp = Parser.L(LexicalAnalyzer.Tokenize(line),0);
            System.Console.WriteLine(exp.Item2.Evaluate());
        }
    }
}