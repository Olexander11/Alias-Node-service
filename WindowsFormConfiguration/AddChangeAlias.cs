using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormConfiguration
{
    public partial class AddChangeAlias : Form
    {
        private Dictionary<string, string> aliasList;
        private bool newItemCreated;
        private string oldRenamed;
        public string TextBoxAliasName
        {
            get
            {
                return textBoxAliasName.Text;
            } 
            set
            {
                textBoxAliasName.Text = value;
            }
        }

        public string TextBoxPath
        {
            get
            {
                return textBoxPath.Text;
            }
            set
            {
                textBoxAliasName.Text = value;
            }
        }



        public AddChangeAlias(Dictionary<string, string> aliasList, string info, bool newItem)
        {
            InitializeComponent();

            textBoxAliasName.Select();
            textBoxAliasName.Validating += Name_Validating;
            textBoxPath.Validating += Path_Validating;
            this.aliasList = aliasList;
            labelInform.Text = info;
            newItemCreated = newItem;
        }

        public AddChangeAlias(Dictionary<string, string> aliasList, string info, bool newItem,  string oldAliasName, string oldPath)
        {
            InitializeComponent();

            textBoxAliasName.Select();
            textBoxAliasName.Validating += Name_Validating;
            textBoxPath.Validating += Path_Validating;
            this.aliasList = aliasList;
            labelInform.Text = info;
            newItemCreated = newItem;
            oldRenamed = oldAliasName;
            textBoxAliasName.Text = oldAliasName;
            textBoxPath.Text = oldPath;
        }

        public AddChangeAlias(Dictionary<string, string> _aliasdictionary)
        {
            InitializeComponent();

            textBoxAliasName.Select();
            textBoxAliasName.Validating += Name_Validating;
            textBoxPath.Validating += Path_Validating;
        }

        private void Path_Validating(object sender, CancelEventArgs e)
        {
            if (!Directory.Exists(textBoxPath.Text))
            {
                errorProvider1.SetError(textBoxPath, "No such directory!!");
                textBoxPath.Select();
            }
            else 
                errorProvider1.Clear();
        }

        private void Name_Validating(object sender, CancelEventArgs e)
        {
            textBoxAliasName.Text = textBoxAliasName.Text.Trim();

            if (newItemCreated)
            {
                if ((aliasList.ContainsKey(textBoxAliasName.Text)))
                {
                    errorProvider1.SetError(textBoxAliasName, "The name you entered is already used!");
                    textBoxAliasName.Select();
                    return;
                }
            }
            else if (oldRenamed != textBoxAliasName.Text)
            {
                if ((aliasList.ContainsKey(textBoxAliasName.Text)))
                {
                    errorProvider1.SetError(textBoxAliasName, "The name you entered is already used!");
                    textBoxAliasName.Select();
                    return;
                }
            }


            if (textBoxAliasName.Text == "" | textBoxAliasName.Text == null)
            {
                errorProvider1.SetError(textBoxAliasName, " It is not possible to have a alias with an empty name");
                textBoxAliasName.Select();
            }
            else 
                errorProvider1.Clear();
        }

        private void ButtonSetDir_Click(object sender, EventArgs e)
        {
            var dir = new FolderBrowserDialog
                {
                    Description = "Select folder for alias"
                };
            if (dir.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = dir.SelectedPath;
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(textBoxAliasName) != "" | errorProvider1.GetError(textBoxPath) != "")
            {
                return;
            }

            if (!Directory.Exists(textBoxPath.Text))
            {
                errorProvider1.SetError(textBoxPath, "No such directory!!");
                textBoxPath.Select();
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}