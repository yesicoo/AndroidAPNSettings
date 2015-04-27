using LiteSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndroidAPNSettings
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void btn_Connect_Click(object sender, EventArgs e)
        {
            var result = CommandHelper.instance.Connect(this.txt_IP.Text, int.Parse(this.txt_Port.Text));
            if (!result)
            {
                MessageBox.Show("连接失败！");
                panel_Set.Enabled = false;
            }
            else
            {
                panel_Set.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel_Set.Enabled = false;
            CommandHelper.instance.AdbForward(this.txt_Port.Text);
        }

        private void btn_OpenAPNSetPage_Click(object sender, EventArgs e)
        {
            CommandHelper.instance.OpenApnPage();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommandHelper.instance.Close();
        }

        private void btn_AddApn_Click(object sender, EventArgs e)
        {

            MessageBox.Show(CommandHelper.instance.AddApn("ZApnName", "APN").ToString());
        }

        private void btn_CHANGE_NETWORK_MODE_Click(object sender, EventArgs e)
        {
            string netMode = rdBtn_4G.Checked ? "4G" : (rdBtn_3G.Checked ? "3G" : "2G");
            MessageBox.Show(CommandHelper.instance.ChangeNetMode(netMode).ToString());
            //

        }

        private void btn_TelnetCheck_Click(object sender, EventArgs e)
        {
            var result = CommandHelper.instance.DoTelnet(this.txt_TelnetURL.Text, this.txt_TelnetPort.Text);
            MessageBox.Show(result.ToString());
        }

        private void btn_Ping_Click(object sender, EventArgs e)
        {
            this.txt_PingResult.Text = "Ping " + this.txt_PingURL.Text + " ......";
            var result = CommandHelper.instance.DoPing(this.txt_PingURL.Text);
            this.txt_PingResult.Text = result;
        }




    }
}
