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
        bool[] isSquareFilled = new bool[25];
        PictureBox[] pictureBoxes = new PictureBox[25];


        public Form1()
        {
            InitializeComponent();
            Perceptron.bias = (int)numericUpDown2.Value;
            Perceptron.trainings = (int)numericUpDown1.Value;
            Perceptron.training();
            PictureBox[] pictureBoxes1 =
            {
                pictureBox51,
                pictureBox50,
                pictureBox49,
                pictureBox48,
                pictureBox47,
                pictureBox46,
                pictureBox45,
                pictureBox44,
                pictureBox43,
                pictureBox42,
                pictureBox41,
                pictureBox40,
                pictureBox39,
                pictureBox38,
                pictureBox37,
                pictureBox36,
                pictureBox35,
                pictureBox34,
                pictureBox33,
                pictureBox32,
                pictureBox31,
                pictureBox30,
                pictureBox29,
                pictureBox28,
                pictureBox27


            };
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i] = pictureBoxes1[i];
            }
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
            Char[] symbols = new char[4] { '˄', '˅', '→', '!' };
            Graphics g = pictureBox26.CreateGraphics();
            g.Clear(Color.White);
            int num = determine(isSquareFilled);
            if (num != 10)
                g.DrawString(symbols[num].ToString(), new Font("Courier New", 85.0F), new SolidBrush(Color.Red), new Point(10, 10));
            else
                g.DrawString("can't define ", new Font("Courier New", 10.0F), new SolidBrush(Color.Red), new Point(3, 3));
                for (int j = 0; j < pictureBoxes.Length; j++)
                {
                if (num == 10)
                    return;
                    Graphics gr = pictureBoxes[j].CreateGraphics();
                    gr.Clear(Color.Yellow);
               
                if (Perceptron.weights[num, j] < 0)
                    gr.Clear(Color.Red);
                else if(Perceptron.weights[num, j] > 0)
                    gr.Clear(Color.Green);
                gr.DrawString(Perceptron.weights[num, j].ToString(), new Font("Courier New", 10.0F), new SolidBrush(Color.Black), new Point(1, 1));
                }
            
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

            for (int i = 0; i < 4; i++)
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
            int[,] weights = Perceptron.weights;

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
