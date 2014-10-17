using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
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
			dbContext.Reservations.Add(reservation);
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
			List<Reservation> x = dbContext.Reservations.Where(p => (p.DayOfArrival > begin && p.DayOfArrival < end) || (p.DayOfDeparture > begin && p.DayOfDeparture < end) || (p.DayOfArrival < begin && p.DayOfDeparture > end)).ToList();
			return x;
		}
	}
}