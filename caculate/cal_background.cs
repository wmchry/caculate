using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace caculate
{
	class cal_background
	{
		private static double result = 0;
		private static Stack<string> sign = new Stack<string>();
		private static Stack<double> num = new Stack<double>();
		private static double n = 0;
		protected static bool is_number(string a)
		{
			return Regex.IsMatch(a, @"^[0-9]");
		}
		protected static bool options_judge(string a, string b)
		{
			Dictionary<string,int> dic=new Dictionary<string, int>();
			dic.Add("+", 1);
			dic.Add("-", 1);
			dic.Add("*", 2);
			dic.Add("/", 2);
			dic.Add("sin", 4);
			dic.Add("cos", 4);
			dic.Add("tan", 4);
			dic.Add("cot", 4);
			dic.Add("(", 0);
			dic.Add(")", -1);
			dic.Add("#",100);
			if (dic[b]==0)
			{
				return true;
			}
			if (dic[a] < dic[b])
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static void cal_cal()
		{
			Dictionary<string, int> dic = new Dictionary<string, int>();
			dic.Add("+", 1);
			dic.Add("-", 2);
			dic.Add("*", 3);
			dic.Add("/", 4);
			dic.Add("sin", 5);
			dic.Add("cos", 6);
			dic.Add("tan", 7);
			dic.Add("cot", 8);
			dic.Add(")",9);
			double a = 0, b = 0;
			string op;
			if (num.Count == 0)
			{
				error(0);
			}
			b = num.Pop();
			if (sign.Count==0)
			{
				error(0);
			}
			op = sign.Pop();
			if (op=="(")
			{
				error(1);
			}
			switch (dic[op])
			{
				case 5:
				{
					num.Push(Math.Sin(b));
					return;
				}
				case 6:
				{
					num.Push(Math.Cos(b));
					return;
				}
				case 7:
				{
					num.Push(Math.Tan(b));
					return;
				}
				case 8:
				{
					
					num.Push(1/Math.Tan(b));
					return;
				}
				default:break;
			}
			if (num.Count == 0)
			{
				if (dic[op] == 1)
				{
					num.Push(b);
				}
				else if (dic[op]==2)
				{
					num.Push(-b);
				}
				else
				{
					error(0);
				}
			}
			else
			{
				a = num.Pop();
				if (sign.Count != 0)
				{
					if (sign.Peek() == "-")
					{
						a = -a;
						sign.Pop();
						sign.Push("+");
					}
				}
				switch (dic[op])
				{
					case 1: num.Push(a+b);break;
					case 2: num.Push(a-b);break;
					case 3: num.Push(a*b);break;
					case 4:
					{
						if (b!=0)
						{
							num.Push(a / b);
							break;
						}
						error(2);
						break;
					}
						
					default:break;
				}
			}


		}
		private static void num_change(string[] input, int front, int bottom)
		{
			int jud = 0;
			for (; front <= bottom; front++)
			{
				//小数点判断
				if (input[front] == ".")
				{
					jud = 1;
					continue;
				}

				//pi判断
				if (input[front] == "π")
				{
					num.Push(Math.PI);
					if (is_number(input[front - 1]))
					{
						num.Push(n);
						sign_change("×");
					}
					continue; 
				}
				
				//数字转换
				if (is_number(input[front]))
				{
					if (jud == 0)
					{
						n = n * 10 + Convert.ToDouble(input[front]);
					}
					else
					{
						jud = jud * 10;
						n = n + Convert.ToDouble(input[front]) / jud;
					}
				}
				else
				{

					//判断首项输入是否非法
					 if (front == 0)
					{
						if (input[front] == "×" || input[front] == "÷" || input[front] == ")")
						{
							error(0);
						}
						else
						{
							sign.Push(input[front]);
							continue;
						}
					}

					else if (is_number(input[front - 1]))
					{
						num.Push(n);
					}

					if (input[front] == "#")
					{
						while (sign.Count!=0)
						{
							cal_cal();
						}
					}
					else
					{
						sign_change(input[front]);
						n = 0;
						jud = 0;
					}
				}
			}
			n = 0;
			jud = 0;
			result = num.Pop();
			return;
		}

		private static void sign_change(string input)
		{
			if (input == "×") input = "*";
			if (input == "÷") input = "/";
			if (sign.Count == 0)
			{
				sign.Push(input);
				return;
			}
			if (options_judge(sign.Peek(), input))
			{
				sign.Push(input);
			}
			else if (input == ")")
			{
				while (sign.Peek() != "(")
				{
					cal_cal();
				}

				sign.Pop();
				return;
			}
			else
			{
				cal_cal();
				sign.Push(input);
			}
			return;
		}

		public static double Cal(string[] input, int front, int bottom)
		{
			num_change(input,front,bottom);
			return Math.Round(result,4);
		}

		public static void error(int a)
		{
			switch (a)
			{
				case 0: MessageBox.Show("You have wrong input");break;
				case 1: MessageBox.Show("You loss the \")\""); break;
				case 2: MessageBox.Show("\"0\" can not be denominator"); break;
			}
			
			Application.ExitThread();
			Application.Exit();
			Application.Restart();
			Process.GetCurrentProcess().Kill();
			return;
		}
	}
}
