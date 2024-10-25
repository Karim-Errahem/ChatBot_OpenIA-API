﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot1.ChatItems
{
    public partial class OutGoing : UserControl
    {
        

        public OutGoing()
        {
            InitializeComponent();
            AdjustHeight();
        }

        public string Message
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
                AdjustHeight();
            }
        }

        private void AdjustHeight()
        {
            int preferredHeight = TextRenderer.MeasureText(label1.Text, label1.Font, new Size(label1.Width, int.MaxValue), TextFormatFlags.WordBreak).Height + label1.Margin.Vertical;

            



            label1.Height = preferredHeight + 10;
            bunifuUserControl1.Height = label1.Top + bunifuUserControl1.Top + label1.Height;
            this.Height = bunifuUserControl1.Bottom + 10;
        }

        public Image Avatar { get => bunifuPictureBox1.Image; set => bunifuPictureBox1.Image = value; }

        private void OutGoing_Resize(object sender, EventArgs e)
        {
            AdjustHeight();
        }
    }
}
