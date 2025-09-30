using System.ComponentModel;

namespace Vengage.WebAwesome
{
    public static class ValueProviderResult
    {
        public static T ConvertTo<T>(this object value) //where T : Enum
        {

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if(typeof(T).IsEnum) return (T)Enum.Parse(typeof(T), value.ToString()!);

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}