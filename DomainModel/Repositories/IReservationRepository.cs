using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
	public interface IReservationRepository
	{
		Reservation Get(int ReservationID);
		List<Reservation> GetAll();
		List<Reservation> GetBetween(DateTime begin, DateTime end);
		Reservation Create(Reservation reservation);
		Reservation Update(Reservation reservation);
		void Delete(Reservation reservation);
	}
}
