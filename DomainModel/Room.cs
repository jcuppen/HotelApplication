using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
	public class Room
	{
		[Key]
		public int RoomID { get; set; }

		public decimal  MinimumPrice { get; set; }

		public int RoomSize { get; set; }
		// en nog meer
	}
}