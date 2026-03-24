namespace Library2026.Models
{
    public class Series
    {
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        
        public ICollection<Book> Books { get; set; }


    }
}
