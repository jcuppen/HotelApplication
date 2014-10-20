using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HotelApplication
{
	public class MyEntityContext : DbContext
	{
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Person> Persons { get;	set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}