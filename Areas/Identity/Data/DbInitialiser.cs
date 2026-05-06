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
                new LibraryUser{UserName="admin", Email="admin@admin.admin",

        }
    }
}
