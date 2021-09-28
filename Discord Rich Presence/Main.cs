using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_Rich_Presence
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Text = $"Discord Rich Presence By Wslt | Version 1.0";
            this.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            RPCTextbox.Text = Properties.Settings.Default.RPCID;
            DetailsTextbox.Text = Properties.Settings.Default.Details;
            StateTextbox.Text = Properties.Settings.Default.State;
            if (Properties.Settings.Default.TimeStamp == true)
                checkBox1.Checked = true;
        }
        private void DetailsTextbox_TextChanged(object sender, EventArgs e) => label2.Text = DetailsTextbox.Text;
        private void StateTextbox_TextChanged(object sender, EventArgs e) => label3.Text = StateTextbox.Text;
        private void button1_Click(object sender, EventArgs e)
        {
            RPC.SetRPC(DetailsTextbox.Text, StateTextbox.Text, checkBox1.Checked);
            Task.Run(() => {
                CheckForIllegalCrossThreadCalls = false;
                try
                {
                    pictureBox1.ImageLocation = RPC.UserPfp;
                    label1.Text = RPC.Username;
                }
                catch { pictureBox1.LoadAsync("https://www.galaxyswapperv2.com/Icons/InvalidIcon.png"); }
            });
            Properties.Settings.Default.RPCID = RPCTextbox.Text;
            Properties.Settings.Default.Details = DetailsTextbox.Text;
            Properties.Settings.Default.State = StateTextbox.Text;
            Properties.Settings.Default.TimeStamp = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
