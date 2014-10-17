using DomainModel;
using DomainModel.Repositories;
using HotelApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelApplication.Controllers
{
	public class ReservationController : Controller
	{
		private IReservationRepository reservationRepository;
		private IPersonRepository personRepository;

		public ReservationController()
		{
			reservationRepository = new EntityReservationRepository();
			personRepository = new EntityPersonRepository();
		}

		public ActionResult Index()
		{
			var model = reservationRepository.GetAll();
			return View(model);
		}

		//[HttpGet]
		//public ActionResult NewReservation(int numberOfPeople, DateTime begin, DateTime end)
		//{
		//	return View(new Reservation(numberOfPeople, begin, end));
		//}

		[HttpGet]
		public ActionResult NewReservation()
		{
			Reservation r = (Reservation) Session["newReservation"];

			//Reservation res = new Reservation(numberOfPeople, begin, end);
			for (int i = 0; i < r.People.Length; i++)
			{
				r.People[i] = new Person();
			}
			return View(r);
		}

		[HttpPost]
		public ActionResult NewReservation(Reservation reservation)
		{
			if (reservation != null)
			{
				//List<Reservation> r = reservationRepository.GetAll();

				//reservation.NumberOfGuests = 3;
				//foreach (var item in reservation.People)
				//{
					
					//personRepository.Create(item);
				//}
				//reservationRepository.Create(reservation);
				return RedirectToAction("Index");
			}
			return View();
		}

		public ActionResult ReservationOverview()
		{
			return null;
		}

		public ActionResult nee()
		{
			return View();
		}
	}
}