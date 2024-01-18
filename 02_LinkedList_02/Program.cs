using System;
using System.Collections.Generic;

namespace _02_LinkedList_02
{
	internal class Program
	{
		//요세푸스 문제는 다음과 같다.
		//1번부터 N번까지 N명의 사람이 원을 이루면서 앉아있고, 양의 정수 K(≤ N)가 주어진다.이제 순서대로 K번째 사람을 제거한다.
		//한 사람이 제거되면 남은 사람들로 이루어진 원을 따라 이 과정을 계속해 나간다. 이 과정은 N명의 사람이 모두 제거될 때까지 계속된다.
		//원에서 사람들이 제거되는 순서를 (N, K)-요세푸스 순열이라고 한다.예를 들어 (7, 3)-요세푸스 순열은<3, 6, 2, 7, 5, 1, 4>이다.
		//N과 K가 주어지면 (N, K)-요세푸스 순열을 구하는 프로그램을 작성하시오.
		static void Main()
		{
			LinkedList<int> linkedList = new LinkedList<int>();

			int n = 7;
			int k = 3;

			for (int i = 0; i < n; i++)
			{
				linkedList.AddLast(i);
			}

			while (linkedList.Count > 0) ;
			{
				for (int i = 0; i < k; i++)
				{
					LinkedListNode<int> node = linkedList.First;
					if (i == k)
					{//빠지기
						linkedList.Remove(node);
						Console.WriteLine($"{node.Value}");
					}
					else
					{//뒤로 돌아가기
						linkedList.Remove(node);
						linkedList.AddLast(node);
					}
				}
			}
		}
		//void Main11()
		//{
			//LinkedList<int> linkedlist = new LinkedList<int>();
			//Console.WriteLine("인원수를 입력하세요");
			//int member = int.Parse(Console.ReadLine());
			//
			//for (int i = 0; i < member; i++)
			//{
			//	linkedlist.AddLast(i+1);
			//}
			//
			//foreach (int i in linkedlist)
			//{
			//	Console.WriteLine(i);
			//}
			//
			//LinkedListNode<int> head = linkedlist.First;
			//LinkedListNode<int> tail = linkedlist.Last;
			//
			//Console.WriteLine($"{tail.Value}");
			//Console.WriteLine($"{head.Value}");
			//
			//tail.Next = head;
			//
			//if (tail.Next == null )
			//{
			//	tail.next = head;
			//}
			//else
			//{
			//
			//}
			//
			//
			//
			//Console.WriteLine("무작위 숫자를 입력하세요");
			//int deathturn = int.Parse(Console.ReadLine());
			//
			//
            //for (int i = 0; i < member; i++)
            //{
			//	for (int j = 1; j < deathturn; j++)
			//	{
			//		head = head.Next;
			//	}
			//
			//	Console.WriteLine(head.Value);
			//}



			


		//}
	}
}
