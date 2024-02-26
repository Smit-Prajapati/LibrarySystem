namespace LibrarySystemAssignment
{
    public class TextFormatter
    {
        public static void PrintWithColor(string message, ConsoleColor color, bool newLine = true)
        {

            Console.ForegroundColor = color;
            Console.Write(message);
            if (newLine)
                Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void CenterAlign(string text, ConsoleColor color = ConsoleColor.White)
        {

            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = color;
            Console.WriteLine(" " + text + " ");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void Typewriter(string text, ConsoleColor color = ConsoleColor.White)
        {
            foreach (char c in text)
            {
                Console.ForegroundColor = color;
                Console.Write(c);
                System.Threading.Thread.Sleep(10);
            }
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine();
        }


        private static bool anotherColor = false;
        public static void TypeWriterLine(string text, ConsoleColor color1=ConsoleColor.Yellow, ConsoleColor color2 = ConsoleColor.White)
        {
            
            if(anotherColor == false)
            {
                Console.ForegroundColor = color1;
                anotherColor = true;
            }
            else
            {
                Console.ForegroundColor = color2;
                anotherColor = false;
            }
            Console.WriteLine(text);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
