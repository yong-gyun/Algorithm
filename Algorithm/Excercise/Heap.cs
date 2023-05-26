using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    public class Heap
    {
        int[] _heap;

        public Heap(int[] array)
        {
            _heap = array;
        }

        public int GetChildFromLeft(int idx)
        {
            int value = _heap[(2 * idx) + 1];
            return value;
        }

        public int GetChldFromRight(int idx)
        {
            int value = _heap[(2 * idx) + 2];
            return value;
        }

        public int GetParentByNode(int idx)
        {
            int value = _heap[(idx - 1) / 2];
            return value;
        }

        public void AddNode(int value)
        {
            int[] tmp = new int[_heap.Length + 1];


        }
    }
}
