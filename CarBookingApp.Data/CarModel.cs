using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarBookingApp.Data
{
    public class CarModel : BaseDomainEntity
    {
        [Display(Name = "Model")]
        public string Name { get; set; }

        [Display(Name = "Make")]
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}