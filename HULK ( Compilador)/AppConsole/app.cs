namespace Hulk
{
    public static class App
    {
        public static void Presentation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Welcome To Hulk Kompiler");
            System.Console.WriteLine("Write the code to compile");
            SelectKey();
        }
        public static void SelectKey()
        {
            System.Console.Write(">>");
            string line = Console.ReadLine()!;
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {

                var result = Parser.L(LexicalAnalyzer.Tokenize(line.ToLower()), 0);
                //var check = result.Item2.CheckSemantic();

                if (Additional.declared_func)
                {
                    Additional.declared_func = false;
                    Additional.call_func = false;
                    Additional.if_expression_active = true;
                    Additional.created_stack = false;
                    SelectKey();
                }
                else
                    Console.WriteLine(result.Item2.Evaluate());
                Additional.if_expression_active = true;
                Additional.created_stack = false;
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