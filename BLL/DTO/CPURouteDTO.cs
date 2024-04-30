using DLL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CPURouteDTO
    {
        public string Adres { get; set; }
        public string? CPU { get; set; }
        public CPURouteDTO(Route route)
        {
            Adres = route.Adres;
            CPU = route.CPU;
        }
        public CPURouteDTO() { }
    }
}
