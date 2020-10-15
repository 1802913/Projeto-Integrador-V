using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Projeto_Integrador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String numstr = textBox1.Text;
            String vinstr = textBox2.Text;
			try
			{
				int resistores = Convert.ToInt16(numstr);
				if (resistores <= 0)
				{
					MessageBox.Show("A quantidade de resistores deve ser um número natural.", "Erro");
				}
				else
				{
					try
					{
						double vin = Convert.ToDouble(vinstr);
						if (vin < 0)
						{
							MessageBox.Show("A tensão de entrada deve ser um número real positivo.", "Erro");
						}
						else
						{
							Form2 f = new Form2(resistores,vin);
							f.Show();
						}
					}
					catch
					{
						MessageBox.Show("A tensão de entrada deve ser um número real positivo.", "Erro");
					}
					}
				}
			catch
			{
				MessageBox.Show("A quantidade de resistores deve ser um número natural.", "Erro");
			}
		}
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
