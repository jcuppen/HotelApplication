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
			Reservation r = (Reservation)Session["newReservation"];
			Session["rooms"] = r.Rooms;
			//Reservation res = new Reservation(numberOfPeople, begin, end);
			//for (int i = 0; i < r.People.Length; i++)
			//{
			//	r.People[i] = new Person();
			//}
			return View(r);
		}

		[HttpPost]
		public ActionResult NewReservation(Reservation reservation)
		{
			//var context = new MyEntityContext();
			//context.Reservations.Attach(reservation);
			foreach (var person in reservation.People)
			{


			}
			//reservation.Rooms = (List<Room>) Session["rooms"];
			Session["newReservation"] = reservation;
			//List<Room> reservationRooms = (List<Room>) Session["rooms"];
			//foreach (var item in reservationRooms)

			//var room = context.Rooms.FirstOrDefault(s => s.RoomID == item.RoomID);

			//reservation.Rooms.Add(room);
			//reservation.Rooms.Add(context.Rooms.FirstOrDefault(s => s.RoomID == item.RoomID));

			//List<Reservation> r = reservationRepository.GetAll();

			//reservation.NumberOfGuests = 3;

			//foreach (var item in reservation.People)
			//{
			//	personRepository.Create(item);
			//}

			//foreach (var item in reservation.Rooms)
			//{
			//	roomRepository.Create(item);
			//}



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

		//[HttpPost]
		//public ActionResult ShowSummary()
		//{
		//	return null;
		//}

		[HttpGet]
		public ActionResult Invoice()
		{
			Invoice v = new Invoice();
			return View(v);
		}

		[HttpPost]
		public ActionResult Invoice(Invoice invoice)
		{
			Reservation reservation = (Reservation) Session["newReservation"];
			reservation.InvoiceCity = invoice.City;
			reservation.InvoiceNumber = invoice.Number;
			reservation.InvoiceStreet = invoice.Street;
			reservation.InvoiceZipCode = invoice.ZipCode;
			reservation.BankAccountNumber = invoice.BankAccountNumber;



			// alles klaar, verzenden maar
			reservationRepository.Create(reservation);
			return null;
		}
	}
}