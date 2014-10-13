using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainModel
{
	public class Room
	{
		[Key]
		public int RoomID
		{
			get;
			set;
		}

		public decimal minimumPrice
		{
			get;
			set;
		}

		public int roomSize
		{
			get;
			set;
		}

		// en nog meer
	}
}
