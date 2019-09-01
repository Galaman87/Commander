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
    public partial class Form2Rename : Form
    {
       
        IElement element;
        public Form2Rename(string renElement)
        {
            if (File.Exists(renElement))
                element = new FileElement(renElement);
            else
                element = new DirectoryElement(renElement);
            InitializeComponent();
            
            textBox1.Text = element.Name();
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(element.Rename(NewNameTextBox2.Text));
            this.Close();
            
        }
    }
}
