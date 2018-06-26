using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos_dotnet.Models;

namespace Todos_dotnet.Data
{
	public class DbInitializer
	{
		public static void Initialize(Todos_dotnetContext context)
		{
			context.Database.EnsureCreated();

			if (context.Todo.Any())
			{
				return;
			}
			var Alice = new Person { Name = "Alice" };
			var Bob = new Person { Name = "Bob" };

			var people = new List<Person>(){
				Alice,
				Bob,
				new Person {Name= "Carol" },
				new Person {Name= "Dan" },
				new Person {Name= "Eve" },
				new Person {Name= "Faythe" },
				new Person {Name= "Grace" },
				new Person {Name= "Heidi" },
				new Person {Name= "Judy" },
				new Person {Name= "Mallory" },
				new Person {Name= "Olivia" },
				new Person {Name= "Peggy" },
				new Person {Name= "Sybil" },
				new Person {Name= "Ted" },
				new Person {Name= "Victor" },
				new Person {Name= "Wendy" }
			};
			foreach (Person s in people)
			{
				context.Person.Add(s);
			}
			context.SaveChanges();

			var todos = new List<Todo> {
				new Todo { Title = "Check Todo?", Due = new DateTime(2018, 06, 30), Person = Alice, Done = true },
				new Todo { Title = "New Todo", Due = new DateTime(2018, 7, 4), Person = Bob, Done = false }
				};

			foreach (Todo s in todos)
			{
				context.Todo.Add(s);
			}
			context.SaveChanges();


		}
	}
}
