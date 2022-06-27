using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Cache_Cleaner
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            linkLabelFFCache.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\" + ffProfile + "\\storage\\default";
            linkLabelFFCache2.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Mozilla\\Firefox\\" + ffProfile;
            linkLabelFFCookies.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\" + ffProfile + "\\cookies.sqlite";
            linkLabelGCCache.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache";
            linkLabelGCCache2.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache2\\entries";
            linkLabelGCCookies.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Cookies";
            linkLabelGCCookiesJ.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Cookies-journal";
            linkLabelGCMedia.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Media Cache";
            linkLabeliETF.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Microsoft\\Windows\\INetCache";
            linkLabeliETEMP.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp";
        }

        private static Process process = new Process();
        private static string ffProfile = MainForm.ffProfile;

        private void linkLabelFFCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findDirectoryOpen(linkLabelFFCache.Text);
        }

        private void linkLabelFFCache2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findDirectoryOpen(linkLabelFFCache2.Text);
        }

        private void linkLabelFFCookies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findFileOpen(linkLabelFFCookies.Text);
        }

        private void linkLabelGCCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findDirectoryOpen(linkLabelGCCache.Text);
        }

        private void linkLabelGCCache2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findDirectoryOpen(linkLabelGCCache2.Text);
        }

        private void linkLabelGCCookies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findFileOpen(linkLabelGCCookies.Text);
        }

        private void linkLabelGCCookiesJ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findFileOpen(linkLabelGCCookiesJ.Text);
        }

        private void linkLabelGCMedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findFileOpen(linkLabelGCMedia.Text);
        }

        private void linkLabeliETF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //findDirectoryOpen(linkLabeliETF.Text);
            MessageBox.Show("Directory currently disabled\nReason: It's considered a junction directory", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabeliETEMP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            findDirectoryOpen(linkLabeliETEMP.Text);
        }

        private void findDirectoryOpen(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Directory doesn't exist!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            process.StartInfo.FileName = (path);
            process.Start();
        }

        private void findFileOpen(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File doesn't exist!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start("explorer.exe", "/select, " + path);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.AliceBlue,
                                                                       Color.White,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
