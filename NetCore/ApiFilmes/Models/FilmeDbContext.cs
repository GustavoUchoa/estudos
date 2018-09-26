using Microsoft.EntityFrameworkCore;

namespace ApiFilmes.Models
{
    public class FilmeDbContext : DbContext
    {
        public FilmeDbContext(DbContextOptions<FilmeDbContext> options)
        : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}