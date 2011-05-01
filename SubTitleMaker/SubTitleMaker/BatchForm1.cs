using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubExtractor;
using System.Collections;
using System.IO;

namespace SubTitleMaker
{
    public partial class BatchForm1 : Form
    {
        private delegate void runfake();
        //int counter = 0;
        BatchTool newbatch;
        List<Object> directories = new List<object>();
        IAsyncResult runhandle;
        //private AsyncCallback doneprocallback;

        public BatchForm1()
        {
            InitializeComponent();

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            lb_directories.Enabled = false;
            btn_start.Enabled = false;
            lb_results.Items.Clear();
            lb_test.Text = "Processing...";
            btn_stop.Enabled = true;
            btn_adddir.Enabled = false;
            btn_removedir.Enabled = false;
            btn_save.Enabled = false;
            btn_adddir.Enabled = false;
            btn_clear.Enabled = false;
            cb_recursive.Enabled = false;
            cb_overwrite.Enabled = false;
            cb_showtime.Enabled = false;
            runfake rundel = new runfake(processdirlist);
            runhandle = rundel.BeginInvoke(onDoneCallback, null);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void processdirlist()
        {
            int index;

            //IEnumerator lb_enumerator =  lb_directories.Items.GetEnumerator();
            ListBox.ObjectCollection dirs_to_process = lb_directories.Items;

            foreach (String dir in directories)
            {
                processdirectory(dir);
                lb_directories.Invoke((MethodInvoker)delegate
                {
                    index = lb_directories.Items.IndexOf(dir);
                    if (index >= 0)
                    {
                        lb_directories.Items[index] = dir + " -- done";
                    }
                });


            }
        }

        private void processdirectory(String dirstring)
        {
            fpstype camtype = fpstype.Type1;
            if (rb_type0.Checked == true) camtype = fpstype.Type0;
            if (rb_type1.Checked == true) camtype = fpstype.Type1;
            newbatch = new BatchTool(dirstring, camtype, cb_recursive.Checked, cb_overwrite.Checked, cb_showtime.Checked);
            newbatch.OnSubgenResult += new BatchTool.SubGenResultHandler(fileprocessed);
            newbatch.OnDirectoryChange += new BatchTool.SubGenDirectoryChanged(directoryevent);

            newbatch.ProcessVideoDirectory();

        }

        private void fileprocessed(object sender, SubGenEventArgs e)
        {

            btn_start.Invoke((MethodInvoker)delegate()
           {
               String temp = e.resultstring;
               lb_results.Items.Add(temp);

               //Cursor = Cursors.Default;
           });  //methodinvoker is HANDY!


            //counter++;
        }

        private void directoryevent(object sender, SubGenEventArgs e)
        {
            btn_start.Invoke((MethodInvoker)delegate()
            {
                String temp = e.resultstring;
                lb_results.Items.Add(temp);

            });  //methodinvoker is HANDY!
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            newbatch.isactive = false;
        }

        private void onDoneCallback(IAsyncResult ar)
        {
            btn_start.Invoke((MethodInvoker)delegate()
            {
                done_directory();
            });  //methodinvoker is HANDY!
        }

        private void done_directory()
        {

            lb_test.Text = "Done Processing";
            btn_start.Enabled = false;
            btn_stop.Enabled = false;
            btn_save.Enabled = true;
            btn_clear.Enabled = true;
            lb_results.Items.Add("----Finished----");
            lb_results.Items.Add("");
        }

        private void btn_adddir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog newfolder = new FolderBrowserDialog();
            newfolder.ShowNewFolderButton = false;
            DialogResult result = newfolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                lb_directories.Items.Add(newfolder.SelectedPath);
                directories.Add(newfolder.SelectedPath);
            }
        }

        private void btn_removedir_Click(object sender, EventArgs e)
        {
            Object remove = lb_directories.SelectedItem;
            lb_directories.Items.Remove(remove);
            directories.Remove(remove);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            lb_directories.Items.Clear();
            directories.Clear();
            btn_adddir.Enabled = true;
            btn_start.Enabled = true;
            btn_removedir.Enabled = true;
            lb_directories.Enabled = true;
            cb_recursive.Enabled = true;
            cb_recursive.Checked = false;
            cb_overwrite.Enabled = true;
            cb_overwrite.Checked = false;
            cb_showtime.Checked = false;
            cb_showtime.Enabled = true;
            rb_type1.Checked = true;
            lb_test.Text = "Ready";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            String filename;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Log File";
            dlg.Filter = "log file|*.log";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;

                if (!(File.Exists(filename)))
                {
                    StreamWriter logfile_stream = new StreamWriter(filename, false);
                    //logfile_stream.Write(lb_results.Items.ToString());
                    foreach (String line in lb_results.Items)
                    {
                        logfile_stream.WriteLine(line);
                    }
                    logfile_stream.Close();
                }
                else
                {
                    MessageBox.Show("that logfile file already exists");
                }
            }
        }
    }
}
