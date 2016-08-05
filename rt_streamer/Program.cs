using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Net;
using System.IO.Compression;


namespace rt_streamer2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("rtStream.conf")) 
            {
                if (Environment.OSVersion.Platform == PlatformID.Unix) { } else
                {
                    

                }
                Application.EnableVisualStyles();
                Application.Run(new mainwindow());
            }
            else
            {

                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    MessageBox.Show("This program on it's own is licensed MIT while VLC and FFmpeg have their own (Compatable) licenses, a copy of this license is included with the program and the source code is available upon request or available at the same source of this program. I am not related to FFmpeg, VLC or Rooster Teeth, I am simply a fan of Rooster Teeth and someone who wanted to make a nice open source project. For now, you will need to install them from your package manager or compile and install from source");

                    string[] lines = {"vlc", "ffmpeg", "$HOME/videos", "rt_video.ts"};
                    DirectoryInfo di = Directory.CreateDirectory(lines[2]);
                    System.IO.File.WriteAllLines("rtStream.conf", lines);

                    Application.EnableVisualStyles();

                    Application.Run(new mainwindow());
                }
                else
                {
                    MessageBox.Show("This program on it's own is licensed MIT while VLC and FFmpeg have their own (Compatable) licenses, a copy of this license is included with the program and the source code is available upon request or available on my website. I am not related to FFmpeg, VLC or Rooster Teeth, I am simply a fan of Rooster Teeth and someone who wanted to make a nice open source project. To set up FFmpeg and VLC, use the instructions in the about page");

                    
                    string folder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string[] lines = { null, null, folder + "/videos", "normal" };
                    DirectoryInfo di = Directory.CreateDirectory(lines[2]);
                    File.WriteAllLines("rtStream.conf", lines);

                    Application.EnableVisualStyles();

                    Application.Run(new mainwindow());

                }
            }
        }

    }
            
}
