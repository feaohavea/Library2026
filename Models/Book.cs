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
        public int Pages { get; set; }
        public int Status { get; set; } // Available, Checked Out, Reserved - drop down in UI
        public string Description { get; set; }
        public int LocationID { get; set; } // Shelf location

        public ICollection<AuthorBook> AuthorBooks { get; set; }


    }
}
