using System;
using System.Collections.Generic;
using System.Text;
namespace LeetCode.DataStructures{
    
    //https://leetcode.com/problems/lru-cache/solution/

    /*
        //https://www.youtube.com/watch?v=S6IfqDXWa10

        Approach
        The problem can be solved with a hashmap that keeps track of the keys and its values in the double linked list. 
        That results in O(1) time for put and get operations and allows to remove the first added node in O(1) time as well.

        One advantage of double linked list is that the node can remove itself without other reference. 
        In addition, it takes constant time to add and remove nodes from the head or tail.

        One particularity about the double linked list implemented here is that there are pseudo head and pseudo tail to 
        mark the boundary, so that we don't need to check the null node during the update.

    */
    public class LRUCache{
        private class DLinkedNode{
            //If fields of private class is public, its only going to be exposed to the enclosing class.
            public int key;
            public int value;

            public DLinkedNode prev;
            public DLinkedNode next;
        }

        private Dictionary<int,DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head;
        private DLinkedNode tail;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.size = 0;
            head = new DLinkedNode(); //head.prev is null
            tail = new DLinkedNode(); //tail.next is null

            head.next = tail;
            tail.prev = head;

        }

        public void Put(int key, int value){
            DLinkedNode node;
            cache.TryGetValue(key, out node);

            if(node == null){
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                 cache.Add(key,newNode);
                 AddNode(newNode);

                 ++size;
                 if(size > capacity){
                     //pop the tail
                     var tail = PopTail();
                     cache.Remove(tail.key);
                     --size;

                 }


            }else {
                //update the value
                node.value = value;
                MoveToHead(node);
            }
           

        }


        public int Get(int key){
             DLinkedNode node;
             cache.TryGetValue(key, out node);
             if(node == null){
                 return -1;
             }else{
                 MoveToHead(node);
                 return node.value;
             }

        }
        private DLinkedNode PopTail(){
            //Pop the current tail.
            DLinkedNode result = tail.prev;
            RemoveNode(result);
            return result;

        }
        private void AddNode(DLinkedNode node){
            //Always add the new node right after head

            node.prev = head;
            node.next = head.next;

            head.next.prev = node;
            head.next = node;
        }

         private void RemoveNode(DLinkedNode node){
             // * Remove an existing node from the linked list
             DLinkedNode prev = node.prev;
             DLinkedNode next = node.next;

             prev.next = next;
             next.prev = prev;
         }

        private void MoveToHead(DLinkedNode node){
            RemoveNode(node);
            AddNode(node);
        }




}

}