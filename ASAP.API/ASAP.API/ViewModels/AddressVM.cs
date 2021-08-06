using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.ViewModels
{
    public class AddressVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}
