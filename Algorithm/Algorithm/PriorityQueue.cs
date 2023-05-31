using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T data)
        {
            //힙의 맨 끝에 새로운 데이터를 삽입한다
            _heap.Add(data);

            int now = _heap.Count - 1;

            //도장깨기를 시작

            while(now > 0)
            {
                //도장깨기를 시도
                int next = (now - 1) / 2;

                if (_heap[now].CompareTo(_heap[next]) < 0)       //실패
                    break;

                //두 값을 교체한다
                T tmp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = tmp;

                //검사 위치를 이동한다.
                now = next;
            }
        }

        public T Pop()
        {
            //반환할 데이터를 따로 저장
            T ret = _heap[0];

            //마지막 데이터를 루트로 이동한다.
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            //역으로 내려가는 도장깨기 시작
            int now = 0;

            while (true)
            {
                int left = (now * 2) + 1;
                int right = (now * 2) + 2;

                int next = now;

                //왼쪽값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                //오른값이 현재값보다 크면, 오른쪽으로 이동
                if(right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                //왼쪽/오른쪽 모두 현재 값보다 작으면 종료
                if(now == next)
                    break;

                //두 값을 교체
                T tmp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = tmp;

                //검사 위치를 이동한다.
                now = next;
            }

            return ret;
        }

        public int Count { get { return _heap.Count; } }
    }
}
