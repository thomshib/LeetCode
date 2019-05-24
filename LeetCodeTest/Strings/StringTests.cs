using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Strings;

namespace LeetCodeTest.Strings
{
    [TestClass]
    public class StringTests
    {

        [TestMethod]
        public void LongestSubstringSuccess()
        {
            string input = "abcabcbb";
            int result;

            result = new LongestSubstring().LengthOfLongestSubstring(input);
            Assert.AreEqual(result, 3);

            input = "pwwkew";
            result = new LongestSubstring().LengthOfLongestSubstring(input);
            Assert.AreEqual(result, 3);

            input = "bbbbbb";
            result = new LongestSubstring().LengthOfLongestSubstring(input);
            Assert.AreEqual(result, 1);

        }

        [TestMethod]
        public void LongestSubstringSlidingWindowSuccess()
        {
            string input = "abcabcbb";
            int result;

            result = new LongestSubstring().LengthOfLongestSubstringSlidingWindow(input);
            Assert.AreEqual(result, 3);

            input = "pwwkew";
            result = new LongestSubstring().LengthOfLongestSubstringSlidingWindow(input);
            Assert.AreEqual(result, 3);

            input = "bbbbbb";
            result = new LongestSubstring().LengthOfLongestSubstringSlidingWindow(input);
            Assert.AreEqual(result, 1);

        }


        [TestMethod]
        public void StringtoIntegerWindowSuccess()
        {
            string input = "42";
            int result;

            result = new StringtoInteger().MyAtoi(input);
            Assert.AreEqual(result, 42);


            input = "   -42";
            result = new StringtoInteger().MyAtoi(input);
            Assert.AreEqual(result, -42);

            input = "-91283472332";
            result = new StringtoInteger().MyAtoi(input);
            Assert.AreEqual(result, int.MinValue);


        }



        [TestMethod]
        public void MinimumWindowSubstringMapSuccess()
        {
            string S = "dbanc";
            string T = "abc";

            var expectedResult = "banc";

            var result = new MinimumWindowSubstring().MinWindow(S, T);

            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod]
        public void PalindromeSuccess()
        {
            string input = "A man, a plan, a canal: Panama";

            var result = new LeetCode.Strings.Palindrome().IsPalindrome(input);

            Assert.IsTrue(result);


            input = "race a car";

            result = new LeetCode.Strings.Palindrome().IsPalindrome(input);

            Assert.IsFalse(result);



        }

        [TestMethod]
        public void OneEditDistanceSuccess()
        {
            string s = "ab";
            string t = "abc";

            var result = new OneEditDistance().IsOneEditDistance(s, t);
            Assert.IsTrue(result);

            s = "cab";
            t = "ad";

            result = new OneEditDistance().IsOneEditDistance(s, t);
            Assert.IsFalse(result);

            s = "1213";
            t = "1203";

            result = new OneEditDistance().IsOneEditDistance(s, t);
            Assert.IsTrue(result);


        }

        [TestMethod]
        public void LengthOfLongestSubstringKDistinctSuccess()
        {
            string input = "eceba"; 
            //ece
            var result = new LongestSubstringwithKDistinctCharacters().LengthOfLongestSubstringKDistinct(input,2);

            Assert.AreEqual(result,3);



            input = "aa";
            //ece
            result = new LongestSubstringwithKDistinctCharacters().LengthOfLongestSubstringKDistinct(input, 1);

            Assert.AreEqual(result, 2);
        }


        [TestMethod]
        public void IPAddress()
        {
            string input;
            string result;
            

            input = "172.16.254.1";
            result = new IPAddress().ValidIPAddress(input);
            Assert.AreEqual(result, "IPv4");

            input = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            result = new IPAddress().ValidIPAddress(input);
            Assert.AreEqual(result, "IPv6");

            input = "256.256.256.256";
            result = new IPAddress().ValidIPAddress(input);
            Assert.AreEqual(result, "Neither");

        }


        [TestMethod]
        public void Palindrome2Success()
        {
            string input = "abca";

            var result = new Palindrome2().ValidPalindrome(input);

            Assert.IsTrue(result);


        }
    }
}
