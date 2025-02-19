using System;

namespace BusinessObjects.Entities
{
    public abstract class AuditableEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }
    }
}