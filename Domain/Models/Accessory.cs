using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Accessory:Commodity
    {
        public Accessory()
        {

        }
        public string Model { get; set; }
    }
}
