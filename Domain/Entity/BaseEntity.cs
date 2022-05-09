using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
