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


        #region WordLadder Problem1

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

        public IEnumerable<string> GenerateNeighbors(string initialWord, List<string> wordDict)
        {
            int len = initialWord.Length;
            string newWord;
            for (int index = 0; index < len; index++)
            {
                for (char letter = 'a'; letter <= 'z'; letter++)
                {
                    //newWord = initialWord[:i] + letter + initialWord[i+1:]

                    if (index == 0)
                    {
                        newWord = String.Concat(letter, initialWord.Substring(index + 1));
                    }
                    else
                    {

                        newWord = String.Concat(initialWord.Substring(0, index), letter, initialWord.Substring(index + 1));
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






        //Approach 2
        //BFS， two-end method
        //traverse the path simultaneously from start node and end node, and merge in the middle
        //the speed will increase (logN/2)^2 times compared with one-end method

        public int LadderLengthTwoEndBFS(string beginWord, string endWord, List<string> wordDict)
        {

            HashSet<string> beginSet = new HashSet<string>();
            HashSet<string> endSet = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();

            int ladderLength = 1;
            beginSet.Add(beginWord);
            endSet.Add(endWord);
            visited.Add(beginWord);
            visited.Add(endWord);

            while(beginSet.Count > 0 && endSet.Count > 0)
            {
                // add new words to smaller set to achieve better performance
                Swap(beginSet, endSet);

                ladderLength++;
                HashSet<string> nextSet = new HashSet<string>();

                foreach(var word in beginSet)
                {
                    foreach (var candidate in GenerateNeighbors(word, wordDict))
                    {
                        if (endSet.Contains(candidate))
                        {
                            return ladderLength;
                        }

                        if (!visited.Contains(candidate))
                        {
                            nextSet.Add(candidate);
                            visited.Add(candidate);
                        }
                    }
                }
                beginSet = nextSet;

            }


            return 0;




        }

        private void Swap(HashSet<string> beginSet, HashSet<string> endSet)
        {
            // add new words to smaller set to achieve better performance
            if(beginSet.Count > endSet.Count)
            {
                var temp = beginSet;
                beginSet = endSet;
                endSet = temp;
            }

        }



        #region  Ideal Solution


        //https://leetcode.com/problems/word-ladder/solution/
        public int LadderLengthIdeal(String beginWord, String endWord, List<String> wordList)
        {

            //Dictionary to hold combination of words that can be formed,
            // from any given word. By changing one letter at a time.
            Dictionary<string, List<string>> allComboDict = new Dictionary<string, List<string>>();
            // Since all words are of same length.
            int L = beginWord.Length;


            //create the transformations
            // for e.g for the word hot create the below transformation
            // *ot -> hot
            // h*t -> hot
            // ho* -> hot
            wordList.ForEach(word =>
           {
               for(int i = 0; i < L; i++)
               {
                   string newWord = i == 0 ? String.Concat("*", word.Substring(i + 1)) : String.Concat(word.Substring(0, i), "*", word.Substring(i + 1));

                   if (!allComboDict.ContainsKey(newWord))
                   {
                       allComboDict.Add(newWord, new List<string>());
                   }

                   allComboDict[newWord].Add(word);
                  

               }

           });


            //BFS
            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(beginWord, 1));

            //visited to avoid processing the same word

            HashSet<string> visited = new HashSet<string>();
            visited.Add(beginWord);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                var word = node.Item1;
                var level = node.Item2;

                for(int i = 0; i < L; i++)
                {
                    // Intermediate words for current word
                    string newWord = i == 0 ? String.Concat("*", word.Substring(i + 1)) : String.Concat(word.Substring(0, i), "*", word.Substring(i + 1));

                    // Next states are all the words which share the same intermediate state.

                    if (allComboDict.ContainsKey(newWord))
                    {
                        foreach(var adjacentWord in allComboDict[newWord])
                        {
                            // If at any point if we find what we are looking for
                            // i.e. the end word - we can return with the answer.
                            if (adjacentWord.Equals(endWord))
                            {
                                return level + 1;
                            }

                            // Otherwise, add it to the BFS Queue. Also mark it visited
                            if (!visited.Contains(adjacentWord))
                            {
                                visited.Add(adjacentWord);
                                queue.Enqueue(new Tuple<string, int>(adjacentWord, level + 1));
                            }

                        }
                    }
                }
            }




            return 0;
        }


        //Approach 2
        //BFS Bidirectional BFS

        public int LadderLengthIdealBidirectionalBFS(String beginWord, String endWord, List<String> wordList)
        {


            var wList = (List<string>)wordList;
            if (!wList.Contains(endWord))
            {
                return 0;
            }

            //Dictionary to hold combination of words that can be formed,
            // from any given word. By changing one letter at a time.
            Dictionary<string, List<string>> allComboDict = new Dictionary<string, List<string>>();
            // Since all words are of same length.
            int L = beginWord.Length;


            //create the transformations
            // for e.g for the word hot create the below transformation
            // *ot -> hot
            // h*t -> hot
            // ho* -> hot
            wordList.ForEach(word =>
            {
                for (int i = 0; i < L; i++)
                {
                    string newWord = i == 0 ? String.Concat("*", word.Substring(i + 1)) : String.Concat(word.Substring(0, i), "*", word.Substring(i + 1));

                    if (!allComboDict.ContainsKey(newWord))
                    {
                        allComboDict.Add(newWord, new List<string>());
                    }

                    allComboDict[newWord].Add(word);


                }

            });


            //Bidirectional BFS
            Queue<Tuple<string, int>> Q_begin = new Queue<Tuple<string, int>>();
            Queue<Tuple<string, int>> Q_end = new Queue<Tuple<string, int>>();
            Q_begin.Enqueue(new Tuple<string, int>(beginWord, 1));
            Q_end.Enqueue(new Tuple<string, int>(endWord, 1));

            //visited to avoid processing the same word

            Dictionary<string,int> visitedBegin = new Dictionary<string, int>();
            Dictionary<string, int> visitedEnd = new Dictionary<string, int>();
            visitedBegin.Add(beginWord, 1);
            visitedEnd.Add(endWord, 1);


            while(Q_begin.Count > 0 && Q_end.Count > 0)
            {
                //one hop from begin word
                int result = VisitWordNode(Q_begin, visitedBegin, visitedEnd , allComboDict);
                if (result > -1) return result;

                //one hop from end word
                 result = VisitWordNode(Q_end,  visitedEnd, visitedBegin,allComboDict);
                if (result > -1) return result;

            }




            return 0;
        }

        private int VisitWordNode(Queue<Tuple<string, int>> queue, Dictionary<string, int> visited, Dictionary<string, int> visitedOthers, Dictionary<string, List<string>> allComboDict)
        {
            var node = queue.Dequeue();
            var word = node.Item1;
            var level = node.Item2;
            int L = word.Length;

            for(int i = 0; i < L; i++)
            {
                var newWord = i == 0 ? String.Concat("*", word.Substring(i + 1)) : String.Concat(word.Substring(0, i), "*", word.Substring(i + 1));

                if (allComboDict.ContainsKey(newWord))
                {
                    foreach(var adjacentWord in allComboDict[newWord])
                    {
                        if (visitedOthers.ContainsKey(adjacentWord))
                        {
                            return level + visitedOthers[adjacentWord];
                        }

                        if (!visited.ContainsKey(adjacentWord))
                        {
                            visited.Add(adjacentWord, level + 1);
                            queue.Enqueue(new Tuple<string, int>(adjacentWord, level + 1));
                        }
                    }
                }
            }

            return -1;


        }


        #endregion


        #endregion

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


       


        
    }
}
