using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.DTOs
{
   public class CustomerDto
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LasttName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]

        public string Phone { get; set; }
    }
}
