using ASAP.API.Data;
using ASAP.API.Data.Entities;
using ASAP.API.Data.IRepos;
using ASAP.API.Data.Repos;
using ASAP.API.IServices;
using ASAP.API.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Extensions
{
    public static class ServiceInjectionExtension
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepos,PersonRepos>();
            services.AddScoped<IAddressRepos, AddressRepos>();
            services.AddScoped<IConverter<Person, PersonVM>, Converter<Person, PersonVM>>();
        }
    }
}
