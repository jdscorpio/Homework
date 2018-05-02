using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 info = new AboutBox1();
            info.Show();
        }

        public struct Point
        {
            public double x;
            public double y;
        }

        private int amountPoinsAboveAxisX(Point[] points, int amount)
        {
            int countPointsAboveAxisX = 0;
            for (int i = 0; i < amount; i++)
            {
                if (points[i].y > 0) countPointsAboveAxisX++;
            }
            return countPointsAboveAxisX;
        }

        private double lenghtOfLineSegment(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(B.x-A.x,2)+Math.Pow(B.y-A.y,2));
        }

        private double areaOfTrangle(double AB, double AC, double BC)
        {
            double p = (AB+AC+BC)/2.0;
            return Math.Sqrt(p*(p-AB)*(p-AC)*(p-BC));
        }

        private bool ifExistTriangle(Point A, Point B, Point C)
        {
            double AB = lenghtOfLineSegment(A, B);
            double AC = lenghtOfLineSegment(A, C);
            double BC = lenghtOfLineSegment(B, C);

            if (AB + AC > BC && AB + BC > AC && AC + BC > AB && areaOfTrangle(AB, AC, BC)>0)
                return true;
            else
                return false;
        }

        private int amountTriangles(Point[] points, int amount)
        {
            int countTriangle = 0;

            for (int i = 0; i < amount-2; i++)
            {
                for (int j = i+1; j < amount-1; j++)
                {
                    for (int k = j+1; k < amount; k++)
                    {
                        if (ifExistTriangle(points[i], points[j], points[k]))
                            countTriangle++;
                    }                    
                }
            }

            return countTriangle;
        }

        private bool ifInsideLineSegment(Point A)
        {
            Point begin, end;
            begin.x = 0;
            begin.y = 0;
            end.x = 0;
            end.y = 5;
            double temp = lenghtOfLineSegment(begin, end);
            if (lenghtOfLineSegment(begin, A) + lenghtOfLineSegment(A, end) == temp)
                return true;
            else
                return false;
        }

        private int amountInsideLineSegnment(Point[] points, int amount)
        {
            int amountInside = 0;
            for (int i = 0; i < amount; i++)
            {
                if (ifInsideLineSegment(points[i]))
                    amountInside++;
            }

            return amountInside;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(openFileDialog1.FileName));

                Point[] points = new Point[100];
                int i = 0;
                int count = 0;
                string text;
                try
                {
                    while ((text = sr.ReadLine()) != null)
                    {
                        string[] tab = text.Split('\t');
                        int x1 = int.Parse(tab[0]);
                        int y1 = int.Parse(tab[1]);
                        points[i].x = int.Parse(tab[0]);
                        points[i].y = int.Parse(tab[1]);
                        i++;
                        textBox1.AppendText(text + '\n');
                       
                        count++;
                    }
                    label1.Text = "Amount of points above the X-Axis: " + amountPoinsAboveAxisX(points, count).ToString();
                    label3.Text = "Amount of triangles: " + amountTriangles(points, count).ToString();
                    label4.Text = "Amount of points inside the line segment: " + amountInsideLineSegnment(points, count).ToString();
                    label2.Text = "File: " + openFileDialog1.FileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }   
                sr.Dispose();
            } 
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
