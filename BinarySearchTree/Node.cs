using System;
using System.Reflection;

namespace BinarySearchTree
{
   public class Node<T>
      where T : IComparable<T>
   {
      public T Value { get; set; }
      public Node(T item)
      {
         Value = item;
      }

      public Node<T> Left { get; set; }
      public Node<T> Right { get; set; }

      public bool HasLeft => Left != null;
      public bool HasRight => Right != null;

   }
}
