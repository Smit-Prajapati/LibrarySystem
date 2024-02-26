using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Media;

namespace LibrarySystemAssignment
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            bool isSubscribe = false;
            Library library = new Library();
            //TextFormatter.CenterAlign("LIBRARY MANAGEMENT SYSTEM", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("  ___     _                     _    _ _                      \r\n / __|  _| |__  __ _ __ _ ___  | |  (_) |__ _ _ __ _ _ _ _  _ \r\n| (_| || | '_ \\/ _` / _` / -_) | |__| | '_ \\ '_/ _` | '_| || |\r\n \\___\\_, |_.__/\\__,_\\__, \\___| |____|_|_.__/_| \\__,_|_|  \\_, |\r\n     |__/           |___/                                |__/ ", ConsoleColor.DarkYellow);
            while (true)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                Console.WriteLine("║              Library Management System              ║");
                Console.WriteLine("╠───┬─────────────────────────────────────────────────╣");
                Console.WriteLine("║ 1 │ Add Book                                        ║");
                Console.WriteLine("║ 2 │ Display all Books                               ║");
                Console.WriteLine("║ 3 │ Search Book                                     ║");
                Console.WriteLine("║ 4 │ Sort Books                                      ║");
                Console.WriteLine("║ 5 │ Subscribe to book addition events               ║");
                Console.WriteLine("║ 6 │ Exit                                            ║");
                Console.WriteLine("╚═══╩═════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                TextFormatter.PrintWithColor("Enter your choice : ", ConsoleColor.White, false);

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            library.AddBook();
                            break;
                        case 2:
                            library.DisplayAllBooks();
                            break;
                        case 3:
                            library.SearchBook();
                            break;
                        case 4:
                            library.SortBooks();
                            break;
                        case 5:
                            if (!isSubscribe)
                            {
                                SubscribeToBookAddedEvent(library);
                                isSubscribe = true;
                            }
                            else
                                TextFormatter.Typewriter("Already Subscribed", ConsoleColor.Red);
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            TextFormatter.Typewriter("Invalid choice", ConsoleColor.DarkRed);
                            break;
                    }

                }

                catch (FormatException)
                {
                    TextFormatter.Typewriter("Invalid input. Please enter a valid number.", ConsoleColor.DarkRed);
                }
                catch (Exception e)
                {
                    TextFormatter.Typewriter("Choose From 1 to 6", ConsoleColor.DarkRed);
                }

            }

        }

        static void SubscribeToBookAddedEvent(Library library)
        {
            NotifyUser notify = new NotifyUser();
            library.BookAdded += notify.OnBookAdded;
            TextFormatter.Typewriter("You have subscribed to Book Addition event.", ConsoleColor.Green);
        }
    }

    public class BookEventArgs : EventArgs
    {
        public Book Book { get; set; }
    }
}
