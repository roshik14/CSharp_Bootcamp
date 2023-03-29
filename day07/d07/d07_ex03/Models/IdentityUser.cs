using System.ComponentModel;

namespace d07_ex03.Models
{
    public class IdentityUser
    {
        public IdentityUser()
        {
        }

        public IdentityUser(string userName) : this()
        {
            UserName = userName;
        }

        [Description("User name")]
        [DefaultValue("Me")]
        public virtual string UserName { get; set; } = string.Empty;
        public virtual string NormalizedUserName { get; set; } = string.Empty;

        [Description("Email address")]
        [DefaultValue("test@test")]
        public virtual string Email { get; set; } = string.Empty;
        public virtual string NormalizedEmail { get; set; } = string.Empty;
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; } = string.Empty;
        public virtual string SecurityStamp { get; set; } = string.Empty;
        public virtual string ConcurrencyStamp() => Guid.NewGuid().ToString();
        [Description("Phone number")]
        [DefaultValue("1234567890")]
        public virtual string PhoneNumber { get; set; } = string.Empty;
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public override string ToString()
            => $"User: {UserName}, {Email}, {PhoneNumber}";
    }

}
