using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
	public interface IRoomRepository
	{
		Room Get(int RoomID);
		List<Room> GetAll();
		Room Create(Room room);
		Room Update(Room room);
		void Delete(Room room);
	}
}
