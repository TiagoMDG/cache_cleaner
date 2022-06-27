namespace Cache_Cleaner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkFFCookies = new System.Windows.Forms.CheckBox();
            this.checkFFCache = new System.Windows.Forms.CheckBox();
            this.btnRunTask = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkGCCookies = new System.Windows.Forms.CheckBox();
            this.checkGCCache = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkIECache = new System.Windows.Forms.CheckBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabelRecommended = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkFFCookies);
            this.groupBox1.Controls.Add(this.checkFFCache);
            this.groupBox1.Location = new System.Drawing.Point(15, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mozilla Firefox";
            // 
            // checkFFCookies
            // 
            this.checkFFCookies.AutoSize = true;
            this.checkFFCookies.Location = new System.Drawing.Point(7, 44);
            this.checkFFCookies.Name = "checkFFCookies";
            this.checkFFCookies.Size = new System.Drawing.Size(64, 17);
            this.checkFFCookies.TabIndex = 1;
            this.checkFFCookies.Text = "Cookies";
            this.checkFFCookies.UseVisualStyleBackColor = true;
            // 
            // checkFFCache
            // 
            this.checkFFCache.AutoSize = true;
            this.checkFFCache.Location = new System.Drawing.Point(7, 20);
            this.checkFFCache.Name = "checkFFCache";
            this.checkFFCache.Size = new System.Drawing.Size(57, 17);
            this.checkFFCache.TabIndex = 0;
            this.checkFFCache.Text = "Cache";
            this.checkFFCache.UseVisualStyleBackColor = true;
            // 
            // btnRunTask
            // 
            this.btnRunTask.Location = new System.Drawing.Point(528, 133);
            this.btnRunTask.Name = "btnRunTask";
            this.btnRunTask.Size = new System.Drawing.Size(119, 39);
            this.btnRunTask.TabIndex = 1;
            this.btnRunTask.Text = "Run Task";
            this.btnRunTask.UseVisualStyleBackColor = true;
            this.btnRunTask.Click += new System.EventHandler(this.btnRunTask_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 149);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(491, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.checkGCCookies);
            this.groupBox2.Controls.Add(this.checkGCCache);
            this.groupBox2.Location = new System.Drawing.Point(231, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 87);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Google Chrome";
            // 
            // checkGCCookies
            // 
            this.checkGCCookies.AutoSize = true;
            this.checkGCCookies.Location = new System.Drawing.Point(7, 44);
            this.checkGCCookies.Name = "checkGCCookies";
            this.checkGCCookies.Size = new System.Drawing.Size(64, 17);
            this.checkGCCookies.TabIndex = 1;
            this.checkGCCookies.Text = "Cookies";
            this.checkGCCookies.UseVisualStyleBackColor = true;
            // 
            // checkGCCache
            // 
            this.checkGCCache.AutoSize = true;
            this.checkGCCache.Location = new System.Drawing.Point(7, 20);
            this.checkGCCache.Name = "checkGCCache";
            this.checkGCCache.Size = new System.Drawing.Size(57, 17);
            this.checkGCCache.TabIndex = 0;
            this.checkGCCache.Text = "Cache";
            this.checkGCCache.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.checkIECache);
            this.groupBox3.Location = new System.Drawing.Point(447, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 87);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Internet Explorer";
            // 
            // checkIECache
            // 
            this.checkIECache.AutoSize = true;
            this.checkIECache.Location = new System.Drawing.Point(7, 20);
            this.checkIECache.Name = "checkIECache";
            this.checkIECache.Size = new System.Drawing.Size(181, 17);
            this.checkIECache.TabIndex = 0;
            this.checkIECache.Text = "Cache / Internet Temporary Files";
            this.checkIECache.UseVisualStyleBackColor = true;
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Location = new System.Drawing.Point(134, 133);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(252, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Waiting...";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 15);
            this.toolStripLabel1.Text = "Help";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 15);
            this.toolStripLabel2.Text = "About";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.logsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logsToolStripMenuItem.Text = "Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // linkLabelRecommended
            // 
            this.linkLabelRecommended.AutoSize = true;
            this.linkLabelRecommended.Location = new System.Drawing.Point(527, 119);
            this.linkLabelRecommended.Name = "linkLabelRecommended";
            this.linkLabelRecommended.Size = new System.Drawing.Size(120, 13);
            this.linkLabelRecommended.TabIndex = 11;
            this.linkLabelRecommended.TabStop = true;
            this.linkLabelRecommended.Text = "Recommended Settings";
            this.linkLabelRecommended.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRecommended_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 179);
            this.Controls.Add(this.linkLabelRecommended);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRunTask);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cache Cleaner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkFFCookies;
        private System.Windows.Forms.CheckBox checkFFCache;
        private System.Windows.Forms.Button btnRunTask;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkGCCookies;
        private System.Windows.Forms.CheckBox checkGCCache;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkIECache;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelRecommended;
    }
}

