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

        public void Run_Dijkstra(int start)
        {
            bool[] visited = new bool[6];   //이젠 찾았다가 아닌 방문했다가 중요함
            int[] distance = new int[6];    //정점에서 정점으로 이동하는데에 필요한 가중치를 기입
            
        }
    }
}
