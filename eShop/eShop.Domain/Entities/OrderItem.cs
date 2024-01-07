using eShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Entities
{
    public class OrderItem : BaseEntity<Guid>
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
