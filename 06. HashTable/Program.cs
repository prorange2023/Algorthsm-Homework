namespace _06._HashTable01
{
	public class CheatKey
	{
		private Dictionary<string, Action> cheatDic;

		private bool loop;

		public event Action OnMoneyCheat;
		public event Action OnWinCheat;

		public CheatKey()
		{
			OnMoneyCheat += ShowMeTheMoney;
			OnWinCheat += ThereIsNoCowLevel;

			cheatDic = new Dictionary<string, Action>();
			cheatDic.Add("showmethemoney", OnMoneyCheat);
			cheatDic.Add("thereisnocowlevel", OnWinCheat);
			loop = true;
		}

		public void Run(string cheatKey)
		{
			// 치트키 변환
			//  1. 띄어쓰기 제거
			//  2. 대문자 -> 소문자 변환
			string cheat = cheatKey.ToLower();
			cheatDic.TryGetValue(cheat, out Action act);
			act?.Invoke();
		}
		public void ShowMeTheMoney()
		{
			Console.WriteLine("골드를 늘려주는 치트키 발동!\n");
		}
		public void ThereIsNoCowLevel()
		{
			Console.WriteLine("바로 승리합니다 치트키 발동!\n");
		}

		public void Render()
		{
			Console.Write("치트키를 입력하세요:");
		}
		public void Input()
		{
			Run(Console.ReadLine());
		}
		public void RunGame()
		{
			while (loop)
			{
				Render();
				Input();
			}
		}
	}

	public class Program
	{
		static void Main(string[] argc)
		{
			CheatKey cheatKey = new CheatKey();
			cheatKey.RunGame();
		}
	}
}
