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
		public ActionResult Index()
		{
			return View(new ReservationStarter());
		}

		[HttpPost]
		public ActionResult Index(ReservationStarter reservationStarter)
		{
			ReservationStarter r = reservationStarter;
			if (r != null)
			{
				//return RedirectToAction("NewReservation", "Reservation", new
				//{
				//	numberOfPeople = reservationStarter.NumberOfPeople,
				//	begin = reservationStarter.Begin,
				//	end = reservationStarter.End
				//});

				return RedirectToAction("NewReservation", "Reservation", r);
			}
			return View();
		}
	}
}
