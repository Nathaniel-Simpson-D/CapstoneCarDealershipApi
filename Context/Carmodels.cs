using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerCapstone.Context
{
    public class CarModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Make { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MaxLength(20)]
        public string Color { get; set; }
    }
}
