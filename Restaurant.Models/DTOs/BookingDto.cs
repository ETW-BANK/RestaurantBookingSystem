using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.DTOs
{
    public class BookingDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public int NumberOfGuests { get; set; }

    }
}
