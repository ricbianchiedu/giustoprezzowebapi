using Microsoft.EntityFrameworkCore;

    public class DbArticoli : DbContext
    {
        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbArticoli (DbContextOptions<DbArticoli> options)
            : base(options)
        {
        }
    }
