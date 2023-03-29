using System.ComponentModel;

namespace d07_ex03.Models
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
