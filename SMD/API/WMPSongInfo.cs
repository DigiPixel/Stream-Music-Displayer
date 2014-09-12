using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;

namespace SMD.API
{
    public class WMPSongInfo
    {
        [DllImport("User32.dll")]
        private static extern IntPtr FindWindow(string strClassName, string strWindowName);

        public Song GetCurrentPlayingSong()
        {
            try
            {
                // Finding the WMP window
                IntPtr handle = FindWindow("WMPlayerApp", "Windows Media Player");
                if (handle == IntPtr.Zero)
                    throw new InvalidOperationException("Windows Media Player window not found.");

                TreeWalker walker = TreeWalker.ControlViewWalker;
                // Whole WMP window
                AutomationElement wmpPlayer = AutomationElement.FromHandle(handle);
                AutomationElement wmpAppHost = walker.GetFirstChild(wmpPlayer);
                AutomationElement wmpSkinHost = walker.GetFirstChild(wmpAppHost);
                // All emements in WMP window
                AutomationElement wmpContainer = walker.GetFirstChild(wmpSkinHost);
                // Container with song informations
                AutomationElement wmpSongInfo = walker.GetFirstChild(wmpContainer);

                if (wmpSongInfo == null)
                    throw new InvalidOperationException("Unable to find CWMPControlCntr in Windows Media Player Window. Try to switch to full view.");

                // Iterating throung all components in container - searching for container with song informations
                while (wmpSongInfo.Current.ClassName != "CWmpControlCntr")
                {
                    wmpSongInfo = walker.GetNextSibling(wmpSongInfo);

                    if (wmpSongInfo == null)
                        break;
                }

                // Walking throung childs (image, hyperlink, song info etc.)
                List<AutomationElement> info = GetChildren(wmpSongInfo);
                info = GetChildren(info[0]);
                info = GetChildren(info[1]);
                info = GetChildren(info[2]);

                // Obtaining elements with desired informations
                AutomationElement songE = info[0];
                AutomationElement albumE = info[3];
                AutomationElement artistE = info[4];

                string name = songE.Current.Name;
                string album = albumE.Current.Name;
                string artist = artistE.Current.Name;

                return new Song(artist, name, album);
            }
            catch (Exception e)
            {
                return new Song("Error Loading Track Infromation");
            }
        }

        // Returns all child AutomationElement nodes in "element" node
        private List<AutomationElement> GetChildren(AutomationElement element)
        {
            List<AutomationElement> result = new List<AutomationElement>();
            TreeWalker walker = TreeWalker.ControlViewWalker;
            AutomationElement child = walker.GetFirstChild(element);
            result.Add(child);

            while (child != null)
            {
                child = walker.GetNextSibling(child);
                result.Add(child);
            }

            return result;
        }
    }
}
