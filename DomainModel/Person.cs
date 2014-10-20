using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
	public class Person
	{
		[Key]
		public int PersonID { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string Infix { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public string Gender { get; set; }
		public virtual Reservation Reservation	{ get; set; }
	}
}