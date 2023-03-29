﻿using d07_ex02.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d07_ex02.Models
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
        [NoDisplay]
        public virtual string NormalizedUserName { get; set; } = string.Empty;
        [Description("Email address")]
        [DefaultValue("test@test")]
        public virtual string Email { get; set; } = string.Empty;
        [NoDisplay]
        public virtual string NormalizedEmail { get; set; } = string.Empty;
        [NoDisplay]
        public virtual bool EmailConfirmed { get; set; }
        [NoDisplay]
        public virtual string PasswordHash { get; set; } = string.Empty;
        [NoDisplay]
        public virtual string SecurityStamp { get; set; } = string.Empty;
        public virtual string ConcurrencyStamp() => Guid.NewGuid().ToString();
        [Description("Phone number")]
        [DefaultValue("1234567890")]
        public virtual string PhoneNumber { get; set; } = string.Empty;
        [NoDisplay]
        public virtual bool PhoneNumberConfirmed { get; set; }
        [NoDisplay]
        public virtual bool TwoFactorEnabled { get; set; }
        [NoDisplay]
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        [NoDisplay]
        public virtual bool LockoutEnabled { get; set; }
        public override string ToString()
            => $"User: {UserName}, {Email}, {PhoneNumber}";
    }

}
