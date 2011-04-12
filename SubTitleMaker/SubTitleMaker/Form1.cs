//This file is part of the Time and Date Subtitle Maker.

//    The Time and Date Subtitle Maker is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    Time and Date Subtitle Maker is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with the Time and Date Subtitle Maker.  If not, see <http://www.gnu.org/licenses/>.




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
        private int elapsedtime = 0;
        //private String about_message = "SubTitleMaker version 0.1\nKarl Voss (vsko@yahoo.com)\nMarch 26th, 2011";

        public Form1()
        {
            InitializeComponent();
            ttip_camera.SetToolTip(groupBox_cameratype, "Method of Determing Frame rate\nIf subtitle time doesn't sync or is slow\ntry the other setting");
            ttip_displaytime.SetToolTip(cb_timedisp, "Select to show both date and time");
            cb_timedisp.Checked = true;
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
            btn_savesubs.Enabled = false;
            cb_timedisp.Enabled = true;
            
        }

        private void btn_subgen_Click(object sender, EventArgs e)
        {


            subtitle_handle.VideoFile = filename;      
            if (radioButton_type0.Checked == true)
            {
                subtitle_handle.FpsType = fpstype.Type0;
            }
            if (radioButton_type1.Checked == true)
            {
                subtitle_handle.FpsType = fpstype.Type1;
            }
            
            makesub subdelegate = new makesub(generatesubtitles);
            IAsyncResult makereturn = subdelegate.BeginInvoke(null, null);
            //makereturn.AsyncWaitHandle.WaitOne();                            //this blocks the thread until the asyncresult returms - be careful,
                                                                //calls to UI thread (control.invoke) in other threads will lock up the program
            elapsedtime = 0;
            lb_elapsedtime.Text = elapsedtime.ToString();
            timer1.Enabled = true;
            UseWaitCursor = true;
            btn_subgen.Enabled = false;
            btn_savesubs.Enabled = false;
            rtb_subcontent.Enabled = false;
            cb_timedisp.Enabled = false;
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

                    //subfile_stream.Write(subtitle_handle.FullSubOutput);
                    if (cb_timedisp.Checked == false)
                    {
                        subfile_stream.Write(subtitle_handle.NoTimeSubOutput);
                    }
                    else if (cb_timedisp.Checked == true)
                    {
                        subfile_stream.Write(subtitle_handle.FullSubOutput);
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

                subtitle_handle.MakeSubTitles();   //calls the c dll, may be slow from large file, hence separate thread
                //subtitle_handle.SplitSubTitles();
                //Thread.Sleep(4000);                   //simulate large file - comment this out when done
                subtitle_handle.RemoveSubTime();        //automatically remove time
                btn_subgen.Invoke((MethodInvoker)delegate()
                {
                    rtb_subcontent.Text = subtitle_handle.FullSubOutput;
                    //rtb_subcontent.Text = subtitle_handle.NoTimeSubOutput;
                    rtb_subcontent.Enabled = true;
                    btn_savesubs.Enabled = true;
                    btn_subgen.Enabled = true;
                    cb_timedisp.Enabled = true;
                    //Cursor = Cursors.Default;
                });  //methodinvoker is HANDY!
                //btn_subgen.Invoke(new MethodInvoker (delegate() { rtb_subcontent.Text = subtitle_handle.FullSubOutput; }));  //this also works!
            }
            catch (System.Exception e)
            {
                btn_subgen.Invoke((MethodInvoker)delegate()
                {
                    String errormessage = "There is a problem with the video file.\nYou may not have selected a .mts or .m2ts\nfile or it may be corrupt.\n\nThe error type is: " + e.Message;
                    MessageBox.Show(errormessage,
                        "File Open Error");
                   
                });
            }
            finally
            {
                btn_subgen.Invoke((MethodInvoker)delegate()
                {
                    UseWaitCursor = false;
                    timer1.Enabled = false;
                });
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedtime++;
            lb_elapsedtime.Text = elapsedtime.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutthis = new AboutBox1();
            aboutthis.ShowDialog();
        }

        private void cb_timedisp_Click(object sender, EventArgs e)
        {
            if (cb_timedisp.Checked == false)
            {
                rtb_subcontent.Text = subtitle_handle.NoTimeSubOutput;
            }
            else if (cb_timedisp.Checked == true)
            {
                rtb_subcontent.Text = subtitle_handle.FullSubOutput;
            }
        }

        private void batchToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatchForm1 batchwindow = new BatchForm1();
            batchwindow.Show();
        }
    }
}
