using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    public class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;
        public MyLinkedListNode<T> Tail = null;
        public int Count;

        public MyLinkedListNode<T> AddFirst(T value)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>();
            node.Data = value;

            if (Head != null)
            {
                Head.Prev = node;
                node.Next = Head;
            }

            Head = node;
            Count++;

            return node;
        }

        //O(1)
        public MyLinkedListNode<T> AddLast(T value)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>();
            node.Data = value;

            //만약에 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 곧 Head이다.
            if (Head == null)
                Head = node;

            //기존에 마지막 방과 새로 추가되는 방을 연결해준다.
            if (Tail != null)
            {
                node.Prev = Tail;
                Tail.Next = node;
            }

            //새로 추가되는 방을 마지막 방으로 바꿈.
            Tail = node;
            Count++;

            return node;
        }

        //O(1)
        public void Remove(MyLinkedListNode<T> node)
        {
            //기존의 첫번째 방의 다음 방을 헤드로 바꿈.
            if (Head == node)
                Head = Head.Next;

            //기존의 마지막 방의 이전 방을 마지막 방으로 인정한다.
            if (Tail == node)
                Tail = Tail.Prev;

            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;

            Count--;
        }
    }
}
