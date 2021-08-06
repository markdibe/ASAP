using ASAP.API.Data;
using ASAP.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace ASAP.API.Extensions
{
    public static class BaseFilterExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, BaseFilter filter)
        {

            //where conditions
            if (filter.Properties!=null && filter.Properties?.Count() == filter.Values?.Count())
            {
                string stringBuilder = "";
                int counter = 0;
                foreach (string propertyName in filter.Properties)
                {
                    bool propertyExists = typeof(T).GetProperties().Any(x => x.Name.ToLower().Equals(propertyName.ToLower()));
                    if (propertyExists)
                    {
                        int indexOfProp = Array.IndexOf(filter.Properties, propertyName);
                        string propertyValue = filter.Values[indexOfProp];
                        stringBuilder += $"{propertyName} == @{counter}";
                        if(indexOfProp < filter.Properties.Length - 1)
                        {
                            stringBuilder += " and ";
                        }
                        counter += 1;
                    }
                }
                query = query.Where(stringBuilder, filter.Values);
            }
            //order condition
            if (!string.IsNullOrEmpty(filter.OrderProperty))
            {
                bool propertyExists = typeof(T).GetProperties().Any(x => x.Name.ToLower().Equals(filter.OrderProperty.ToLower()));
                if (propertyExists)
                {
                    query = filter.OrderByDescending ?
                    query.OrderBy($"{filter.OrderProperty}").Reverse()
                    : query.OrderBy($"{filter.OrderProperty}");
                }
            }
            //paging and range condition
            query = query.Skip(filter.PageNumber * filter.Range).Take(filter.Range);
            return query.AsQueryable<T>();
        }

    }
}
