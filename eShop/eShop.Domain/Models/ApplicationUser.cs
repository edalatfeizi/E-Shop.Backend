using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; } = null;
        public string? Street { get; set; } = null;
        public string? Apartment { get; set; } = null;
        public string? City { get; set; } = null;
        public string? Zip { get; set; } = null;
        public string? Country { get; set; } = null;
        public bool IsAdmin { get; set; }
    }
}
