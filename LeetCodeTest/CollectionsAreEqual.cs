using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    public class CollectionsAreEqual
    {
        public static bool AreEqual<T>(IList<T> list1, IList<T> list2)
        {
            if (list1?.Count != list2?.Count)
            {
                return false;
            }
            return list1.SequenceEqual(list2);
        }

        public static bool AreEqual<T>(IList<T> list1, IList<T> list2,IEqualityComparer<T> comparer)
        {
            if (list1?.Count != list2?.Count)
            {
                return false;
            }
            return list1.SequenceEqual(list2,comparer);
        }

        public static bool AreEqualListOfLists<T>(IList<List<T>> lists1, IList<List<T>> lists2)
        {

            return lists1.All(innerList1 => lists2.Any(innerList2 => AreEqual(innerList1, innerList2)));


        }

        public static bool AreEqualListOfLists<T>(IList<IList<T>> lists1, IList<IList<T>> lists2)
        {

            return lists1.All(innerList1 => lists2.Any(innerList2 => AreEqual(innerList1, innerList2)));


        }

        public static bool AreEqualListOfTuple<T>(IList<Tuple<T, T>> lists1, IList<Tuple<T, T>> lists2)
        {

            return lists1.All(innerList1 => lists2.Any(innerList2 => innerList1.Equals(innerList2)));


        }

    }
}