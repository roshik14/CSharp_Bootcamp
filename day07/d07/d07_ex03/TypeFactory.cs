using System.Reflection;

namespace d07_ex03
{
    public class TypeFactory
    {
        public static T CreateWithConstructor<T>() where T : class
        {
            var constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public,
                Array.Empty<Type>());
            if (constructor != null)
            {
                return (T)constructor.Invoke(null);
            }
            throw new ArgumentException("No such constructor");
        }

        public static T CreateWithActivator<T>() where T : class
        {
            var obj = Activator.CreateInstance(typeof(T));
            if (obj != null)
            {
                return (T)obj;
            }
            throw new ArgumentException("No such constructor");
        }

        public static T CreateWithParameters<T>(params object[] objects) where T : class
        {
            var obj = Activator.CreateInstance(typeof(T), objects);
            if (obj != null)
            {
                return (T)obj;
            }
            throw new ArgumentException("No such constructor");
        }
    }
}
