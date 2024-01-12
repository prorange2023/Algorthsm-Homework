using System.Collections.Generic;

namespace List01
{
	internal class Program
	{
		//		<실습>

		//사용자에게 숫자를 입력 받아서
		//0부터 숫자까지 가지는 리스트 만들기
		//0 요소를 제거
		//리스트가 가지는 모든 요소들을 출력해주는 반복문 작성

		/////////////////////////////////////////////////

		

		/////////////////////////////////////////////////

		



		public void MakeList(int input, List<int> list)
		{
			for (int i = 0; i < input; i++)
			{
				list.Add(i);
			}
		}
		void PrintList(List<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
			}
		}

		public int Input()
		{
			Console.WriteLine("숫자를 입력하세요");
			int input = int.Parse(Console.ReadLine());
			return input;
		}
		

		static void Main(string[] args)
		{
			List<int> list = new List<int>();
			Program program = new Program();
			
			program.MakeList(program.Input(), list);
			
			list.RemoveAt(0);

			program.PrintList(list);
			

		}
	}
}
