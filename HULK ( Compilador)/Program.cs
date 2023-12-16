namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
            App.Presentation();

            /*
                        //string line  = "let x=10 , y=5 in x+y;";
                        //string line = "print(sin(2 * PI) ^ 2 + cos(3 * PI / log(5)));";
                        //string line = "let a=\"te quedó \" in print(let b=5 in if(b>=3) a @ \"bien\" else a @ \"mal\");";
                       // string line = " let a=(let b=2 in b) in a+2;";
                        //string line = " let a=5 in (let b=6 in b) + a;";
                        //string line= " \"hello\"@ \" world\";";
                        //string line= "function Prueba (x,y,z,t) => x+y+z+t;";
                        string line = "let x=5 in Print(x+3);";
                        var result = Parser.L(LexicalAnalyzer.Tokenize(line.ToLower()), 0);
                       var ok = result.Item2.CheckSemantic();
                       System.Console.WriteLine(ok);
                        Console.WriteLine(result.Item2.Evaluate());
            */
        }
    }
}