namespace WindowsFormConfiguration
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.labelAliaes = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelAliasInfo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewAliases = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelIP = new System.Windows.Forms.Label();
            this.buttonDeleteIp = new System.Windows.Forms.Button();
            this.buttonAddIp = new System.Windows.Forms.Button();
            this.listBoxIP = new System.Windows.Forms.ListBox();
            this.labelDB = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonSelectDB = new System.Windows.Forms.Button();
            this.buttonCreateNew = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAliaes
            // 
            resources.ApplyResources(this.labelAliaes, "labelAliaes");
            this.labelAliaes.Name = "labelAliaes";
            // 
            // buttonNew
            // 
            resources.ApplyResources(this.buttonNew, "buttonNew");
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // buttonChange
            // 
            resources.ApplyResources(this.buttonChange, "buttonChange");
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // labelAliasInfo
            // 
            resources.ApplyResources(this.labelAliasInfo, "labelAliasInfo");
            this.labelAliasInfo.Name = "labelAliasInfo";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl1_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewAliases);
            this.tabPage1.Controls.Add(this.labelAliaes);
            this.tabPage1.Controls.Add(this.buttonNew);
            this.tabPage1.Controls.Add(this.labelAliasInfo);
            this.tabPage1.Controls.Add(this.buttonChange);
            this.tabPage1.Controls.Add(this.buttonDelete);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewAliases
            // 
            resources.ApplyResources(this.listViewAliases, "listViewAliases");
            this.listViewAliases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewAliases.MultiSelect = false;
            this.listViewAliases.Name = "listViewAliases";
            this.listViewAliases.UseCompatibleStateImageBehavior = false;
            this.listViewAliases.View = System.Windows.Forms.View.Details;
            this.listViewAliases.SelectedIndexChanged += new System.EventHandler(this.ListViewAlias_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelIP);
            this.tabPage2.Controls.Add(this.buttonDeleteIp);
            this.tabPage2.Controls.Add(this.buttonAddIp);
            this.tabPage2.Controls.Add(this.listBoxIP);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelIP
            // 
            resources.ApplyResources(this.labelIP, "labelIP");
            this.labelIP.Name = "labelIP";
            // 
            // buttonDelIp
            // 
            resources.ApplyResources(this.buttonDeleteIp, "buttonDelIp");
            this.buttonDeleteIp.Name = "buttonDelIp";
            this.buttonDeleteIp.UseVisualStyleBackColor = true;
            this.buttonDeleteIp.Click += new System.EventHandler(this.ButtonDelIp_Click);
            // 
            // buttonAddIp
            // 
            resources.ApplyResources(this.buttonAddIp, "buttonAddIp");
            this.buttonAddIp.Name = "buttonAddIp";
            this.buttonAddIp.UseVisualStyleBackColor = true;
            this.buttonAddIp.Click += new System.EventHandler(this.ButtonAddIp_Click);
            // 
            // listBoxIP
            // 
            resources.ApplyResources(this.listBoxIP, "listBoxIP");
            this.listBoxIP.FormattingEnabled = true;
            this.listBoxIP.Name = "listBoxIP";
            this.listBoxIP.SelectedIndexChanged += new System.EventHandler(this.ListBoxIP_SelectedIndexChanged);
            // 
            // labelDB
            // 
            resources.ApplyResources(this.labelDB, "labelDB");
            this.labelDB.Name = "labelDB";
            // 
            // labelStatus
            // 
            resources.ApplyResources(this.labelStatus, "labelStatus");
            this.labelStatus.Name = "labelStatus";
            // 
            // buttonSelectDB
            // 
            resources.ApplyResources(this.buttonSelectDB, "buttonSelectDB");
            this.buttonSelectDB.Name = "buttonSelectDB";
            this.buttonSelectDB.UseVisualStyleBackColor = true;
            this.buttonSelectDB.Click += new System.EventHandler(this.ButtonSelectDB_Click);
            // 
            // buttonCreateNew
            // 
            resources.ApplyResources(this.buttonCreateNew, "buttonCreateNew");
            this.buttonCreateNew.Name = "buttonCreateNew";
            this.buttonCreateNew.UseVisualStyleBackColor = true;
            this.buttonCreateNew.Click += new System.EventHandler(this.ButtonCreateBD_Click);
            // 
            // buttonReload
            // 
            resources.ApplyResources(this.buttonReload, "buttonReload");
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonCreateNew);
            this.Controls.Add(this.buttonSelectDB);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDB);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainWindow";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAliaes;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelAliasInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Button buttonDeleteIp;
        private System.Windows.Forms.Button buttonAddIp;
        private System.Windows.Forms.ListBox listBoxIP;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonCreateNew;
        private System.Windows.Forms.Button buttonSelectDB;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListView listViewAliases;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

