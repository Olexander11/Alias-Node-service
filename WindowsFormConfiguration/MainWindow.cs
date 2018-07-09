using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SqliteDB;

namespace WindowsFormConfiguration
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, string> aliasDictionary;
        private List<string> ipList;

        public MainWindow()
        {
            InitializeComponent();

            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;
            buttonNew.Enabled = false;
            buttonReload.Enabled = false;
            buttonDeleteIp.Enabled = false;
            buttonAddIp.Enabled = false;
            labelAliasInfo.Text = "Aliases";
        }


        private void ButtonNew_Click(object sender, EventArgs e)
        {
            var newForm = new AddChangeAlias (aliasDictionary, "Create new alias item" + "\n\r" + "submit proper fields", true);
                
            if (newForm.ShowDialog(this) != DialogResult.OK) return;
            var dataBase = new SqliteDatabase(labelDB.Text);
            dataBase.AddNewItems(newForm.TextBoxAliasName, newForm.TextBoxPath);
            aliasDictionary.Add(newForm.TextBoxAliasName, newForm.TextBoxPath);
            RefreshAlias();
            RefreshIp();
            labelAliasInfo.Text = "New alias " + newForm.TextBoxAliasName + " created";
            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void RefreshAlias()
        {
            listViewAliases.Items.Clear();
            foreach (var keyVal in aliasDictionary)
            {
                listViewAliases.Items.Add(new ListViewItem(new[] {keyVal.Key, keyVal.Value}));
            }
        }

        private void RefreshIp()
        {
            listBoxIP.Items.Clear();
            foreach (string ipItem in ipList)
            {
                listBoxIP.Items.Add(ipItem);
            }
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listViewAliases.SelectedItems[0];
            string oldAlias = selectedItem.SubItems[0].Text;
            string oldPath = selectedItem.SubItems[1].Text;
            var newForm = new AddChangeAlias(aliasDictionary, "Change alias item" + "\n\r" + "make it", false, oldAlias, oldPath);

            if (newForm.ShowDialog(this) != DialogResult.OK) return;
            var dataBase = new SqliteDatabase(labelDB.Text);
            dataBase.RenameAlias(oldAlias, newForm.TextBoxAliasName, newForm.TextBoxPath);
            aliasDictionary.Remove(oldAlias);
            aliasDictionary.Add(newForm.TextBoxAliasName, newForm.TextBoxPath);
            RefreshAlias();
            labelAliasInfo.Text = "Alias " + oldAlias[0] + " changed";

            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;
            
        }


        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listViewAliases.SelectedItems[0];
            string text = selectedItem.SubItems[0].Text;

            string[] oldAlias = text.Split(' ');

            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                                         "Confirm Delete!!", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)

            {
                var dataBase = new SqliteDatabase(labelDB.Text);
                dataBase.DeleteAlias(oldAlias[0]);
                aliasDictionary.Remove(oldAlias[0]);
                RefreshAlias();
            }
            else return;

            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;

            labelAliasInfo.Text = "Alias  " + text + " was deleted ";
        }


        private void ListViewAlias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAliases.SelectedIndices.Count > 0)
            {
                buttonChange.Enabled = true;
                buttonDelete.Enabled = true;
                labelAliasInfo.Text = listViewAliases.SelectedItems.ToString();
            }
            else
            {
                buttonChange.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }


        private void ButtonAddIp_Click(object sender, EventArgs e)
        {
            var newForm = new InputIP ("Add new IP");
            if (newForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            labelIP.Text = newForm.labelInputIp.Text;
            string newip = newForm.textBox1.Text + "." + newForm.textBox2.Text + "." + newForm.textBox3.Text + "." + newForm.textBox4.Text;
            if (ipList.Contains(newip))
            {
                labelIP.Text = "This IP is alredy exist in list!";
                return;
            }
            var dataBase = new SqliteDatabase(labelDB.Text);
            dataBase.AddNewItems(newip);
            ipList.Add(newip);
            RefreshIp();
            labelIP.Text = "New IP " + newip + " was added!";
            buttonDeleteIp.Enabled = false;
        }


        private void ButtonReload_Click(object sender, EventArgs e)
        {
            ReloadDate();
        }

        private void ReloadDate()
        {
            var dataBase = new SqliteDatabase(labelDB.Text);
            ipList = (List<string>) dataBase.LoadIp();
            aliasDictionary = (Dictionary<string, string>) dataBase.LoadAlias();
            RefreshAlias();
            RefreshIp();
            labelStatus.Text = "Data base reloaded.";
        }

        private void ButtonSelectDB_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "DB files (*.db, *.sqlite)|*.db;*.sqlite| All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            labelDB.Text = openFileDialog1.FileName;
            var dataBase = new SqliteDatabase(labelDB.Text);
            aliasDictionary = (Dictionary<string, string>) dataBase.LoadAlias();
            ipList = (List<string>) dataBase.LoadIp();
            RefreshAlias();
            RefreshIp();
            labelStatus.Text = "Data base loaded from " + labelDB.Text;
            buttonNew.Enabled = true;
            buttonReload.Enabled = true;
            buttonAddIp.Enabled = true;
        }

        private void ButtonCreateBD_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "db";
            saveFileDialog1.Filter = "DB files (*.db, *.sqlite)|*.db;*.sqlite| All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string fileName = saveFileDialog1.FileName;
            labelDB.Text = fileName;
            var dataBase = new SqliteDatabase(fileName);
            dataBase.CreateNewDataBase();
            buttonNew.Enabled = true;
            buttonReload.Enabled = true;
            buttonAddIp.Enabled = true;
            labelStatus.Text = "Status: new bd is created!";
        }

        private void ButtonDelIp_Click(object sender, EventArgs e)
        {
            string text = listBoxIP.SelectedItem.ToString();
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                buttonDeleteIp.Enabled = false;
                return;
            }
            var dataBase = new SqliteDatabase(labelDB.Text);
            labelIP.Text = dataBase.DeleteIp(text);
            ipList.Remove(text);
            RefreshIp();
            buttonDeleteIp.Enabled = false;
        }

        private void ListBoxIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDeleteIp.Enabled = true;
            labelIP.Text = "Selected IP is " + listBoxIP.SelectedItem;
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            buttonDeleteIp.Enabled = false;
            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;
        }


        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (buttonDeleteIp.Enabled)
                {
                    buttonDeleteIp.PerformClick();
                }
                if (buttonDelete.Enabled)
                {
                    buttonDelete.PerformClick();
                }
            }
        }
    }
}