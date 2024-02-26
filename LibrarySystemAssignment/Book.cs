namespace LibrarySystemAssignment
{
    public class Book : IComparable<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        private static int nextId = 101;

        public Book(string title, string author, int publicationYear)
        {
            Id = nextId++;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public int CompareTo(Book? other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
}
