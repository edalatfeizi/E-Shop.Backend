using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }
    }
}
