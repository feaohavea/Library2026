using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library2026.Models
{
    public enum Status
    {
        Available,
        CheckedOut,
        Reserved
    }
    public enum Shelf
    {
        A, B, C, D, E, F, G, H, I, J
    }
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int Status { get; set; } // Available, Checked Out, Reserved - drop down in UI
        public string Description { get; set; } 
        public int Location { get; set; } // Shelf location

        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<GenreBook> GenreBooks { get; set; }
        public ICollection<SeriesBook> SeriesBooks { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }

    }
}
