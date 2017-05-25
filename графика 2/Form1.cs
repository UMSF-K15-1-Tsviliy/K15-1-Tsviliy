using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace графика_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = SmoothingMode.HighQuality;
            snowflake = new Bitmap(200, 200);
            Graphics snowflakeGraphics = Graphics.FromImage(snowflake);

            snowflakeGraphics.DrawLine(blue, 0, 100, 200, 100);
            snowflakeGraphics.DrawLine(blue, 150, 25, 50, 175);
            snowflakeGraphics.DrawLine(blue, 50, 25, 150, 175);
            
            snowflakeGraphics.DrawLine(blue, 125, 55, 125, 20);
            snowflakeGraphics.DrawLine(blue, 125, 55, 170, 45);

            snowflakeGraphics.DrawLine(blue, 170, 100, 195, 80);
            snowflakeGraphics.DrawLine(blue, 170, 100, 195, 120);
            snowflakeGraphics.DrawLine(blue, 30, 100, 5, 80);
            snowflakeGraphics.DrawLine(blue, 30, 100, 5, 120);

            snowflakeGraphics.DrawLine(blue, 75, 145, 75, 180);
            snowflakeGraphics.DrawLine(blue, 75, 145, 30, 155);

            snowflakeGraphics.DrawLine(blue, 75, 55, 75, 20);
            snowflakeGraphics.DrawLine(blue, 75, 55, 30, 45);
            snowflakeGraphics.DrawLine(blue, 125, 145, 125, 180);
            snowflakeGraphics.DrawLine(blue, 125, 145, 170, 155);
        }
        double t, step;
        int startingX, xCoeff, yCoeff, size;
        Random random = new Random();
        Graphics gr;
        Pen blue = new Pen(Color.FromArgb(50, 128, 128, 255), 3);
        Bitmap snowflake;

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += step;
            gr.DrawImage(snowflake, (float)(xCoeff*Math.Sin(t))+startingX, (float)t*yCoeff-size/2, size, size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            t = 0;
            step = random.NextDouble();
            if (step < 0.01) step += 0.01;
            while (step > 0.05) step -= 0.05;
            xCoeff = random.Next(10, 100);
            yCoeff = random.Next(10, 100);
            size = random.Next(5, 200);
            startingX = random.Next(0, pictureBox1.Width - 100);
            timer1.Start();
        }

    }
}