using DomainModel;
using HotelApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelApplication.Controllers
{
	public class HomeController : Controller
	{
		EntityReservationRepository reservationRepository;
		public HomeController()
		{
			reservationRepository = new EntityReservationRepository();
		}
		public ActionResult Index()
		{
			if (Session["msg"] != null)
			{
				ViewBag.message = Session["msg"];
				Session["msg"] = null;
			};
			return View(new ReservationStarter());
		}

		[HttpPost]
		public ActionResult Index(ReservationStarter reservation)
		{
			Reservation r = new Reservation();
			if (reservation != null)
			{
				//return RedirectToAction("NewReservation", "Reservation", new
				//{
				r.DayOfArrival = reservation.Begin;
				r.DayOfDeparture = reservation.End;

				if (r.DayOfArrival.CompareTo(r.DayOfDeparture) >= 0)
				{
					Session["msg"] = "Day of departure must be after day of arrival.";
					return Redirect("/");
				}
				if (reservation.NumberOfPeople <= 0)
				{
					Session["msg"] = "At least one person is required.";
					return Redirect("/");
				}

				List<Reservation> x = reservationRepository.GetBetween(r.DayOfArrival, r.DayOfDeparture);


				r.People = new Person[reservation.NumberOfPeople];
				//});
				Session["newReservation"] = r;

				return RedirectToAction("NewReservation", "Reservation");
			}
			return View();
		}
	}
}
