using System.ComponentModel.DataAnnotations;

namespace Library2026.Models
{
    public class SeriesBook
    {
        public int SeriesBookID { get; set; }
        public int SeriesID { get; set; }
        public int BookID { get; set; }
        public int SeriesNumber { get; set; }

        public Series Series { get; set; }
        public Book Book { get; set; }
        
    }
}
