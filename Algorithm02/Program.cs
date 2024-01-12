using System.Collections.Generic;

namespace List02
{
	internal class Program
	{
		//사용자의 입력을 받아서 없는 데이터면 추가, 있던 데이터면 삭제하는 보관함
		//ex) 1, 6, 7, 8, 3 들고 있던 상황이면
		//2 입력하면 없던 경우니까 1, 6, 7, 8, 3, 2
		//7 입력하면 있던 경우니까 1, 6, 8, 3

		public int Input()
		{
			Console.WriteLine("숫자를 입력하세요");
			int input = int.Parse(Console.ReadLine());
			return input;
		}
		void SandD(List<int> list, int number)
		{
			if (list.IndexOf(number) == -1)
			{
				list.Add(number);
			}
			else
			{
				list.Remove(number);
			}
		}
		void PrintList(List<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
			}
		}
		static void Main(string[] args)
		{
			List<int> list = new List<int>();
			Program program = new Program();

			list.Add(1);
			list.Add(6);
			list.Add(7);
			list.Add(8);
			list.Add(3);

			program.SandD(list, program.Input());

			program.PrintList(list);
		}
	}
}
