using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:250,MinimumLength =4)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2000)]
        public string  Biography{ get; set; }
        [DataType(DataType.ImageUrl)]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }



        
    }
}
