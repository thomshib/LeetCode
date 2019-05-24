using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3014/
    public class GroupAnagramsSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            if(strs == null || strs.Length == 0)
            {
                return result;
            }

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach(string item in strs)
            {
                char[] chars = item.ToCharArray();
                Array.Sort(chars);
                string keyString = new string(chars);

                if (!map.ContainsKey(keyString))
                {
                    map[keyString] = new List<string>();
                }
                map[keyString].Add(item);
            }

            CopyResult(map, result);

            return result;
        }

        private void CopyResult(Dictionary<string, List<string>> map, List<IList<string>> result)
        {
            foreach(var key in map.Keys)
            {
                List<string> list = new List<string>();
                result.Add(list);

                foreach(var value in map[key])
                {
                    list.Add(value);
                }
            }
        }
    }
}
