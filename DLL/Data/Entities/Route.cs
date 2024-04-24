using System.ComponentModel.DataAnnotations;

namespace DLL.Data.Entities
{
    public class Route
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Adres { get; set; }
        public string? GPU { get; set; }
        public string? CPU { get; set; }
    }
}
