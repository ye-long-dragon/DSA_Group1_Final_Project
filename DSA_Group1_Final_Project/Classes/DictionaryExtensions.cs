using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes
{
    public static class DictionaryExtensions
    {
        public static T TryGetValueOrDefault<T>(this Dictionary<string, object> dict, string key, T defaultValue = default)
        {
            if (dict.TryGetValue(key, out var value))
            {
                if (value is T typedValue) return typedValue; // ✅ Direct cast if type matches
                if (value is long l && typeof(T) == typeof(int)) return (T)(object)(int)l; // ✅ Convert `long` to `int`
                if (value is List<object> list && typeof(T) == typeof(List<string>)) return (T)(object)list.Cast<string>().ToList(); // ✅ Convert List<object> to List<string>
                return (T)Convert.ChangeType(value, typeof(T)); // ✅ Convert to target type
            }
            return defaultValue;
        }
    }
}
