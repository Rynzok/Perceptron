using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice_form
{

    public partial class Form1 : Form
    {
        bool[] isSquareFilled = new bool[15];

        public Form1()
        {
            InitializeComponent();
            Perceptron.bias = (int)numericUpDown2.Value;
            Perceptron.trainings = (int)numericUpDown1.Value;
            Perceptron.training();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int index = int.Parse(((PictureBox)sender).Name.Split('x')[1]);
            isSquareFilled[index - 1] = !isSquareFilled[index - 1];
            if (isSquareFilled[index - 1])
                ((PictureBox)sender).BackColor = Color.Green;
            else
                ((PictureBox)sender).BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox16.CreateGraphics();
            g.Clear(Color.White);
            int num = determine(isSquareFilled);
            if (num != 10)
                g.DrawString(num.ToString(), new Font("Courier New", 85.0F), new SolidBrush(Color.Red), new Point(10, 10));
            else
                g.DrawString("can't define ", new Font("Courier New", 10.0F), new SolidBrush(Color.Red), new Point(3, 3));
        }

        private int determine(bool[] array)
        {
            string num = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i])
                    num += 1;
                else
                    num += 0;
            }

            for (int i = 0; i < 10; i++)
            {
                if (Perceptron.proceed(num.ToCharArray(), i))
                {
                    return i;
                }
            }
            return 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] weights = Perceptron.Weights;

            int height = weights.GetLength(0);
            int width = weights.GetLength(1);

            string msg = "";

            for (int i = 0; i < height; i++)
            {
                msg += i.ToString() + ": ";
                for (int j = 0; j < width; j++)
                {
                    msg += weights[i, j].ToString() + ", ";
                    if (j % 3 == 2)
                    {
                        msg += '\n';
                        msg += "   ";
                    }
                    
                }
                msg += '\t';
                msg += '\n';
            }
            MessageBox.Show(msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Perceptron.bias = (int)numericUpDown2.Value;
            Perceptron.trainings = (int)numericUpDown1.Value;
            Perceptron.training();
        }
    }
}
