using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace CoreApplication3.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderLines { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter a Value")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter a Value")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter a Value")]
        public string Info { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }

    }
}
