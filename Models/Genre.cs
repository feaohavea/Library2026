namespace Library2026.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; } 

        public ICollection<Book> Books { get; set; }
    }
}
