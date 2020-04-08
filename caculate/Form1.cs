using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caculate
{
	
	public partial class Form1 : Form
	{
		string[] exp=new string[100];
		private string temp = " " ;
		private int i = 0;
		private double result = 0;
		private Stack<int> brackets=new Stack<int>();
		private int front = 0;
		private int bottom = 0;
		public Form1()
		{
			InitializeComponent();
		}

		private void num_click(object sender, EventArgs e)
		{
			Button btn = (sender as Button);
			if ("=" != btn.Text)
			{
				exp[i] = btn.Text;
				temp = temp + exp[i];
				display.Text = temp;
				i++;
			}
			else
			{
				bottom = i;
				i = front;
				exp[i] = cal_background.num_change(exp, front, bottom).ToString();
				result =cal_background.Cal(exp,front,bottom);
				output.Text = result.ToString();
				temp = null;
				for (; i >= 0; i--)
				{
					exp[i] = " ";
				}
				i=0;
			}
		}
		private void spec_click(object sender, EventArgs e)
		{
			Button btn = (sender as Button);
			if ("clear" == btn.Text)
			{
				temp = null;
				for (; i >= 0; i--)
				{
					exp[i] = " ";
				}
				i=0;
			}
			else if ("back" == btn.Text)
			{
				if (i<1)
				{
					MessageBox.Show("You have no input!");
					return;
				}
				i--;
				temp = temp.Substring(0, temp.Length - exp[i].Length);
			}
			else
			{
				bottom = i;
				i = front;
				exp[i] = cal_background.num_change(exp, front, bottom).ToString();
				i++;
				front = i;
				exp[i] = cal_background.sign_change(btn.Text);
				temp = temp + exp[i];
			}
			display.Text = temp;
		}
		private void tri_click(object sender, EventArgs e)
		{
			Button btn = (sender as Button);
			bottom = i;
			i = front;
			exp[i] = cal_background.num_change(exp, front, bottom).ToString();
			i++;
			front = i;
			exp[i] = cal_background.sign_change(btn.Text);
			temp = temp + exp[i];
			display.Text = temp;
		}
		private void sign_click(object sender, EventArgs e)
		{
			Button btn = (sender as Button);
			bottom = i;
			i = front;
			exp[i] = cal_background.num_change(exp, front, bottom).ToString();
			i++;
			front = i;
			exp[i] = cal_background.sign_change(btn.Text);
			temp = temp + exp[i];
			display.Text = temp;
		}
	}
}