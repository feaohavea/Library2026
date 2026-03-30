namespace Library2026.Models
{
    public enum Name
    {
        Available,
        CheckedOut,
        Reserved
    }
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; } 

        public ICollection<Book> Books { get; set; }
    }
}
