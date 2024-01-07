namespace eShop.Domain.Entities.Base
{
    public class BaseEntity<T>
    {
        public T? Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
