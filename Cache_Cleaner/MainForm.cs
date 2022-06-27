using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Cache_Cleaner
{
    public partial class MainForm : Form
    {
        private static WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        private bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);
        private static string logPath = Environment.CurrentDirectory + @"\Cache Cleaner Logs\";
        public static string ffProfile = firefoxProfile.get();

        public MainForm()
        {
            InitializeComponent();
            DirectoryInfo di = Directory.CreateDirectory(logPath);

            /*CustomToolStripRenderer r = new CustomToolStripRenderer();
            r.RoundedEdges = false;
            menuStrip1.Renderer = r;*/
        }

        private void btnRunTask_Click(object sender, EventArgs e)
        {
            List<string> pathList = new List<string>();
            List<string> fileList = new List<string>();
            string[] filesArray = new string[] {};

            if (Process.GetProcessesByName("firefox").Length > 0) //Checking if Mozilla Firefox is running
            {
                MessageBox.Show("Firefox must be shutdown before trying again", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Process.GetProcessesByName("chrome").Length > 0) //Checking if Google Chrome is running
            {
                MessageBox.Show("Google Chrome must be shutdown before trying again", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkFFCache.Checked)
            {
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\" + ffProfile + "\\storage\\default");
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Mozilla\\Firefox\\" + ffProfile);
            }

            if (checkFFCookies.Checked)
            {
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\" + ffProfile + "\\cookies.sqlite");
            }

            if (checkGCCache.Checked)
            {
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache2\\entries");
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Media Cache");
            }

            if (checkGCCookies.Checked)
            {
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Cookies");
                fileList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Network\\Cookies-journal");
            }

            if (checkIECache.Checked)
            {
                if (!hasAdministrativeRight) //Checking to see if the program has Administrative Rights
                {
                    var option = MessageBox.Show("You must run the application as administrator.\nDo you want to do it now?", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult.Yes == option)
                    {
                        RunElevated(Application.ExecutablePath);
                        this.Close();
                        Application.Exit();
                    }
                    return;
                }
                //pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Microsoft\\Windows\\INetCache"); Disabled due to being a junction file.
                pathList.Add("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp");
            } 

            if (!(fileList.Count > 0 || pathList.Count > 0)) //Checks if any of the boxes were checked by counting the number of elements in the lists
            {
                MessageBox.Show("Nothing Selected!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            filesArray = fileList.ToArray();
            RemoveFiles(pathList, filesArray);
        }

        private static bool RunElevated(string executablePath) //Function for administrative rights
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.Verb = "runas";
            processInfo.FileName = executablePath;
            try
            {
                Process.Start(processInfo);
                return true;
            }
            catch (Win32Exception)
            {
                //Do nothing. Probably the user canceled the UAC window
            }
            return false;
        }

        private void RemoveFiles(List<string> pathList, string[] fileList)
        {
            string[] fileArray = new string[] {};
            string[] directoryArray = new string[] {};
            List<string> confirmedList = new List<string>();
            int errors = 0;
            int success = 0;

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

                if (confirmedList.Count <= 0 && fileArray.Length <= 0 && directoryArray.Length <= 0)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        log.writeLog("Nothing to delete");
                        log.closeLog(errors);
                        MessageBox.Show("Nothing to delete.", "Jobs done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    return;
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
                        try
                        {
                            File.Delete(file);
                            success++;
                        }
                        catch (Exception)
                        {
                            log.writeLog("ERROR Deleting - " + file);
                            errors++;
                        }
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
                        try
                        {
                            Directory.Delete(dir, true);
                            success++;
                        }
                        catch (Exception)
                        {
                            log.writeLog("ERROR Deleting - " + dir);
                            errors++;
                        }
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
                        try
                        {
                            File.Delete(file);
                            success++;
                        }
                        catch (Exception)
                        {
                            log.writeLog("ERROR Deleting - " + file);
                            errors++;
                        }
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
                    log.closeLog(errors);
                    MessageBox.Show("Task Finished!\nFiles Deleted: " + success + "\nErrors: " + errors, "Jobs done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }, null);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();

            if (!Directory.Exists(logPath))
            {
                MessageBox.Show("Logs Directory doesn't exist!\nWe will now create one for you.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DirectoryInfo di = Directory.CreateDirectory(logPath);
                process.StartInfo.FileName = (logPath);
                process.Start();
                return;
            }
            process.StartInfo.FileName = (logPath);
            process.Start();
        }

        private void linkLabelRecommended_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is GroupBox)
                {
                    GroupBox groupBox = (GroupBox)item;
                    foreach (CheckBox checkBox in groupBox.Controls)
                    {
                        checkBox.Checked = true;
                    }
                }
            }
        }
    }
}
