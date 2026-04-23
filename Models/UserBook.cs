using System.ComponentModel.DataAnnotations;

namespace Library2026.Models
{
    public class UserBook
    {
        public int UserBookID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
