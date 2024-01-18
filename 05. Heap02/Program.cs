namespace _05._Heap02
{
	public class Problem4
	{
		public struct Meeting
		{
			public string name;
			public int start;
			public int end;

			public Meeting(string name, int start, int end)
			{
				this.name = name;
				this.start = start;
				this.end = end;
			}
		}

		static void Main()
		{
			List<Meeting> meetings = new List<Meeting>();

			meetings.Add(new Meeting("A", 0, 40));
			meetings.Add(new Meeting("B", 15, 30));
			meetings.Add(new Meeting("C", 5, 10));
			meetings.Add(new Meeting("D", 20, 40));
			meetings.Add(new Meeting("E", 1, 5));

			PriorityQueue<Meeting, int> remainMeeting = new PriorityQueue<Meeting, int>();
			foreach (Meeting meeting in meetings)
			{
				remainMeeting.Enqueue(meeting, meeting.start);
			}

			PriorityQueue<Meeting, int> doMeeting = new PriorityQueue<Meeting, int>();
			while (remainMeeting.Count > 0)
			{
				Meeting nextStartMeeting = remainMeeting.Dequeue();
				if (doMeeting.Count == 0)
				{
					Console.WriteLine($"{nextStartMeeting.name}회의를 열기에 비어있는 회의실이 없습니다.");
					doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
					Console.WriteLine($"회의실을 추가로 확보하여 {doMeeting.Count}개의 회의실을 사용합니다.");
				}
				else
				{
					Meeting nextEndMeeting = doMeeting.Peek();
					if (nextEndMeeting.end <= nextStartMeeting.start)
					{
						Console.WriteLine($"{nextEndMeeting.name}이 끝난 회의실에 {nextStartMeeting.name}이 시작합니다.");
						doMeeting.Dequeue();
						doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
					}
					else
					{
						Console.WriteLine($"{nextStartMeeting.name}회의를 열기에 비어있는 회의실이 없습니다.");
						doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
						Console.WriteLine($"회의실을 추가로 확보하여 {doMeeting.Count}개의 회의실을 사용합니다.");
					}
				}
			}

			Console.WriteLine($"필요한 회의실의 갯수는 {doMeeting.Count}개 입니다");
		}
	}

}
