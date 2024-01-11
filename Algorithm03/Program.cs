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

			void PickItem(Item item)
			{
				inventory.Add(item);
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

			
		}
	}
}
