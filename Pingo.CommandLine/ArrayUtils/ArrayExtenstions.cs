using System.Linq;

namespace Pingo.CommandLine.ArrayUtils
{
    public static class ArrayExtenstions
    {
        public static bool IsNullOrEmpty<T>(this T[] array) 
        {
            if (array == null)
                return true;
            return array.Count() == 0;
        }
    }
}