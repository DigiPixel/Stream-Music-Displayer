using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SMD
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        PlayerList Plist;
        PlayerList NewList;

        private void Options_Load(object sender, EventArgs e)
        {
            output_location.Text = SMD.Properties.Settings.Default.OutputFile;
            formatbox.Text = SMD.Properties.Settings.Default.OutFormat;
            numericRefrsh.Value = SMD.Properties.Settings.Default.RefeshRate;

            using (Stream s = File.OpenRead("Players.xml"))
            {
                Plist = (PlayerList)new XmlSerializer(typeof(PlayerList)).Deserialize(s);
            }

            foreach (Player p in Plist.Players)
            {
                if(p.Enabled)
                    enabledList.Items.Add(p.Name);
                else
                    disabledList.Items.Add(p.Name);
            }

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            SMD.Properties.Settings.Default.OutputFile = output_location.Text;
            SMD.Properties.Settings.Default.OutFormat = formatbox.Text;
            SMD.Properties.Settings.Default.RefeshRate = (int)numericRefrsh.Value;
            SMD.Properties.Settings.Default.Save();

            NewList = new PlayerList();
            NewList.Players = new List<Player>();
            foreach (var Item in disabledList.Items)
            {
                string ItemName = Item.ToString();
                foreach (Player Plr in Plist.Players)
                {
                    if (ItemName == Plr.Name)
                    {
                        Player i = new Player();
                        i.Name = Plr.Name;
                        i.Type = Plr.Type;
                        i.Enabled = false;
                        
                        NewList.Players.Add(i);
                    }
                }
            }

            foreach (var Item in enabledList.Items)
            {
                string ItemName = Item.ToString();
                foreach (Player Plr in Plist.Players)
                {
                    if (ItemName == Plr.Name)
                    {
                        Player i = new Player();
                        i.Name = Plr.Name;
                        i.Type = Plr.Type;
                        i.Enabled = true;

                        NewList.Players.Add(i);
                    }
                }
            }

            File.Delete("Players.xml");
            using (Stream s = File.Create("Players.xml"))
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(PlayerList));
                Serializer.Serialize(s, NewList);
            }

            this.Close();
        }

        private void browsbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Properties.Settings.Default.OutputFile;
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                output_location.Text = sfd.FileName;
        }

        private void movetod_Click(object sender, EventArgs e)
        {
            foreach (var Item in enabledList.Items)
            {
                disabledList.Items.Add(Item.ToString());
            }

            enabledList.Items.Clear();
        }

        private void movetoe_Click(object sender, EventArgs e)
        {
            foreach (var Item in disabledList.Items)
            {
                enabledList.Items.Add(Item.ToString());
            }

            disabledList.Items.Clear();
        }

        private void moveonee_Click(object sender, EventArgs e)
        {
            if (disabledList.SelectedIndex > -1)
            {
                enabledList.Items.Add(disabledList.Items[disabledList.SelectedIndex].ToString());
                disabledList.Items.RemoveAt(disabledList.SelectedIndex);
            }
        }

        private void moveoned_Click(object sender, EventArgs e)
        {
            if (enabledList.SelectedIndex > -1)
            {
                disabledList.Items.Add(enabledList.Items[enabledList.SelectedIndex].ToString());
                enabledList.Items.RemoveAt(enabledList.SelectedIndex);
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            SMD.Properties.Settings.Default.Reset();
            output_location.Text = SMD.Properties.Settings.Default.OutputFile;
            formatbox.Text = SMD.Properties.Settings.Default.OutFormat;
            numericRefrsh.Value = SMD.Properties.Settings.Default.RefeshRate;
        }

        private void updatesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string ver;

                var webRequest = WebRequest.Create(@"https://dl.dropboxusercontent.com/u/37497632/SMD/ver.txt");
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    ver = reader.ReadToEnd();
                }

                if (ver != Assembly.GetExecutingAssembly().GetName().Version.ToString())
                {
                    if (MessageBox.Show("A new update is avalible! You have '" + Assembly.GetExecutingAssembly().GetName().Version.ToString()  + "'. Version '" + ver + "' is avalible. Would you like to download it?") == System.Windows.Forms.DialogResult.OK)
                    {
                        var webRequest2 = WebRequest.Create(@"https://dl.dropboxusercontent.com/u/37497632/SMD/dl.txt");
                        using (var response = webRequest2.GetResponse())
                        using (var content = response.GetResponseStream())
                        using (var reader = new StreamReader(content))
                        {
                            Process.Start(reader.ReadToEnd());
                        }
                    }

                }
                else { MessageBox.Show("You're Up To Date!"); }
            }
            catch (Exception ex) { MessageBox.Show("Unable to check for update."); }
        }
    }
}
