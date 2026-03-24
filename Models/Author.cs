namespace Library2026.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorCode { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
