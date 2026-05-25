namespace Library2026.Areas.Identity.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(LibraryContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var users = new LibraryUser[]
            {
                //new LibraryUser { UserName = "admin", Email = "--EMAIL_ADDRESS--" },
            };

            foreach (LibraryUser u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var books = new Library2026.Models.Book[]
            {
               new Models.Book() {Title = "The Hobbit", Pages = 310, Status = 1, Description = "A fantasy novel by J.R.R. Tolkien.", Location = 1},
               new Models.Book() {Title = "1984", Pages = 328, Status = 0, Description = "A dystopian novel by Jorjor Wel.", Location = 2},
               new Models.Book() {Title = "To Kill a Mockingbird", Pages = 281, Status = 1, Description = "A novel by Harper Lee.", Location = 3},
               new Models.Book() {Title = "Pride and Prejudice", Pages = 279, Status = 0, Description = "A romantic novel by Jane Austen.", Location = 4},
               new Models.Book() {Title = "The Great Gatsby", Pages = 180, Status = 1, Description = "A novel by F. Scott Fitzgerald.", Location = 5},
               new Models.Book() {Title = "M", Pages = 500, Status = 1, Description = "A mystery novel by Agatha Christie.", Location = 6},
               new Models.Book() {Title = "The Catcher in the Rye", Pages = 214, Status = 0, Description = "A novel by J.D. Salinger.", Location = 7},
               new Models.Book() {Title = "The Lord of the Rings", Pages = 1178, Status = 1, Description = "An epic fantasy novel by J.R.R. Tolkien.", Location = 8},
               new Models.Book() {Title = "The Chronicles of Narnia", Pages = 767, Status = 0, Description = "A series of fantasy novels by C.S. Lewis.", Location = 9},
               new Models.Book() {Title = "The Alchemist", Pages = 208, Status = 1, Description = "A novel by Paulo Coelho.", Location = 10},
               //10 books, can add more if needed
            };

            var authors = new Library2026.Models.Author[]
            {
                new Models.Author() {FirstName = "J.R.R.", LastName="Tolkien", Abbreviaton="TOL"},
                new Models.Author() {FirstName = "Jorjor", LastName="Wel", Abbreviaton="ORW"},
                new Models.Author() {FirstName = "Harper", LastName="Lee", Abbreviaton="LEE"},
                new Models.Author() {FirstName = "Jane", LastName="Austen", Abbreviaton="AUS"},
                new Models.Author() {FirstName = "F. Scott", LastName="Fitzgerald", Abbreviaton="FIT"},
                new Models.Author() {FirstName = "Agatha", LastName="Christie", Abbreviaton="CHR"},
                new Models.Author() {FirstName = "J.D.", LastName="Salinger", Abbreviaton="SAL"},
                new Models.Author() {FirstName = "C.S.", LastName="Lewis", Abbreviaton="LEW"},
                new Models.Author() {FirstName = "Paulo", LastName="Coelho", Abbreviaton="COE"},

            };

            var genres = new Library2026.Models.Genre[]
            {
                new Models.Genre() {GenreName = "Horror" },
                new Models.Genre() {GenreName = "Thriller" },
                new Models.Genre() {GenreName = "Action" },
                new Models.Genre() {GenreName = "Adventure" },
                new Models.Genre() {GenreName = "Fantasy" },
                new Models.Genre() {GenreName = "Thriller" },
                new Models.Genre() {GenreName = "Horror" },
                new Models.Genre() {GenreName = "Thriller" },
                new Models.Genre() {GenreName = "Horror" },
                new Models.Genre() {GenreName = "Thriller" },
                new Models.Genre() {GenreName = "Horror" },
                new Models.Genre() {GenreName = "Thriller" },
                new Models.Genre() {GenreName = "Horror" },
                new Models.Genre() {GenreName = "Thriller" },

            };
           
            var genreBooks = new Library2026.Models.GenreBook[]
            {
                new Models.GenreBook() { BookID = 1, GenreID = 5 },
                new Models.GenreBook() { BookID = 2, GenreID = 2 },
                new Models.GenreBook() { BookID = 3, GenreID = 4 },
                new Models.GenreBook() { BookID = 4, GenreID = 4 },
                new Models.GenreBook() { BookID = 5, GenreID = 4 },
                new Models.GenreBook() { BookID = 6, GenreID = 1 },
                new Models.GenreBook() { BookID = 7, GenreID = 2 },
                new Models.GenreBook() { BookID = 8, GenreID = 5 },
                new Models.GenreBook() { BookID = 9, GenreID = 5 },
                new Models.GenreBook() { BookID = 10, GenreID = 4 },
            };

            var Series = new Library2026.Models.Series() 
            {
                SeriesName = "The Lord of the Rings",
            };

            var SeriesBooks = new Library2026.Models.SeriesBook[]
            {
                new Models.SeriesBook() { BookID = 1, SeriesID = 1 },
                new Models.SeriesBook() { BookID = 8, SeriesID = 1 },
            };

            var Users = new Library2026.Models.User[]
            {
                new Models.User ()
                {
                    FirstName = "Meow",
                    LastName = "Meow",
                    Email = "meow@meow.com",
                    Username = "meow",
                    Password = "meowmeowmeow123"
                },

                new Models.User ()
                {
                    FirstName = "Bark",
                    LastName = "Bark",
                    Email = "bark@bark.com",
                    Username = "bark",
                    Password = "barkbarkbark123"
                },

            };

            var UserBooks = new Library2026.Models.UserBook[] { 
            
                new Models.UserBook () { BookID = 1, UserID = 1 },
                
                new Models.UserBook () { BookID = 8, UserID = 1 },

                new Models.UserBook () { BookID = 9, UserID = 1 },

            };


        }
    }
}
