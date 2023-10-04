using System;

public class MinHeap
{
    private int[] heap;
    private int size;
    private int capacity;

    public MinHeap(int capacity)
    {
        this.capacity = capacity;
        this.size = 0;
        this.heap = new int[capacity];
    }

    private int Parent(int i) => (i - 1) / 2;
    private int LeftChild(int i) => 2 * i + 1;
    private int RightChild(int i) => 2 * i + 2;

    private void Swap(int a, int b)
    {
        int temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
    }

    public void Insert(int key)
    {
        if (size == capacity)
        {
            Console.WriteLine("Куча переполнена. Невозможно вставить элемент.");
            return;
        }

        size++;
        int i = size - 1;
        heap[i] = key;

        while (i != 0 && heap[i] < heap[Parent(i)])
        {
            Swap(i, Parent(i));
            i = Parent(i);
        }
    }

    public int ExtractMin()
    {
        if (size <= 0)
        {
            Console.WriteLine("Куча пуста.");
            return int.MaxValue; // Возвращаем максимальное значение для индикации ошибки
        }
        if (size == 1)
        {
            size--;
            return heap[0];
        }

        int root = heap[0];
        heap[0] = heap[size - 1];
        size--;
        MinHeapify(0);

        return root;
    }

    private void MinHeapify(int i)
    {
        int left = LeftChild(i);
        int right = RightChild(i);
        int smallest = i;

        if (left < size && heap[left] < heap[i])
            smallest = left;
        if (right < size && heap[right] < heap[smallest])
            smallest = right;

        if (smallest != i)
        {
            Swap(i, smallest);
            MinHeapify(smallest);
        }
    }

    public void Print()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(heap[i] + " ");
        }
        Console.WriteLine();
    }
}

class TempProgram
{
    public static void NoMain(string[] args)
    {
        MinHeap minHeap = new MinHeap(10);

        minHeap.Insert(3);
        minHeap.Insert(2);
        minHeap.Insert(1);
        minHeap.Insert(7);
        minHeap.Insert(8);
        minHeap.Insert(4);
        minHeap.Insert(5);


        Console.WriteLine("Куча до извлечения минимального элемента:");
        minHeap.Print();

        Console.WriteLine("Минимальный элемент: " + minHeap.ExtractMin());

        Console.WriteLine("Куча после извлечения минимального элемента:");
        minHeap.Print();
    }
}
