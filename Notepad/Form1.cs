using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OPEN.Title = "Select a file";
            OPEN.FileName = "";
            OPEN.InitialDirectory = "C:\\Users\\USER\\Documents";
            OPEN.Filter = "TXT Files| *.txt";

            string selected_file = "";

            if (OPEN.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("No file was selected");
            }

            else
            {
                selected_file = OPEN.FileName;
                richTextBox1.LoadFile(selected_file, RichTextBoxStreamType.PlainText);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAVE.Title = "Save the file";
            SAVE.FileName = "";
            SAVE.InitialDirectory = "C:\\Users\\USER\\Documents";
            SAVE.Filter = "TXT Files| *.txt | All Files| *.*";


            if (SAVE.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("File wasn't saved");
            }

            else 
            {
                richTextBox1.SaveFile(SAVE.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                richTextBox1.Text = "";
            }
        }
    }
}
