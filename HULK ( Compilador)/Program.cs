namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
           // App.Presentation();

           // me falta verificar el not en unary
            //string line  = "let x=10 , y=5 in x+y;";
            //string line ="Print(\"Hello World\");";
            string line = "let x= 5 in x != 3 &  x==5 ;";
           // string line = "let x= 4a in Print(x);";
            var exp = Parser.L(LexicalAnalyzer.Tokenize(line.ToLower()), 0);
            Console.WriteLine(exp.Item2.Evaluate());

        }
    }
}