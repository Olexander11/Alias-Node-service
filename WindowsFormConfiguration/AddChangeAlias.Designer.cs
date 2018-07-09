namespace WindowsFormConfiguration
{
    partial class AddChangeAlias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddChangeAlias));
            this.labelInform = new System.Windows.Forms.Label();
            this.textBoxAliasName = new System.Windows.Forms.TextBox();
            this.labelAliasName = new System.Windows.Forms.Label();
            this.labelPathName = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonSetDir = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInform
            // 
            resources.ApplyResources(this.labelInform, "labelInform");
            this.errorProvider1.SetError(this.labelInform, resources.GetString("labelInform.Error"));
            this.errorProvider1.SetIconAlignment(this.labelInform, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelInform.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.labelInform, ((int)(resources.GetObject("labelInform.IconPadding"))));
            this.labelInform.Name = "labelInform";
            // 
            // textBoxAliasName
            // 
            resources.ApplyResources(this.textBoxAliasName, "textBoxAliasName");
            this.errorProvider1.SetError(this.textBoxAliasName, resources.GetString("textBoxAliasName.Error"));
            this.errorProvider1.SetIconAlignment(this.textBoxAliasName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxAliasName.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.textBoxAliasName, ((int)(resources.GetObject("textBoxAliasName.IconPadding"))));
            this.textBoxAliasName.Name = "textBoxAliasName";
            // 
            // labelAliasName
            // 
            resources.ApplyResources(this.labelAliasName, "labelAliasName");
            this.errorProvider1.SetError(this.labelAliasName, resources.GetString("labelAliasName.Error"));
            this.errorProvider1.SetIconAlignment(this.labelAliasName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelAliasName.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.labelAliasName, ((int)(resources.GetObject("labelAliasName.IconPadding"))));
            this.labelAliasName.Name = "labelAliasName";
            // 
            // labelPathName
            // 
            resources.ApplyResources(this.labelPathName, "labelPathName");
            this.errorProvider1.SetError(this.labelPathName, resources.GetString("labelPathName.Error"));
            this.errorProvider1.SetIconAlignment(this.labelPathName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelPathName.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.labelPathName, ((int)(resources.GetObject("labelPathName.IconPadding"))));
            this.labelPathName.Name = "labelPathName";
            // 
            // textBoxPath
            // 
            resources.ApplyResources(this.textBoxPath, "textBoxPath");
            this.errorProvider1.SetError(this.textBoxPath, resources.GetString("textBoxPath.Error"));
            this.errorProvider1.SetIconAlignment(this.textBoxPath, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxPath.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.textBoxPath, ((int)(resources.GetObject("textBoxPath.IconPadding"))));
            this.textBoxPath.Name = "textBoxPath";
            // 
            // buttonSetDir
            // 
            resources.ApplyResources(this.buttonSetDir, "buttonSetDir");
            this.errorProvider1.SetError(this.buttonSetDir, resources.GetString("buttonSetDir.Error"));
            this.errorProvider1.SetIconAlignment(this.buttonSetDir, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonSetDir.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.buttonSetDir, ((int)(resources.GetObject("buttonSetDir.IconPadding"))));
            this.buttonSetDir.Name = "buttonSetDir";
            this.buttonSetDir.UseVisualStyleBackColor = true;
            this.buttonSetDir.Click += new System.EventHandler(this.ButtonSetDir_Click);
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.errorProvider1.SetError(this.buttonOk, resources.GetString("buttonOk.Error"));
            this.errorProvider1.SetIconAlignment(this.buttonOk, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonOk.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.buttonOk, ((int)(resources.GetObject("buttonOk.IconPadding"))));
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider1.SetError(this.buttonCancel, resources.GetString("buttonCancel.Error"));
            this.errorProvider1.SetIconAlignment(this.buttonCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonCancel.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.buttonCancel, ((int)(resources.GetObject("buttonCancel.IconPadding"))));
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            resources.ApplyResources(this.errorProvider1, "errorProvider1");
            // 
            // AddChangeAlias
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonSetDir);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelPathName);
            this.Controls.Add(this.labelAliasName);
            this.Controls.Add(this.textBoxAliasName);
            this.Controls.Add(this.labelInform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddChangeAlias";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAliasName;
        private System.Windows.Forms.Label labelPathName;
        private System.Windows.Forms.Button buttonSetDir;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        protected System.Windows.Forms.Label labelInform;
        protected System.Windows.Forms.TextBox textBoxAliasName;
        protected System.Windows.Forms.TextBox textBoxPath;
    }
}