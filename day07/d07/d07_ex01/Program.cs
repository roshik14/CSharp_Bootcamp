using Microsoft.AspNetCore.Http;
using System.Reflection;

var ctx = new DefaultHttpContext();
Console.WriteLine($"Old Response value: {ctx.Response}");
var field = ctx.GetType().GetField("_response", BindingFlags.Instance | BindingFlags.NonPublic);
if (field != null)
{
    field.SetValue(ctx, null);
    Console.WriteLine($"New Response value: {ctx.Response}");
}

