using Microsoft.EntityFrameworkCore;
using Minimal_API.Models;

namespace Minimal_API.Contexto
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) => Database.EnsureCreated();
        
        public DbSet<Produto> Produtos { get; set; }    

    }
}