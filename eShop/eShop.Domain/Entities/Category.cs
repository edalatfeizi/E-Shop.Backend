using eShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Entities
{
    public class Category : TrackableEntity<Guid>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
    }
}
