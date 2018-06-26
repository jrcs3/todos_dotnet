using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todos_dotnet.Models;

namespace Todos_dotnet.Models
{
    public class Todos_dotnetContext : DbContext
    {
        public Todos_dotnetContext (DbContextOptions<Todos_dotnetContext> options)
            : base(options)
        {
        }

        public DbSet<Todos_dotnet.Models.Person> Person { get; set; }

        public DbSet<Todos_dotnet.Models.Todo> Todo { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Person>()
				.HasMany<Todo>(t => t.Todos);
			modelBuilder.Entity<Todo>()
				.HasOne<Person>(p => p.Person);
		}
	}
}
