using ASAP.API.Data.Entities;
using ASAP.API.Data.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.Repos
{
    public class AddressRepos : GenericRepos<Address>, IAddressRepos
    {
        public AddressRepos(ApplicationDbContext context) : base(context)
        {
        }
    }
}
