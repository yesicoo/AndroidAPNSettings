namespace AndroidAPNSettings
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Set = new System.Windows.Forms.Panel();
            this.txt_PingResult = new System.Windows.Forms.TextBox();
            this.rdBtn_2G = new System.Windows.Forms.RadioButton();
            this.rdBtn_3G = new System.Windows.Forms.RadioButton();
            this.btn_Ping = new System.Windows.Forms.Button();
            this.btn_TelnetCheck = new System.Windows.Forms.Button();
            this.txt_TelnetPort = new System.Windows.Forms.TextBox();
            this.rdBtn_4G = new System.Windows.Forms.RadioButton();
            this.txt_PingURL = new System.Windows.Forms.TextBox();
            this.txt_TelnetURL = new System.Windows.Forms.TextBox();
            this.btn_CHANGE_NETWORK_MODE = new System.Windows.Forms.Button();
            this.btn_AddApn = new System.Windows.Forms.Button();
            this.btn_OpenAPNSetPage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Set.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(188, 11);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(93, 23);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "开始连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(13, 12);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(102, 21);
            this.txt_IP.TabIndex = 1;
            this.txt_IP.Text = "127.0.0.1";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(135, 12);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(47, 21);
            this.txt_Port.TabIndex = 1;
            this.txt_Port.Text = "57641";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(111, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // panel_Set
            // 
            this.panel_Set.Controls.Add(this.txt_PingResult);
            this.panel_Set.Controls.Add(this.rdBtn_2G);
            this.panel_Set.Controls.Add(this.label1);
            this.panel_Set.Controls.Add(this.rdBtn_3G);
            this.panel_Set.Controls.Add(this.btn_Ping);
            this.panel_Set.Controls.Add(this.btn_TelnetCheck);
            this.panel_Set.Controls.Add(this.txt_TelnetPort);
            this.panel_Set.Controls.Add(this.rdBtn_4G);
            this.panel_Set.Controls.Add(this.txt_PingURL);
            this.panel_Set.Controls.Add(this.txt_TelnetURL);
            this.panel_Set.Controls.Add(this.btn_CHANGE_NETWORK_MODE);
            this.panel_Set.Controls.Add(this.btn_AddApn);
            this.panel_Set.Controls.Add(this.btn_OpenAPNSetPage);
            this.panel_Set.Location = new System.Drawing.Point(2, 40);
            this.panel_Set.Name = "panel_Set";
            this.panel_Set.Size = new System.Drawing.Size(290, 334);
            this.panel_Set.TabIndex = 3;
            // 
            // txt_PingResult
            // 
            this.txt_PingResult.BackColor = System.Drawing.Color.Black;
            this.txt_PingResult.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PingResult.ForeColor = System.Drawing.Color.Yellow;
            this.txt_PingResult.Location = new System.Drawing.Point(5, 161);
            this.txt_PingResult.Multiline = true;
            this.txt_PingResult.Name = "txt_PingResult";
            this.txt_PingResult.Size = new System.Drawing.Size(273, 173);
            this.txt_PingResult.TabIndex = 3;
            // 
            // rdBtn_2G
            // 
            this.rdBtn_2G.AutoSize = true;
            this.rdBtn_2G.Location = new System.Drawing.Point(133, 75);
            this.rdBtn_2G.Name = "rdBtn_2G";
            this.rdBtn_2G.Size = new System.Drawing.Size(47, 16);
            this.rdBtn_2G.TabIndex = 1;
            this.rdBtn_2G.Text = "仅2G";
            this.rdBtn_2G.UseVisualStyleBackColor = true;
            // 
            // rdBtn_3G
            // 
            this.rdBtn_3G.AutoSize = true;
            this.rdBtn_3G.Location = new System.Drawing.Point(73, 75);
            this.rdBtn_3G.Name = "rdBtn_3G";
            this.rdBtn_3G.Size = new System.Drawing.Size(59, 16);
            this.rdBtn_3G.TabIndex = 1;
            this.rdBtn_3G.Text = "3G优先";
            this.rdBtn_3G.UseVisualStyleBackColor = true;
            // 
            // btn_Ping
            // 
            this.btn_Ping.Location = new System.Drawing.Point(186, 132);
            this.btn_Ping.Name = "btn_Ping";
            this.btn_Ping.Size = new System.Drawing.Size(93, 23);
            this.btn_Ping.TabIndex = 0;
            this.btn_Ping.Text = "Ping";
            this.btn_Ping.UseVisualStyleBackColor = true;
            this.btn_Ping.Click += new System.EventHandler(this.btn_Ping_Click);
            // 
            // btn_TelnetCheck
            // 
            this.btn_TelnetCheck.Location = new System.Drawing.Point(185, 104);
            this.btn_TelnetCheck.Name = "btn_TelnetCheck";
            this.btn_TelnetCheck.Size = new System.Drawing.Size(93, 23);
            this.btn_TelnetCheck.TabIndex = 0;
            this.btn_TelnetCheck.Text = "Telnet检查";
            this.btn_TelnetCheck.UseVisualStyleBackColor = true;
            this.btn_TelnetCheck.Click += new System.EventHandler(this.btn_TelnetCheck_Click);
            // 
            // txt_TelnetPort
            // 
            this.txt_TelnetPort.Location = new System.Drawing.Point(128, 106);
            this.txt_TelnetPort.Name = "txt_TelnetPort";
            this.txt_TelnetPort.Size = new System.Drawing.Size(47, 21);
            this.txt_TelnetPort.TabIndex = 1;
            this.txt_TelnetPort.Text = "80";
            // 
            // rdBtn_4G
            // 
            this.rdBtn_4G.AutoSize = true;
            this.rdBtn_4G.Checked = true;
            this.rdBtn_4G.Location = new System.Drawing.Point(10, 75);
            this.rdBtn_4G.Name = "rdBtn_4G";
            this.rdBtn_4G.Size = new System.Drawing.Size(59, 16);
            this.rdBtn_4G.TabIndex = 1;
            this.rdBtn_4G.TabStop = true;
            this.rdBtn_4G.Text = "4G优先";
            this.rdBtn_4G.UseVisualStyleBackColor = true;
            // 
            // txt_PingURL
            // 
            this.txt_PingURL.Location = new System.Drawing.Point(3, 133);
            this.txt_PingURL.Name = "txt_PingURL";
            this.txt_PingURL.Size = new System.Drawing.Size(172, 21);
            this.txt_PingURL.TabIndex = 1;
            this.txt_PingURL.Text = "www.baidu.com";
            // 
            // txt_TelnetURL
            // 
            this.txt_TelnetURL.Location = new System.Drawing.Point(5, 106);
            this.txt_TelnetURL.Name = "txt_TelnetURL";
            this.txt_TelnetURL.Size = new System.Drawing.Size(102, 21);
            this.txt_TelnetURL.TabIndex = 1;
            this.txt_TelnetURL.Text = "www.baidu.com";
            // 
            // btn_CHANGE_NETWORK_MODE
            // 
            this.btn_CHANGE_NETWORK_MODE.Location = new System.Drawing.Point(186, 72);
            this.btn_CHANGE_NETWORK_MODE.Name = "btn_CHANGE_NETWORK_MODE";
            this.btn_CHANGE_NETWORK_MODE.Size = new System.Drawing.Size(92, 23);
            this.btn_CHANGE_NETWORK_MODE.TabIndex = 0;
            this.btn_CHANGE_NETWORK_MODE.Text = "设置网络模式";
            this.btn_CHANGE_NETWORK_MODE.UseVisualStyleBackColor = true;
            this.btn_CHANGE_NETWORK_MODE.Click += new System.EventHandler(this.btn_CHANGE_NETWORK_MODE_Click);
            // 
            // btn_AddApn
            // 
            this.btn_AddApn.Location = new System.Drawing.Point(5, 43);
            this.btn_AddApn.Name = "btn_AddApn";
            this.btn_AddApn.Size = new System.Drawing.Size(273, 23);
            this.btn_AddApn.TabIndex = 0;
            this.btn_AddApn.Text = "添加APN";
            this.btn_AddApn.UseVisualStyleBackColor = true;
            this.btn_AddApn.Click += new System.EventHandler(this.btn_AddApn_Click);
            // 
            // btn_OpenAPNSetPage
            // 
            this.btn_OpenAPNSetPage.Location = new System.Drawing.Point(5, 8);
            this.btn_OpenAPNSetPage.Name = "btn_OpenAPNSetPage";
            this.btn_OpenAPNSetPage.Size = new System.Drawing.Size(273, 29);
            this.btn_OpenAPNSetPage.TabIndex = 0;
            this.btn_OpenAPNSetPage.Text = "打开APN设置界面";
            this.btn_OpenAPNSetPage.UseVisualStyleBackColor = true;
            this.btn_OpenAPNSetPage.Click += new System.EventHandler(this.btn_OpenAPNSetPage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(118, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 386);
            this.Controls.Add(this.panel_Set);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.btn_Connect);
            this.Name = "MainForm";
            this.Text = "APN Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_Set.ResumeLayout(false);
            this.panel_Set.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Set;
        private System.Windows.Forms.Button btn_OpenAPNSetPage;
        private System.Windows.Forms.Button btn_AddApn;
        private System.Windows.Forms.Button btn_CHANGE_NETWORK_MODE;
        private System.Windows.Forms.RadioButton rdBtn_2G;
        private System.Windows.Forms.RadioButton rdBtn_3G;
        private System.Windows.Forms.RadioButton rdBtn_4G;
        private System.Windows.Forms.Button btn_TelnetCheck;
        private System.Windows.Forms.TextBox txt_TelnetPort;
        private System.Windows.Forms.TextBox txt_TelnetURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Ping;
        private System.Windows.Forms.TextBox txt_PingURL;
        private System.Windows.Forms.TextBox txt_PingResult;
    }
}

