using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        public string? Brand { get; set; }
        
        public string? Title { get; set; }

        public string? Description { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}