using System.Collections.Generic;

namespace Algorithm03
{
	internal class Program
	{
		// A++) 인벤토리 구현(아이템 수집, 아이템 버리기)

		public class Item
		{
			public string name;
			public int number;

			void Used()
			{

			}
		}

		public class Player
		{
			public string name;
			public List<Item> inventory;

			public Player(string name)
			{
				this.name = name;
				inventory = new List<Item>();

			}

			public void PickItem(Item item)
			{
				inventory.Add(item);
				Console.WriteLine($"{item.name}을 {item.number}개 인벤토리에 넣었습니다.");
			}

			public void ThrowItem(Item item)
			{
				inventory.Remove(item);
				Console.WriteLine($"{item.name}을 {item.number}개 인벤토리에서 제거했습니다.");
			}

			public void PrintList(List<Item> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Console.WriteLine("인벤토리에 보유한 아이템입니다.");
					Console.WriteLine($"{list[i].name}를 {list[i].number}개 보유하고있습니다");
				}
			}

		}

		
		static void Main(string[] args)
		{
			Player red = new Player("red");

			Item potion = new Item();
			potion.name = "potion";
			potion.number = 5;

			Item Goldbar = new Item();
			Goldbar.name = "goldbar";
			Goldbar.number = 1;

			red.PickItem(potion);
			red.PickItem(Goldbar);

			red.PrintList(red.inventory);

			red.ThrowItem(potion);

			red.PrintList(red.inventory);
		}
	}
}
