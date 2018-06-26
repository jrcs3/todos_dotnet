using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos_dotnet.Models
{
    public class Person
    {
		public int PersonId { get; set; }
		public string Name { get; set; }
		public ICollection<Todo> Todos { get; set; }
    }
}
