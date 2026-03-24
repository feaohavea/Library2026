namespace Library2026.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Shelf { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
