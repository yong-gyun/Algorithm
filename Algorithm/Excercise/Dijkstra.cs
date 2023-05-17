using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Dijkstra
    {
        //정점들이 연결 되어 있는지만 판단 할것이 아닌 가중치 또한 기입해줘야함.
        //연결되어 있지 않은 정점들은 -1로 표시함.
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1},
            { 15, -1, 5, 10, -1, -1},
            { -1, 1, -1, -1, -1, -1},
            { 1, 1, -1, -1, 5, -1},
            { -1, -1, -1, 5, -1, 5},
            { -1, -1, -1, -1, 5, -1}
        };

        public void Excercise_Dijkstra(int start = 0)
        {

        }

        public void Run_Dijkstra(int start)
        {
            bool[] visited = new bool[6];       //이젠 찾았다가 아닌 방문했다가 중요함
            int[] distance = new int[6];        //정점에서 정점으로 이동하는데에 필요한 가중치를 기입
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while(true)
            {
                //제일 좋은 후보를 찾는다 (가장 가까이에 있는 후보)

                //가장 유력한 후보의 거리와 번호를 저장한다.
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    //이미 방문한 정점은 스킵

                    if (visited[i])
                        continue;

                    //아직 발견(예약)된 적이 없거나 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;

                    //여태껏 발견한 가장 좋은 후보라는 의미니까 정보를 갱신
                    closest = distance[i];
                    now = i;
                }

                //다음 후보가 하나도 없다(모든 정점을 찾았거나 연결이 단절되어 있는 경우) -> 종료
                if (now == -1)
                    break;

                //제일 좋은 후보를 찾았으니까 방문한다
                visited[now] = true;

                //방문한 정점과 인접한 정점들을 조사해서,
                //상황에 따라 발견한 최단 거리를 갱신한다.

                for (int next = 0; next < 6; next++)
                {
                    //연결되지 않은 정점은 스킵
                    if (adj[now, next] == -1)
                        continue;

                    //이미 방문한 정점은 스킵
                    //ex) 1번에서 0번을 조회해보니 연결은 되어있긴한데 이미 방문했던적이 있으니 뒤로 돌아갈 필요가 없음.
                    if (visited[next])
                        continue;

                    //새로 조사된 정점의 최단거리를 계산한다.
                    int nextDist = distance[now] + adj[now, next];

                    //만약에 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면, 정보를 갱신

                    if(nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }
}