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
    public class teste
    {
        public TextBox box = new TextBox();
        public Label labelR = new Label();
    }
    public partial class Form2 : Form
    {
        private System.ComponentModel.IContainer components = null;
      
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        public Form2(int resistores, double vin)
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();

            teste[] abcd = new teste[resistores];
            for (int i = 0; i < abcd.Length; i++)
            {
                abcd[i] = new teste();
                abcd[i].box.Location = new System.Drawing.Point(118, 130 + (30 * i));
                abcd[i].box.Name = "textBox" + i;
                abcd[i].box.Size = new System.Drawing.Size(44, 22);
                abcd[i].box.Text = "R" + (i + 1);
                abcd[i].labelR.AutoSize = true;
                abcd[i].labelR.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                abcd[i].labelR.Location = new System.Drawing.Point(380, 132 + (30 * i));
                abcd[i].labelR.Name = "label" + i;
                abcd[i].labelR.Size = new System.Drawing.Size(20, 19);
                abcd[i].labelR.Text = "V" + (i + 1) + " = ";
            }
            this.SuspendLayout();

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 19);
            this.label1.Text = "Insira, nos campos respectivos, o valor de cada resistor (em Ohms):";

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 19);
            this.label2.Text = "Resistores:";

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 19);
            this.label3.Text = "Tensão sobre os resistores:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(318, (330 + (20 * resistores)));
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler((s, e) => button1_Click(s, e, abcd, vin));

            //   }
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, (400 + (20 * resistores)));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            for (int i = 0; i < resistores; i++)
            {
                this.Controls.Add(abcd[i].box);
                this.Controls.Add(abcd[i].labelR);
            }
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }
        public void button1_Click(object sender, EventArgs e, teste[] abcd, double vin)
        {
            double Requivalente = 0;
            try
            {
                for (int i = 0; i < abcd.Length; i++)
                {
                    if (Convert.ToDouble(abcd[i].box.Text)<=0)
                    {
                        MessageBox.Show("O valor das resistências deve ser um número real positivo.", "Erro");
                        return;
                    }
                    else
                    {
                        Requivalente = Convert.ToDouble(abcd[i].box.Text) + Requivalente;
                    }

                }
                double corrente = vin / Requivalente;
                for (int i = 0; i < abcd.Length; i++)
                {
                    abcd[i].labelR.Text = "V" + (i + 1) + " = " + corrente * Convert.ToDouble(abcd[i].box.Text) + "V";
                }
            }
            catch
            {
                MessageBox.Show("O valor das resistências deve ser um número real positivo.", "Erro");
            }

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
