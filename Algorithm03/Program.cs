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
			List<Item> inventory;

			void PickItem()
			{

			}
		}
		static void Main(string[] args)
		{
			List<Item> Inventory = new List<Item>();

			Player player = new Player();
			player.name = "starter";

			Item potion = new Item();
			potion.name = "potion";
			potion.number = 5;

			Inventory.Add(potion);
		}
	}
}
