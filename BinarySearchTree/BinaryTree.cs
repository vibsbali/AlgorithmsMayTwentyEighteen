using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BinarySearchTreeTests")]
namespace BinarySearchTree
{
   public class BinaryTree<T> : IEnumerable<T>
      where T : IComparable<T>
   {
      internal Node<T> Head { get; set; }
      public int Count { get; private set; }
      public void Add(T item)
      {
         var nodeToAdd = new Node<T>(item);

         if (Head == null)
         {
            Head = nodeToAdd;
         }
         else
         {
            var current = Head;
            while (current != null)
            {
               if (item.CompareTo(current.Value) < 0)
               {
                  if (current.HasLeft)
                  {
                     current = current.Left;

                  }
                  else
                  {
                     current.Left = nodeToAdd;
                     break;
                  }
               }
               else
               {
                  if (current.HasRight)
                  {
                     current = current.Right;
                  }
                  else
                  {
                     current.Right = nodeToAdd;
                     break;
                  }
               }
            }
         }

         ++Count;
      }

      public bool Contains(T item)
      {
         var current = Head;
         while (current != null)
         {
            if (current.Value.Equals(item))
            {
               return true;
            }

            if (item.CompareTo(current.Value) < 0)
            {
               current = current.Left;
            }
            else
            {
               current = current.Right;
            }
         }

         return false;
      }

      public bool Remove(T item)
      {
         var current = Head;
         Node<T> parent = null;

         while (current != null)
         {
            if (item.CompareTo(current.Value) < 0)
            {
               parent = current;
               current = current.Left;
            }
            else if (item.CompareTo(current.Value) > 0)
            {
               parent = current;
               current = current.Right;
            }
            //Match Found
            else if (current.Value.Equals(item))
            {
               //Is it tail node i.e. no left or right child
               if (!current.HasLeft && !current.HasLeft)
               {
                  //Head node being removed 
                  if (parent == null)
                  {
                     Head = null;
                     Count = 0;
                     return true;
                  }

                  if (IsLeftOfParent(parent, current))
                  {
                     parent.Left = null;
                  }
                  else
                  {
                     parent.Right = null;
                  }
               }
               //Item to remove has a left child but no right child
               else if (!current.HasRight)
               {
                  //Head node being removed 
                  if (parent == null)
                  {
                     Head = default(Node<T>);
                     Head = current;
                  }
                  else
                  {
                     if (IsLeftOfParent(parent, current))
                     {
                        parent.Left = current.Left;
                     }
                     else
                     {
                        parent.Right = current.Left;
                     }
                  }
               }
               //Item to remove has a right child
               else if (current.HasRight)
               {
                  //if node to remove has a right child which doesn't have left child
                  if (!current.Right.HasLeft)
                  {
                     //If head is being removed
                     if (parent == null)
                     {
                        current.Right.Left = Head.Left;
                        Head = current.Right;
                     }
                     else
                     {
                        if (IsLeftOfParent(parent, current))
                        {
                           parent.Left = current.Right;
                           //Update Left Pointer
                           parent.Left.Left = current.Left;
                        }
                        else
                        {
                           parent.Right = current.Right;
                           //Update Left Pointer
                           parent.Right.Left = current.Left;
                        }
                     }
                  }

                  //Find the left most child of node's right child
                  else if (current.Right.HasLeft)
                  {
                     var currentLeftParent = current.Right;
                     var currentLeftMost = current.Right.Left;
                     while (currentLeftMost.HasLeft)
                     {
                        currentLeftParent = currentLeftMost;
                        currentLeftMost = currentLeftMost.Left;
                     }

                     if (parent == null)
                     {
                        currentLeftMost.Left = Head.Left;
                        currentLeftMost.Right = Head.Right;
                        Head = currentLeftMost;
                     }
                     else
                     {
                        if (IsLeftOfParent(parent, current))
                        {
                           parent.Left = currentLeftMost;
                           currentLeftMost.Left = current.Left;
                           currentLeftMost.Right = current.Right;
                        }
                        else
                        {
                           parent.Right = currentLeftMost;
                           currentLeftMost.Left = current.Left;
                           currentLeftMost.Right = current.Right;
                        }
                     }

                     //remove the left pointer of last left child which is currently going to 
                     //be placed
                     currentLeftParent.Left = null;
                  }
               }
               else
               {
                  throw new ApplicationException("Undertermined State");
               }

               --Count;
               return true;
            }
         }

         return false;
      }

      private bool IsLeftOfParent(Node<T> parent, Node<T> current)
      {
         return current.Value.CompareTo(parent.Value) < 0;
      }

      public IEnumerator<T> GetEnumerator()
      {
         return BreadthFirstSearch();
      }

      private IEnumerator<T> BreadthFirstSearch()
      {
         var auxQueue = new Queue<Node<T>>();
         var storageQueue = new Queue<T>();

         auxQueue.Enqueue(Head);
         while (auxQueue.Count != 0)
         {
            var itemToEnqueue = auxQueue.Dequeue();
            storageQueue.Enqueue(itemToEnqueue.Value);
            if (itemToEnqueue.HasLeft)
            {
               auxQueue.Enqueue(itemToEnqueue.Left);
            }

            if (itemToEnqueue.HasRight)
            {
               auxQueue.Enqueue(itemToEnqueue.Right);
            }
         }

         return storageQueue.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}