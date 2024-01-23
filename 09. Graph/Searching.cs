using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Graph
{
	internal class Searching
	{
		// <깊이 우선 탐색 (Depth-First Search)>
		// 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
		// 분기의 탐색을 마쳤을 때 다음 분기를 탐색
		// 스택을 통해 구현 -- 이게 중요하다
		public static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
		{
			visited = new bool[graph.GetLength(0)];
			parents = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parents[i] = -1;
			}

			// 이 위는 값 세팅

			SearchNode(graph, start, visited, parents);
		}

		private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] parents)
		{
			visited[start] = true;// 방문표시해주고
			for (int i = 0; i < graph.GetLength(0); i++)//전부 돌아본다. 끝
			{
				if (graph[start, i] &&      // 연결되어 있는 정점이며,
					!visited[i])            // 방문한적 없는 정점
				{
					parents[i] = start; // 어떤 경로로 탐색됐는지만 알아보려고 넣은값 페런츠
					SearchNode(graph, i, visited, parents);
				}
			}
		}

		// <너비 우선 탐색 (Breadth-First Search)>
		// 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
		// 다음 깊이의 분기들을 탐색
		// 큐를 통해 탐색

		// DFS, BFS 뭐가더 좋은가요? 그런거 없다
		public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents/*어느 정점에 의해 탐색되는지*/)
		{
			visited = new bool[graph.GetLength(0)];
			parents = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parents[i] = -1;
			}
			visited[start] = true;

			Queue<int> bfsQueue = new Queue<int>();

			bfsQueue.Enqueue(start);
			while (bfsQueue.Count > 0)
			{
				int next = bfsQueue.Dequeue(); // 그 정점이 탐색해야하는 정점.

				for (int i = 0; i < graph.GetLength(0); i++)
				{
					if (graph[next, i] &&       // 연결되어 있는 정점이며,
						!visited[i])            // 방문한적 없는 정점
					{
						visited[i] = true;
						parents[i] = next;
						bfsQueue.Enqueue(i);
						// 거의 유사하지만 큐를 쓴다는 점, 바로 써치노드하는식이 아니라
						// 큐에 담아놓고 지나간다는 점이 다름
						// 무조건 최단경로가 나온다는 장점
					}
				}
			}
		}
	}
}
