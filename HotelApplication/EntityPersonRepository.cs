using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelApplication
{
	public class EntityPersonRepository : IPersonRepository
	{
		MyEntityContext dbContext;
		public EntityPersonRepository()
		{
			dbContext = new MyEntityContext();
		}
		public List<Person> GetAll()
		{
			return dbContext.Persons.ToList();
		}

		public Person Create(Person person)
		{
			dbContext.Persons.Add(person);
			dbContext.SaveChanges();
			return person;
		}

		public Person Update(Person person)
		{
			dbContext.Entry(person).State = EntityState.Modified;
			dbContext.SaveChanges();
			return person;
		}

		public void Delete(Person person)
		{
			dbContext.Persons.Remove(dbContext.Persons.First(p => p.PersonID == person.PersonID));
			dbContext.SaveChanges();
		}

		public Person Get(int PersonID)
		{
			return (dbContext.Persons.First(p => p.PersonID == PersonID));
		}
	}
}