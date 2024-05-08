using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RouteDTO
    {
        [Required]
        public string Adres { get; set; }
        public string? GPU { get; set; }
        public string? CPU { get; set; }
    }
}
