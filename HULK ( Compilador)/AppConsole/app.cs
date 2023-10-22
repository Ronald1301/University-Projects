namespace Hulk
{
    public static class App
    {
        //This class is a  "Visual App" for HULK. Is just a Console Application
        //but with some colors.
        public static void Presentation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Welcome To Hulk Kompiler");
            System.Console.WriteLine("Write the code to compile");
            SelectKey();
        }
        //Application is Run
        public static void SelectKey()
        {
            System.Console.Write(">>");
            string line = Console.ReadLine()!;
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {
                //Tokenize and parse the user input
               var exp = Parser.L(LexicalAnalyzer.Tokenize(line.ToLower()), 0);
                //Analyze the AST 
                //My AST is a "Big Expression" with expression
                Console.WriteLine(exp.Item2.Evaluate());
                /*
                exp.Item2.GetScope(Utils.Global);
                if (!Utils.Declarate_Funtion)
                {
                    try
                    {
                        exp.Item2.Semantic_Walk();
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    try
                    {
                        System.Console.WriteLine(exp.Item2.Evaluate());
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
                Utils.Declarate_Funtion = false;
                Utils.Global = new(null!, new(), new());
                */
                //Now you ca write again
                SelectKey();
                
            }
            if (key == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
        }
        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Green;
            SelectKey();
        }
    }
}