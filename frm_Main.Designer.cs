namespace MIUI_Theme_Magiskizer
{
    partial class frm_Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.lstThemes = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstModules = new System.Windows.Forms.ListBox();
            this.lstModuleAdd = new System.Windows.Forms.ListBox();
            this.btnAddModule = new System.Windows.Forms.Button();
            this.btnRemoveModule = new System.Windows.Forms.Button();
            this.txtModuleName = new System.Windows.Forms.TextBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.lblText2 = new System.Windows.Forms.Label();
            this.txtModuleAuthor = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblText3 = new System.Windows.Forms.Label();
            this.lblText4 = new System.Windows.Forms.Label();
            this.lblText5 = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.lblText6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblText7 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstThemes
            // 
            this.lstThemes.FormattingEnabled = true;
            resources.ApplyResources(this.lstThemes, "lstThemes");
            this.lstThemes.Name = "lstThemes";
            this.lstThemes.SelectedIndexChanged += new System.EventHandler(this.lstThemes_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstModules
            // 
            this.lstModules.FormattingEnabled = true;
            resources.ApplyResources(this.lstModules, "lstModules");
            this.lstModules.Name = "lstModules";
            this.lstModules.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lstModuleAdd
            // 
            this.lstModuleAdd.FormattingEnabled = true;
            resources.ApplyResources(this.lstModuleAdd, "lstModuleAdd");
            this.lstModuleAdd.Name = "lstModuleAdd";
            this.lstModuleAdd.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // btnAddModule
            // 
            resources.ApplyResources(this.btnAddModule, "btnAddModule");
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.UseVisualStyleBackColor = true;
            this.btnAddModule.Click += new System.EventHandler(this.btnAddModule_Click);
            // 
            // btnRemoveModule
            // 
            resources.ApplyResources(this.btnRemoveModule, "btnRemoveModule");
            this.btnRemoveModule.Name = "btnRemoveModule";
            this.btnRemoveModule.UseVisualStyleBackColor = true;
            this.btnRemoveModule.Click += new System.EventHandler(this.btnRemoveModule_Click);
            // 
            // txtModuleName
            // 
            resources.ApplyResources(this.txtModuleName, "txtModuleName");
            this.txtModuleName.Name = "txtModuleName";
            // 
            // lblText1
            // 
            resources.ApplyResources(this.lblText1, "lblText1");
            this.lblText1.Name = "lblText1";
            // 
            // lblText2
            // 
            resources.ApplyResources(this.lblText2, "lblText2");
            this.lblText2.Name = "lblText2";
            // 
            // txtModuleAuthor
            // 
            resources.ApplyResources(this.txtModuleAuthor, "txtModuleAuthor");
            this.txtModuleAuthor.Name = "txtModuleAuthor";
            // 
            // btnGenerate
            // 
            resources.ApplyResources(this.btnGenerate, "btnGenerate");
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // lblText3
            // 
            resources.ApplyResources(this.lblText3, "lblText3");
            this.lblText3.Name = "lblText3";
            // 
            // lblText4
            // 
            resources.ApplyResources(this.lblText4, "lblText4");
            this.lblText4.Name = "lblText4";
            // 
            // lblText5
            // 
            resources.ApplyResources(this.lblText5, "lblText5");
            this.lblText5.Name = "lblText5";
            // 
            // openFile
            // 
            resources.ApplyResources(this.openFile, "openFile");
            // 
            // saveFile
            // 
            resources.ApplyResources(this.saveFile, "saveFile");
            // 
            // lblText6
            // 
            resources.ApplyResources(this.lblText6, "lblText6");
            this.lblText6.Name = "lblText6";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // lblText7
            // 
            resources.ApplyResources(this.lblText7, "lblText7");
            this.lblText7.Name = "lblText7";
            // 
            // txtVersion
            // 
            resources.ApplyResources(this.txtVersion, "txtVersion");
            this.txtVersion.Name = "txtVersion";
            // 
            // frm_Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblText7);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblText6);
            this.Controls.Add(this.lblText5);
            this.Controls.Add(this.lblText4);
            this.Controls.Add(this.lblText3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtModuleAuthor);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.txtModuleName);
            this.Controls.Add(this.btnRemoveModule);
            this.Controls.Add(this.btnAddModule);
            this.Controls.Add(this.lstModuleAdd);
            this.Controls.Add(this.lstModules);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstThemes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstThemes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstModules;
        private System.Windows.Forms.ListBox lstModuleAdd;
        private System.Windows.Forms.Button btnAddModule;
        private System.Windows.Forms.Button btnRemoveModule;
        private System.Windows.Forms.TextBox txtModuleName;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.TextBox txtModuleAuthor;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblText3;
        private System.Windows.Forms.Label lblText4;
        private System.Windows.Forms.Label lblText5;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Label lblText6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblText7;
        private System.Windows.Forms.TextBox txtVersion;
    }
}

