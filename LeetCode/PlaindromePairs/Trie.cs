using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.ExtensionMethods;

namespace LeetCode.PlaindromePairs
{

    //https://fizzbuzzed.com/top-interview-questions-5/
    public class Trie
    {
        public class TrieNode
        {
            //letter -> next Trie node
            Dictionary<char, TrieNode> children;

            //if a word ends at this node, then this will be a +ve value
            //that indicates the position of the word in the input list
            public int WordEndIndex { get; set; } = -1;


            //Stores all words that are palindromes from this node to the end of the word
            //e.g. if we are on a path 'a' , 'c' and word 'babca' exists in this trie
            //(words are added in reverse) then, 'acbab' index will be in this list
            //since bab is a palindrome

            public List<int> PalindromesBelow { get; set; } = new List<int>();
            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
            }

            public Dictionary<char, TrieNode> Children 
            {
                get { return children; }
            }
            
        }

        private readonly TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public TrieNode Root { get { return root; } }


        //the word will be added in revese
        //e.g. 'abcd' adds the path 'd', 'c', 'b' ,'a', $index to the trie
        //index - index of word in the list, used as a word identifier 
        public void AddWord(string word,int index)
        {
            TrieNode current = root;
            int len = word.Length;
            string rWord = word.Reverse();
            for (int i = 0; i < len; i++)
            {

                
                if (IsPalindrome(rWord.Substring(0, len-i)))
                {
                    current.PalindromesBelow.Add(index);
                }

                char c = rWord[i];
                if (!current.Children.ContainsKey(c))
                {
                    var node = new TrieNode();
                    current.Children.Add(c, node);
                }
                current = current.Children[c];
            }
            current.WordEndIndex = index;
        }



        public void Insert(string word)
        {
            TrieNode current = root;
            int len = word.Length;
            for(int index=0; index < len; index++)
            {
                char c = word[index];
                if (!current.Children.ContainsKey(c))
                {
                    var node = new TrieNode();
                    current.Children.Add(c, node);
                }
                current = current.Children[c];
            }
        }


  

     

  
        public bool IsPalindrome(string word)
        {
            //this method is optimized
            //instead of n equality checks, this does half of that i.e n/2 equality checks
            int len = word.Length;
            int upperDim = Convert.ToInt32(len / 2);
            for (int i = 0; i < upperDim; i++)
            {
                if (word[i] != word[(len - 1) - i])
                {
                    return false;
                }
            }
            return true;
        }


    }
}
