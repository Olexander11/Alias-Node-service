using System;
using System.IO;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfClient.ServiceAlias;
using Application = System.Windows.Application;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using TreeView = System.Windows.Controls.TreeView;

namespace WpfClient
{
    public partial class MainWindow : Window
    {
        private ServiceAliasClient client;
        private CompositeTypeNode nodeImport;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Click buttom conect to server
        private void ConectToServer(object sender, RoutedEventArgs e)
        {
            client = new ServiceAliasClient();
            myTreeItem.Items.Clear();

            try
            {
                string[] aliasNameList = client.GetDataAlias();

                foreach (string name in aliasNameList)
                {
                    // build root tree
                    var rootItem = new TreeViewItem
                        {
                            Header = name
                        };
                    myTreeItem.Items.Add(rootItem);
                }


                AliasesText.Text = "Available aliases was loaded.";
            }
            catch (FaultException<InvalidUserIPFault>)
            {
                MessageBox.Show("Your IP adress is in Black List. Program will be closed. ");
                Application.Current.Shutdown();
            }
            catch (Exception  ex)
            {
                AliasesText.Text = "Something wrong.. " + ex.Message;
            }
        }

        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            var item = myTreeItem.SelectedItem as TreeViewItem;
            if (item == null) return;
            AliasesText.Text = "You select " + item.Header;
            string nodePath = MakePathFromSelected(item, "", out string aliasname);
            try
            {
                if (nodePath == "\\") nodePath = "";

                nodeImport = client.GetNode(nodePath, aliasname);
            }
            catch (FaultException<InvalidUserIPFault>)
            {
                MessageBox.Show("Your IP adress is in Black List. Program will be closed. ");
                Application.Current.Shutdown();
            }

            catch (FaultException<AliasNotExistFault>)
            {
                AliasesText.Text = "This alias is now not available.";
                RemoveAlias(aliasname);
                return;
            }
            catch (FaultException<ItemNotExcistFault> ex)
            {
                AliasesText.Text = "Access to selected item is now not available." + "\n\r" + ex.Message;

                if (sender is Button)
                {
                    item.Items.Remove(sender);
                }
                else
                {
                    if (item.Parent as TreeViewItem != null)
                    {
                        var parent = (myTreeItem.SelectedItem as TreeViewItem).Parent as TreeViewItem;
                        parent.Items.Remove(myTreeItem.SelectedItem);
                    }
                    else
                    {
                        myTreeItem.Items.Remove(item);
                    }
                }

                return;
            }

            catch (Exception ex)
            {
                AliasesText.Text = "Something wrong.. " + ex.Message;
                return;
            }

            var newChild = myTreeItem.SelectedItem as TreeViewItem;
            newChild.Items.Clear();
            foreach (AliasNode nodeItem in nodeImport.NodeArray)
            {
                if (nodeItem.IsDirectory)
                {
                    newChild.Items.Add(new TreeViewItem {Header = nodeItem.ItemName});
                }
                else
                {
                    var button = new Button
                        {
                            Content = nodeItem.ItemName
                        };
                    button.Click += Button_Click;
                    newChild.Items.Add(button);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buttonOnClick = sender as Button;
            var item = buttonOnClick.Parent as TreeViewItem;
            string fileName = buttonOnClick.Content.ToString();
            string fileFullPath = MakePathFromSelected(item, fileName, out string aliasname);

            using (var dialog = new SaveFileDialog
                {
                    FileName = fileName
                })

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        int count = 0;
                        do
                        {
                            if (count > 2)
                            {
                                AliasesText.Text = "File cannot be loaded because network trouble. Try it later";
                                return;
                            }
                            count++;
                            Stream stream = client.GetFile(fileFullPath, aliasname);

                            using (Stream fileStream = dialog.OpenFile())
                            {
                                stream.CopyTo(fileStream);
                            }
                        } while (client.MD5HashFile(fileFullPath, aliasname) != GetMD5HashFromFile(dialog.FileName));

                        AliasesText.Text = "File  " + dialog.FileName + "  was loaded.";
                    }
                    catch (FaultException<InvalidUserIPFault>)
                    {
                        MessageBox.Show("Your IP adress is in Black List. Program will be closed. ");
                        Application.Current.Shutdown();
                    }

                    catch (FaultException<AliasNotExistFault>)
                    {
                        AliasesText.Text = "This alias is now not available.";
                        RemoveAlias(aliasname);
                    }
                    catch (FaultException<ItemNotExcistFault> ex)
                    {
                        AliasesText.Text = "Access to file is now not available." + "\n\r" + ex.Message;
                        item.Items.Remove(sender);
                    }
                    catch (Exception ex)
                    {
                        AliasesText.Text = "Something wrong.. " + ex.Message;
                    }
                }
        }

        private void RemoveAlias(string aliasName)
        {
            foreach (TreeViewItem roottree in myTreeItem.Items)
            {
                if (roottree.Header.ToString() == aliasName)
                {
                    myTreeItem.Items.Remove(roottree);
                    break;
                }
            }
        }

        private string GetMD5HashFromFile(string fileName)
        {
            byte[] hashArray;
            using (var file = new FileStream(fileName, FileMode.Open))
            using (MD5 md5 = new MD5CryptoServiceProvider())
                hashArray = md5.ComputeHash(file);

            var string16 = new StringBuilder();
            for (int i = 0; i < hashArray.Length; i++)
            {
                string16.Append(hashArray[i].ToString("x2"));
            }
            return string16.ToString();
        }

        private string MakePathFromSelected(TreeViewItem selectedItem, string path, out string aliasName)
        {
            if (selectedItem.Parent is TreeView)
            {
                aliasName = selectedItem.Header.ToString();
                return path;
            }
            var item = selectedItem.Parent as TreeViewItem;
            return MakePathFromSelected(item, (selectedItem.Header + "\\" + path), out aliasName);
        }
    }
}