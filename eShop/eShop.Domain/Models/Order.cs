using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ShippingAdress1 { get; set; } = string.Empty;
        public string ShippingAdress2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Status { get; set; }
        public DateTime DateOrdered { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
