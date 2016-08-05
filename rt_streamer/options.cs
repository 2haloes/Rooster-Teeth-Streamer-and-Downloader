using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rt_streamer
{
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("rtStream.conf");
            lines[0] = textBox1.Text;
            lines[1] = textBox2.Text;
            lines[2] = textBox3.Text;
            File.WriteAllLines("rtStream.conf", lines);
            Close();
        }
    }
}
