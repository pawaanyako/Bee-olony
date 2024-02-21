using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngouriMath;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BeeСolony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown2.Maximum = numericUpDown1.Value;
            numericUpDown3.Maximum = numericUpDown2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x, y, z;
                BeeColony beeColony = new BeeColony(
                    textBox1.Text,
                    (int)numericUpDown1.Value,
                    (int)numericUpDown2.Value,
                    (int)numericUpDown3.Value,
                    (int)numericUpDown4.Value,
                    (int)numericUpDown5.Value,
                    (int)numericUpDown6.Value,
                    (int)numericUpDown7.Value,
                    (int)numericUpDown8.Value,
                    (int)numericUpDown9.Value);
                (x, y, z) = beeColony.StartBeeColony((int)numericUpDown10.Value);
                label11.Text = "Ответ: (" + x.ToString() + ", " + y.ToString() + "). Значение функции в этой точке: " + z.ToString();
            }
            catch { MessageBox.Show("Неправильный ввод функции", "Ошибка"); }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = numericUpDown2.Value;
        }
    }
}
