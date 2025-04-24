using JornadaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JornadaAPI.Data;

public class JornadaContext : DbContext
{
    public JornadaContext(DbContextOptions<JornadaContext> options) : base(options)
    {
        //No passa nada!
    }

    public DbSet<Depoimentos> Depoimentos { get; set; }
    public DbSet<Destinos> Destinos { get; set; }
}
