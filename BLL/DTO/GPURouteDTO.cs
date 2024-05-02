

namespace BLL.DTO
{
    public class GPURouteDTO
    {
        public string Adres { get; set; }
        public string? GPU { get; set; }
        public GPURouteDTO(string adres, string gpu)
        {
            Adres = adres;
            GPU = gpu;
        }
        public GPURouteDTO() { }
    }
}
