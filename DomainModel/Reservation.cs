using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
	public class Reservation
	{
		public Person[] People { get; set; }
		//public int NumberOfGuests { get; set; }

		[Key]
		public int ReservationID { get; set; }

		//General information
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public int Number { get; set; }
		public string EmailAddress { get; set; }
		public decimal TotalPrice { get; set; }
		public int BankAccountNumber { get; set; }
		public DateTime DayOfArrival { get; set; }
		public DateTime DayOfDeparture { get; set; }

		//Invoice information
		public string InvoiceZipCode { get; set; }
		public string InvoiceCity { get; set; }
		public string InvoiceStreet { get; set; }
		public int InvoiceNumber { get; set; }

		public Reservation()
		{
		}

		public Reservation( DateTime begin, DateTime end)
		{
			//NumberOfGuests = numberOfPeople;
			DayOfArrival = begin;
			DayOfDeparture = end;
		}
	}
}