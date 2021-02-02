using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// تنظیمات
    /// </summary>
    public class Setting
    {
        public Setting()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
