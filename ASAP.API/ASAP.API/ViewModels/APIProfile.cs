using ASAP.API.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.ViewModels
{
    public class APIProfile:Profile
    {
        
        public APIProfile()
        {
            CreateMap<AddressVM, Address>().ReverseMap();
            CreateMap<Person, PersonVM>().ReverseMap();
        }
    }
}
