using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Laptop :Commodity
    {
        public Laptop()
        {
        }
        public int LaptopRam { get; set; }
        public bool IsTouchable { get; set; }
        public int ScreenSize { get; set; }
        public bool MatteImage { get; set; }
        public string RAM_Type { get; set; }
        public int RAM_Size { get; set; }
        public int ScreenResolution { get; set; }
        public string GPU_Company { get; set; }
        public int GPU_Size { get; set; }
        public string CPU { get; set; }
        public string OS { get; set; }
        public int InternalStorage { get; set; }
    }
}
