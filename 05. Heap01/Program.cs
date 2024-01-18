namespace _05._Heap01
{
	public class Problem3
	{
		public struct Homework
		{
			public string name;
			public int deadline;
			public int score;

			public Homework(string name, int deadline, int score)
			{
				this.name = name;
				this.deadline = deadline;
				this.score = score;
			}
		}

		static void Main()
		{
			int sumScore = 0;
			List<Homework> homeworks = new List<Homework>();

			homeworks.Add(new Homework("A", 4, 60));
			homeworks.Add(new Homework("B", 4, 40));
			homeworks.Add(new Homework("C", 1, 20));
			homeworks.Add(new Homework("D", 2, 50));
			homeworks.Add(new Homework("E", 3, 30));
			homeworks.Add(new Homework("F", 4, 10));
			homeworks.Add(new Homework("G", 6, 5));

			// 마감일이 많이 남은 순서대로 꺼내기 위해 내림차순 우선순위 큐에 추가
			PriorityQueue<Homework, int> remainPQ = new PriorityQueue<Homework, int>();
			foreach (Homework work in homeworks)
			{
				remainPQ.Enqueue(work, -work.deadline);
			}

			// 뒤에서부터 가장 높은 점수 순서대로 처리
			PriorityQueue<Homework, int> scorePQ = new PriorityQueue<Homework, int>();
			for (int day = remainPQ.Peek().deadline; day >= 1; day--)
			{
				while (remainPQ.Count > 0 && remainPQ.Peek().deadline == day)
				{
					Homework homework = remainPQ.Dequeue();
					scorePQ.Enqueue(homework, -homework.score);
				}

				if (scorePQ.Count > 0)
				{
					Homework target = scorePQ.Dequeue();
					sumScore += target.score;
					Console.WriteLine($"{target.name} 과제를 {day} 일차에 수행해야 한다. 총점 : {sumScore}");
				}

				if (remainPQ.Count == 0)
					break;
			}
		}

		
	}

}
