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

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < directory.elements.Count; i++)
            {
                this.listBox1.Items.Add(directory.elements.ToArray()[i]);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            this.AddressTextBox1.Text = ((this.listBox1.SelectedItem)as IElement).FullPath;
            this.DetailsTextBox1.Text = ((this.listBox1.SelectedItem) as IElement).Properties();

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (Directory.Exists(((this.listBox1.SelectedItem) as IElement).FullPath))
            {
                directory.UpdateDirectory(directory.FullPath + ((this.listBox1.SelectedItem) as IElement).FullPath);
                listBox1.Items.Clear();
                for (int i = 0; i < directory.elements.Count; i++)
                {
                    this.listBox1.Items.Add(directory.elements.ToArray()[i]);
                }
               // this.AddressTextBox1.Text = ((this.listBox1.SelectedItem) as IElement).FullPath;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            
            directory.GoBack();
            listBox1.Items.Clear();
            for (int i = 0; i < directory.elements.Count; i++)
            {
                this.listBox1.Items.Add(directory.elements.ToArray()[i]);
            }
            this.AddressTextBox1.Text = ((this.listBox1.Items[0]) as IElement).FullPath;

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
