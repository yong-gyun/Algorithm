using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];
        public int Count { get; private set; } = 0;    //실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } //예약된 데이터 개수

        //시간 복잡도 O(1) 예외 케이스 : 이사 비용은 무시한다.
        public void Add(T item)
        {
            //1. 공간이 충분히 남아있는지 확인한다.

            if (Count >= Capacity)
            {
                //공간을 늘려서 확보한다.
                T[] newArray = new T[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
                }

                _data = newArray;
            }

            //2. 공간에다가 데이터를 넣어준다.
            _data[Count] = item;
            Count++;
        }


        //인덱서 문법 / 시간 복잡도 O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        //O(N) / 최악의 상황은 index가 0에서 부터 N까지 돌아가는 것이므로 시간 복잡도는 O(N)
        public void RemoveAt(int index)
        {
            //101 102 103 104 105

            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            //Default(T) -> T 에 int가 오면 0으로 class가 오면 null로 바꿔줌.
            _data[Count - 1] = default(T);
            Count--;
        }

        //Big-O 표기법에서 시간 복잡도는 항상 최악의 상황을 생각해야한다.

        public bool Remove(T item)
        {
            bool result = false;

            for (int i = 0; i < Count; i++)
            {
                result = _data[i].Equals(item);

                if (result)
                {
                    RemoveAt(i);
                    break;
                }
            }

            return result;
        }
    }
}
