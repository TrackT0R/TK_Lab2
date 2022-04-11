using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TK_Lab2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
        }

        private void OpenSourceFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Source file|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                MainRichTextBox.Text = Fano_Shennon.EncryptFile(openFileDialog.FileName);
            }
        }

        private void OpenEncryptedFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".etxt";
            openFileDialog.Filter = "Encrypted file|*.etxt";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                MainRichTextBox.Text = Fano_Shennon.DecryptFile(openFileDialog.FileName);
            }
        }
    }
}
