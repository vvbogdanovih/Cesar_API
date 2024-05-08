using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class IdRouteDTO
    {
        public IdRouteDTO(Guid id, string adres, string? gPU, string? cPU)
        {
            Id = id;
            Adres = adres;
            GPU = gPU;
            CPU = cPU;
        }

        public Guid Id { get; set; }
        public string Adres { get; set; }
        public string? GPU { get; set; }
        public string? CPU { get; set; }
    }
}
