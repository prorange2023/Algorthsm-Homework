namespace _08._Sorting
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			int count = 8;

			List<int> selectionlist = new List<int>();

			List<int> insertList = new List<int>();

			List<int> bubblelist = new List<int>();

			List<int> mergeList = new List<int>();

			List<int> quickList = new List<int>();

			List<int> introList = new List<int>();



			Console.WriteLine("랜덤데이터 : ");

			for (int i = 0; i < count; i++)
			{
				int rand = random.Next(0, 100);
				Console.Write($"{rand,3} ");

				selectionlist.Add(rand);
				insertList.Add(rand);
				bubblelist.Add(rand);
				mergeList.Add(rand);
				quickList.Add(rand);
				introList.Add(rand);


			}

			Console.WriteLine();

			Console.WriteLine("선택정렬 결과 : ");

			Sorting.SelectionSort(selectionlist, 0, selectionlist.Count - 1);

			foreach (int value in selectionlist)
			{
				Console.Write($"{value,3}");
			}





			Console.WriteLine();

			Console.WriteLine("삽입정렬 결과 : ");

			Sorting.InsertSort(insertList, 0, insertList.Count - 1);

			foreach (int value in insertList)
			{
				Console.Write($"{value,3}");
			}




			Console.WriteLine();

			Console.WriteLine("버블정렬 결과 : ");

			Sorting.BubbleSort(bubblelist, 0, bubblelist.Count - 1);

			foreach (int value in bubblelist)
			{
				Console.Write($"{value,3}");
			}






			Console.WriteLine();

			Console.WriteLine("병합정렬 결과 : ");

			Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);

			foreach (int value in mergeList)
			{
				Console.Write($"{value,3}");
			}





			//Console.WriteLine();

			//Console.WriteLine("퀵정렬 결과 : ");

			//Sorting.QuickSort(quickList, 0, quickList.Count - 1);

			//foreach (int value in quickList)
			//{
			//	Console.Write($"{value,3}");
			//}



			//Console.WriteLine();

			//Console.WriteLine("인트로 정렬 결과 : ");

			//introList.Sort();

			//foreach (int value in introList)
			//{
			//	Console.Write($"{value,3}");
			//}


		}
	}
}
