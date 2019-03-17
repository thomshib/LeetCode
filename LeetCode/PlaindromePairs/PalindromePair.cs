using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.PlaindromePairs
{
    //https://fizzbuzzed.com/top-interview-questions-5/
    public class PalindromePair
    {

        
        public bool IsPalindrome(string word)
        {
            //this method is optimized
            //instead of n equality checks, this does half of that i.e n/2 equality checks
            int len = word.Length;
            int upperDim = Convert.ToInt32(len / 2); 
            for( int i = 0; i < upperDim; i++)
            {
                if(word[i] != word[(len-1) - i])
                {
                    return false;
                }
            }
            return true;
        }

        public List<List<int>> BruteForceSolution(List<string> words)
        {
            //O(n squared ) solution, very bad
            var result = new List<List<int>>();

            int len = words.Count;
            for(int i=0; i < len; i++)
            {
                for(int j=0; j < len; j++)
                {
                    if(i != j)
                    {
                        if (IsPalindrome(String.Concat(words[i], words[j])))
                        {
                            result.Add(new List<int>() { i, j });
                        }
                    }
                }
            }

            return result;
        }


        public Trie MakeTrie(string[] words)
        {
            Trie t = new Trie();
            for (int i = 0; i < words.Length; i++)
            {
                t.AddWord(words[i], i);
            }

            return t;
        }

        //Take tehe trie, a word and its index in the word array
        //Returns the index of the every word that could be appended 
        //to it to form a palindrome
        public List<int> GetPalindromeForWord(Trie trie, string word, int index)
        {
            //Walk the trie
            //Everytime we find a word ending
            //check if we could make a palindrome
            //Once we reach the end of the word,
            // we must check all endings below for palindromes(they are already stored in
            // 'PalindromesBelow'

            var currentNode = trie.Root;
            List<int> output = new List<int>();

            while (word.Length > 0)
            {
                if (currentNode.WordEndIndex >= 0)
                {
                    if (IsPalindrome(word))
                    {
                        output.Add(currentNode.WordEndIndex);
                    }
                }

                if (!currentNode.Children.ContainsKey(word[0]))
                {
                    return output;
                }

                currentNode = currentNode.Children[word[0]];
                word = word.Substring(1);

            }

            if (currentNode.WordEndIndex >= 0)
            {
                output.Add(currentNode.WordEndIndex);
            }

            currentNode.PalindromesBelow.ForEach(i => output.Add(i));

            return output;
        }

        public List<Tuple<int, int>> PalindromePairsSolution(string[] words)
        {
            Trie trie = MakeTrie(words);

            List<Tuple<int, int>> output = new List<Tuple<int, int>>();
            int len = words.Length;

            Tuple<int, int> result;
            for (int i = 0; i < len; i++)
            {

                var candidates = GetPalindromeForWord(trie, words[i], i);

                candidates.ForEach(n =>
                {
                    if (n != i)
                    {
                        result = new Tuple<int, int>(i, n);
                        output.Add(result);
                    }
                }
                );
            }

            return output;
        }



    }
}
