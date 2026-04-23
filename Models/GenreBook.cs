using System.ComponentModel.DataAnnotations;

namespace Library2026.Models
{
    public class GenreBook
    {
        public int GenreBookID { get; set; }
        public int GenreID { get; set; }
        public int BookID { get; set; }

        public Genre Genre { get; set; }
        public Book Book { get; set; }
    }
}
