namespace LibrarySystemAssignment
{
    public class Library 
    {
        List<Book> books = new List<Book>()
        {
            new Book("Mahabharata", "Sage Ved Vyasa", -400),
            new Book("Ramayana", "Valmiki", -400),
            new Book("Ravana Samhita", "Ravana", 1200),
            new Book("To Kill a Mockingbird", "Harper Lee", 1960),
            new Book("1984", "George Orwell", 1949),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925),
            new Book("Pride and Prejudice", "Jane Austen", 1813),
            new Book("The Catcher in the Rye", "J.D. Salinger", 1951),
            new Book("Moby-Dick", "Herman Melville", 1851),
            new Book("The Lord of the Rings", "J.R.R. Tolkien", 1954)
        };

        public delegate void BookAddedEventHandler(object source, BookEventArgs args);
        public event BookAddedEventHandler BookAdded;
        public void AddBook()
        {
            Console.WriteLine();
            TextFormatter.PrintWithColor("\t┌──────────────────┐", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("\t│   ADD NEW BOOK   │", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("\t└──────────────────┘", ConsoleColor.DarkYellow);
            Console.Write("\tTitle : ");
            string title = Console.ReadLine();

            Console.Write("\tAuthor : ");
            string author = Console.ReadLine();

            Console.Write("\tPublication Year : ");
            int pulicatiionYear = Convert.ToInt32(Console.ReadLine());


            Book newBook = new Book(title, author, pulicatiionYear);
            books.Add(newBook);
            OnBookAdded(newBook);
        }
        protected virtual void OnBookAdded(Book book)
        {
            BookAdded?.Invoke(this, new BookEventArgs() { Book = book});
        }



        public void DisplayAllBooks()
        {
            Console.WriteLine();
            int count = 1;
           
            TextFormatter.PrintWithColor("\t┌──────────────────┐", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("\t│ BOOKS IN LIBRARY │", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("\t└──────────────────┘", ConsoleColor.DarkYellow);
           
           

            Console.WriteLine();
            if (books.Count == 0)
            {
                TextFormatter.Typewriter("\tBook not found.", ConsoleColor.DarkRed);
            }
            else
            {
                foreach (Book book in books)
                {
                    //TextFormatter.Typewriter($"\t{count++}) {book.Id}\t{book.Title} - \t {book.Author}");
                    TextFormatter.TypeWriterLine($"\t{count++}) {book.Id}\t{book.Title} - {book.Author}");
                }
            }
        }

        public void SearchBook()
        {
            Console.WriteLine();
            TextFormatter.PrintWithColor("\tSearch Book : ", ConsoleColor.Gray, false);
            string searchString = Console.ReadLine();

            List<Book> mathcedBooks = books.FindAll(book => book.Title.ToLower().Contains(searchString.ToLower()));

            if(mathcedBooks.Count == 0)
            {
                TextFormatter.PrintWithColor("\tBook not found.", ConsoleColor.DarkRed);
            }
            else
            {
                Console.WriteLine();
                TextFormatter.PrintWithColor("\t┌───────────────────┐", ConsoleColor.DarkYellow);
                TextFormatter.PrintWithColor("\t│   Matched Books   │", ConsoleColor.DarkYellow);
                TextFormatter.PrintWithColor("\t└───────────────────┘", ConsoleColor.DarkYellow);
                int count = 1;
                foreach (Book book in mathcedBooks)
                {
                    TextFormatter.Typewriter($"\t{count++}) {book.Title}");
                }
            }

        }

        public void SortBooks()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine("\t[A] Accending");
            Console.WriteLine("\t[D] Descending");
            Console.ForegroundColor = ConsoleColor.White;
            TextFormatter.PrintWithColor("\tChoose Order : ", ConsoleColor.Gray, false);
            string choice = Console.ReadLine().ToUpper();

            books.Sort();
            if (choice != "D" && choice !="A")
            {
                Console.WriteLine();
                TextFormatter.Typewriter("\tInvalid Choice !", ConsoleColor.DarkRed);
                Console.WriteLine();
                return;
            }
            else if(choice == "D")
            {
                books.Reverse();
            }
            int count = 1;
            Console.WriteLine();
            TextFormatter.PrintWithColor("\t┌─────────────────┐", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("\t│  SORTED RESULT  │", ConsoleColor.DarkYellow);
            TextFormatter.PrintWithColor("\t└─────────────────┘", ConsoleColor.DarkYellow);

            
            foreach (Book book in books)
            {
                TextFormatter.Typewriter($"\t{count++}) {book.Title}");
               
            }
            
        }
    }
}
