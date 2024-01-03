namespace eShop.Domain.Models
{
    public class CorsSettings
    {
        public string ActivePolicyName { get; set; }
        public List<CorsPolicies> Policies { get; set; } 
    }
}
