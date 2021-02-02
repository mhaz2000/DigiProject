using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoModels
{
    public class AssembledCaseDto : AccessoryDto
    {
        public string CPU_Company { get; set; }
        public string IntrnalStorageType { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
    }
}
