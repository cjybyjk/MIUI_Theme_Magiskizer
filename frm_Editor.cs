using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 

namespace MIUI_Theme_Magiskizer
{
    public partial class frm_Editor : Form
    {
        public static string tmpPath = Application.UserAppDataPath + @"\temp";
        public string unitPath=tmpPath + @"\unitTmp";

        public frm_Editor()
        {
            InitializeComponent();
            LoadFilesAndDirectoriesToTree(unitPath,treeFile.Nodes);
        }

        private void LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);
            foreach (string item in files)
            {
                treeNodeCollection.Add(Path.GetFileName(item));
            }
            foreach (string item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                LoadFilesAndDirectoriesToTree(item, node.Nodes);
            }

        }

        private void 导入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeFile.SelectedNode.Remove();
        }

        private void treeFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && treeFile.SelectedNode == null)
            {
                导出ToolStripMenuItem.Enabled = false;
                删除ToolStripMenuItem.Enabled = false;
            }
            else
            {
                导出ToolStripMenuItem.Enabled = true;
                删除ToolStripMenuItem.Enabled = true;
            }

        }
    }
}
