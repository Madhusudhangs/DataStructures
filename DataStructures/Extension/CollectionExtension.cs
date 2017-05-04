using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Extension
{
    internal static class CollectionExtension
    {
        public static void Swap<T>(this IList<T> list, int index1, int index2)
        {
            T temp = list[index1];

            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
