using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace LeetCode.Streams
{
    //https://www.youtube.com/watch?v=E-kjYOZEBxY
    public class MovingAverage
    {
        private Queue<int> queue;
        private int mazSize;
        private double sum;

        public MovingAverage(int size)
        {
            queue = new Queue<int>(size);
            mazSize = size;
            sum = 0.0;
        }

        private double Next(int value)
        {
            if(queue.Count == mazSize)
            {
                sum -= queue.Dequeue();
            }

            queue.Enqueue(value);

            sum += value;

            return sum;
        }
    }
}
