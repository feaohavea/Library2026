using System.ComponentModel.DataAnnotations;

namespace Library2026.Models
{
   
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; } 

        public ICollection<GenreBook> GenreBooks { get; set; }
    }
}
