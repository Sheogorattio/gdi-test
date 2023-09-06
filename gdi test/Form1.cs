using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gdi_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen[] pens = { new Pen(Color.White, 1), new Pen(Color.Black, 1) };
            Pen pen = pens[0];
            Brush[] brushes = {new SolidBrush(Color.White),new SolidBrush(Color.Black)};
            Brush brush = brushes[0];
            bool change_pen = false;
            Rectangle[] rectangles = new Rectangle[64];
            int board_size = 8;
            int rect_size = 30;
            for(int i=0; i< board_size; i++)
            {
                for(int j=0; j< board_size; j++)
                {
                    rectangles[i * board_size + j] = new Rectangle(100 + j * rect_size, 100 + i * rect_size, rect_size, rect_size);

                    if (change_pen == false)
                    {
                        pen = pens[0];
                        brush = brushes[0];
                        change_pen = !change_pen;
                    }
                    else
                    {
                        pen = pens[1];
                        brush = brushes[1];
                        change_pen = !change_pen;
                    }
                    g.DrawRectangle(pen,rectangles[i * board_size + j]);
                    g.FillRectangle(brush, rectangles[i * board_size + j]);
                }
                (pens[0], pens[1]) = (pens[1], pens[0]);
                (brushes[0], brushes[1]) = (brushes[1], brushes[0]);
            }


            Brush black_figure = new SolidBrush(Color.Brown);
            Brush white_figure = new SolidBrush(Color.Blue);
            int[] start_block = { 0, 1 };
            for(int i=0; i<3; i++)
            {
                for (int j = start_block[1]; j < 8; j += 2)
                {
                    g.DrawEllipse(pens[1], rectangles[i * board_size + j]);
                    g.FillEllipse(black_figure, rectangles[i * board_size + j]);
                }
                (start_block[0], start_block[1]) = (start_block[1], start_block[0]);
            }

            for (int i = 5; i < 8; i++)
            {
                for (int j = start_block[1]; j < 8; j += 2)
                {
                    g.DrawEllipse(pens[1], rectangles[i * board_size + j]);
                    g.FillEllipse(white_figure, rectangles[i * board_size + j]);
                }
                (start_block[0], start_block[1]) = (start_block[1], start_block[0]);
            }
        }
    }
}
