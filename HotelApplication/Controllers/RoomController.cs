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
	}
}
