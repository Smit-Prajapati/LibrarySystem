namespace LibrarySystemAssignment
{
    public class NotifyUser
    {
        public void OnBookAdded(object source, BookEventArgs args)
        {
            Console.WriteLine();
            TextFormatter.Typewriter("\tNotify User service :  " + args.Book.Title + " is added successfully." , ConsoleColor.Green);
        }
    }
}
