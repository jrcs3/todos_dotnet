using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos_dotnet.Models
{
	// Todos for display:
    public class TodoDto
    {
		public int TodoId { get; set; }
		public string Title { get; set; }
		public DateTime Due { get; set; }
		public int PersonId { get; set; }
		public string PersonName { get; set; }
		public bool Done { get; set; }
	}
}
