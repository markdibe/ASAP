using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Data.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [Required]
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
