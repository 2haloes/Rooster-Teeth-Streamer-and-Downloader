using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rt_streamer
{
    public partial class webbrowse : Form
    {
        public webbrowse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }


        //FFmpeg stream
        private void button4_Click(object sender, EventArgs e)
        {
            string webpage = null;
                webpage = webBrowser1.Url.ToString();

            using (var wc = new System.Net.WebClient())
            {
                webpage = wc.DownloadString(webpage);
            }


            string FFmpeg = ffmpegfile();
            webpage = findid(webpage);
            string file_name = filenameset();
            string playfile = OldOrNew(webpage);

            startffmpeg(FFmpeg, playfile, file_name);
        }



        // VLC stream
        private void button5_Click(object sender, EventArgs e)
        {
            string webpage = null;
            webpage = webBrowser1.Url.ToString();

            using (var wc = new System.Net.WebClient())
            {
                webpage = wc.DownloadString(webpage);
            }

            string vlc = vlcfile();
            webpage = findid(webpage);
            string playfile = OldOrNew(webpage);

            Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
            return;
        }


        // Launches FFmpeg and checks for OS
        public void startffmpeg(string FFmpeg, string playfile, string file_name)
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                Process ffmpeg_start = new Process();
                ffmpeg_start.StartInfo.FileName = FFmpeg;
                ffmpeg_start.StartInfo.Arguments = "-e ffmpeg -i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                ffmpeg_start.Start();
                ffmpeg_start.WaitForExit();
            }
            else
            {
                Process ffmpeg_start = new Process();
                ffmpeg_start.StartInfo.FileName = FFmpeg;
                ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                ffmpeg_start.Start();
                ffmpeg_start.WaitForExit();
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

        // Decide where to load FFmpeg, based on if there is a setting set for FFmpeg or not and the OS
        public string ffmpegfile()
        {
            string ffmpeg = null;
            string[] file_lines = File.ReadAllLines("rtStream.conf");
            if (file_lines[1] == "")
            {
                string location = Path.GetDirectoryName(Application.ExecutablePath);
                ffmpeg = location + "/ffmpeg/ffmpeg.exe";
            }
            else
            {
                ffmpeg = file_lines[1];
            }
            return ffmpeg;
        }

        // Decide where to load FFmpeg, based on if there is a setting set for FFmpeg or not and the OS
        public string vlcfile()
        {
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

        public string filenameset()
        {
            string[] file_lines = File.ReadAllLines("rtStream.conf");
            string file_name = file_lines[2] + "/" + textBox1.Text + ".ts";
            if (File.Exists(file_name))
            {
                string fn = Path.GetFileNameWithoutExtension(file_name);
                string fnExt = Path.GetExtension(file_name);
                int i = 1;
                do
                {
                    file_name = fn + i + fnExt;
                    i = i + 1;
                    file_name = file_lines[2] + "/" + file_name;
                } while (File.Exists(file_name));
            }
            return file_name;
        }
    }
    }
