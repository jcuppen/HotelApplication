using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelApplication.Controllers
{
	public class RoomController : Controller
	{
		private IRoomRepository roomRepository;

		public RoomController()
		{
			roomRepository = new EntityRoomRepository();
		}

		public ActionResult Index()
		{
			var model = roomRepository.GetAll();
			return View(model);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View(new Room());
		}

		[HttpPost]
		public ActionResult Create(Room room)
		{
			if(room != null)
			{
				roomRepository.Create(room);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{

			Room room = roomRepository.Get(id);

			return View(room);
		}

		[HttpPost]
		public ActionResult Edit(Room room)
		{
			if (room != null)
			{
				Room oldRoom = roomRepository.Get(room.RoomID);

				List<Reservation> reservations = oldRoom.Reservations;
				foreach (var item in reservations)
				{
					if (item.DayOfDeparture.CompareTo(DateTime.Today) >= 0 && oldRoom.RoomSize > room.RoomSize)
					{
						Session["msg"] = "There are current and/or future reservations for which this room is reserved, therefore you cannot lower the room size.";
						return RedirectToAction("Index");
					}
				}

				roomRepository.Update(room);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult Details(int id)
		{
			Room room = roomRepository.Get(id);
			return View(room);
		}


		[HttpGet]
		public ActionResult Delete(int id)
		{
			Room room = roomRepository.Get(id);
			return View(room);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Room room = roomRepository.Get(id);

			List<Reservation> reservations = room.Reservations;
			foreach (var item in reservations)
			{
				if (item.DayOfDeparture.CompareTo(DateTime.Today) >= 0)
				{
					Session["msg"] = "There are current and/or future reservations for which this room is reserved.";
					return RedirectToAction("Index");
				}
			}

			roomRepository.Delete(room);
			return RedirectToAction("Index");
		}
	}
}