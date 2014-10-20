using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelApplication
{
	public class EntityReservationRepository : IReservationRepository
	{
		MyEntityContext dbContext;
		public EntityReservationRepository()
		{
			dbContext = new MyEntityContext();
		}
		public List<Reservation> GetAll()
		{
			return dbContext.Reservations.ToList();
		}

		public Reservation Create(Reservation reservation)
		{
			//foreach (var item in reservation.Rooms)
			//{
				//var room = dbContext.Rooms.FirstOrDefault(s => s.RoomID == item.RoomID);
				//dbContext.Rooms.Attach(room);
				//reservation.Rooms.Add(room);
				//reservation.Rooms.Add(context.Rooms.FirstOrDefault(s => s.RoomID == item.RoomID));
			//}
			//dbContext.Entry(reservation.Rooms).State = EntityState.Unchanged;
			List<Room> rooms = reservation.Rooms;
			reservation.Rooms = null;
			dbContext.Reservations.Add(reservation);
			dbContext.SaveChanges();

			reservation.Rooms = new List<Room>();
			//var lastReservation = dbContext.Reservations.Last();
			var lastReservation = dbContext.Reservations.OrderByDescending(i => i.ReservationID).First();
			dbContext.Reservations.Attach(lastReservation);
			foreach (var item in rooms)
			{
				Room room = dbContext.Rooms.SingleOrDefault(p => p.RoomID == item.RoomID);

				dbContext.Rooms.Attach(room);
				lastReservation.Rooms.Add(room);
			}

			dbContext.SaveChanges();
			return reservation;
		}

		public Reservation Update(Reservation reservation)
		{
			dbContext.Reservations.Remove(dbContext.Reservations.First(p => p.ReservationID == reservation.ReservationID));
			dbContext.Reservations.Add(reservation);
			dbContext.SaveChanges();
			return reservation;
		}

		public void Delete(Reservation reservation)
		{
			dbContext.Reservations.Remove(dbContext.Reservations.First(p => p.ReservationID == reservation.ReservationID));
			dbContext.SaveChanges();
		}

		public Reservation Get(int reservationID)
		{
			return (dbContext.Reservations.First(p => p.ReservationID == reservationID));
		}

		public List<Reservation> GetBetween(DateTime begin, DateTime end)
		{
			List<Reservation> x = dbContext.Reservations.Where(p => (p.DayOfArrival >= begin && p.DayOfArrival <= end) || (p.DayOfDeparture >= begin && p.DayOfDeparture <= end) || (p.DayOfArrival <= begin && p.DayOfDeparture >= end)).ToList();
			return x;
		}
	}
}