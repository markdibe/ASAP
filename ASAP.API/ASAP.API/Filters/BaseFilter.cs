using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Filters
{
    public class BaseFilter
    {
    
        public int Id { get; set; }

        public int PageNumber { get; set; } = 0;

        public int Range { get; set; } = 100;

        public string[] Properties { get; set; }

        public string[] Values { get; set; }

        public bool OrderByDescending { get; set; } = false;

        public string OrderProperty { get; set; }
    }
}
