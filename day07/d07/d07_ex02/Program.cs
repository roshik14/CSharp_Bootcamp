
using d07_ex02.ConsoleSetter;
using d07_ex02.Models;

var user = new IdentityUser();
var setter = new ConsoleSetter<IdentityUser>();
Console.WriteLine();
setter.SetValues(user);

Console.WriteLine("We've set our instance!");
Console.WriteLine($"User: {user.UserName}, {user.Email}, {user.PhoneNumber}");

var role = new IdentityRole();
var setter2 = new ConsoleSetter<IdentityRole>();
Console.WriteLine();
setter2.SetValues(role);

Console.WriteLine();
Console.WriteLine("We've set our instance!");
Console.WriteLine($"{role.Name}, {role.Description}");