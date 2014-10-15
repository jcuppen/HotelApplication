using DomainModel;
using DomainModel.Repositories;
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

		public ReservationController()
		{
			reservationRepository = new EntityReservationRepository();
		}

		public ActionResult Index()
		{
			var model = reservationRepository.GetAll();
			return View(model);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View(new Reservation());
		}

		[HttpPost]
		public ActionResult Create(Reservation reservation)
		{
			if (reservation != null)
			{
				reservationRepository.Create(reservation);
				return RedirectToAction("Index");
			}
			return View();
		}
    }
}