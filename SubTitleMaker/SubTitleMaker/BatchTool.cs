using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SubExtractor;
using System.Threading;
using System.Text.RegularExpressions;

namespace SubTitleMaker
{
    class BatchTool
    {
        private List<String> resultlog = new List<String>();
        private List<String> dirlist = new List<string>();
        private String startdir;
        public delegate void SubGenResultHandler( object batch, SubGenEventArgs subgeninfo);
        public event SubGenResultHandler OnSubgenResult;
        public delegate void SubGenDirectoryChanged(object batch, SubGenEventArgs subgeninfo);
        public event SubGenDirectoryChanged OnDirectoryChange;
        public bool isactive = true;
        private bool isrecursive = false;
        private fpstype cameratype = fpstype.Type1;
        private bool overwrite = false;
        private bool showsubtime = false;

        public BatchTool(String initaldir, fpstype cameratypein, bool recursive, bool overwritefiles, bool showtime)
        {
            startdir = initaldir;
            cameratype = cameratypein;
            isrecursive = recursive;
            overwrite = overwritefiles;
            showsubtime = showtime;
            //processdirectory(new DirectoryInfo(initaldir));
        }

        public BatchTool(List<String> directorylist, fpstype cameratypein, bool recursive, bool overwritefiles, bool showtime)
        {
            dirlist = directorylist;
            cameratype = cameratypein;
            isrecursive = recursive;
            overwrite = overwritefiles;
            showsubtime = showtime;
            //foreach (String nextdirectory in directorylist)
            //{
            //    if (!isactive) break;
            //    processdirectory(new DirectoryInfo (nextdirectory));
            //}
        }


        public void ProcessVideoDirectory()
        {
            DirectoryInfo startdirectory = new DirectoryInfo(startdir);
            processdirectory(startdirectory);
        }
        
        private void processdirectory(DirectoryInfo newdir)
        {
            if (!isactive) return;
            String directoryis = "Entering Directory: " + newdir.FullName;
            SubGenEventArgs neweventargs = new SubGenEventArgs(directoryis, false, "");
            if (OnDirectoryChange != null)
            {
                OnDirectoryChange(this, neweventargs);
            }
            foreach (FileInfo file in newdir.GetFiles())
            {
                processfile(file);
            }
            if (isrecursive)
            {
                foreach (DirectoryInfo nextdir in newdir.GetDirectories())
                {
                    processdirectory(nextdir);
                }
            }

        }

        private void processfile(FileInfo file)
        {

            if (!isactive) return;
            if ((file.Extension == ".mts") || (file.Extension == ".m2ts"))
            {
                try
                {
                    String message = "   Opening File: " + file.FullName;
                    SubGenEventArgs neweventargs = new SubGenEventArgs(message, false, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                    SubFile newvideofile = new SubFile();
                    newvideofile.FpsType = cameratype;
                    newvideofile.VideoFile = file.FullName;
                    newvideofile.MakeSubTitles();
                    newvideofile.RemoveSubTime();                  
                    String filename = "   Processed File: " + file.FullName;
                    neweventargs = new SubGenEventArgs(filename, false, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                    if (showsubtime)
                    {
                        savesubtitles(file, newvideofile.FullSubOutput);
                    }
                    else
                    {
                        savesubtitles(file, newvideofile.NoTimeSubOutput);
                    }
                }
                catch
                {
                    String filename = "   Error Processing File: " + file.FullName;
                    SubGenEventArgs neweventargs = new SubGenEventArgs(filename, true, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                }
                //
                //  add code to actually generate and save the subtitles in here
                //  try/catch to find errors and trigger appropriate event
                //
                //Thread.Sleep(2000); //to simulate reading a real file - erase when code wired up.

            }
        }

        private void savesubtitles(FileInfo parentmtsfile, string subtitles)   //remember parentmtsfile is the name of the video file, not the output file
        {
            String videofilename = parentmtsfile.FullName;
            Regex rx = new Regex(@".m2{0,1}ts\z", RegexOptions.IgnoreCase);
            String savefilename = rx.Replace(videofilename, ".srt");
            //for safety sake check to ensure that this is not the mts or m2ts file!!!
            FileInfo temp = new FileInfo(savefilename);
            if (temp.Extension == ".mts" || temp.Extension == ".m2ts") return;
            if (File.Exists(savefilename) && overwrite == true)
            {
                try
                {
                    StreamWriter subfile_stream = new StreamWriter(savefilename, false);
                    subfile_stream.Write(subtitles);
                    subfile_stream.Close();
                    String message = "   Saved file: " + savefilename;
                    SubGenEventArgs neweventargs = new SubGenEventArgs(message, false, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                }
                catch
                {
                    String message = "   Unalbe to write file: " + savefilename;
                    SubGenEventArgs neweventargs = new SubGenEventArgs(message, true, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                }
            }
            else if (File.Exists(savefilename) && overwrite == false)
            {
                String message = "   File already exists: " + savefilename;
                SubGenEventArgs neweventargs = new SubGenEventArgs(message, true, "");
                if (OnSubgenResult != null)
                {
                    OnSubgenResult(this, neweventargs);
                }
            }
            else
            {
                try
                {
                    StreamWriter subfile_stream = new StreamWriter(savefilename, false);
                    subfile_stream.Write(subtitles);
                    subfile_stream.Close();
                    String message = "   Saved file: " + savefilename;
                    SubGenEventArgs neweventargs = new SubGenEventArgs(message, true, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                }
                catch
                {
                    String message = "   Unalbe to write file: " + savefilename;
                    SubGenEventArgs neweventargs = new SubGenEventArgs(message, true, "");
                    if (OnSubgenResult != null)
                    {
                        OnSubgenResult(this, neweventargs);
                    }
                }
            }

            //Console.WriteLine(savefilename);
        }

    }

    public class SubGenEventArgs : EventArgs
    {
        public readonly String resultstring;
        public readonly bool iserror;
        public readonly String errormessage;

        public SubGenEventArgs(String result, bool error, String emessage)
        {
            this.resultstring = result;
            this.iserror = error;
            this.errormessage = emessage;
        }
    }
}
