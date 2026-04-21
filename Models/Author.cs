namespace Library2026.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Abbreviaton { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
