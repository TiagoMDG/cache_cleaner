using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace Cache_Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + @"\logs");

            /*CustomToolStripRenderer r = new CustomToolStripRenderer();
            r.RoundedEdges = false;
            menuStrip1.Renderer = r;*/
        }

        private void btnRunTask_Click(object sender, EventArgs e)
        {
            List<string> pathList = new List<string>();
            List<string> fileList = new List<string>();
            string[] filesArray = new string[] {};

            if (Process.GetProcessesByName("firefox").Length > 0)
            {
                MessageBox.Show("Firefox must be shutdown before trying again", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkFFCache.Checked)
            {
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\" + getFFprofile() + "\\storage\\default");
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Mozilla\\Firefox\\" + getFFprofile());
            }

            if (checkFFCookies.Checked)
            {
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\" + getFFprofile() + "\\cookies.sqlite");
            }

            if (checkGCCache.Checked)
            {
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");
            }

            if (checkGCCookies.Checked)
            {
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Cookies");
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Cookies-journal");
            }

            if (checkIECache.Checked)
            {
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Microsoft\\Windows\\INetCache");
            }

            if (!(fileList.Count > 0 || pathList.Count > 0))
            {
                MessageBox.Show("Nothing Selected!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            filesArray = fileList.ToArray();
            RemoveFiles(pathList, filesArray);
        }

        private void RemoveFiles(List<string> pathList, string[] fileList)
        {
            string[] fileArray = new string[] {};
            string[] directoryArray = new string[] {};
            List<string> confirmedList = new List<string>();

            Logger log = new Logger();
            log.startLog();

            ThreadPool.QueueUserWorkItem((o) =>
            {
                foreach (string path in pathList)
                {
                    if (Directory.Exists(path))
                    {
                        string[] fileNames = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                        fileArray = fileArray.Union(fileNames).ToArray();
                        string[] directories = Directory.GetDirectories(path);
                        directoryArray = directoryArray.Union(directories).ToArray();
                    }
                }

                foreach (string file in fileList)
                {
                    if (File.Exists(file))
                    {
                        confirmedList.Add(file);   
                    }
                }

                if (fileArray.Length > 0) //This block deletes all files from selected directories
                {
                    this.BeginInvoke(new Action(() =>
                            {
                                progressBar1.Minimum = 0;
                                progressBar1.Value = 1;
                                progressBar1.Maximum = fileArray.Length;
                                progressBar1.Step = 1;
                            }));

                    foreach (String file in fileArray)
                    {
                        File.Delete(file);
                        Thread.Sleep(1);

                        this.BeginInvoke(new Action(() =>
                        {
                            log.writeLog(file);
                            progressLabel.Text = "Deleting Files: " + Convert.ToString(progressBar1.Value) + "/" + Convert.ToString(progressBar1.Maximum);
                        }));
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep()));
                    } 
                }

                if (directoryArray.Length > 0) //This block deletes leftover directories from the previous action
                {
                    this.BeginInvoke(new Action(() =>
                            {
                                progressBar1.Value = 1;
                                progressBar1.Maximum = directoryArray.Length;
                            }));

                    foreach (String dir in directoryArray)
                    {
                        Directory.Delete(dir, true);
                        Thread.Sleep(1);

                        this.BeginInvoke(new Action(() =>
                        {
                            log.writeLog(dir);
                            progressLabel.Text = "Deleting Directories: " + Convert.ToString(progressBar1.Value) + "/" + Convert.ToString(progressBar1.Maximum);
                        }));
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep()));
                    }
                } 

                if (confirmedList.Count > 0) //This block deletes standalone files (Cookies, etc.)
                {
                    this.BeginInvoke(new Action(() =>
                            {
                                progressBar1.Value = 1;
                                progressBar1.Maximum = confirmedList.Count;
                            }));

                    foreach (String file in confirmedList)
                    {
                        File.Delete(file);
                        Thread.Sleep(1);

                        this.BeginInvoke(new Action(() =>
                        {
                            log.writeLog(file);
                            progressLabel.Text = "Deleting Files: " + Convert.ToString(progressBar1.Value) + "/" + Convert.ToString(progressBar1.Maximum);
                        }));
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep()));
                    } 
                }
                this.BeginInvoke(new Action(() =>
                {
                    log.closeLog();
                    MessageBox.Show("Task Finished!", "Jobs done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }, null);
        }

        private string getFFprofile()
        {
            string aux, profile;
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\profiles.ini");
            foreach (var value in data.Sections)
            {
                if (value.SectionName.Contains("Install"))
                    foreach (KeyData key in value.Keys)
                    {
                        if (key.KeyName == "Default")
                        {
                            aux = key.Value;
                            return profile = aux.Replace("/", "\\");
                        }
                    }
            }
            return null;
        }

        /*protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.AliceBlue,
                                                                       Color.White,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }*/
    }
}
