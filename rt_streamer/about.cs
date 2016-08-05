using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rt_streamer2
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.videolan.org/vlc/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.ffmpeg.org");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.roosterteeth.com");
        }
    }
}
