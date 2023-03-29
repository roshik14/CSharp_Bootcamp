using System.Reflection;
using d07_ex02.Attributes;
using System.ComponentModel;

namespace d07_ex02.ConsoleSetter
{
    public class ConsoleSetter<T> where T : class
    {
        public void SetValues(T input)
        {
            var type = input.GetType();
            Console.WriteLine($"Let's set {type.Name}");
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties.Where(x => x.GetCustomAttribute<NoDisplayAttribute>() is null))
            {
                Console.WriteLine($"Set {prop.GetCustomAttribute<DescriptionAttribute>()?.Description ?? prop.Name}");
                var userInput = Console.ReadLine();
                var value = string.IsNullOrEmpty(userInput)
                    ? prop.GetCustomAttribute<DefaultValueAttribute>()?.Value
                    : userInput;
                prop.SetValue(input, value);
            }
        }
    }
}
