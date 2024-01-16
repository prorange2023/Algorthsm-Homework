namespace _03._stack_queue01
{
	internal class Program
	{

		//		<괄호 검사기를 구현하자>
		//괄호 : 괄호가 바르게 짝지어졌다는 것은 열렸으면 짝지어서 닫혀야 한다는 뜻

		//텍스트를 입력으로 받아서 괄호가 유효한지 판단하는 함수
		//bool IsOk(string text) { }

		//		검사할 괄호 : [], {}, ()

		//		예시 : () 완성, (() 미완성, [) 미완성, [[(){}]] 완성




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
