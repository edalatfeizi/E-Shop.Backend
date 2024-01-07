using eShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Entities
{
    public class Review: TrackableEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
