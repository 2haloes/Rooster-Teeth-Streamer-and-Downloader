using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using rt_streamer;

namespace rt_streamer2
{
    public partial class mainwindow : Form
    {
        public mainwindow()
        {
            InitializeComponent();
            }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's a streamer, downloader and slight easter egger");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stream stream = new rt_streamer2.stream();
            stream.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            download DL = new download();
            DL.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            options OP = new options();
            OP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webbrowse web = new webbrowse();
            web.Show();
        }
    }
}
