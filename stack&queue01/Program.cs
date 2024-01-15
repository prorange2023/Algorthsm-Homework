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

		


		static void Main()
		{
			bool check;
			string a = "[";
			string b = "]";
			string c = "{";
			string d = "}";
			string e = "(";
			string f = ")";

			

			Queue<string> queue = new Queue<string>();

			queue.Enqueue(a);
			queue.Enqueue(b);
			queue.Enqueue(c);
			queue.Enqueue(d);
			queue.Enqueue(e);
			queue.Enqueue(f);


			string left = queue.Dequeue();


			


			if (left == "(")
			{
				if (queue.Contains(f)) 
				{ 
					check = true; 
					Console.WriteLine(check);
				}
				else
				{
					check = false;
					Console.WriteLine(check);
				}
			}

			else if(left == "[")
			{
				if (queue.Contains(b)) 
				{ 
					check = true;
					Console.WriteLine(check);
				}
				else
				{
					check = false;
					Console.WriteLine(check);
				}
			}
			else if(left == "{")
			{
				if (queue.Contains(d)) 
				{ 
					check = true;
					Console.WriteLine(check);
				}
				else
				{
					check = false;
					Console.WriteLine(check);
				}
			}
			else if (left == "}")
			{
				check = false;
				Console.WriteLine(check);
			}
			else if (left == ")")
			{
				check = false;
				Console.WriteLine(check);
			}
			else if (left == "]")
			{
				check = false;
				Console.WriteLine(check);
			}
			

			


		}
	}
}
