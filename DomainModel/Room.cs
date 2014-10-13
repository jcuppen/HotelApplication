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

		public decimal MinimumPrice
		{
			get;
			set;
		}

		public int RoomSize
		{
			get;
			set;
		}

		// en nog meer
	}
}
