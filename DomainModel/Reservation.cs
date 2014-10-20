using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
	public class Reservation
	{
		public virtual List<Person> People { get; set; }
		public virtual List<Room> Rooms { get; set; }
		//public int NumberOfGuests { get; set; }

		[Key]
		public int ReservationID { get; set; }

		//General information
		[Required]
		public string ZipCode { get; set; }

		[Required]
		public string City { get; set; }
		[Required]
		public string Street { get; set; }
		[Required]
		[Range(0.0, Double.MaxValue, ErrorMessage = "Must be higher than 0")]
		public int Number { get; set; }
		[Required]
		[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter an valid email address")]  
		public string EmailAddress { get; set; }
		[Required]
		[Range(0.0, Double.MaxValue, ErrorMessage = "Must be higher than 0")]
		public decimal TotalPrice { get; set; }
		[Required]
		[Range(0.0, Double.MaxValue, ErrorMessage = "Must be higher than 0")]
		public int BankAccountNumber { get; set; }
		[Required]
		public DateTime DayOfArrival { get; set; }
		[Required]
		public DateTime DayOfDeparture { get; set; }

		//Invoice information
		[Required]
		public string InvoiceZipCode { get; set; }
		[Required]
		public string InvoiceCity { get; set; }
		[Required]
		public string InvoiceStreet { get; set; }
		[Required]
		[Range(0.0, Double.MaxValue, ErrorMessage = "Must be higher than 0")]
		public int InvoiceNumber { get; set; }

		public Reservation()
		{
			People = new List<Person>();
			Rooms = new List<Room>();
		}

		//public Reservation(DateTime begin, DateTime end)
		//{
			//NumberOfGuests = numberOfPeople;
			//DayOfArrival = begin;
			//DayOfDeparture = end;

			//People = new List<Person>();
		//}
	}
}