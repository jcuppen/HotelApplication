using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
	public interface IPersonRepository
	{
		Person Get(int PersonID);
		List<Person> GetAll();
		Person Create(Person person);
		Person Update(Person person);
		void Delete(Person person);
	}
}
