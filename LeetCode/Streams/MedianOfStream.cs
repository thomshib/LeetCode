using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;
using System.Collections.Concurrent;
using LeetCode.BinaryHeaps;

namespace LeetCode.Streams
{
    //https://www.youtube.com/watch?v=VmogG01IjYc
    //https://leetcode.com/problems/find-median-from-data-stream/
    public class MedianOfStream
    {
        //Two heaps
        //maxHeap to store lower half of the numbers
        //minHeap to store upper half of the numbers
        private BinaryHeap<double> _minHeap;
        private BinaryHeap<double> _maxHeap;

        public MedianOfStream()
        {
            _minHeap = new BinaryHeap<double>(false);
            _maxHeap = new BinaryHeap<double>(true);
            
        }


        public double FindMedian(double[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                var number = array[i];
                AddNumber(number, _minHeap, _maxHeap);
                Rebalance(_minHeap, _maxHeap);
            }

            return GetMedian(_minHeap,_maxHeap);
        }

        private double GetMedian(BinaryHeap<double>  minHeap, BinaryHeap<double> maxHeap)
        {
            var smallerHeap = minHeap.Size() > maxHeap.Size() ? maxHeap : minHeap;
            var biggerHeap = minHeap.Size() > maxHeap.Size() ? minHeap : maxHeap;

            if(smallerHeap.Size() == biggerHeap.Size())
            {
                return (smallerHeap.Peek() + biggerHeap.Peek()) / 2;
            }
            else
            {
                return biggerHeap.Peek();
            }
        }

        private void Rebalance(BinaryHeap<double> minHeap, BinaryHeap<double> maxHeap)
        {
            var smallerHeap = minHeap.Size() > maxHeap.Size() ? maxHeap : minHeap;
            var biggerHeap = minHeap.Size() > maxHeap.Size() ? minHeap : maxHeap;

            if(biggerHeap.Size() - smallerHeap.Size() >= 2)
            {
                smallerHeap.AddItem(biggerHeap.RemoveItem());
            }

        }

        private void AddNumber(double number, BinaryHeap<double> minHeap, BinaryHeap<double> maxHeap)
        {
            //divide into two parts
            //if input is 2,3,4,5,6
            //maxHeap is the first part that contains 2,3,4
            //minHeap is the second part that contains 5,6
            if(_maxHeap.Size() == 0 || (_maxHeap.Size() > 0 && number < _maxHeap.Peek()))
            {
                _maxHeap.AddItem(number);
            }
            else
            {
                _minHeap.AddItem(number);
            }
        }
    }
}
