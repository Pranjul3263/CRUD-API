using CurdApiApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CurdApiApplication.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



		
		public DbSet<Product> products { get; set; }

		public DbSet<User> users { get; set; }

	}
}
