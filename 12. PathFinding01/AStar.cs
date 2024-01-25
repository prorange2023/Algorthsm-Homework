using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._PathFinding01
{

	//
	internal class AStar
	{

		const int CostStraight = 10;
		const int CostDiagonal = 14;

		static Point[] direction =
		{
			new Point(0,+1), //상
			new Point(0,-1), //하
			new Point(-1,0), //좌
			new Point(+1,0), //우
			new Point(+1,+1), // 우상
			new Point(+1,-1), // 우하
			new Point(-1,+1), // 좌상
			new Point(-1,-1), // 좌하
		};
		public static bool/*탐색이 성공하면 True 아니면 false*/ PathFinding(bool[,] tileMap/*타일맵을 요구하고*/, Point start/*시작지점지정하고*/, Point end/*끝지점지정하면*/, out List<Point> path/*경로가 나옴*/)
		{
			int ySize = tileMap.GetLength(0);
			int xSize = tileMap.GetLength(1);

			ASNode[,] nodes = new ASNode[ySize, xSize];
			bool[,] visited = new bool[ySize, xSize]; // 정점이 탐색됐는지 안됐는지 알아보는곳
			PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>(); // f가 작은 순서대로 뽑아줄 우선순위큐

			// 0. 시작 정점을 생성하여 추가

			ASNode startNode = new ASNode(start, new Point(), 0/*이게 g*/, Heruistic(end, start));
			nodes[startNode.pos.y, startNode.pos.x] = startNode;
			nextPointPQ.Enqueue(startNode, startNode.f); // f가 가장 작은 정점부터 꺼내지도록 기준 설정해주고 우선순위큐에 집어넣기.


			while (nextPointPQ.Count > 0)
			{
				// 지금 있는 정점들 중에서 가장 f가 낮은 정점부터 수행하도록
				// 하나씩 꺼내서 탐색하는 상황
				// 1. 다음으로 탐색할 정점 꺼내기 : f가 가장 낮은 정점
				ASNode nextNode = nextPointPQ.Dequeue();

				// 2. 탐색할 정점은 방문표시
				visited[nextNode.pos.y, nextNode.pos.x] = true;// 방문표시

				// 3. 계산 전에 탐색할 정점이 도착지인 경우 
				// 도착했다고 판단해서 경로를 반환
				if (nextNode.pos.x == end.x && nextNode.pos.y == end.y) // 그 정점이 도착지면
				{
					path = new List<Point>();
					Point point = end;

					while ((point.x == start.x && point.y == start.y) == false) //시작지가 아니면반복
					{
						path.Add(point); // 지점 집어넣고
						point = nodes[point.y, point.x].parent;// 또 앞순으로
					}
					path.Add(start);
					path.Reverse(); // 넣은 순서 반전(거꾸로넣었으니까)
					return true;

				}


				// 4. 탐색한 정점 주변의 정점의 점수 계산(대각선 여부에 따라 4개하거나 8개하거나)
				for (int i = 0; i < direction.Length; i++)
				{
					int x = nextNode.pos.x + direction[i].x;
					int y = nextNode.pos.y + direction[i].y;

					// 4-1 점수계산을 하면 안되는 경우 제외
					// 맵을 벗어나는 경우
					if (x < 0 || x >= xSize || y < 0 || y >= ySize)
					{
						continue;
					}
					// 또는 탐색할 수 없는 정점인 경우
					else if (tileMap[y, x] == false)
					{
						continue;
					}
					// 이미 탐색한 정점일 경우
					else if (visited[y, x])
					{
						continue;
					}

					// 대각선으로 이동이 불가능 지역인 경우
					else if(i>=4 && tileMap[y, nextNode.pos.x] == false &&/*둘중 하나라도 막혀있으면 못가게 하고 싶으면 || 입력*/ tileMap[nextNode.pos.y, x] == false)
					{
						continue;
					}
					// 4-2 점수를 계산한 정점 만들기
					int g = nextNode.g + i < 4? CostStraight : CostDiagonal; // 삼항연산자 조건이 맞으면 CostStraight 아니면 Costdiagonal
					int h = Heruistic(new Point(x, y), end);
					ASNode newNode = new ASNode(new Point(x, y), nextNode.pos, g, h);

					// 4-3 정점이 갱신이 필요한 경우만 넣는다.
					if (nodes[y, x] == null || // 점수계산을 하지 않은 정점이거나
						nodes[y, x].f > newNode.f) // 새로운 정점의 f 가중치가 더 낮은경우
					{
						nodes[y, x] = newNode;
						nextPointPQ.Enqueue(newNode, newNode.f); // 정점갱신
					}


				}

			}
			path = null;
			return false;
			
		}

		public static int Heruistic(Point start, Point end) //  휴리스틱에 따라서 탐색 속도가 달라짐
		{
			int xSize = Math.Abs(start.x - end.x); // 가로로 가야하는 횟수
			int ySize = Math.Abs(start.y - end.y); // 세로로 가야하는 횟수

			//맨허튼 거리 : 직선을 통해 이동하는 거리
			//return CostStraight * (xSize + ySize);

			//유클리드 거리 : 대각선도 포함해 이동하는 직선거리
			//return CostStraight*(int)Math.Sqrt(xSize*xSize +ySize * ySize); //이러면 루트 때문에느림

			// 타일맵 유클리드거리 : 직선과 대각선을 통해 이동하는 거리
			// 대각선의 갯수는 더 숫자가 작은 축의 갯수만큼 가능한것을 이용
			// 직선은 직선 숫자에서 대각선 하고 남은거만큼
			int straightCount = Math.Abs(xSize - ySize); // 직선갯수
			int diagonalCount = Math.Max(xSize, ySize) - straightCount;

			return CostStraight * straightCount + CostDiagonal * diagonalCount;

			// 다익스트라
			//return 1;

		}

		//fgh 값을 담기위한 자료형
		public class ASNode // 클래스인 이유? 안탐색한건 null취급하려고 클래스로. 데이터가 중요한거라면 구조체가 더 나을수도?
		{

			public Point pos;// 정점의 위치
			public Point parent; // 이 정점을 탐색한 정점의 위치


			public int f; // 총 예상거리 f = g +h
			public int g; // 지금까지 이동한 거리
			public int h; // 휴리스틱, 앞으로 예상되는 가중치, 목표까지 추정경로 가중치(장애물 고려 안함)


			public ASNode(Point pos, Point parent, int g, int h)
			{
				this.pos = pos;
				this.parent = parent;
				this.f = g + h;
				this.g = g;
				this.h = h;
			}
		}
	}


	public struct Point
	{
		public int x;
		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;

		}
	}
}
