using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3018/
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3018/discuss/95491/Java-Simple-Solution
    public class IPAddress


    {

        private readonly String VALIDIPV6CHARS = "0123456789abcdefABCDEF";
        public string ValidIPAddress(string IP)
        {
            if (IsValidIPv4(IP)) return "IPv4";
            else if (IsValidIPv6(IP)) return "IPv6";
            else return "Neither";
        }

        private bool IsValidIPv6(string ip)
        {
            if (ip.Length < 15) return false;  //1:1:1:1:1:1:1:1

            if (ip[0] == ':') return false;

            if (ip[ip.Length - 1] == ':') return false;
            string[] tokens = ip.Split(':');
            if (tokens.Length != 8) return false;

            foreach (var item in tokens)
            {
                if (!IsValidIPv6Token(item)) return false;
            }

            return true;
        }

        private bool IsValidIPv6Token(string token)
        {
            if (token.Length == 0 ||token.Length >4)
            {
                return false;
            }
            
            foreach(var item in token)
            {
                if (!VALIDIPV6CHARS.Contains(item.ToString()))
                {
                    return false;
                }
            }
            

            return true;
        }

        private bool IsValidIPv4(string ip)
        {
            if (ip.Length < 7) return false;  //1.1.1.1

            if (ip[0] == '.') return false;

            if (ip[ip.Length - 1] == '.') return false;
            string[] tokens = ip.Split('.');
            if (tokens.Length != 4) return false;

            foreach(var item in tokens)
            {
                if (!IsValidIPv4Token(item)) return false;
            }

            return true;

        }

        private bool IsValidIPv4Token(string token)
        {
            if(token.Length == 0)
            {
                return false;
            }
            if (token.Length != 1 && token.StartsWith("0"))
            {
                return false;
            }

            int result;
            int.TryParse(token, out result);

            if (result < 0 || result > 255) return false;
            if (result == 0 && token[0] != '0') return false; // 0.0.0.-0;

            return true;

        }
    }
}


