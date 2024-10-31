using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fall2024_Assignment3_ggazzam.Models; 

namespace Fall2024_Assignment3_ggazzam.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }
    }
}

