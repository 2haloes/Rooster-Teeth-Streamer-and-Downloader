# Rooster-Teeth-Streamer-and-Downloader
This is a simple frontend to FFmpeg and VLC that allows users to stream and download Rooster Teeth videos though a few different ways being, from the video id, the HTML file that can be download though most web browsers, the url of the page (Public videos only) and a web browser (Not working in Linux (Mono or Wine) and for public videos only)

This program is licensed under MIT, however, there will be a version coming as soon as this hits version 1.0 that will be more of a base and can run on whatever anyone wants

This program requires the .Net framework 4.5 (https://www.microsoft.com/en-us/download/details.aspx?id=30653) for Windows or Mono/Wine for Linux

NOTE: This requires FFmpeg to download and VLC to stream, for Windows, you will need to download them and link to them in the options menu, in Linux, you can install from a package manager (However the Ubuntu version of FFmpeg is acting a bit strange but that my be due to using WiFi0

Linux users: In the oprions menu, instead of linking to FFmpeg, you need to input the terminal emulator being used (xterm, konsole, lxterminal etc), for now, I don't really have any clue as to how to get it to work better. Also, the save folder is a bit messed up for now (It saves to an odd folder if the save folder option is untoutched), version 1.0 will likely being the Linux running version upto the standards of the Windows version

WIP features: 
Anything that doesn't work in Linux (Web browser, some labels being wrong)
Improve on the web browser, possibly allow to download the HTML file from inside the browser to use
Clean everything up a bit

Known issues:
Linux support is a bit bad, I will try to fix this as quickly as possible, however, my enthernet connection decided to die on me so I can't test with different OS' and some things that didn't work in Ubuntu did work in Arch

This program was created with Visual Studio Community 2015 but is also compatable with Mono-Develop if you would like to edit or complile the program for yourself
