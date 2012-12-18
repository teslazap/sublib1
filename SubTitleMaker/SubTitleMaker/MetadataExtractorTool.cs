using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubExtractor;
using System.Threading;
using System.IO;

namespace SubTitleMaker
{
    public partial class MetadataExtractorTool : Form
    {

        //private MetaDataHandle metaframe;
        private videometadata newvideofiledata;
        private string filename;
        private string filename_save;
        private delegate void readmetadata();
        private int elapsedtime = 0;

        public MetadataExtractorTool()
        {
            InitializeComponent();
        }

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Movie File";
            dlg.Filter = "mts files (*.mts;*.m2ts)|*.mts;*.m2ts|All files (*.*)|*.*";
            dlg.ShowDialog();
            filename = dlg.FileName;
            tb_path.Text = filename;
            btn_analyze.Enabled = true;
            
            //cb_timedisp.Enabled = true;
        }

        private void btn_analyze_Click(object sender, EventArgs e)
        {

            //newvideofiledata = new videometadata(filename, videotype.avchd);   //this call must be done in separate thread with callback and counter eventually //try anon delegate for fun

            readmetadata readmeta_delegate = delegate()
            {
                try
                {
                    newvideofiledata = new videometadata(filename, videotype.avchd);
                    btn_analyze.Invoke((MethodInvoker)delegate()
                    {
                        timer1.Enabled = false;
                        UseWaitCursor = false;
                        btn_openfile.Enabled = true;
                        btn_analyze.Enabled = true;
                        btn_savemetadata.Enabled = true;
                        
                        this.lb_results.Items.Add("Data from file: " + filename);
                        this.lb_results.Items.Add(("Calculated Framerate: " + newvideofiledata.Calc_Framerate.ToString()));
                        this.lb_results.Items.Add(("Calculated Number of Frames: " + newvideofiledata.Calc_Number_of_Frames.ToString()));
                        this.lb_results.Items.Add(("Movie Duration: " + newvideofiledata.Calc_Movielength.ToString() + " seconds"));
                        this.lb_results.Items.Add(("Date and Time of First Frame: " + newvideofiledata.getFrameDateTime(0).ToString()));
                        this.lb_results.Items.Add("");
                        //this.lb_results.Items.Add(newvideofiledata.getmetaframeText(0));
                    });
                }
                catch (System.Exception exception)
                {
                    btn_analyze.Invoke((MethodInvoker)delegate()
                    {
                        String errormessage = "There is a problem with the video file.\nYou may not have selected a .mts or .m2ts\nfile or it may be corrupt.\n\nThe error type is: " + exception.Message;
                        MessageBox.Show(errormessage,
                            "File Open Error");

                    });
                }
                finally
                {
                    btn_analyze.Invoke((MethodInvoker)delegate()
                    {
                        timer1.Enabled = false;
                        UseWaitCursor = false;
                        btn_openfile.Enabled = true;
                        btn_analyze.Enabled = true;
                        btn_savemetadata.Enabled = true;
                    });
                }

            };
            elapsedtime = 0;  //reset time counter
            label_time.Text = elapsedtime.ToString();
            timer1.Enabled = true;
            UseWaitCursor = true;
            btn_openfile.Enabled = false;
            btn_analyze.Enabled = false;
            btn_savemetadata.Enabled = false;

            readmeta_delegate.BeginInvoke(null, null);
        }

        private void btn_savemetadata_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not Hooked UP yet!");
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Subtitle File";
            dlg.Filter = "txt file|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename_save = dlg.FileName;

                if (!(File.Exists(filename_save)))
                {

                    elapsedtime = 0;  //reset time counter
                    label_time.Text = elapsedtime.ToString();
                    timer1.Enabled = true;
                    UseWaitCursor = true;
                    btn_openfile.Enabled = false;
                    btn_analyze.Enabled = false;
                    
                    
                    readmetadata readmeta_delegate = delegate()
                    {
                        try
                        {
                            //StreamWriter subfile_stream = new StreamWriter(filename, false);  //open file
                            //actual code to write to file goes here
                            newvideofiledata.writemetadatafile(filename_save);
                            //to here

                            //
                            
                            btn_analyze.Invoke((MethodInvoker)delegate()   //reset form on UI thread
                            {
                                timer1.Enabled = false;
                                UseWaitCursor = false;
                                btn_openfile.Enabled = true;
                                btn_analyze.Enabled = true;
                                btn_savemetadata.Enabled = true;

                                this.lb_results.Items.Add("");
                                this.lb_results.Items.Add("Saved Metadata from file: " + filename);

                                //this.lb_results.Items.Add(newvideofiledata.getmetaframeText(0));
                            });
                        }
                        catch (System.Exception exception)
                        {
                            btn_analyze.Invoke((MethodInvoker)delegate()
                            {
                                String errormessage = "There is a problem saving the subtitles.\n\nThe error type is: " + exception.Message;
                                MessageBox.Show(errormessage,
                                    "File Open Error");

                            });
                        }
                        finally
                        {
                            btn_analyze.Invoke((MethodInvoker)delegate()
                            {
                                timer1.Enabled = false;
                                UseWaitCursor = false;
                                btn_openfile.Enabled = true;
                                btn_analyze.Enabled = true;
                                btn_savemetadata.Enabled = true;
                            });
                        }

                    };
                    //and here

                    readmeta_delegate.BeginInvoke(null, null);   //call the write routine

                }
                else
                {
                    MessageBox.Show("that file already exists");
                }

            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedtime++;
            label_time.Text = elapsedtime.ToString();
        }
    }
}
