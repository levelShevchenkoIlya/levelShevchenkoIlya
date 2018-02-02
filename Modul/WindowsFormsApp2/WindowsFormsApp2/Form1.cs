using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int[,] Figure = new int[3, 3];
        public static int[,] Map = new int[100, 100];
        public static int[,] MapTemp = new int[100, 100];
        public static int[,] MapHistore = new int[100, 100];
        public static int[,] MiniMash = new int[3, 3];

        public static void DrawFigure(string value)
        {
            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            if (value == "Rectangle")
            {
                Figure[0, 0] = life.Lifeless; Figure[0, 1] = life.Lifeless; Figure[0, 2] = life.Lifeless;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = dead.Dead; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = life.Lifeless; Figure[2, 1] = life.Lifeless; Figure[2, 2] = life.Lifeless;

            }
            if (value == "X")
            {
                Figure[0, 0] = life.Lifeless; Figure[0, 1] = dead.Dead; Figure[0, 2] = life.Lifeless;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = life.Lifeless; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = life.Lifeless; Figure[2, 1] = dead.Dead; Figure[2, 2] = life.Lifeless;
            }
            if (value == "Plus")
            {
                Figure[0, 0] = dead.Dead; Figure[0, 1] = life.Lifeless; Figure[0, 2] = dead.Dead;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = life.Lifeless; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = dead.Dead; Figure[2, 1] = life.Lifeless; Figure[2, 2] = dead.Dead;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Map[50 + i, 50 + j] = Figure[i, j];
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Rectangle");
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("Plus");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            for (int i = 0; i < Map.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Map.GetUpperBound(0) + 1; j++)
                {
                    Map[i, j] = dead.Dead;
                }
            }
            //We maked our map all dead
            if (comboBox1.AccessibilityObject.Value == "Rectangle")
            {
                DrawFigure(comboBox1.AccessibilityObject.Value);
            }
            if (comboBox1.AccessibilityObject.Value == "X")
            {
                DrawFigure(comboBox1.AccessibilityObject.Value);
            }
            if (comboBox1.AccessibilityObject.Value == "Plus")
            {
                DrawFigure(comboBox1.AccessibilityObject.Value);
            }
            //Later we can add new figures
            do
            {
                for (int i = 0; i < Map.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < Map.GetUpperBound(0) + 1; j++)
                    {
                        if (Map[i, j] == dead.Dead)
                        {
                            MapTemp[i, j] = Map[i, j];
                        }
                        if (Map[i, j] == life.Lifeless)
                        {
                            if (i > 0 && i < 100 && j > 0 && j < 100)
                            {
                                MiniMash[0, 0] = Map[i - 1, j - 1]; MiniMash[0, 1] = Map[i, j - 1]; MiniMash[0, 2] = Map[i + 1, j - 1];
                                MiniMash[1, 0] = Map[i - 1, j]; MiniMash[1, 1] = Map[i, j]; MiniMash[1, 2] = Map[i + 1, j];
                                MiniMash[2, 0] = Map[i - 1, j + 1]; MiniMash[2, 1] = Map[i, j + 1]; MiniMash[2, 2] = Map[i + 1, j + 1];
                                RewriteToSeconsArr.Checkking(MiniMash, ref MapTemp, i, j);
                            }

                        }
                    }
                }

            } while (true);//Условия на конец(все мертвое,все статическое,все повторяеться)
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // BackColor = Color.Red;
            //ControlPaint.(e.Graphics, e.ClipRectangle, new Size(5, 5), Color.Red);
            //this.Controls.Add(pictureBox1); this.Controls.Add(pictureBox1);
            //Graphics gr = Graphics.FromHwnd(this.Controls.Add(pictureBox1));
            //gr.DrawRectangle(Pens.Black, 10, 10, 10, 10);
        }
    }
}
