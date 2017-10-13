﻿using System;
using Algorithm.Sandbox.DataStructures.Heap.Min;

namespace Algorithm.Sandbox.DataStructures.Queues.PriorityQueue
{

    /// priority queue implementation using min heap
    /// assuming lower values of P have higher priority
    public class MinPriorityQueue<T> where T : IComparable
    {
        private BMinHeap<T> minHeap = new BMinHeap<T>();

        public void Enqueue(T queueItem)
        {
            minHeap.Insert(queueItem);
        }

        public T Dequeue()
        {
            return minHeap.ExtractMin();
        }
    }
}