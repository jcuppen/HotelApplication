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
		private IRoomRepository roomRepository;

		public ReservationController()
		{
			reservationRepository = new EntityReservationRepository();
			personRepository = new EntityPersonRepository();
			roomRepository = new EntityRoomRepository();
		}

		[HttpGet]
		public ActionResult Index()
		{
			var model = reservationRepository.GetAll();
			return View(model);
		}

		[HttpPost]
		public ActionResult Index(DateTime start, DateTime end)
		{
			var model = reservationRepository.GetBetween(start, end);
			return View(model);
		}

		[HttpGet]
		public ActionResult Details(int id)
		{
			Reservation r = reservationRepository.Get(id);
			return View(r);
		}

		[HttpGet]
		public ActionResult NewReservation()
		{
			Reservation r = (Reservation)Session["newReservation"];
			Session["rooms"] = r.Rooms;
			return View(r);
		}

		[HttpPost]
		public ActionResult NewReservation(Reservation reservation)
		{
			Session["newReservation"] = reservation;

			return RedirectToAction("ShowSummary");
		}

		[HttpGet]
		public ActionResult ShowSummary()
		{
			Reservation r = (Reservation)Session["newReservation"];
			List<Room> roomList = (List<Room>)Session["rooms"];
			decimal total = 0;
			foreach (var item in roomList)
			{
				total = total + item.MinimumPrice + item.AdditionalCosts;
			}

			r.TotalPrice = total;

			r.Rooms = roomList;
			Session["newReservation"] = r;
			return View(r);
		}

		[HttpGet]
		public ActionResult Invoice()
		{
			Invoice v = new Invoice();
			return View(v);
		}

		[HttpPost]
		public ActionResult Invoice(Invoice invoice)
		{
			Reservation reservation = (Reservation)Session["newReservation"];
			reservation.InvoiceCity = invoice.City;
			reservation.InvoiceNumber = invoice.Number;
			reservation.InvoiceStreet = invoice.Street;
			reservation.InvoiceZipCode = invoice.ZipCode;
			reservation.BankAccountNumber = invoice.BankAccountNumber;

			// alles klaar, verzenden maar
			reservationRepository.Create(reservation);
			return RedirectToAction("Success");
		}

		public ActionResult Success()
		{
			Session["newReservation"] = null;
			Session["rooms"] = null;
			return View();
		}
	}
}