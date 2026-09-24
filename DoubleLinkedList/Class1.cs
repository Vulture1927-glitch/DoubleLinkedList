using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NodeClass;
namespace DLLClass
{
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;
        private int length;
        public DoublyLinkedList(int value)
        {
            Node newNode = new Node(value);
            head = newNode;
            tail = newNode;
            length = 1;
        }
        public void PrintList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.value);
                if (temp.next != null) Console.Write(" <-> ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
        public void GetHead()
        {
            Console.WriteLine(head == null ? "Head: null" : "Head: " + head.value);
        }
        public void GetTail()
        {
            Console.WriteLine(tail == null ? "Tail: null" : "Tail: " + tail.value);
        }
        public void GetLength()
        {
            Console.WriteLine("Length: " + length);
        }
       
        public void Append(int value)
        {
            Node newNode = new Node(value);
            if (length == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            length++;
        }
      
        public void Prepend(int value)
        {
            Node newNode = new Node(value);
            if (length == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            length++;
        }
       
        public Node RemoveFirst()
        {
            if (length == 0) return null;
            Node temp = head;
            if (length == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
                temp.next = null;
            }
            length--;
            return temp;
        }
     
        public Node RemoveLast()
        {
            if (length == 0) return null;
            Node temp = tail;
            if (length == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.prev;
                temp.prev = null;
                tail.next = null;
            }
            length--;
            return temp;
        }
     
        public Node Get(int index)
        {
            if (index < 0 || index >= length) return null;
            Node temp;
            if (index <= length / 2)
            {
                temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
            }
            else
            {
                temp = tail;
                for (int i = length - 1; i > index; i--)
                {
                    temp = temp.prev;
                }
            }
            return temp;
        }
        public bool Set(int index, int value)
        {
            Node temp = Get(index);
            if (temp == null) return false;
            temp.value = value;
            return true;
        }
        
        public bool Insert(int index, int value)
        {
            if (index < 0 || index > length) return false;
            if (index == 0) { Prepend(value); return true; }
            if (index == length) { Append(value); return true; }
            Node before = Get(index - 1);
            Node after = before.next;
            Node newNode = new Node(value);
            before.next = newNode;
            newNode.prev = before;
            newNode.next = after;
            after.prev = newNode;
            length++;
            return true;
        }
     
        public Node Remove(int index)
        {
            if (index < 0 || index >= length) return null;
            if (index == 0) return RemoveFirst();
            if (index == length - 1) return RemoveLast();
            Node temp = Get(index);
            Node before = temp.prev;
            Node after = temp.next;
            before.next = after;
            after.prev = before;
            temp.next = null;
            temp.prev = null;
            length--;
            return temp;
        }
       
        public bool IsPalindrome()
        {
            if (length == 0 || length == 1) return true;
            Node before = head;
            Node after = tail;
            for (int i = 0; i < length / 2; i++)
            {
                if (before.value != after.value) return false;
                before = before.next;
                after = after.prev;
            }
            return true;
        }
        
        public void Reverse()
        {
            if (length == 0 || length == 1) return;
            Node current = head;
            Node temp;
            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }
            temp = head;
            head = tail;
            tail = temp;
        }

        //I was thinking about just using while loops that way 
        //I don't have to worry if there were ever a large amount of duplicates, they will all be taken care of

        public void AnyDuplicates()
        {
             Node current = head;
            if(current == null) return;
           while (current != null && current.next != null)
            {
                while(current.value == current.next.value)
                {
                    Console.WriteLine("Duplicate found: " + current.value);
                    Remove(current.next.value);
                }
                current = current.next;
            }
            
        }

        public void BinaryToDecimal()
        {
            int finalTotal = 0;
            for(Node i =head; i != null; i = i.next)
            {
                finalTotal = (finalTotal * 2) + i.value;
            }
            Console.WriteLine("Decimal value: " + finalTotal);
        }
        //I just created a list just to store the values in the order they were added,
        //then I just printed them out at the end.
        public void DecimalToBinary()
        {
            if (length == 0) return;
            int decimalValue = 0;
            DoublyLinkedList values = new DoublyLinkedList(decimalValue);
            Node current = head;
            while (current != null)
            {
                decimalValue = (decimalValue % 2);
                values.Prepend(decimalValue);
                current = current.next;
            }
          
            
            Console.WriteLine("Binary values: " + string.Join(", ", values));
        }
        //I figured I would set a temporary node just to make it easier to
        //go through the entire list then swap head and tail afterwards
        //O(n)
        public void ReverseList()
        {
            if (head == null) return;
            Node current = head;
            while(current != null)
            {
                Node temp = current.next;
                current.next = current.prev;
                current.prev = current.next;
                current = temp;
            }
            head = tail;
            tail = head;

        }
        //I was thinking of sorting them through the dummy nodes then remove the dummy nodes once the loop had finished
        //O(n)

        public void PartitionList(int x)
        {
            Node dummyNode1 = new Node(0);
            Node dummyNode2 = new Node(0);

            Node lessTail = dummyNode1;
            Node greaterTail = dummyNode2;
            Node current = head;
            while(current != null)
            {
                Node next = current.next;
                if(current.value < x)
                {
                    lessTail.next = current;
                    current.prev = lessTail;
                    lessTail = current;
                }
                else
                {
                    greaterTail.next = current;
                    current.prev = greaterTail;
                    greaterTail = current;
                }
                current = next;
            }
            Node lessHead = dummyNode1.next;
            Node greaterHead = dummyNode2.next;

            lessTail.next = greaterHead;

            if (greaterHead != null)
            {
                greaterHead.prev = lessTail;
            }

            head = lessHead;

            if (head != null)
            {
                head.prev = null;
            }

        }
    }
    

}
