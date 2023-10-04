using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        MinHeap<int> minHeapInt = new MinHeap<int>();
        minHeapInt.Insert(4);
        minHeapInt.Insert(20);
        minHeapInt.Insert(7);
        minHeapInt.Insert(10);


        string filePath = "C:\\Users\\NixAt\\Desktop\\BinaryHeap\\BinaryHeap\\Massive.txt";

        //int numberOfRandomNumbers = 1000000;
        //try
        //{
        //    // Создайте объект Random для генерации случайных чисел.
        //    Random random = new Random();

        //    // Откройте файл для записи.
        //    using (StreamWriter sw = new StreamWriter(filePath))
        //    {
        //        for (int i = 0; i < numberOfRandomNumbers; i++)
        //        {
        //            // Генерируйте случайное число и записывайте его в файл.
        //            int randomNumber = random.Next(0, 1000000001); // Генерация чисел от 1 до 100 (включительно).
        //            sw.WriteLine(randomNumber);
        //        }
        //    }

        //    Console.WriteLine($"Сгенерированы и записаны {numberOfRandomNumbers} случайных чисел в файл: {filePath}");
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine($"Ошибка при записи в файл: {e.Message}");
        //}



        try
        {
            // Откройте файл для чтения.
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Попробуйте преобразовать считанную строку в целое число.
                    if (int.TryParse(line, out int value))
                    {
                        // Вставьте значение в MinHeap.
                        minHeapInt.Insert(value);
                    }
                    else
                    {
                        Console.WriteLine($"Невозможно преобразовать строку в целое число: ({line}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine("Минимальный элемент: " + minHeapInt.ExtractMin()); // Выведет 1
        stopwatch.Stop();

        Console.WriteLine("Минимальный элемент: " + minHeapInt.ExtractMin() +  "\tВремя выполнения:" + stopwatch.ElapsedMilliseconds + "мс"); // Выведет 2
    }
}
