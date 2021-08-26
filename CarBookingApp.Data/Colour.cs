using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarBookingApp.Data
{
    public class Colour : BaseDomainEntity
    {
        [Display(Name = "Colour")]
        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}