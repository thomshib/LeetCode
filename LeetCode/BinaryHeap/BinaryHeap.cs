using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BinaryHeaps
{
    public class BinaryHeap<T> where T:IComparable<T> 
    {
        private const int  CAPACITY = 10;
        T[] array;
        int size;
        bool _isMaxHeap;

        public BinaryHeap()
        {
            array = new T[CAPACITY];
            size = 0;
            _isMaxHeap = false;

        }

        public BinaryHeap(bool isMaxHeap):this()
        {
           
            _isMaxHeap = isMaxHeap;

        }

        public BinaryHeap(List<T> list, bool isMaxHeap=false)
        {
            this._isMaxHeap = isMaxHeap;
            array = new T[list.Count];
            size = 0;

            for(int i = 0; i < list.Count; i++)
            {
                AddItem(list[i]);
            }

        }


        private int CustomCompareTo(T x, T y)
        {
            if (_isMaxHeap)
            {
                return y.CompareTo(x); //for maxheap
            }
            return x.CompareTo(y); //for minheap
        }
        public void AddItem(T item)
        {
            size++;
            if(size >= array.Length - 1)
            {
                Resize();
            }

            array[size] = item;

            BubbleUp();

        }

        private void BubbleUp()
        {
            int index = size;

            while (HasParent(index))
            {
                if(CustomCompareTo(array[index],array[ParentIndex(index)]) < 0){
                    Swap(index, ParentIndex(index));
                }

                index = ParentIndex(index);
            }
        }

        public int Size()
        {
            return size - 1;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public T Peek()
        {
            if (!IsEmpty())
            {
                return array[1];
            }
            throw new ArgumentException("Array is invalid");
        }

        public T RemoveItem()
        {
            T result = Peek();
            Swap(1, size);
            array[size] = default(T);
            size--;
            BubbleDown();

            return result;
        }

        private void BubbleDown()
        {
            int index = 1;

            while (HasLeftChild(index))
            {
                int smallerchild = FindMinChild(index);
                if( CustomCompareTo(array[index],array[smallerchild]) > 0)
                {
                    Swap(index, smallerchild);
                }
                index = smallerchild
;            }
        }

        private int FindMinChild(int index)
        {
            if (HasRightChild(index)){
                if( CustomCompareTo(array[RighChildIndex(index)],array[LeftChildIndex(index)]) < 0)
                {
                    return RighChildIndex(index);
                }
            }

            return LeftChildIndex(index);
        }

        private void Resize()
        {
            Array.Resize(ref array, array.Length * 2);
        }

       

        private int RighChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        private bool HasRightChild(int index)
        {
            return RighChildIndex(index) <= size;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private int LeftChildIndex(int index)
        {
            return (index * 2);
        }

        private int ParentIndex(int index)
        {
            return index / 2;
        }

        private bool HasParent(int index)
        {
            var parent = ParentIndex(index);
            return parent > 0;
        }
       


        private void Swap(int source, int target)
        {
            T temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }


    }
}
