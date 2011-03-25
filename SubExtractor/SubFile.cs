using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SubExtractor
{
    //replace with xml docs
    //relies on c library Sublib1.dll to be in the same executable directory
    //also needs avformat-52.dll and avcodec-52.dll (From FFMpeg) to be in the excutable directory
    //constructor takes pathname (as a string) to a mts movie file or pathname and the cameratype enum
    // call new Subfile (filenamestring)
    //Generates
    // RawSubOutput - String that contains subtitles with * breaking each subtitle
    // FullSubOutput - String that contains subtitles with \n breaking each subtitle - probably what you want
    // SplitSubOutput - List<String> contains each of the individual 1 second subtitle bits
    //
    // subtitles are split automatically, wastes memory, but I assume that isn't an issue.

    public class SubFile
    {
        [DllImport("Sublib1.dll")]
        //private static extern IntPtr createsub(IntPtr filename, int cameratype, byte separator);
        private static extern IntPtr createsub([MarshalAs(UnmanagedType.LPStr)]String filename, System.Int32 cameratype, System.Char separator);

        [DllImport("Sublib1.dll")]
        private static extern void freesub(IntPtr filepointer);
        
        private String rawsubfile;
        private string moviefile;
        private String collatedsubfile;
        private List<String> splitsubs;
        private int camera_type = 1;
        public enum fpstype
        {
            Type0 = 0,
            Type1 = 1,
        }
        fpstype fpsmode = fpstype.Type1;

        //constructors

        public SubFile()
        {
            
            //this.moviefile = p;
            //MakeSubTitles();
            //SplitSubTitles();
        }

        //public SubFile(string p, int cameratypein)
        //{
        //    this.moviefile = p;
        //    if (cameratypein == 0)
        //    {
        //        camera_type = 0;
        //    }
        //    else if (cameratypein == 1)
        //    {
        //        camera_type = 1;
        //    }
        //    else
        //    {
        //        throw new SystemException("Camera Type not Supported");
        //    }
        //    MakeSubTitles();
        //    SplitSubTitles();
        //}


        //properties follow

        public String VideoFile
        {
            get
            {
                return moviefile;
            }
            set
            {
                moviefile = value;
            }
        }

        public fpstype FpsType
        {
            get
            {
                return fpsmode;
            }
            set
            {
                fpsmode = value;
                camera_type = (int)fpsmode;
            }
        }
    
            
    


        public String RawSubOutput
        {
            get
            {
                return rawsubfile;
            }
        }

        public String FullSubOutput
        {
            get
            {
                return collatedsubfile;
            }
        }
        public List<String> SplitSubOutput
        {
            get
            {
                return splitsubs;
            }
        }

        //methods

        public void MakeSubTitles() 
        {
            
            //call the c dll at this point and convert to a C# string
            IntPtr output = IntPtr.Zero;
            //filename = Marshal.StringToHGlobalAnsi(moviefile);
            //byte sep = (byte) '*';

            //IntPtr output = createsub(filename, 1, sep);
            output = createsub(moviefile, camera_type, '*');    //always flags a stack imbalace error in debug mode - ignore for now
            //Marshal.FreeHGlobal(filename);
            rawsubfile = (String)Marshal.PtrToStringAnsi(output);
            freesub(output);                                       //use method in dll to free the results pointer - don't know if this matters, does work though
            //Marshal.FreeHGlobal(output);   //what is the right way to free the output pointer?
            //Marshal.FreeCoTaskMem(output);
            //Throw exceptions for each possible error returned by the c dll

            if (string.Compare(rawsubfile, "file_open_error") == 0)
            {
                throw new System.Exception("the movie file could not be opened");
            }
            if (string.Compare(rawsubfile, "no_stream_info") == 0)
            {
                throw new System.Exception("could not find stream information");
            }
            if (string.Compare(rawsubfile, "memory_error") == 0)
            {
                throw new System.Exception("Memory Error");
            }
            if (string.Compare(rawsubfile, "camera_not_supported_error") == 0)
            {
                throw new System.Exception("Camera Not Supported");
            }
            if (string.Compare(rawsubfile, "videostream_not_found_error") == 0)
            {
                throw new System.Exception("VideoStream not Found");
            }
            if (string.Compare(rawsubfile, "codec_not_found_error") == 0)
            {
                throw new System.Exception("Unsupported Codec");
            }
            if (string.Compare(rawsubfile, "open_codec_error") == 0)
            {
                throw new System.Exception("Could not open Codec");
            }

            StringBuilder editsubs = new StringBuilder(rawsubfile);
            editsubs.Replace('*', '\n');
            collatedsubfile = editsubs.ToString();
            
        }

        public void PrintOutput()  //writes the raw subfile to console - not usually what you want - good for debuging
        {
            Console.Write(rawsubfile);
        }

        public void SplitSubTitles()
        {
            splitsubs = new List<string>();
            foreach (string substring in rawsubfile.Split('*'))
            {
                splitsubs.Add(substring);
            }
        }
    }
}
