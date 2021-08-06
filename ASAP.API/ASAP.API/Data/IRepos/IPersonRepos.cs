using ASAP.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.IRepos
{
    public interface IPersonRepos : IGenericRepos<Person>
    {
        IQueryable<Person> GetPeopleAddresses();
        Task<Person> GetPersonAddresses(int personId);
    }
}
