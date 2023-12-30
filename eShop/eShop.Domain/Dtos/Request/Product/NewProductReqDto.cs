using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Dtos.Request.Product
{
    public class NewProductReqDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int CountInStock { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
