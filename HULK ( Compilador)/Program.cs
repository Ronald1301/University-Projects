namespace Hulk
{
    class Program
    {
        static void Main(string[] args)
        {
            //App.Presentation();


            //string line  = "let x=10 , y=5 in x+y;";
            //string line = "print(sin(2 * PI) ^ 2 + cos(3 * PI / log(5)));";
            //string line = "let a=\"te quedó \" in print(let b=5 in if(b>=3) a @ \"bien\" else a @ \"mal\");";
            //string line = " let a=(let b=2 in b) in a+2;";
            //string line = " let a=5 in (let b=6 in b) + a;";
            //string line= " \"hello\"@ \" world\";";
            //string line = "let x=5 in Print(x+3);";


            //string line = "function Prueba (x,y,z,t) => x+y+z+t;";
            //string line = "function tan(x) => sin(x) / cos(x) ;";
            // string line = "function fib(n) => if (n > 1) fib(n-1) + fib(n-2) else 1;";
            string line = "Function Fact(n) => if(n==0) 1 else n*Fact(n-1);";
            var result = Parser.L(LexicalAnalyzer.Tokenize(line.ToLower()), 0);
            var ok = result.Item2.CheckSemantic();
            System.Console.WriteLine(ok);
            Console.WriteLine(result.Item2.Evaluate());


            #region 

            //string line2 = "Prueba(2,3,4,6);";
            //string line2 = "print(tan(PI*2/3));";
            //string line2 = "fib(1)";
            string line2="Fact(2)";
            var result_2 = Parser.L(LexicalAnalyzer.Tokenize(line2.ToLower()), 0);
            var ok2 = result.Item2.CheckSemantic();
            System.Console.WriteLine(ok2);
            Console.WriteLine(result_2.Item2.Evaluate());

            #endregion


        }
    }
}