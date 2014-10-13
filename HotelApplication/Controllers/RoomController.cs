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
			//productRepository = new DummyProductRepository();
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
			if (room != null)
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
			roomRepository.Delete(room);
			return RedirectToAction("Index");
		}

	}
}
