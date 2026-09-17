using System;
using System.Collections.Generic;
using System.Text;
using DLLClass;
namespace NodeClass
{
    public class Node
    {
        public int value;
        public Node next;
        public Node prev;
        public Node (int val)
        {
            value = val;
        }
    }
}
