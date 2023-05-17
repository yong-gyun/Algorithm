using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class BFS
    {
        //2차월 배열,즉 행렬로 구현
        //그래프를 표시하는 방법 1
        //장점 : 메모리 효율성이 좋음 (new 키워드를 통해 객체를 여러개를 만들 필요가 없음)
        //단점 : 필요없는 데이터들을 (0인 데이터) 모두 들고 있어야함, 가독성이 안좋음
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0},
            { 1, 0, 1, 1, 0, 0},
            { 0, 1, 0, 0, 0, 0},
            { 1, 1, 0, 0, 1, 0},
            { 0, 0, 0, 1, 0, 1},
            { 0, 0, 0, 0, 1, 0}
        };

        public void Run_BFS(int start)
        {
            bool[] found = new bool[6];

            int[] parent = new int[6];    //내가 어디서부터 왔는지 추척하기 위한 배열
            int[] distance = new int[6];  //오기까지 얼마나 걸렸는지를 확인하기 위한 배열

            Queue<int> q = new Queue<int>();

            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    //인접하지 않았으면 스킵
                    if (adj[now, next] == 0)
                        continue;

                    //이미 방문한 애라면 스킵
                    if (found[next] == true)
                        continue;

                    q.Enqueue(next);
                    found[next] = true;
                    //1번의 부모는 0번이됌
                    parent[next] = now;
                    //이전까지 이동한 거리 + 1
                    distance[next] = distance[now] + 1;
                }
            }
        }
    }
}
