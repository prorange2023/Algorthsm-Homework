using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._Sorting
{
	internal class Sorting
	{
		public static void SelectionSort(IList<int> list, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				int minIndex = i;
				for (int j = i+1; j <= end; j++)
				{
					if (list[j] < list[minIndex])
					{
						minIndex = j;
					}
				}
				Swap(list, i, minIndex);
			}
		}

		public static void InsertSort(IList<int> list, int start, int end)
		{
			for(int i = start; i < end; ++i)
			{
				for( int j = i;j >= start; j--)
				{
					if (list[j] > list[j+1])
					{
						Swap(list, j, j+1);
					}
				}
			}
		}


		public static void BubbleSort(IList<int> list, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				for (int j = 0; j < end-start; j++)
				{
					if (list[j] > list[j + 1])
					{
						Swap(list, j, j+1);
					}
				}
			}
		}

		public static void MergeSort(IList<int> list, int start, int end)
		{
			if (start == end)
			{
				return;
			}

			int middle = (start + end) / 2;
			MergeSort(list, start, middle);
			MergeSort(list, middle+1, end);
			Merge(list, start, middle, end);

		}

		public static void Merge(IList<int> list, int start, int middle,int end)
		{
			List<int> sortedList = new List<int>();
			int leftIndex = start;
			int rightIndex = middle+1;

			while (leftIndex <=middle && rightIndex <=end)
			{
				if (list[leftIndex] < list[rightIndex])
				{
					sortedList.Add(list[leftIndex++]);
				}
				else
				{
					sortedList.Add(list[rightIndex++]);
				}
			}

			if (leftIndex>middle)
			{
				for (int i = rightIndex; i <= end; i++) // 왜 이하인지 생각해라
				{
					sortedList.Add(list[i]);
				}
			}
			else
			{
				for(int i = leftIndex; i <= middle;i++)// 왜 이하인지 생각해라
				{
					sortedList.Add(list[i]);
				}
			}

			for(int i = 0;i < sortedList.Count;i++)
			{
				list[start + i] = sortedList[i]; // 여기서 왜 start + i지
			}

		}

		public static void QuickSort(IList<int> list, int start, int middle, int end)
		{
			int pibut = list[0];
			
		}

		private static void Swap(IList<int> list, int i, int j)
		{
			int temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}
	}
}
