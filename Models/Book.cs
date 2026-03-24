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
        public string AuthorID { get; set; }
        public string AuthorCode { get; set; } 
        public string Description { get; set; }
        public string SeriesID { get; set; }
        public string NoInSeries { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; } // Available, Checked Out, Reserved - drop down in UI
        public string Location { get; set; } // Shelf location

    }
}
