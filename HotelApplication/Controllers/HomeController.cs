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
		EntityRoomRepository roomRepository;
		public HomeController()
		{
			reservationRepository = new EntityReservationRepository();
			roomRepository = new EntityRoomRepository();
		}
		public ActionResult Index()
		{
			if (Session["msg"] != null)
			{
				ViewBag.message = Session["msg"];
				Session["msg"] = null;
			};
			ReservationStarter r = new ReservationStarter();
			return View(r);
		}

		[HttpPost]
		public ActionResult Index(ReservationStarter reservation)
		{
			Reservation r = new Reservation();
			if (reservation != null)
			{
				r.DayOfArrival = reservation.Begin;
				r.DayOfDeparture = reservation.End;

				if (r.DayOfArrival.CompareTo(DateTime.Today) < 0)
				{
					Session["msg"] = "Day of arrival must be after today";
					return Redirect("/");
				}

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

				List<Reservation> allReservations = reservationRepository.GetBetween(r.DayOfArrival, r.DayOfDeparture);
				List<Room> allRooms = roomRepository.GetAll();
				List<Room> reservationRooms = new List<Room>();

				foreach (var res in allReservations)
				{
					if (res.Rooms != null)
					{
						foreach (var room in res.Rooms)
						{
							Room id = allRooms.Find(p => p.RoomID == room.RoomID);
							allRooms.Remove(id);
						}
					}
				}

				int numberOfPeople = reservation.NumberOfPeople;
				while (numberOfPeople > 0)
				{
					if (allRooms.Count > 0)
					{
						Room room = FindRoom(allRooms, numberOfPeople);

						if (room == null)
						{
							Session["msg"] = "Could not find a Room.";
							return Redirect("/");
						}

						allRooms.Remove(room);
						reservationRooms.Add(room);

						numberOfPeople = numberOfPeople - room.RoomSize;
					}
					else
					{
						Session["msg"] = "No rooms available for this amount of guests.";
						return Redirect("/");
					}
				}

				r.Rooms = reservationRooms;
				for (int i = 0; i < reservation.NumberOfPeople; i++)
				{
					r.People.Add(new Person());
				}

				Session["newReservation"] = r;

				return RedirectToAction("NewReservation", "Reservation");
			}
			return View();
		}

		private Room FindRoom(List<Room> allRooms, int people)
		{
			Room room = null;
			List<int> intList = new List<int>();

			foreach (var item in allRooms)
			{
				if (!intList.Contains(item.RoomSize))
				{
					intList.Add(item.RoomSize);
				}
			}
			intList.Sort();
			intList.Reverse();

			foreach (var roomSize in intList)
			{
				if (people >= roomSize)
				{
					room = roomOf(allRooms, roomSize);
					if (room != null)
					{
						return room;
					}
				}
			}

			if (room == null)
			{
				if (people != 0)
				{
					room = roomOf(allRooms, intList.Last());
				}
				return room;
			}

			return room;
		}

		private Room roomOf(List<Room> allRooms, int roomSize)
		{
			foreach (var item in allRooms)
			{
				if (item.RoomSize == roomSize)
				{
					return item;
				}
			}

			return null;
		}
	}
}
