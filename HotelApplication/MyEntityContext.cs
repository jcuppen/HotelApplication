using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelApplication
{
	public class MyEntityContext : DbContext
	{
		public DbSet<Room> Rooms
		{
			get;
			set;
		}

	}
}