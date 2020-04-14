using System.Drawing;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace caculate
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		[CanBeNull] private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.display = new System.Windows.Forms.TextBox();
			this.output = new System.Windows.Forms.TextBox();
			this.num = new System.Windows.Forms.Button[12];
			this.spec = new System.Windows.Forms.Button[5];
			this.tri = new System.Windows.Forms.Button[4];
			this.sign = new System.Windows.Forms.Button[4];
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.Location = new System.Drawing.Point(50, 50);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(475, 30);
			this.display.TabIndex = 0;
			this.display.ReadOnly = true;
			//
			//output
			//
			this.output.Location = new System.Drawing.Point(50,100);
			this.output.Name = "output";
			this.output.Size = new System.Drawing.Size(475, 30);
			this.output.TabIndex = 0;
			this.output.ReadOnly = true;
			//
			//button
			//
			int btn_h = 30;
			int btn_w = 75;
			int xcount = 5;
			int ycount = 5;
			int x = 50;
			int y = 150;
			///数字按钮
			for (int count=0; count < 12; count++)
			{
				this.num[count] = new System.Windows.Forms.Button();
				this.num[count].Text = count.ToString();
				this.num[count].UseVisualStyleBackColor = false;
				this.num[count].Size = new System.Drawing.Size(btn_w, btn_h);
				if (count == 10)
				{
					this.num[count].Text = ".";
				}
				if (count == 11)
				{
					this.num[count].Text = "=";
					this.num[count].BackColor = System.Drawing.Color.Orange;
				}
				this.num[count].Click += new System.EventHandler(this.num_click);
			}
			///特殊按钮
			for (int count=0; count < 5; count++)
			{
				this.spec[count] = new System.Windows.Forms.Button();
				this.spec[count].UseVisualStyleBackColor = false;
				this.spec[count].Size = new System.Drawing.Size(btn_w, btn_h);
				switch (count)
				{
					case 0: this.spec[count].Text = "π";break;
					case 1: this.spec[count].Text = "("; break;
					case 2: this.spec[count].Text = ")"; break;
					case 3: this.spec[count].Text = "clear"; this.spec[count].BackColor = System.Drawing.Color.Red; break;
					case 4: this.spec[count].Text = "back"; break;
				}
				this.spec[count].Click += new System.EventHandler(this.spec_click);
			}
			///三角函数
			for (int count=0; count < 4; count++)
			{
				this.tri[count] = new System.Windows.Forms.Button();
				this.tri[count].UseVisualStyleBackColor = false;
				this.tri[count].Size = new System.Drawing.Size(btn_w, btn_h);
				switch (count)
				{
					case 0: this.tri[count].Text = "sin("; break;
					case 1: this.tri[count].Text = "cos("; break;
					case 2: this.tri[count].Text = "tan("; break;
					case 3: this.tri[count].Text = "cot("; break;
				}
				this.tri[count].Click += new System.EventHandler(this.tri_click);
			}
			///符号按钮
			for (int count = 0; count < 4; count++)
			{
				this.sign[count] = new System.Windows.Forms.Button();
				this.sign[count].UseVisualStyleBackColor = false;
				this.sign[count].Size = new System.Drawing.Size(btn_w, btn_h);
				switch (count)
				{
					case 0: this.sign[count].Text = "+"; break;
					case 1: this.sign[count].Text = "-"; break;
					case 2: this.sign[count].Text = "×"; break;
					case 3: this.sign[count].Text = "÷"; break;
				}
				this.sign[count].Click += new System.EventHandler(this.sign_click);
			}
			///按钮摆放
			int num_count = 1;
			int spec_count = 0;
			int p = -1;
			for (int j = 0; j < xcount; j++)
			{
				for (int i = 0; i < ycount; i++)
				{
					if (j==0)
					{
						this.spec[spec_count].Location = new System.Drawing.Point(x, y);
						spec_count++;
					}
					if (i < 3 && j > 0 && j < 5 &&  num_count<12)
					{


						this.num[num_count].Location = new System.Drawing.Point(x, y);
						if (i == 1 && j == 4)
						{
							this.num[0].Location = new System.Drawing.Point(x, y);
							num_count--;
						}
						num_count++;
					}

					if (j > 0)
					{
						if (i == 3)
						{
							this.tri[p].Location = new System.Drawing.Point(x, y);
						}

						if (i == 4)
						{
							this.sign[p].Location = new System.Drawing.Point(x, y);
						}
					}
					x += 100;
				}
				p++;
				y += 50;
				x = 50;
			}

			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage= global::caculate.Properties.Resources.bg;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon =  global::caculate.Properties.Resources.icon;
			for (int count = 0; count < 12; count++)
			{
				this.Controls.Add(this.num[count]);
			}
			for (int count = 0; count < 5; count++)
			{
				this.Controls.Add(this.spec[count]);
			}
			for (int count= 0; count < 4; count++)
			{
				this.Controls.Add(this.tri[count]);
				this.Controls.Add(this.sign[count]);
			}
			this.Controls.Add(this.display);
			this.Controls.Add(this.output);
			this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
			this.Name = "Form1";
			this.Text = "计算器";
			this.PerformLayout();
			this.ResumeLayout(false);

		}


		#endregion
		
		private System.Windows.Forms.TextBox display;
		private System.Windows.Forms.TextBox output;
		private Button[] num;
		private Button[] spec;
		private Button[] tri;
		private Button[] sign;
	}
}

