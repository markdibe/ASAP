using ASAP.API.Data.Entities;
using ASAP.API.Data.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.Repos
{
    public class PersonRepos: GenericRepos<Person>, IPersonRepos
    {
        public PersonRepos(ApplicationDbContext context) : base(context)
        {

        }

        public  IQueryable<Person> GetPeopleAddresses()
        {
            return _context.People.Include(x => x.Addresses).AsQueryable();
        }

        public async Task<Person> GetPersonAddresses(int personId)
        {
            return await _context.People.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == personId);
        }
    }
}
