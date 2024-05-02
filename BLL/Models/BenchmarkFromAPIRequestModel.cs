using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BenchmarkFromAPIRequestModel
    {
        public int StartSize { get; set; }
        public int EndSize { get; set; }
        public int Step { get; set; }
        public string GpuRoute { get; set; }
        public string CpuRoute { get; set; }
    }
}
