using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelApplication.Controllers
{
	public class PersonController : Controller
	{
		private IPersonRepository personRepository;

		public PersonController()
		{
			personRepository = new EntityPersonRepository();
		}

		public ActionResult Index()
		{
			var model = personRepository.GetAll();
			return View(model);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			Person person = personRepository.Get(id);

			return View(person);
		}

		[HttpPost]
		public ActionResult Edit(Person person)
		{
			if (person != null)
			{
				personRepository.Update(person);
				return RedirectToAction("Index");
			}
			return View();
		}
    }
}
