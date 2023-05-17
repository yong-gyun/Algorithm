using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class DFS
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0},
            { 1, 0, 1, 1, 0, 0},
            { 0, 1, 0, 0, 0, 0},
            { 1, 1, 0, 0, 1, 0},
            { 0, 0, 0, 1, 0, 1},
            { 0, 0, 0, 0, 1, 0}
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3},
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4},
            new List<int>() { 3, 5},
            new List<int>() { 4 },
        };

        bool[] visited = new bool[6];

        //1) 우선 now부터 방문함
        //2) now와 연결된 정점들을 하나씩 확인해서, 아직 방문하지 않은 상태라면 방문함.

        //2차원 배열을 활용한 DFS 구현
        public void Run_DFS(int now)
        {
            Console.WriteLine($"{now}");
            visited[now] = true;    //우선 now를 방문함

            for (int next = 0; next < 6; next++)
            {
                //정점이 연결되어 있지 않으면 스킵.
                if (adj[now, next] == 0)
                    continue;

                //방문한 상태라면 스킵
                if (visited[next])
                    continue;

                Run_DFS(next);
            }
        }

        //foreach문과 List를 활용한 DFS 구현
        public void Run_DFS2(int now)
        {
            Console.WriteLine($"{now}");
            visited[now] = true;    //우선 now를 방문함

            foreach (int next in adj2[now])
            {
                if (visited[next])
                    continue;

                Run_DFS2(next);
            }
        }

        //만약 노드를 잇는 엣지가 끊어져 있으면 해당 노드는 탐색이 불가능할 것이다.
        //그런 상황을 대비해서 모든 노드를 탐색하는 함수를 만듦.
        public void SearchAll()
        {
            visited = new bool[6];

            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)      //false일시 해당 인덱스의 정점과 해당 정점과 연결된 모든 정점들을 방문함.
                    Run_DFS(now);
            }
        }
    }
}
