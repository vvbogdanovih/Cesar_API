using DLL.Data.Entities;

namespace BLL.DTO
{
    public class GPURouteDTO
    {
        public string Adres { get; set; }
        public string? GPU { get; set; }
        public GPURouteDTO(Route route)
        {
            Adres = route.Adres;
            GPU = route.GPU;
        }
        public GPURouteDTO() { }
    }
}
