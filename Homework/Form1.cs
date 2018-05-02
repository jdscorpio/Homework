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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(openFileDialog1.FileName));
                int count = 0;
                try
                {
                    while (sr.ReadLine() != null)
                    {
                        string text = sr.ReadLine();
                        string[] tab = text.Split('\t');
                        int x = int.Parse(tab[0]);
                        int y = int.Parse(tab[1]);
                        textBox1.AppendText(text + '\n');
                        if (y > 0) count++;
                    }
                    label1.Text = "Amount points above the X-Axis: " + count.ToString();
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
    }
}
