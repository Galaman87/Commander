using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GalamanCommanderWF
{
    public partial class Form1 : Form
    {
       ActiveDirectory directory = new ActiveDirectory("");
        ActiveDirectory selectedirectory = new ActiveDirectory("");
        string activeElement="";
        string action;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateElements();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            this.AddressTextBox1.Text = ((this.listBox1.SelectedItem)as IElement).FullPath;
            this.DetailsTextBox1.Text = ((this.listBox1.SelectedItem) as IElement).Properties();

        }
        private void UpdateElements()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < directory.elements.Count; i++)
            {
                this.listBox1.Items.Add(directory.elements.ToArray()[i]);
            }

        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (Directory.Exists(((this.listBox1.SelectedItem) as IElement).FullPath))
            {
                directory.UpdateDirectory(directory.FullPath + ((this.listBox1.SelectedItem) as IElement).FullPath);
                UpdateElements();               
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {            
            directory.GoBack();
            UpdateElements();
            this.AddressTextBox1.Text = ((this.listBox1.Items[0]) as IElement).FullPath;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show($"Delete {this.listBox1.SelectedItem}", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
                MessageBox.Show(((this.listBox1.SelectedItem) as IElement).Delete());
                listBox1.SelectedIndex = 0;
                directory.UpdateDirectory();
                UpdateElements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStripButton2_Click(object sender, EventArgs e)
        {
            directory.UpdateDirectory();
            this.UpdateElements();

        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            action = "copy";
            activeElement = (listBox1.SelectedItem as IElement).FullPath;
            
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            action = "cut";
            activeElement = (listBox1.SelectedItem as IElement).FullPath;
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            if (action == ""||activeElement==null) return;
            if (action == "copy") 
                if (File.Exists(activeElement))
                {
                    FileInfo fileInfo = new FileInfo(activeElement);
                    MessageBox.Show(FileElement.Copy(activeElement, directory.Part + "\\" + fileInfo.Name));
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(activeElement);
                    MessageBox.Show(DirectoryElement.Copy(activeElement, directory.Part + "\\" + directoryInfo.Name));
                }
            if (action == "cut")
                if (File.Exists(activeElement))
                {
                    FileInfo fileInfo = new FileInfo(activeElement);
                    MessageBox.Show(FileElement.Move(activeElement, directory.Part + "\\" + fileInfo.Name));
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(activeElement);
                    MessageBox.Show(DirectoryElement.Move(activeElement, directory.Part + "\\" + directoryInfo.Name));
                }

            action = "";
            activeElement = null;
            directory.UpdateDirectory();
            UpdateElements();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            string element = (listBox1.SelectedItem as IElement).FullPath;
            Form form = new Form2Rename(element);
            form.ShowDialog();

            directory.UpdateDirectory();
            this.UpdateElements();

        }
    }
}
