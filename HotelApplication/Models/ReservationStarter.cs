using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplication.Models
{
	public class ReservationStarter
	{
		public int NumberOfPeople { get; set; }
		public DateTime Begin { get; set; }
		public DateTime  End { get; set; }

		public ReservationStarter()
		{
			Begin = DateTime.Today;
			End = DateTime.Today.AddDays(1);

		}
	}
}