using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Keyboard : ComputersAndAccessory
    {
        public Keyboard()
        {

        }
        public bool MicrophoneInput { get; set; }
        public bool USB_Input { get; set; }
        public string ConnectionType { get; set; }
        public string ConnectorType { get; set; }
        public bool Backlight { get; set; }
        public bool CarvedPersian { get; set; }
        public bool LiquidResistance { get; set; }
        public bool HaveMouse { get; set; }
    }
}
