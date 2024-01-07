namespace eShop.Domain.Entities.Base
{
    public class TrackableEntity<T> : BaseEntity<T>
    {
        public string? CreatedBy { get; set; } = null;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

    }
}
