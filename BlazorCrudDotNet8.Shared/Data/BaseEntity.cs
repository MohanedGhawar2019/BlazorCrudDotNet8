using System.ComponentModel.DataAnnotations;

namespace BlazorCrudDotNet8.Shared.Data
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
    }
}
