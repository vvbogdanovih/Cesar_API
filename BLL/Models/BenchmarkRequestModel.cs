using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BenchmarkRequestModel
    {
        public List<List<float>> Data { get; set; }
        public int StartSize { get; set; }
        public int EndSize { get; set; }
        public int Step { get; set; }
    }
}
