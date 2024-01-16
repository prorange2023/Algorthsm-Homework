namespace _03._stack_queue02
{
	internal class Program
	{
		public const int WorkTime = 8;
		public static int[] ProcessJob(int[] jobList)
		{
			Queue<int> queue = new Queue<int>();
			int remainTime = 8;
			int day = 1;
			List<int> days = new List<int>();

			for (int i = 0; i < jobList.Length; i++)
			{
				queue.Enqueue(jobList[i]);
			}

			while (queue.Count > 0) ;
			{
				int workTime = queue.Dequeue();

				while (true)
				{
					if (workTime < remainTime)
					{
						remainTime -= workTime;

						// 작업완료
						days.Add(day);
						break;
					}
					else
					{
						workTime -= remainTime;
						// 다음날로 연장
						day++;
						remainTime = 8;
					}
				}

			}

			return days.ToArray();

		}



		static void Main(string[] args)
		{

			int[] result = ProcessJob(new int[] { 4, 4, 12, 10, 2, 10 });

			foreach (int day in result)
			{
				Console.WriteLine(day);
			}


		}
	}
}
