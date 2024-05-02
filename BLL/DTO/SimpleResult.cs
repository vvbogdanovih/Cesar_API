using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SimpleResult
    {
        public double ElapsedTime { get; set; }
        public int Size { get; set; }
        public SimpleResult(int size, double time)
        {
            Size = size;
            ElapsedTime = time;
        }
    }
}
