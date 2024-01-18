namespace _06.HachTable02
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();

			int n = 3;
			int m = 2;

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("사이트를 입력하세요");
				string site = (string)Console.ReadLine();
				Console.WriteLine("비밀번호를 입력하세요");
				string password = (string)Console.ReadLine();

				dic.Add(site, password);

			}

			Console.WriteLine();


			for (int i = 0; i < m; i++)
			{
				Console.WriteLine("검색해볼 사이트명을 입력하세요");
				string sch = (string)Console.ReadLine();

				bool have = dic.TryGetValue(sch, out string sch2);

				if (have == true)
				{
					Console.WriteLine(dic[sch]);
				}
			}
		}
	}
}
