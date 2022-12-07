using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kisa_sinav
{
    public partial class Form1 : Form
    {

        
        //noktalar çiz 1.button 
        public void nokta_ciz()
        {
            System.Drawing.Graphics graphics;
            graphics = this.CreateGraphics();
            Pen klm = new Pen(Color.Red, 3);
            klm.Color = Color.Black;
            graphics.DrawEllipse(klm, (800 / 2) - 5f, (500 / 2) - 5f, 10f, 10f); // width'i ve Height'i  2'ye böl eksinin tam(0,0) noktası verir , -5f = tam ortasında denk gelsin 
            graphics.DrawEllipse(klm, (400 + 1f * 100) - 5f, (250 - 2.25f * 100) - 5f, 10f, 10f);// 400 = width'in yarısı 250 = Height'in yarısı  
            graphics.DrawEllipse(klm, (400 + 3.5f * 100) - 5f, (250 - 0.75f * 100) - 5f, 10f, 10f);
            graphics.DrawEllipse(klm, (400 + 2.75f * 100) - 5f, (250 - 0.0f * 100) - 5f, 10f, 10f);
        }

        //eksini çiz 2.button 
        public void eksin_ciz()
        {
            System.Drawing.Graphics graphics;
            graphics = this.CreateGraphics();
            Pen klm = new Pen(System.Drawing.Color.Green, 200);
            klm.Color = Color.Red;
            klm.Width = 3;
            graphics.DrawLine(klm, 0, 250, 800, 250); // 800 = width // 250 = Height'in yarısı 
            graphics.DrawLine(klm, 400, 0, 400, 800); // 400 = width'in yarısı 
        }

        //Beziereğrisi  çiz 3.button 
        public void XY_Noktalari_hesapla()
        {
            System.Drawing.Graphics graphics;
            graphics = this.CreateGraphics();

            float[,] noktalar = { { 0, 0 }, { 1, 2.25f }, { 3.5f, 0.75f }, { 2.75f, 0 } };//verilen noktalar 
            Brush flc = new SolidBrush(System.Drawing.Color.Orange);
            float x = 0, y = 0;

            for (float u = 0; u < 1; u += 0.01f)
            {

                // x eksinin noktası hesapla 
                x = (float)((noktalar[0, 0] * Math.Pow(1 - u, 3)) + (noktalar[1, 0] * (3 * u) * Math.Pow(1 - u, 2)) + (noktalar[2, 0] * 3 * Math.Pow(u, 2) * (1 - u) + noktalar[3, 0] * Math.Pow(u, 3)));

                // y eksinin noktası hesapla 
                y = (float)((noktalar[0, 1] * Math.Pow(1 - u, 3)) + (noktalar[1, 1] * (3 * u) * Math.Pow(1 - u, 2)) + (noktalar[2, 1] * 3 * Math.Pow(u, 2) * (1 - u) + noktalar[3, 1] * Math.Pow(u, 3)));


                // bir point diziye ata 
                float[] point = { x, y };
                //noktaları çiz 
                graphics.FillEllipse(flc, (100 * point[0] + 400) - 2.5f, (250 - point[1] * 100) - 2.5f, 5f, 5f);

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            eksin_ciz();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nokta_ciz();
        }

        private void button3_Click(object sender, EventArgs e )
        {
            XY_Noktalari_hesapla();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
