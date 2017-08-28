/*
 * Created by SharpDevelop.
 * User: matthiaspr
 * Date: 18.08.2017
 * Time: 13:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gui_stunden
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
		
			double endTime = 0;
			double beginTime = 0;
			double dayHours = 0;
			double currentNightHours = 0;
			double uebertragNightHours = 0;
			double DayAktuellerTag = 0;
			double NightAktuellerTag = 0;
			
			double[] tagstunden = new double[32];
			double[] nachtstunden = new double[32];
			
			textBox1.Text = null;
			textBox2.Text = null;
			
			for(int y=0; y < dataGridView1.ColumnCount; y++)
			{
				for(int x=0; x < (dataGridView1.RowCount - 2); x = x + 2)
				{
					
					if(dataGridView1.Rows[x].Cells[y].Value == null)
					{
						DayAktuellerTag = DayAktuellerTag + dayHours;
						NightAktuellerTag = NightAktuellerTag + currentNightHours;
						beginTime = 0;
						endTime = 0;
						dayHours = 0;
						currentNightHours = 0;
						break;
					}
					
					beginTime = Convert.ToDouble(dataGridView1.Rows[x].Cells[y].Value.ToString());
					endTime = Convert.ToDouble(dataGridView1.Rows[x+1].Cells[y].Value.ToString());
					
					
					if(beginTime < endTime && beginTime < 6 && endTime <= 6)
					{
						currentNightHours = currentNightHours + (endTime - beginTime);
					}
					else if (beginTime < 22 && endTime <= 6)
					{
						dayHours = dayHours  + (22 - beginTime);
						currentNightHours = currentNightHours + 2;
						uebertragNightHours = uebertragNightHours + endTime;
					}			
					else if (beginTime < endTime && beginTime < 6)
					{
						currentNightHours = currentNightHours + (6 - beginTime);
						dayHours = dayHours + (endTime - 6);
					}
					
					else if (beginTime < endTime && endTime < 22)
					{
						dayHours = dayHours + (endTime - beginTime);
					}
					else if (beginTime < endTime && endTime >= 22)
					{
						dayHours = dayHours + (22 - beginTime);
						currentNightHours = currentNightHours + (endTime - 22);
					}
					else if (beginTime >= 22 && endTime <= 6)
					{
						currentNightHours = currentNightHours + (24 - beginTime);
						uebertragNightHours = uebertragNightHours + endTime;
					}
					else if (beginTime > endTime && endTime <= 6)
					{
						dayHours = dayHours + (22 - beginTime);
						currentNightHours = currentNightHours + 2;
						uebertragNightHours = uebertragNightHours + endTime;
					}
					
					
					DayAktuellerTag = DayAktuellerTag + dayHours;
					NightAktuellerTag = NightAktuellerTag + currentNightHours;
					
					
					beginTime = 0;
					endTime = 0;
					dayHours = 0;
					currentNightHours = 0;
					
				}
				
					tagstunden[y] = DayAktuellerTag;
					nachtstunden[y] = NightAktuellerTag;
					currentNightHours = uebertragNightHours;
					uebertragNightHours = 0;
					DayAktuellerTag = 0;
					NightAktuellerTag = 0;
					
				
					textBox1.Text += tagstunden[y].ToString() + " | ";
					textBox2.Text += nachtstunden[y].ToString() + " | ";
			}		
		
			}
	}
}
