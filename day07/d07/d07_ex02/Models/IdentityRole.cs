using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d07_ex02.Models
{
    public class IdentityRole
    {
        public IdentityRole()
        {
        }

        [DefaultValue("Default Name")]
        public string Name { get; set; } = string.Empty;
        [DefaultValue("Default Description")]
        public string Description { get; set; } = string.Empty;

        public override string ToString()
           => $"{Name}, {Description}";
    }

}
