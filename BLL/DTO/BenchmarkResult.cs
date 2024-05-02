using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BenchmarkResult
    {
        public int Size { get; private set; }
        public double ElapsedTimeCPU { get; set; }
        public double ElapsedTimeCPUMultiThred { get; set; }
        public double ElapsedTimeGPU { get; set; }

        public BenchmarkResult(int size, double elapsedTimeCPU, double elapsedTimeCPUMultiThred, double elapsedTimeGPU) { 
            Size = size;
            ElapsedTimeCPU = elapsedTimeCPU;
            ElapsedTimeCPUMultiThred = elapsedTimeCPUMultiThred;
            ElapsedTimeGPU = elapsedTimeGPU;
        }

    }
}
