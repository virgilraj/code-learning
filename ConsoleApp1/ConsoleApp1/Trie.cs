using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class TrieNode
    {
        internal Dictionary<char, TrieNode> child { get; set; }
        internal bool endOfWord { get; set; }
        public string Data { get; set; }

        internal TrieNode()
        {
            child = new Dictionary<char, TrieNode>();
            endOfWord = false;
        }
    }
    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;
            for(int i=0; i< word.Length; i++)
            {
                if (!current.child.ContainsKey(word[i])){
                    TrieNode node = new TrieNode();
                    current.child.Add(word[i], node);
                    current = node;
                }
                else
                {
                    current = current.child[word[i]];
                }
            }
            current.endOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.child.ContainsKey(word[i]))
                {
                    return false;
                }
                current = current.child[word[i]];
            }

            //Partial search
            //then return  true
            //return true of current's endOfWord is true else return false.
            return current.endOfWord;
        }

        public void AutoComplete(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.child.ContainsKey(word[i]))
                {
                    return;
                }
                current = current.child[word[i]];
            }
            Console.WriteLine();
            BreadthFirstTraverse(current, word);
            Console.WriteLine();
            DepthFirstTraverse(current, word);
            Console.WriteLine();
            HashSet<TrieNode> visited = new HashSet<TrieNode>();
            DFS(current, visited, word);
        }

        public void DFS(TrieNode current, HashSet<TrieNode> visited, string word)
        {
            // mark current node as discovered
            visited.Add(current);

            // do for every edge (v -> u)
            foreach (var lst in current.child)
            {
                if (!visited.Contains(lst.Value))
                {
                    // print current node
                    if (lst.Value.endOfWord)
                    {
                        Console.Write("{0}{1} ", word, lst.Key);
                    }
                    else
                    {
                        word += lst.Key;
                    }
                    DFS(lst.Value, visited, word);
                }
            }
        }

        public void DepthFirstTraverse(TrieNode current, string word)
        {
            Stack<TrieNode> S = new Stack<TrieNode>();
            HashSet<TrieNode> visited = new HashSet<TrieNode>();

            S.Push(current);
            visited.Add(current);

            while(S.Count > 0)
            {
                TrieNode t = S.Pop();
                foreach (var lst in t.child)
                {
                    if (!visited.Contains(lst.Value))
                    {
                        S.Push(lst.Value);
                        if (lst.Value.endOfWord)
                        {
                            Console.Write("{0}{1} ", word, lst.Key);
                            word = "ab";
                        }
                        else
                        {
                            word += lst.Key;
                        }
                    }
                }
            }
        }

        public void BreadthFirstTraverse(TrieNode current, string word)
        {
            Queue<TrieNode> traverseOrder = new Queue<TrieNode>();
            Queue<TrieNode> Q = new Queue<TrieNode>();
            HashSet<TrieNode> visited = new HashSet<TrieNode>();

            Dictionary<string, TrieNode> col = new Dictionary<string, TrieNode>();

            Q.Enqueue(current);
            visited.Add(current);

            while(Q.Count > 0)
            {
                TrieNode t = Q.Dequeue();
                
                traverseOrder.Enqueue(t);
                foreach (var lst in t.child)
                {
                    if (!visited.Contains(lst.Value))
                    {
                        Q.Enqueue(lst.Value);
                    }
                }
            }

            while(traverseOrder.Count > 0)
            {
                TrieNode t = traverseOrder.Dequeue();
                foreach(var a in t.child.Keys)
                    Console.Write("{0}{1} ", word, a);
            }
            
        }

        //public void Delete()
    }
}
