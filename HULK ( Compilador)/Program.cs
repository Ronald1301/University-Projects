namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Console.WriteLine("Escriba una linea de código a compilar");
            // string line = Console.ReadLine()!;

            //string line  = "let x=10 , y=5 in x+y;";
            ///string line = "Print(Hello World)";
            string line ="";
          var exp = Parser.L(LexicalAnalyzer.Tokenize(line.ToLower()), 0);
            Console.WriteLine(exp.Item2.Evaluate());
        }
    }
}