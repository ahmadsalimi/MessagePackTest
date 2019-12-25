using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ListExtension
    {
        public static string MakeString<T>(this List<T> source)
        {
            string result = "[";;
            for (int i = 0; i < source.Count; i++)
            {
                result += $"{source[i]}";
                if (i < source.Count - 1) result += ", ";
            }
            result += "]";
            return result;
        }
    }
}
