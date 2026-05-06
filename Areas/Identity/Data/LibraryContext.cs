using Library2026.Areas.Identity.Data;
using Library2026.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Library2026.Areas.Identity.Data;

public class LibraryContext : IdentityDbContext<LibraryUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(builder);
        modelBuilder.Entity<AuthorBook>().ToTable(nameof(Author));
        modelBuilder.Entity<GenreBook>().ToTable(nameof(GenreBook));
        modelBuilder.Entity<SeriesBook>().ToTable(nameof(SeriesBook));
        modelBuilder.Entity<UserBook>().ToTable(nameof(UserBook));
        modelBuilder.Entity<Book>().ToTable(nameof(Book));
        modelBuilder.Entity<Author>().ToTable(nameof(Author));
        modelBuilder.Entity<Series>().ToTable(nameof(Series));
        modelBuilder.Entity<Genre>().ToTable(nameof(Genre));
        modelBuilder.Entity<User>().ToTable(nameof(User));
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<Library2026.Models.Book> Book { get; set; } = default!;

public DbSet<Library2026.Models.Author> Author { get; set; } = default!;

public DbSet<Library2026.Models.Series> Series { get; set; } = default!;

public DbSet<Library2026.Models.Genre> Genre { get; set; } = default!;

public DbSet<Library2026.Models.User> User { get; set; } = default!;

public DbSet<Library2026.Models.AuthorBook> AuthorBook { get; set; } = default!;

public DbSet<Library2026.Models.GenreBook> GenreBook { get; set; } = default!;

public DbSet<Library2026.Models.SeriesBook> SeriesBook { get; set; } = default!;

public DbSet<Library2026.Models.UserBook> UserBook { get; set; } = default!;
}
