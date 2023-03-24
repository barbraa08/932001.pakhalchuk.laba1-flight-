using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		const double g = 9.81;
		const double C = 0.15;
		const double rho = 1.29;
		double height, angle, speed, s, m, dt;
		double cosa, sina, beta, k;

		double t, x, y, vx, vy;

		List<double> yList = new List<double>();

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void edAccuracy_ValueChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}

		public void btStart_Click(object sender, EventArgs e)
		{
			yList.Clear();
			height = (double)edHeight.Value;
			angle = (double)edAngle.Value;
			speed = (double)edSpeed.Value;
			s = (double)edSize.Value;
			m = (double)edWeight.Value;
			dt = (double)edAccuracy.Value;

			cosa = Math.Cos(angle * Math.PI / 180);
			sina = Math.Sin(angle * Math.PI / 180);
			beta = 0.5 * C * s * rho;
			k = beta / m;

			t = 0;
			x = 0;
			y = height;
			vx = speed * cosa;
			vy = speed * sina;

			chart1.Series[0].Points.AddXY(x, y);
			timer1.Start();
		}

		private void btClear_Click(object sender, EventArgs e)
		{
			chart1.Series[0].Points.Clear();
			yList.Clear();
			lbTimestep.Text = "Time step = ";
			lbDistance.Text = "Distance = ";
			lbHeight.Text = "Max height = ";
			lbEndspeed.Text = "Speed at the end point = ";
			timer1.Stop();
			t = 0;
			x = 0;
			y = height;
			vx = speed * cosa;
			vy = speed * sina;
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			double vx_old = vx;
			double vy_old = vy;
			double root = Math.Sqrt(vx * vx + vy * vy);

			t = t + dt;

			vx = vx_old - k * vx_old * root * dt;
			vy = vy_old - (g + k * vy_old * root) * dt;

			x = x + vx * dt;
			y = y + vy * dt;
			chart1.Series[0].Points.AddXY(x, y);
			yList.Add(y);
			if (y <= 0) 
			{
				lbTimestep.Text = lbTimestep.Text + dt.ToString("0.0000") + "; ";
				lbDistance.Text = lbDistance.Text + x.ToString("0.0000") + "; ";
				lbHeight.Text = lbHeight.Text + yList.Max().ToString("0.0000") + "; ";
				lbEndspeed.Text = lbEndspeed.Text + root.ToString("0.0000") + "; ";
				timer1.Stop(); 
			}
		}

	   /* private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
			DataGridViewCell cell1 = new DataGridViewTextBoxCell();
			DataGridViewCell cell2 = new DataGridViewTextBoxCell();
			DataGridViewCell cell3 = new DataGridViewTextBoxCell();
			DataGridViewCell cell4 = new DataGridViewTextBoxCell();
			cell1.Value = "Time step";
			cell2.Value = "Distance";
			cell3.Value = "Max Height";
			cell4.Value = "Speed at the end point";

			DataGridViewRow row0 = new DataGridViewRow();
			row0.Cells.AddRange(cell1, cell2, cell3, cell4);
			tbResults.Rows.Add(row0);

			col.Name = "cl0";
			col.HeaderText = "Свойство";
			int i = 0;

			if (btStart.Enabled == true)
			{
				i++;
				DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
				col.Name = "cl" + i;
				col.HeaderText = "Модель" + i;
			}
		}*/
	}
}
