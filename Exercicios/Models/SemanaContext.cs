using Microsoft.EntityFrameworkCore;

namespace Exercicios.Models;

    public class SemanaContext : DbContext
    {
        
        public SemanaContext(DbContextOptions<SemanaContext> options) : base(options)
        {
        
        }
    
        public DbSet<SemanaModel> Semana { get; set; }
    }