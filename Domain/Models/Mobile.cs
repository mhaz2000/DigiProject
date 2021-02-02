using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Mobile : Commodity
    {
        public Mobile()
        {

        }
        public int MobileRam { get; set; }
        public int InternalStorage { get; set; }
        public int CameraResolution { get; set; }
        public string OS { get; set; }
        public string Network { get; set; }
        public string Model { get; set; }
    }
}
