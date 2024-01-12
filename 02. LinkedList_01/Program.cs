using System.Collections.Generic;

namespace _02._LinkedList_01
{
	internal class Program
	{
		//사용자의 입력으로 숫자를 입력 받아서(마이너스도 허용)
		//음수는 앞에 추가하고, 양수는 뒤에 추가하여
		//음수&양수를 반으로 나누는 연결리스트 구현
		//입력 받을 때마다 처음부터 끝까지 출력 진행
		public class Funny
		{
			public int listcount = 0;
			public LinkedList<int>? linkedlist;

			public int InputCount()
			{
				Console.WriteLine("만들 node의 수를 입력하세요");
				int count = int.Parse(Console.ReadLine());
				return count;
			}


			public void MakeLinkedList(int num)
			{
				for (int i = 0; i < num; i++)
				{
					InputNode();
					PrintValue();
				}

			}
			public void InputNode()
			{
				Console.WriteLine("정수를 입력하세요");
				int num = int.Parse(Console.ReadLine());

				int value = 0;

				if (num < 0)
				{
					linkedlist.AddFirst(num);
					listcount++;
				}
				else if (num > 0)
				{
					linkedlist.AddLast(num);
					listcount++;
				}
				else
				{
					Console.WriteLine("0은 제외하고 입력해주세요");
				}

				PrintValue();
			}

			public void PrintValue()
			{
				foreach (int value in linkedlist)
				{

					if (linkedlist == null)
					{
						Console.WriteLine("값이 비어있습니다.");
					}
					else 
					{
						Console.WriteLine($"{value}"); 
					}
					
				}
			}
		}
		static void Main(string[] args)
		{
			LinkedList<int> linkedlist = new LinkedList<int>();
			Funny funny = new Funny();
			int count = funny.InputCount();
			
			for (int i = 0; funny.listcount < count; i++)
			{
				Console.WriteLine("정수를 입력하세요");
				int num = int.Parse(Console.ReadLine());
				
				if (num < 0)
				{
					linkedlist.AddFirst(num);
					funny.listcount++;
				}
				else if (num > 0)
				{
					linkedlist.AddLast(num);
					funny.listcount++;
				}
				else
				{
					Console.WriteLine("0은 제외하고 입력해주세요");
				}
				foreach (int value in linkedlist)
				{
					Console.WriteLine($"{value}");
				}
			}
		}
	}
}
