using System;
using System.Collections.Generic;

public class MinHeap<T> where T : IComparable<T>
{
    private List<T> heap = new List<T>();

    public void Insert(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    public T FindMin()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }
        return heap[0];
    }

    public T ExtractMin()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        T min = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        if (heap.Count > 1)
        {
            HeapifyDown(0);
        }

        return min;
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;

        while (index > 0 && heap[index].CompareTo(heap[parentIndex]) < 0)
        {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;
        int smallest = index;

        if (leftChildIndex < heap.Count && heap[leftChildIndex].CompareTo(heap[smallest]) < 0)
        {
            smallest = leftChildIndex;
        }

        if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[smallest]) < 0)
        {
            smallest = rightChildIndex;
        }

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MinHeap<int> minHeap = new MinHeap<int>();
        minHeap.Insert(4);
        minHeap.Insert(2);
        minHeap.Insert(7);
        minHeap.Insert(1);

        Console.WriteLine("Минимальный элемент: " + minHeap.ExtractMin()); // Выведет 1
        Console.WriteLine("Минимальный элемент: " + minHeap.ExtractMin()); // Выведет 2
    }
}
