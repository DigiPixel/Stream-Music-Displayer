using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SMD
{
    public enum MusicPlayers
    {
        None,
        Foobar2000,
        AIMP3,
        Winamp,
        VLC,
        WindowsMP,
        Spotify,
        Pandora,
        iTunes,
        MediaMonkey,
        Zune,
        Jriver,
        MPC,
        Grooveshark,
        Youtube,
        Soundcloud,
        Plug,
        Zaycev,
        EightTracks,
        Nightbot
    }

    class Finder
    {
        private List<ProcessInfo> ProcessList = new List<ProcessInfo>();

        [DllImport("User32.dll")]
        private static extern IntPtr FindWindow(string strClassName, string strWindowName);

        public Song get(MusicPlayers player)
        {
            Song song = new Song("No one", "None");
            ProcessInfo p;
            switch (player)
            {

                //
                //Program Titles
                //

                //Foobar
                case MusicPlayers.Foobar2000:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(.*) - \[(.*?)\] (.*?)   \[", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);

                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[1].ToString().Replace("  ", ""), m.Groups[3].ToString().Replace("  ", ""), m.Groups[2].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //AIMP3
                case MusicPlayers.AIMP3:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(.*) - (.*)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);

                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[1].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //MediaMonkey
                case MusicPlayers.MediaMonkey:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(\d)\. (.*?) - (.*?) - MediaMonkey", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[3].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //MPC
                case MusicPlayers.MPC:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        song = new Song(p.Title.Replace(".mp3", "").Replace(".wav", ""));
                    }
                    break;
                //Winamp
                case MusicPlayers.Winamp:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(\d)\. (.*?) - (.*?) - Winamp", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[3].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //VLC
                case MusicPlayers.VLC:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(.*?) - (.*?) - VLC media player", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[1].ToString().Replace("  ", ""), m.Groups[2].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //Spotify
                case MusicPlayers.Spotify:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=Spotify - )(.*?) – (.*)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        if (m.Success)
                        {
                            song = new Song(m.Groups[1].ToString().Replace("  ", ""), m.Groups[2].ToString().Replace("  ", ""));
                        }
                    }
                    break;

                //
                //Browsers
                //
                
                case MusicPlayers.Grooveshark:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=Grooveshark - )(.*?) by (.*?) - ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[1].ToString().Replace("  ", ""));
                        }
                    }
                    break;

                //Youtube
                case MusicPlayers.Youtube:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(.*?) - YouTube", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);

                        if (m.Success)
                        {
                            song = new Song(m.Groups[1].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //Soundcloud
                case MusicPlayers.Soundcloud:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=Soundcloud - )(.*?) - (.*?) - ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        if (m.Success)
                        {
                            song = new Song(m.Groups[1].ToString().Replace("  ", ""), m.Groups[2].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //Pandora
                case MusicPlayers.Pandora:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=Pandora - )(.*?) - (.*?) -", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        if (m.Success)
                        {
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[1].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //Plug.dj
                case MusicPlayers.Plug:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=Plug.dj - )(.*?) - (.*?) - (.*?) -", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);

                        if (m.Success)
                        {
                            MessageBox.Show(m.Groups[1].ToString());
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[1].ToString().Replace("  ", ""), m.Groups[3].ToString().Replace("  ", ""));
                        }
                        else
                        {
                            Regex r2 = new Regex(@"(?<=Plug.dj - )(.*?) - (.*?) - ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            Match m2 = r2.Match(p.Title);

                            if (m2.Groups[1].ToString() != "")
                            {
                                song = new Song(m2.Groups[2].ToString().Replace("  ", ""), m2.Groups[1].ToString().Replace("  ", ""));
                            }
                        }
                    }
                    break;
                //Zaycev.fm
                case MusicPlayers.Zaycev:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=Zaycev - )(.*?)  -  (.*?) -", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        if (m.Success)
                        {
                            song = new Song(m.Groups[1].ToString().Replace("  ", ""), m.Groups[2].ToString().Replace("  ", ""));
                        }
                    }
                    break;
                //8Tracks
                case MusicPlayers.EightTracks:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        Regex r = new Regex(@"(?<=tracks - )(.*?) - (.*?) -", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        Match m = r.Match(p.Title);
                        
                        //artist, title, album
                        if (m.Success)
                        {
                            song = new Song(m.Groups[2].ToString().Replace("  ", ""), m.Groups[1].ToString().Replace("  ", ""));
                        }
                    }
                    break;

                //
                //Custom APIs
                //
                case MusicPlayers.iTunes:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        API.iTunes info = new API.iTunes();
                        song =  info.GetCurrentPlayingSong();
                    }
                    break;
                case MusicPlayers.Nightbot:

                    break;
                case MusicPlayers.Zune:

                    break;
                case MusicPlayers.Jriver:

                    break;
                case MusicPlayers.WindowsMP:
                    p = getProcess(player);
                    if (p.Player != MusicPlayers.None)
                    {
                        API.WMPSongInfo info = new API.WMPSongInfo();
                        song =  info.GetCurrentPlayingSong();
                    }
                break;
            }

            return song;
        }


        private ProcessInfo getProcess(MusicPlayers player)
        {
            updateProcessList();
            foreach(ProcessInfo p in ProcessList){
                if (p.Player == player)
                    return p;
            }
            return new ProcessInfo("null","null", 0 , MusicPlayers.None);
        }


        private void updateProcessList()
        {
            ProcessList.Clear();
            Process[] Processes = Process.GetProcesses();
            foreach (Process Proc in Processes)
            {
                if (!String.IsNullOrEmpty(Proc.MainWindowTitle))
                {
                    //Spotify
                    if (Proc.ProcessName.Contains("spotify"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Spotify));

                    //Foobar2000
                    else if (Proc.ProcessName.Contains("foobar2000"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Foobar2000));

                    //AIMP3
                    else if (Proc.ProcessName.Contains("AIMP3"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.AIMP3));

                    //Winamp
                    else if (Proc.ProcessName.Contains("winamp"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Winamp));

                    //VLC
                    else if (Proc.ProcessName.Contains("vlc"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.VLC));

                    //Media Player Classic Home Cinema (mpc-hc)
                    else if (Proc.ProcessName.Contains("mpc-hc"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.MPC));

                    //Mediamonkey
                    else if (Proc.ProcessName.Contains("MediaMonkey"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.MediaMonkey));

                    //(wmplayer) Windows Media Player
                    else if (Proc.ProcessName.Contains("wmplayer"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.WindowsMP));

                    //iTunes
                    else if (Proc.ProcessName.Contains("iTunes"))
                        ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.iTunes));


                    //Browsers
                    else if (Proc.ProcessName.Contains("chrome") || Proc.ProcessName.Contains("firefox"))
                    {
                        //Grooveshark
                        if (Proc.MainWindowTitle.ToLower().Contains("grooveshark"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Grooveshark));

                        //Youtube
                        else if (Proc.MainWindowTitle.ToLower().Contains("youtube"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Youtube));

                        //Pandora
                        else if (Proc.MainWindowTitle.ToLower().Contains("pandora"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Pandora));

                        //Soundcloud
                        else if (Proc.MainWindowTitle.ToLower().Contains("soundcloud"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Soundcloud));

                        //Plug.dj
                        else if (Proc.MainWindowTitle.ToLower().Contains("plug"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Plug));

                        //Zaycev.fm
                        else if (Proc.MainWindowTitle.ToLower().Contains("zaycev"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.Zaycev));

                        //8tracks
                        else if (Proc.MainWindowTitle.ToLower().Contains("8tracks"))
                            ProcessList.Add(new ProcessInfo(Proc.ProcessName, Proc.MainWindowTitle, Proc.Id, MusicPlayers.EightTracks));
                    }
                }
            }
        }
    }

    public class ProcessInfo
    {
        public ProcessInfo(string name, string title, int pid, MusicPlayers player)
        {
            this.Name = name;
            this.Title = title;
            this.PID = pid;
            this.Player = player;
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public int PID { get; set; }
        public MusicPlayers Player { get; set; }
    }

    public class Song
    {
        public Song()
        {

        }

        public Song(string title)
        {
            this.Title = title;
        }

        public Song(string artist, string title)
        {
            this.Artist = artist;
            this.Title = title;
        }


        public Song(string artist, string title, string album)
        {
            this.Artist = artist;
            this.Title = title;
            this.Album = album;
        }

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
    }
}
