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

namespace SubTitleMaker
{
    public partial class BatchForm1 : Form
    {
        private delegate void runfake();
        int counter = 0;
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
            //IEnumerator lb_enumerator =  lb_directories.Items.GetEnumerator();
            runfake rundel = new runfake(processdirlist);
            runhandle = rundel.BeginInvoke(onDoneCallback, null);
            //processdirlist();
            //runhandle.AsyncWaitHandle.WaitOne(); //this is not good
            //lb_results.Items.Add("----Finished----");
            //lb_results.Items.Add("");
            //while (lb_enumerator.MoveNext())
            //{
            //    processdirectory(lb_enumerator.Current.ToString());
            //}
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
                    lb_directories.Items[index] = dir + " -- done";
                });


            }
        }
        
        private void processdirectory(String dirstring)
        {
            newbatch = new BatchTool(dirstring, fpstype.Type1, cb_recursive.Checked);
            //btn_start.Enabled = false;
            //newbatch.isactive = true;
            newbatch.OnSubgenResult += new BatchTool.SubGenResultHandler(fileprocessed);
            newbatch.OnDirectoryChange += new BatchTool.SubGenDirectoryChanged(directoryevent);
            //doneprocallback = new AsyncCallback(onDoneCallback);
            //lb_results.Items.Clear();
            //lb_test.Text = "Processing...";
            //btn_stop.Enabled = true;
            //btn_adddir.Enabled = false;
            //btn_removedir.Enabled = false;
            //btn_save.Enabled = false;
            //btn_adddir.Enabled = false;
            //btn_clear.Enabled = false;
            //cb_recursive.Enabled = false;
            newbatch.ProcessVideoDirectory();    //add asynchronous in calling fn
            //runfake rundel = new runfake(newbatch.ProcessVideoDirectory);
            //runhandle = rundel.BeginInvoke(onDoneCallback, null);
            //btn_start.Enabled = true;
        }

        private void fileprocessed(object sender, SubGenEventArgs e)
        {

             btn_start.Invoke((MethodInvoker)delegate()
            {
                String temp = e.resultstring;
                lb_results.Items.Add(temp);

                //Cursor = Cursors.Default;
            });  //methodinvoker is HANDY!
            
            
            counter++;
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
            btn_start.Enabled = true;
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
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            lb_directories.Items.Clear();
            directories.Clear();
            btn_adddir.Enabled = true;
            btn_removedir.Enabled = true;
            lb_directories.Enabled = true;
            cb_recursive.Enabled = true;
            cb_recursive.Checked = false;
        }
    }
}
