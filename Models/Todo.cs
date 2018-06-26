using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos_dotnet.Models
{
    public class Todo
    {
		public int TodoId { get; set; }
		public string Title { get; set; }
		public DateTime Due { get; set; }
		public int PersonId { get; set; }
		public Person Person { get; set; }
		public bool Done { get; set; }
    }
}
