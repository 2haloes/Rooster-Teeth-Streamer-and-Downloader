using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace rt_streamer2
{
    public partial class stream : Form
    {
        public stream()
        {


            InitializeComponent();
            comboBox1.SelectedIndex = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog findpage = new OpenFileDialog();
            findpage.Filter = "Rooster Teeth web page|*.html;*.htm";
            findpage.FilterIndex = 1;
            DialogResult result = findpage.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox2.Text = "";
                textBox2.Text = findpage.FileName;
            }



        }
        private void button2_Click(object sender, EventArgs e)
        {
            string quality = comboBox1.Text;
            //Text box 1 filled
            if (textBox2.Text == "" && textBox3.Text == "")
            {

                string vlc = vlcfile();
                string webpage = textBox1.Text;
                string playfile = OldOrNew(webpage);

                Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
                return;
            //Text box 2 filled
            } else if (textBox1.Text == "" && textBox3.Text == "")  {

                string vlc = vlcfile();

                    string webpage = File.ReadAllText(textBox2.Text);

                    webpage = findid(webpage);

                string playfile = OldOrNew(webpage);
                    Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
                return;
            //Text box 3 filled
            }
            else if (textBox1.Text == "" && textBox2.Text == ""){

                string webpage = null;
                using (var wc = new System.Net.WebClient())
                {
                    webpage = wc.DownloadString(textBox3.Text);
                }
                string vlc = vlcfile();
                webpage = findid(webpage);
                string playfile = OldOrNew(webpage);
                
                    Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
                return;
                } else
            {
                MessageBox.Show("Please only enter a value into one textbox");
            }
            }

        // Check weather the URL is of the old or the new format (There is a difference)
        public string OldOrNew(string id)
        {
            string webpage = id;
            string playfile = "http://wpc.1765A.taucdn.net/801765A/video/uploads/videos/" + webpage + "/NewHLS-" + comboBox1.Text + "P.m3u8";

           try
            {
                WebClient downloader = new WebClient();
                downloader.DownloadFile(playfile, "test.m3u8");
            }
            catch (WebException)
            {
                if (comboBox1.Text == "360")
                {
                    playfile = playfile.Replace("NewHLS-360", "480");
                }
                else
                {
                    playfile = playfile.Replace("NewHLS-" + comboBox1.Text, comboBox1.Text);
                }
            }
            playfile = playfile.Insert(4, "s");
            return playfile;
        }

        // Decide where to load VLC, based on if there is a setting set for VLC or not
            public string vlcfile() {
                string vlc = null;
                string[] file_lines = File.ReadAllLines("rtStream.conf");
                if (file_lines[0] == "")
                {
                    string location = Path.GetDirectoryName(Application.ExecutablePath);
                    vlc = location + "/vlc/vlc.exe";
                }
                else
                {
                    vlc = file_lines[0];
                }
                return vlc;
            }
            

        // Find the video ID within a page if a URL or a HTML file were selected
        public string findid(string fullpage)
        {
            string webpage = fullpage;
            int checkchar = 0;
            checkchar = webpage.IndexOf("file: ");
            if (checkchar == -1)
            {
                MessageBox.Show("The webpage you have input is invalid. It either isn't a rooster teeth page or it is for (first) members only. This doesn't let you bypass those requirements and you should sign up if you REALLY want that content");
                return "";
            }
            checkchar = checkchar + 64;
            webpage = webpage.Remove(0, checkchar);
            webpage = webpage.Remove(webpage.IndexOf('/'));
            return webpage;
        }
          
        
        
         
        }

        }