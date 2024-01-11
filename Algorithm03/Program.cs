using System.Collections.Generic;

namespace Algorithm03
{
	internal class Program
	{
		// A++) 인벤토리 구현(아이템 수집, 아이템 버리기)

		public class Item
		{
			public string name;
			public int ea;
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
				if (inventory.Contains(item))
				{
					item.ea+=2;
					Console.WriteLine($"{item.name}을 인벤토리에 넣었습니다.");
				}
				else
				{
				
					inventory.Add(item);
					Console.WriteLine($"{item.name}을 인벤토리에 넣었습니다.");
				}
				
			}

			public void ThrowItem(Item item)
			{
				if ( inventory.Contains(item) )
				{
					inventory.Remove(item);
					Console.WriteLine($"{item.name}을 인벤토리에서 제거했습니다.");
				}
				else
				{
					Console.WriteLine($"{item.name}는 인벤토리에 존재하지 않습니다.");
				}
				
			}

			public void UseItem(Item item, int num)
			{
				if (inventory.Contains(item) && item.ea > 0)
				{
					item.ea -= num;
					Console.WriteLine($"{item.name}을 {num}개 사용했습니다.");
				}
				else
				{
					Console.WriteLine($"{item.name}는 인벤토리에 존재하지 않습니다.");
				}

			}

			public void PrintList(List<Item> list)
			{
				Console.WriteLine();
				Console.WriteLine("인벤토리에 보유한 아이템입니다.");
				for (int i = 0; i < list.Count; i++)
				{
					
					Console.WriteLine($"{list[i].name}를 {list[i].ea}개 보유하고있습니다");
				}
			}

		}

		
		static void Main(string[] args)
		{
			Player red = new Player("red");

			Item potion = new Item();
			potion.name = "potion";
			potion.ea = 2;
			

			Item Goldbar = new Item();
			Goldbar.name = "goldbar";

			

			red.PickItem(potion);
			red.PickItem(Goldbar);
			red.PickItem(potion);

			red.PrintList(red.inventory);
			red.UseItem(potion, 3);

			red.ThrowItem(potion);


			red.PrintList(red.inventory);
		}
	}
}
