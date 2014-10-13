using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplication
{
	public class EntityRoomRepository : IRoomRepository
	{
		MyEntityContext dbContext;
		public EntityRoomRepository()
		{
			dbContext = new MyEntityContext();
		}
		public List<Room> GetAll()
		{
			return dbContext.Rooms.ToList();
		}

		public Room Create(Room room)
		{
			dbContext.Rooms.Add(room);
			dbContext.SaveChanges();
			return room;
		}

		public Room Update(Room room)
		{
			dbContext.Rooms.Remove(dbContext.Rooms.First(p => p.RoomID == room.RoomID));
			dbContext.Rooms.Add(room);
			dbContext.SaveChanges();
			return room;
		}

		public void Delete(Room room)
		{
			dbContext.Rooms.Remove(dbContext.Rooms.First(p => p.RoomID == room.RoomID));
			dbContext.SaveChanges();
		}

		public Room Get(int RoomID)
		{
			return (dbContext.Rooms.First(p => p.RoomID == RoomID));
		}
	}
}