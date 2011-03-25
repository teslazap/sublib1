using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SubExtractor;

namespace SubTitleMaker
{
    public partial class Form1 : Form
    {
        private string filename;
        private SubFile subtitle_handle = new SubFile();


        public Form1()
        {
            InitializeComponent();
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Movie File";
            dlg.ShowDialog();
            filename = dlg.FileName;
            textBox1.Text = filename;
            btn_subgen.Enabled = true;
            
        }

        private void btn_subgen_Click(object sender, EventArgs e)
        {
            //if (radioButton_type0.Checked == true)   //this is the old method where all stuff was handled through the constuctor
            //{
            //    subtitle_handle = new SubFile(filename, 0);
            //}
            //if (radioButton_type1.Checked == true)
            //{
            //    subtitle_handle = new SubFile(filename, 1);
            //}
            //rtb_subcontent.Text = subtitle_handle.FullSubOutput;
            //btn_savesubs.Enabled = true;

            subtitle_handle.VideoFile = filename;       //new method where explict calls to load and shit are necessary
            if (radioButton_type0.Checked == true)
            {
                subtitle_handle.FpsType = SubFile.fpstype.Type0;
            }
            if (radioButton_type1.Checked == true)
            {
                subtitle_handle.FpsType = SubFile.fpstype.Type1;
            }
            subtitle_handle.MakeSubTitles();
            subtitle_handle.SplitSubTitles();
            rtb_subcontent.Text = subtitle_handle.FullSubOutput;
            btn_savesubs.Enabled = true;


        }

        private void btn_savesubs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Subtitle File";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                
                if (!(File.Exists(filename)))
                {
                    StreamWriter subfile_stream = new StreamWriter(filename, false);
                    foreach (String subtitle in subtitle_handle.SplitSubOutput)
                    {
                        subfile_stream.WriteLine(subtitle);
                    }
                    subfile_stream.Close();
                }
                else
                {
                    MessageBox.Show("that subtitle file already exists");
                }

            }
            
            //textBox1.Text = filename;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
