using AppAnalysis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAnalysis.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<UserApp> Apps { get; set; }
    public DbSet<Event> Events { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}