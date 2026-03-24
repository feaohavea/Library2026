namespace Library2026.Models
{
    public enum Status
    {
        Available,
        CheckedOut,
        Reserved
    }
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int? SeriesID { get; set; }
        public int? NoInSeries { get; set; }
        public int PublicationYear { get; set; }
        public int GenreID { get; set; }
        public int StatusID { get; set; } // Available, Checked Out, Reserved - drop down in UI
        public int LocationID { get; set; } // Shelf location
        public string Description { get; set; }

    }
}
