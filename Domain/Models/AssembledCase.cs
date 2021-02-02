using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AssembledCase :ComputersAndAccessory
    {
        public AssembledCase()
        {

        }
        public string CPU_Company { get; set; }
        public string IntrnalStorageType { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
    }
}