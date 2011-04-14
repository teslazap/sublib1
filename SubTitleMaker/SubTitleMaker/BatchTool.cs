using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SubExtractor;
using System.Threading;

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

        public BatchTool(String initaldir, fpstype cameratypein, bool recursive)
        {
            startdir = initaldir;
            cameratype = cameratypein;
            isrecursive = recursive;
            //processdirectory(new DirectoryInfo(initaldir));
        }

        public BatchTool(List<String> directorylist, fpstype cameratypein, bool recursive)
        {
            dirlist = directorylist;
            cameratype = cameratypein;
            isrecursive = recursive;
            //foreach (String nextdirectory in directorylist)
            //{
            //    if (!isactive) break;
            //    processdirectory(new DirectoryInfo (nextdirectory));
            //}
        }

        private void fakerun()  //just for testing purposes, erase later.
        {
            String fakeresult;
            for (int i = 0; i < 15; i++)
            {
                if (!isactive) break;
                fakeresult = "You are a loser " + i.ToString();
                resultlog.Add(fakeresult);
                Thread.Sleep(1000);
                SubGenEventArgs neweventargs = new SubGenEventArgs(fakeresult, false, "");
                if (OnSubgenResult != null)
                {
                    OnSubgenResult(this, neweventargs);
                }
            }
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
                //
                //  add code to actually generate and save the subtitles in here
                //  try/catch to find errors and trigger appropriate event
                //
                //Thread.Sleep(2000); //to simulate reading a real file - erase when code wired up.
                String filename = "   Processed File: " + file.FullName;
                SubGenEventArgs neweventargs = new SubGenEventArgs(filename, false, "");
                if (OnSubgenResult != null)
                {
                    OnSubgenResult(this, neweventargs);
                }
            }
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
