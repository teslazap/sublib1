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
using System.Threading;

namespace SubTitleMaker
{
    public partial class Form1 : Form
    {
        private string filename;
        private SubFile subtitle_handle = new SubFile();
        private delegate void makesub();

        public Form1()
        {
            InitializeComponent();
            ttip_camera.SetToolTip(groupBox_cameratype, "Method of Determing Frame rate\nIf subtitle time doesn't sync or is slow\ntry the other setting");
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Movie File";
            dlg.Filter = "mts files (*.mts;*.m2ts)|*.mts;*.m2ts|All files (*.*)|*.*";
            dlg.ShowDialog();
            filename = dlg.FileName;
            textBox1.Text = filename;
            btn_subgen.Enabled = true;
            
        }

        private void btn_subgen_Click(object sender, EventArgs e)
        {


            subtitle_handle.VideoFile = filename;      
            if (radioButton_type0.Checked == true)
            {
                subtitle_handle.FpsType = SubFile.fpstype.Type0;
            }
            if (radioButton_type1.Checked == true)
            {
                subtitle_handle.FpsType = SubFile.fpstype.Type1;
            }
            
            makesub subdelegate = new makesub(generatesubtitles);
            IAsyncResult makereturn = subdelegate.BeginInvoke(null, null);
            //makereturn.AsyncWaitHandle.WaitOne();                            //this blocks the thread until the asyncresult returms - be careful,
                                                                               //calls to UI thread (control.invoke) in other threads will lock up the program
            UseWaitCursor = true;
            btn_subgen.Enabled = false;
            btn_savesubs.Enabled = false;
            rtb_subcontent.Enabled = false;
        }

        private void btn_savesubs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Subtitle File";
            dlg.Filter = "srt file|*.srt";
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
            
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void generatesubtitles()
        {
            try
            {

                subtitle_handle.MakeSubTitles();
                subtitle_handle.SplitSubTitles();
                //Thread.Sleep(4000);                           //simulate large file - comment this out when done
                btn_subgen.Invoke((MethodInvoker)delegate()
                {
                    rtb_subcontent.Text = subtitle_handle.FullSubOutput;
                    rtb_subcontent.Enabled = true;
                    btn_savesubs.Enabled = true;
                    btn_subgen.Enabled = true;
                    //Cursor = Cursors.Default;
                });  //methodinvoker is HANDY!
                //btn_subgen.Invoke(new MethodInvoker (delegate() { rtb_subcontent.Text = subtitle_handle.FullSubOutput; }));  //this also works!
            }
            catch
            {
                btn_subgen.Invoke((MethodInvoker)delegate()
                {
                    MessageBox.Show("There is a problem with the subtitle file\nYou may not have selected a .mts or .m2ts\n file or it may be corrupt",
                        "File Open Error");
                });
            }
            finally
            {
                btn_subgen.Invoke((MethodInvoker)delegate() { UseWaitCursor = false; });
            }
        }
    }
}
