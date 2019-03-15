using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace LeetCode.WordLadders


{

    public class WordNode
    {
        public int Steps { get; set; }
        public string Word { get; set; }
        public WordNode Previous { get; set; }
        public WordNode(string word, int steps)
        {
            this.Word = word;
            this.Steps = steps;
            this.Previous = null;
        }

        public WordNode(string word, int steps, WordNode pre)
        {
            this.Word = word;
            this.Steps = steps;
            this.Previous = pre;
        }
    }


    public class WordLadder
    {

        //https://fizzbuzzed.com/top-interview-questions-4/


        //Word Ladder Problem #1
        //https://leetcode.com/problems/word-ladder/description/
        public int LadderShotestLenght(string beginWord, string endWord, List<string> wordDict)
        {
            //BFS search

            Queue<WordNode> queue = new Queue<WordNode>();
            HashSet<string> seen = new HashSet<string>();
            seen.Add(beginWord);
            queue.Enqueue(new WordNode(beginWord, 1));

            while(queue.Count > 0)
            {
                var next = queue.Dequeue();

                foreach(var candidate in GenerateNeighbors(next.Word,wordDict))
                {
                    if (candidate.Equals(endWord))
                    {
                        return next.Steps + 1;
                    }else if (seen.Contains(candidate))
                    {
                        continue;
                    }

                    seen.Add(candidate);
                    queue.Enqueue(new WordNode(candidate, next.Steps + 1));
                }
            }


            return 0;
        }


        //https://leetcode.com/problems/word-ladder-ii/description/

        public List<List<string>> AllShortestLadders(string beginWord, string endWord, List<string> wordDict)
        {
            //unoptimized code

            //Each item in the queue is a list which represents a 'ladder of words':
            Queue<List<string>> queue = new Queue<List<string>>();
            List<List<string>> output = new List<List<string>>();
            HashSet<string> seen = new HashSet<string>();
            HashSet<string> seen_this_level = new HashSet<string>();


            queue.Enqueue(new List<string>() { beginWord });
            seen.Add(beginWord);
            


            while (queue.Count > 0)
            {
                //We can't return as soon as we see an answer
                //We will process level by level
                //and only return when we'are done a full level
                //we also cannot mark values as seen unitl we've processed the full level
                //this is the reason for inefficiency

                int num_in_level = queue.Count;
                
                
                for (int i = 0; i < num_in_level; i++)
                {
                    var next = queue.Dequeue();
                    string last_word_in_queue = next[next.Count - 1];
                    
                    foreach (var candidate in GenerateNeighbors(last_word_in_queue, wordDict))
                    {
                        //Add the list of strings for each level to queue including candidate
                        List<string> list_of_word_in_level = new List<string>();
                        next.ForEach(word => list_of_word_in_level.Add(word));
                        list_of_word_in_level.Add(candidate);

                        if (candidate == endWord)
                        {
                            output.Add(list_of_word_in_level);
                        }
                        else if (seen.Contains(candidate))
                        {
                            continue;
                        }
                        else
                        {
                            seen_this_level.Add(candidate);
                            queue.Enqueue(list_of_word_in_level);
                        }
                    }
                }

                
                               
                seen.UnionWith(seen_this_level);


            }

            return output;

        }


        public List<List<string>> AllShortestLadders_Optimized(string beginWord, string endWord, List<string> wordDict)
        {
            Queue<string> queue = new Queue<string>();
            List<List<string>> output = new List<List<string>>();
            HashSet<string> seen = new HashSet<string>();
            HashSet<string> seen_this_level = new HashSet<string>();

            //word -> List(words), the dictionary will have all words which we reached 'word' during BFS
            Dictionary<string, List<string>> parents = new Dictionary<string, List<string>>();

            queue.Enqueue(beginWord);
            seen.Add(beginWord);

            while (queue.Count > 0)
            {
                //we will process level by level
                int num_in_level = queue.Count;
                bool finished = false;
                seen_this_level = new HashSet<string>();

                for (int i = 0; i < num_in_level; i++)
                {
                    var next = queue.Dequeue();
                    foreach(var candidate in GenerateNeighbors(next, wordDict))
                    {
                        if(candidate == endWord)
                        {
                            finished = true;

                        }else if( seen.Contains(candidate)){
                            continue;
                        }

                        if (!seen_this_level.Contains(candidate))
                        {
                            queue.Enqueue(candidate);
                        }

                        seen_this_level.Add(candidate);

                        if (!parents.ContainsKey(candidate))
                        {
                            parents.Add(candidate, new List<string>());
                        }
                        parents[candidate].Add(next);
                        
                    }                    

                }
                if (finished)
                {
                    break;
                }
                seen.UnionWith(seen_this_level);

            }

            return CreateAllPaths(parents,endWord,beginWord) ;
        }



        public List<List<string>> AllShortestLadders_Optimized_Using_CustomClass(string beginWord, string endWord, List<string> wordDict)
        {
            //Since each node can store one Previous word,
            // this will not all permutations of the paths to endword
            //i.e. if a node is common across paths, only one will be chosen

            List<List<string>> result = new List<List<string>>();
            Queue<WordNode> queue = new Queue<WordNode>();
            HashSet<string> seen = new HashSet<string>();
            HashSet<string> seen_in_this_level = new HashSet<string>();

            queue.Enqueue(new WordNode(beginWord, 1, null));

            while(queue.Count > 0)
            {

                int num_in_level = queue.Count;
                bool finished = false;
                for(int i = 0; i < num_in_level; i++)
                {
                    var next = queue.Dequeue();

                    foreach(var candidate in GenerateNeighbors(next.Word, wordDict))
                    {
                        if(candidate == endWord)
                        {
                            finished = true;
                            List<string> values = new List<string>();
                            values.Add(candidate);
                            
                            while(next.Previous != null)
                            {
                                values.Add(next.Word);
                                next = next.Previous;
                            }
                            values.Add(beginWord);
                            values.Reverse();
                            result.Add(values);
                        }else if (seen.Contains(candidate))
                        {
                            continue;
                        }

                        if (!seen_in_this_level.Contains(candidate))
                        {
                            queue.Enqueue(new WordNode(candidate, next.Steps + 1, next));
                        }
                        seen_in_this_level.Add(candidate);
                    }
                }

                if (finished)
                {
                    break;
                }

                seen.UnionWith(seen_in_this_level);

                
            }


            return result;


        }



        private List<List<string>> CreateAllPaths(Dictionary<string, List<string>> parents,string word,string beginWord)
        {
            if (word == beginWord)
            {
                return new List<List<string>>() {
                   new List<string>(){ beginWord }
                };
            }

            List<List<string>> result = new List<List<string>>();

            foreach (var w in parents[word])
            {
                var output = CreateAllPaths(parents, w, beginWord);
                foreach(var item in output)
                {
                    item.Add(word);
                    result.Add(item);
                }
                
            }

            return result;
            
        }


        public IEnumerable<string> GenerateNeighbors(string initialWord, List<string> wordDict)
        {
            int len = initialWord.Length;
            string newWord;
            for(int index=0; index < len; index++)
            {
                for (char letter = 'a'; letter <= 'z'; letter++)
                {
                    //newWord = initialWord[:i] + letter + initialWord[i+1:]

                    if (index == 0)
                    {
                        newWord = String.Concat(letter,initialWord.Substring(index + 1));
                    }
                    else
                    {

                        newWord = String.Concat(initialWord.Substring(0,index),letter,initialWord.Substring(index + 1));
                    }

                    //Console.WriteLine("---------------------");
                    //Console.WriteLine($"Generated Word: {newWord}");
                    //Console.WriteLine("---------------------");

                    if (wordDict.Contains(newWord))
                    {
                        yield return newWord;
                    }
                }
            }
        }
    }
}
