namespace Library2026.Models
{
    public enum Shelf
    {
       A, B, C, D, E, F, G, H, I, J
    }
    public class Location
    {
        public int LocationID { get; set; }
        public string Shelf { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
