using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Graph
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
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5},
            new List<int>() { 4 },
        };

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            
            int[] parent = new int[6];    //내가 어디서부터 왔는지 추척하기 위한 배열
            int[] distance = new int[6];  //오기까지 얼마나 걸렸는지를 확인하기 위한 배열

            Queue<int> q = new Queue<int>();
            
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while(q.Count > 0)
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
    
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.BFS(0);
        }
    }
}
