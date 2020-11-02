using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    class DebthFIrstSearch
    {
         
    }
    class Node<T>
    {
        List<Node<T>> Children = new List<Node<T>>();
        T Value;
        Node(T value)
        {
            Value = value;
        }
        Node(T[] values)
        {
            if (values.Length >= 1)
            {
                Value = values[0];
            }
            for (int i = 1; i < values.Length; i++)
            {
                Children.Add(new Node<T>(values[i]));
            }

        }
        Node(T value, List<Node<T>> values)
        {
            Value = value;
            Children = values;
        }

    }
}
