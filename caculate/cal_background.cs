using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caculate
{
	class cal_background
	{
		private static double result=0;
		private static Stack<string>sign=new Stack<string>();
		private static Stack<double>num=new Stack<double>();
		private const double pi = 3.14;
		public static double num_change(string[] input, int front, int bottom)
		{
			int jud = 0;
			result = 0;
			for (; front < bottom; front++)
			{
				if (input[front] == ".")
				{
					jud = 1;
					continue;
				}

				if (jud==0)
				{
					result = result * 10 +Convert.ToDouble(input[front]);
				}
				else
				{
					jud = jud * 10;
					result = result + Convert.ToDouble(input[front]) / jud;
				}
			}
			if(bottom>0) num.Push(result);
			return result;
		}

		public static string sign_change(string input)
		{
			if (input== "π")
			{
				num.Push(pi);
			}
			else
			{
				sign.Push(input);
			}
			return input;
		}

		public static double Cal(string[] input, int front, int bottom)
		{
			return result;
		}
	}
}
