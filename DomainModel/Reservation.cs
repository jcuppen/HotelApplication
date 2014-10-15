using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
	public class Reservation
	{
		public List<Person> People { get; set; }

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
	}
}