using System.Runtime.InteropServices.ComTypes;

namespace Pingo.CommandLine.ArrayUtils
{

    public static class ArrayItemDeleter
    {
        public static void RemoveArrayItem<T>(ref T[] inArray, int inIndex)
        {
            var newArray = new T[inArray.Length - 1];
            for (int i = 0, j = 0; i < newArray.Length; i++, j++)
            {
                if (i == inIndex)
                {
                    j++;
                }
                newArray[i] = inArray[j];
            }
            inArray = newArray;
        }
    }
}
