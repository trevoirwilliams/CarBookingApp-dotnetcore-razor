using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Data
{
    public class Car : BaseDomainEntity
    {
        [Required]
        [Range(1990,2021)]
        [Display(Name = "Manufacture Year")]
        public int Year { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "License Plate Number")]
        public string LicensePlateNumber { get; set; }

        [Display(Name = "Make")]
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        [Display(Name = "Colour")]
        public int? ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        [Display(Name = "Car Model")]
        public int? CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
    }
}
