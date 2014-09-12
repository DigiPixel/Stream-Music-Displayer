using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SMD
{
    [XmlRoot("PlayerList")]
    public class PlayerList
    {
        [XmlElement("Player")]
        public List<Player> Players { get; set; }
    }

    public class Player
    {
        [XmlElement("Nmae")]
        public string Name { get; set; }

        [XmlElement("Type")]
        public MusicPlayers Type { get; set; }

        [XmlElement("Enabled")]
        public bool Enabled { get; set; }
    }
}
