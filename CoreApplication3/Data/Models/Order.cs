using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CoreApplication3.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Info { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }

    }
}
