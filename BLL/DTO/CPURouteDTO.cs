
namespace BLL.DTO
{
    public class CPURouteDTO
    {
        public string Adres { get; set; }
        public string? CPU { get; set; }
        public CPURouteDTO(string adres, string cpu)
        {
            Adres = adres;
            CPU = cpu;
        }
        public CPURouteDTO() { }
    }
}
