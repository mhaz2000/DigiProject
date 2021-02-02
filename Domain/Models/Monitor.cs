using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Monitor :ComputersAndAccessory
    {
        public Monitor()
        {

        }
        public bool Backlight { get; set; }
        public bool HDMI_Port { get; set; }
        public bool USB_Port { get; set; }
        public bool DVI_Port { get; set; }
        public int Resolution { get; set; }
        public double ResponseTime { get; set; }
        public string PanelType { get; set; }
        public string Speaker { get; set; }
    }
}
