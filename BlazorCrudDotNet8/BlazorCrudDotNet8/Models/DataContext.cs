using BlazorCrudDotNet8.Models.Entities;
using BlazorCrudDotNet8.Shared.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }


      
    }
}
