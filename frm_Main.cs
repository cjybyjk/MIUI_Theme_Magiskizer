using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CL.IO.Zip;

namespace MIUI_Theme_Magiskizer
{
    public partial class frm_Main : Form
    {
        public static string tmpPath = Application.UserAppDataPath + @"\temp";
        public static string themePath = tmpPath + @"\themes\";
        public static string magiskPath = tmpPath + @"\magisk\";
        public static string magiskThemePath = magiskPath + @"system\media\theme\default\";
        public ZipHandler zip = ZipHandler.GetInstance();

        public frm_Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public static void KillDir(string dir)
        {
            try
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);
                    }
                    else
                        KillDir(d);
                }
                Directory.Delete(dir);
            }
            catch
            {

            }
           
        }

        public void ListFiles(string sSourcePath)
        {
            DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
            FileInfo[] thefileInfo = theFolder.GetFiles("*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile in thefileInfo)
            {
                string fileName = NextFile.FullName.Replace(sSourcePath + @"\", "");
                if(!lstModuleAdd.Items.Contains(fileName)) lstModules.Items.Add(fileName);
            }
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo)

            {
                FileInfo[] fileInfo = NextFolder.GetFiles("*", SearchOption.AllDirectories);
                foreach (FileInfo NextFile in fileInfo)
                {
                    string fileName = NextFile.FullName.Replace(sSourcePath + @"\", "");
                    if (!lstModuleAdd.Items.Contains(fileName)) lstModules.Items.Add(fileName);
                }
            }
        }

        private void CopyDirectory(string srcdir, string desdir)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf(@"\") + 1);
            string desfolderdir = desdir + @"\" + folderName;

            if (desdir.LastIndexOf(@"\") == (desdir.Length - 1)) desfolderdir = desdir + folderName;

            string[] filenames = Directory.GetFileSystemEntries(srcdir);

            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {
                    string currentdir = desfolderdir + @"\" + file.Substring(file.LastIndexOf(@"\") + 1);
                    if (!Directory.Exists(currentdir)) Directory.CreateDirectory(currentdir);
                    CopyDirectory(file, desfolderdir);
                }
                else
                {
                    string srcfileName = file.Substring(file.LastIndexOf(@"\") + 1);
                    srcfileName = desfolderdir + @"\" + srcfileName;
                    if (!Directory.Exists(desfolderdir)) Directory.CreateDirectory(desfolderdir);
                    File.Copy(file, srcfileName);
                }
            }
        }

        private string GetNodeText(string themeDir,string node)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(themeDir + @"\description.xml");
            XmlNodeList dd = doc.GetElementsByTagName(node);
            return dd.Item(0).InnerText;
        }

        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private void GetAlivableItems()
        {
            if (lstThemes.SelectedItem == null) return;
               lstModules.Items.Clear();
            ListFiles(themePath + lstThemes.SelectedItem.ToString());
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            if (lstModules.SelectedItems.Count < 1) return; 
            for (int i = lstModules.SelectedItems.Count - 1; i >= 0; i--)
            {
                string cpFile = lstModules.SelectedItems[i].ToString();
                string cpTo = magiskThemePath + cpFile;
                Directory.CreateDirectory(Path.GetDirectoryName(cpTo));
                File.Copy(themePath + lstThemes.SelectedItem.ToString() + @"\" + cpFile ,
                    cpTo);
                lstModuleAdd.Items.Add(lstModules.SelectedItems[i].ToString());
                lstModules.Items.Remove(lstModules.SelectedItems[i]);
            };
            GetAlivableItems();
        }

        private void btnRemoveModule_Click(object sender, EventArgs e)
        {
            if (lstModuleAdd.SelectedItems.Count < 1) return;
            for (int i = lstModuleAdd.SelectedItems.Count - 1; i >= 0; i--)
            {
                File.Delete(magiskThemePath + lstModuleAdd.SelectedItems[i].ToString());
                lstModuleAdd.Items.Remove(lstModuleAdd.SelectedItems[i]);
            }
            GetAlivableItems();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtModuleName.Text == "" || txtModuleAuthor.Text == "" ||
                txtDescription.Text == "" || txtVersion.Text == "")
            {
                lblStatus.Text = "错误: 输入信息不完整!";
                MessageBox.Show("输入信息不完整!","错误",MessageBoxButtons.OK  , MessageBoxIcon.Error);
                return;
            }
            if (lstModuleAdd.Items.Count == 0)
            {
                lblStatus.Text = "错误: 不能创建一个空模块!";
                MessageBox.Show("不能创建一个空模块!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fromDic = magiskPath;
            saveFile.ShowDialog();
            string toZip = saveFile.FileName;
            if (toZip == "") return;
            btnGenerate.Enabled = false;
            lblStatus.Text = "写入模块信息...";
            string unixTimeStamp = GetTimeStamp();
            string magiskInfo = File.ReadAllText(magiskPath + @"module.prop");
            magiskInfo=magiskInfo.Replace(@"%name%", txtModuleName.Text)
                .Replace(@"%author%", txtModuleAuthor.Text)
                .Replace(@"%description%", txtDescription.Text)
                .Replace(@"%version%", txtVersion.Text)
                .Replace(@"%versionCode%", unixTimeStamp)
                .Replace(@"%id%", @"MIUITheme_" + unixTimeStamp);
            File.WriteAllText(magiskPath + @"module.prop", magiskInfo);
            TaskFactory factory = new TaskFactory();
            factory.StartNew(() =>
            {
                lblStatus.Text = "正在打包...";
                zip.PackDirectory(fromDic, toZip, (num) =>
                {
                    progressBar.Value = Convert.ToInt32(num);
                });
                lblStatus.Text = "完成.";
                progressBar.Value = 0;
                btnGenerate.Enabled = true;
            });
            saveFile.FileName = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            string fromZip = openFile.FileName;
            if (fromZip == "") return;
            
            string toDic = themePath + GetTimeStamp();
            Directory.CreateDirectory(toDic);
            TaskFactory factory = new TaskFactory();
            btnAdd.Enabled = false;
            factory.StartNew(() =>
            {
                lblStatus.Text = "正在解包主题文件...";
                zip.UnpackAll(fromZip, toDic, (num) => {
                    progressBar.Value = Convert.ToInt32(num);
                });
                if (File.Exists(toDic + @"\description.xml") )
                {
                    lblStatus.Text = "读取信息...";
                    string title = System.Text.RegularExpressions.Regex.Replace(
                        GetNodeText(toDic, "title"), "[<>/\\|:\"*?]","_");
                    string author = System.Text.RegularExpressions.Regex.Replace(
                        GetNodeText(toDic, "author"), "[<>/\\|:\"*?]", "_");
                    if (txtVersion.Text == "") txtVersion.Text = GetNodeText(toDic, "version");
                    if (txtDescription.Text == "") txtDescription.Text =
                        System.Text.RegularExpressions.Regex.Replace(
                            GetNodeText(toDic, "description"),"[\r\n\t]","");
                    if (Directory.Exists(toDic + @"\preview"))
                        KillDir(toDic + @"\preview");
                    File.Delete(toDic + @"\description.xml");
                    if (!Directory.Exists(themePath + title + " - " + author))
                    {
                        Directory.Move(toDic, themePath + title + " - " + author);
                        if (txtModuleName.Text == "") txtModuleName.Text = title;
                        if (txtModuleAuthor.Text == "") txtModuleAuthor.Text = author;
                        lstThemes.Items.Add(title + " - " + author);
                        lblStatus.Text = "完成";
                    }
                    else
                    {
                        lblStatus.Text = "错误! 主题已在列表中!";
                        KillDir(toDic);
                    }
                }
                else
                {
                    lblStatus.Text = "错误! 找不到描述文件!";
                    KillDir(toDic);
                }
                progressBar.Value = 0;
                btnAdd.Enabled = true;
            });
            openFile.FileName = "";
            
        }

        private void lstThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAlivableItems();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstThemes.SelectedItem == null) return;
            KillDir(themePath + lstThemes.SelectedItem.ToString());
            lstThemes.Items.Remove(lstThemes.SelectedItem);
            lstModules.Items.Clear();   
        }


        private void frm_Main_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(tmpPath)) KillDir(tmpPath); 
            if (Directory.Exists(Application.StartupPath + @"\magiskTemplate\"))
            {
                CopyDirectory(Application.StartupPath + @"\magiskTemplate\", magiskPath);
            }
            else
            {
                MessageBox.Show("错误! 找不到magiskTemplate!", "MIUI_Theme_Magiskizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            Directory.CreateDirectory(magiskThemePath);
            Directory.CreateDirectory(themePath);
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillDir(tmpPath); 
        }

        private void editUnit(string unitPath)
        {
            TaskFactory factory = new TaskFactory();
            bool flagExtracted = false;
            btnAdd.Enabled = false;
            factory.StartNew(() =>
            {
                KillDir(tmpPath + @"\unitTmp");
                lblStatus.Text = "正在解包组件...";
                zip.UnpackAll(unitPath, tmpPath + @"\unitTmp", (num) =>
                {
                    progressBar.Value = Convert.ToInt32(num);
                });
                flagExtracted = true;
            });
            while (!flagExtracted) {
                Application.DoEvents();
                System.Threading.Thread.Sleep(5);
            }
            lblStatus.Text = "完成!";
            if (Directory.Exists (tmpPath + @"\unitTmp"))
            {
                frm_Editor frmEdit = new frm_Editor();
                frmEdit.Show();
            }
        }

        private void lstModuleAdd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstModuleAdd.SelectedItems.Count != 1) return;
            editUnit(magiskThemePath + @"\" + lstModuleAdd.SelectedItems[0].ToString());
        }
    }
}
