using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel
{
	public class Person
	{
		public int PersonID { get; set; }
		public string FirstName { get; set; }
		public string Infix { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public char Gender { get; set; }
	}
}
