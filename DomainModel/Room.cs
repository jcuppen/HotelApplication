using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
	public class Room
	{
		[Key]
		public int RoomID { get; set; }

		[Required]
		[Range(0.0, Double.MaxValue, ErrorMessage = "Must be higher than 0")]
		public decimal  MinimumPrice { get; set; }


		[Range(0.0, Double.MaxValue, ErrorMessage = "Must be higher than 0")]
		public decimal AdditionalCosts { get; set; }
		[Required, RegularExpression(@"5|3|2", ErrorMessage = "A room should have room for 2, 3 or 5 guests.")]  
		public int RoomSize { get; set; }

		public virtual List<Reservation> Reservations { get; set; }
		// en nog meer
	}
}