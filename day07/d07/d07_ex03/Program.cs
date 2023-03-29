using d07_ex03;
using d07_ex03.Models;
using System.ComponentModel;
using System.Reflection;

var user1 = TypeFactory.CreateWithConstructor<IdentityUser>();
var user2 = TypeFactory.CreateWithActivator<IdentityUser>();


Console.WriteLine(typeof(IdentityUser).FullName);
Console.WriteLine(user1 == user2 ? "user1 == user2" : "user1 != user2");

var role1 = TypeFactory.CreateWithConstructor<IdentityRole>();
var role2 = TypeFactory.CreateWithActivator<IdentityRole>();

Console.WriteLine(typeof(IdentityRole).FullName);
Console.WriteLine(role1 == role2 ? "role1 == role2" : "role1 != role2");

Console.WriteLine();

Console.WriteLine(typeof(IdentityUser).FullName);
Console.WriteLine("Set name:");
var input = Console.ReadLine();
var defaultName = typeof(IdentityUser)
        .GetProperty("UserName")
        ?.GetCustomAttribute<DefaultValueAttribute>()
        ?.Value ?? "";
var user3 = TypeFactory.CreateWithParameters<IdentityUser>(string.IsNullOrEmpty(input) ? defaultName : input);
Console.WriteLine($"Username set: {user3.UserName}");