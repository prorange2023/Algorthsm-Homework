namespace _03._stack_queue01
{
	internal class Program
	{

		//		<괄호 검사기를 구현하자>
		//괄호 : 괄호가 바르게 짝지어졌다는 것은 열렸으면 짝지어서 닫혀야 한다는 뜻

		//텍스트를 입력으로 받아서 괄호가 유효한지 판단하는 함수
		//bool IsOk(string text) { }

		//		검사할 괄호 : [], {}, ()

		//		예시 : () 완성, (() 미완성, [) 미완성, [[(){}]] 완성




		public static bool IsOk(string text)
		{
			Stack<char> stack = new Stack<char>();

			foreach (char c in text)
			{
				if (c == '(')
				{
					stack.Push(c);
				}
				else if (c == '[')
				{
					stack.Push(c);
				}
				else if (c == '{')
				{
					stack.Push(c);
				}
				else if (c == ')')
				{
					if (stack.Count == 0)
					{
						return false;
					}

					char bracket = stack.Pop();
					if (bracket == '(')
					{
						// 이건 괜찮
					}
					else
					{
						return false;
					}
				}
				else if (c == '}')
				{
					if (stack.Count == 0)
					{
						return false;
					}
					char bracket = stack.Pop();
					if (bracket == '{')
					{
						// 이건 괜찮
					}
					else
					{
						return false;
					}
				}
				else if (c == ']')
				{
					if (stack.Count == 0)
					{
						return false;
					}
					char bracket = stack.Pop();
					if (bracket == '[')
					{
						// 이건 괜찮
					}
					else
					{
						return false;
					}
				}

			}

			if (stack.Count > 0)
			{
				return false;
			}

			return true;
		}
		static void Main(string[] args)
		{

			do
			{
				string text = Console.ReadLine();
				Console.WriteLine(IsOk(text));
			} while (true);
			IsOk("()()");
			IsOk("{}");
			IsOk("[]");
			IsOk("[{]");


			// stack으로 넣고 확인하다가 괄호 {[(나오는걸 확인하면
			// 중단하고 반대편을 queue로 넣고 peek으로 엿보기
			// peek 으로 엿봤는데 해당괄호랑 다른 괄호면 False
			// 같은 괄호면 둘다 삭제
			// 반복해서 남은게 없으면 True 반환



		}

	}
}
