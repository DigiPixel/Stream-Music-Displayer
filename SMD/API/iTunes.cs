using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTunesLib;

namespace SMD.API
{
    public class iTunes
    {
        public Song GetCurrentPlayingSong()
        {
            try
            {
                iTunesApp app = new iTunesAppClass();
                IITTrack track = app.CurrentTrack;
                return new Song(track.Artist, track.Name);
            }
            catch (Exception e)
            {
                return new Song("Error Loading Track Infromation");
            }
        }
    }
}
