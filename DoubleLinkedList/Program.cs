using DLLClass;
using NodeClass;

public class Program
{
    private static DoublyLinkedList BuildList(int[] values)
    {
        DoublyLinkedList list = new DoublyLinkedList(values[0]);
        for (int i = 1; i < values.Length; i++)
        {
            list.Append(values[i]);
        }
        return list;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("===== Build & PrintList =====");
        DoublyLinkedList dll = BuildList(new int[] { 10, 20, 30 });
        dll.PrintList();
        dll.GetHead();
        dll.GetTail();
        dll.GetLength();
        Console.WriteLine("\n===== Append(40) =====");
        dll.Append(40);
        dll.PrintList();
        Console.WriteLine("\n===== Prepend(5) =====");
        dll.Prepend(5);
        dll.PrintList();
        Console.WriteLine("\n===== RemoveFirst() =====");
        Node removedFirst = dll.RemoveFirst();
        Console.WriteLine("Removed: " + removedFirst.value);
        dll.PrintList();
        Console.WriteLine("\n===== RemoveLast() =====");
        Node removedLast = dll.RemoveLast();
        Console.WriteLine("Removed: " + removedLast.value);
        dll.PrintList();
        Console.WriteLine("\n===== Get(1) =====");
        Node found = dll.Get(1);
        Console.WriteLine("Get(1) = " + (found != null ? found.value.ToString() :
        "null"));
        Console.WriteLine("\n===== Set(1, 77) =====");
        dll.Set(1, 77);
        dll.PrintList();
        Console.WriteLine("\n===== Insert(1, 99) =====");
        dll.Insert(1, 99);
        dll.PrintList();
        Console.WriteLine("\n===== Remove(1) =====");
        Node removedMid = dll.Remove(1);
        Console.WriteLine("Removed: " + removedMid.value);
        dll.PrintList();
        Console.WriteLine("\n===== IsPalindrome() =====");
        DoublyLinkedList palindromeList = BuildList(new int[] { 1, 2, 3, 2, 1 });
        palindromeList.PrintList();
        Console.WriteLine("IsPalindrome: " + palindromeList.IsPalindrome());
        DoublyLinkedList notPalindrome = BuildList(new int[] { 1, 2, 3, 4 });
        notPalindrome.PrintList();
        Console.WriteLine("IsPalindrome: " + notPalindrome.IsPalindrome());
        Console.WriteLine("\n===== Reverse() =====");
        dll.PrintList();
        dll.Reverse();
        dll.PrintList();
        Console.WriteLine("\nDone. Press any key to exit.");
        Console.ReadKey();
    }
}

