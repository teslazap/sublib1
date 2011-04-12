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
//    along with the Time and Date Subtilte Maker.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SubExtractor
{
    //replace with xml docs
    //relies on c library Sublib1.dll to be in the same executable directory
    //also needs avformat-52.dll and avcodec-52.dll (From FFMpeg) to be in the excutable directory
    //constructor has no args
    //application using this library must:
    // 1. Set VideoFile property to the full pathname of the mts file
    // 2. Set FpsType to fpstype enum - defaults to fpstype.Type1
    // 3. Call MakeSubTitles() after doing 1 and 2.
    //Generates
    // RawSubOutput - String that contains subtitles with * breaking each subtitle
    // FullSubOutput - String that contains subtitles with \r\n breaking each subtitle - probably what you want
    // SplitSubOutput - List<String> contains each of the individual 1 second subtitle bits - you might want this list for further processing
    //      a call to SplitSubTitles() must preceed access to the SplitSubOutput
    // RemoveSubTime() lops off the time display at the end of each subtitle. 
    // subtitles are no longer split automatically.
    // as of this point sublib1 may be called in a multithreaded fashion, there are no "static" variables in it, but this hasn't been tested.



    /// <summary>
    /// Enum denoting the method of calculating fps
    /// </summary>
    public enum fpstype
    {
        Type0 = 0,
        Type1 = 1,
    }
        
    /// <summary>
    /// SubFile class provides methods to extract date and time metadata from .mts and .m2ts (h264) files and generate subtitle strings.</summary>
    /// <remarks>Usage:<para />
    /// <list type="bullet">
    /// <item><description>Set VideoFile property to the full pathname of the mts file for which you wish to generate date and time subtitles</description></item> 
    /// <item><description>Set the FpsType property to fpstype enum - this will default to fpstype.Type1</description></item>  
    /// <item><description>Call MakeSubTitles() </description></item>
    /// </list> 
    /// </remarks>
    public class SubFile
    {
        [DllImport("Sublib1.dll")]
        //private static extern IntPtr createsub(IntPtr filename, int cameratype, byte separator);  //trying to fix the unbalanced stack warning
        private static extern IntPtr createsub([MarshalAs(UnmanagedType.LPStr)]String filename, System.Int32 cameratype, System.Char separator);

        [DllImport("Sublib1.dll")]
        private static extern void freesub(IntPtr filepointer);
        
        private String rawsubfile;
        private string moviefile;
        private String collatedsubfile;
        private String notimesubfile;
        private List<String> splitsubs;
        private int camera_type = 1;
        fpstype fpsmode = fpstype.Type1;


        //constructors

        /// <summary>
        /// SubFile Constructor
        /// </summary>
        public SubFile()
        {
            
        }

        //properties follow

        /// <summary>
        /// VideoFile property - pathname of file to be processed
        /// </summary>
        /// <value>Set to string that contains full pathname of the videofile to be processed</value>
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

        /// <summary>
        /// FpsType property - set to fpstype enum
        /// </summary>
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
    
            
    

        /// <summary>
        /// Unedited subtitle string - including separators
        /// </summary>
        public String RawSubOutput
        {
            get
            {
                return rawsubfile;
            }
        }

        /// <summary>
        /// Subtitle string including date and time
        /// </summary>
        public String FullSubOutput
        {
            get
            {
                return collatedsubfile;
            }
        }
        
        /// <summary>
        /// List of subtitle strings split by entry
        /// </summary>
        public List<String> SplitSubOutput
        {
            get
            {
                return splitsubs;
            }
        }

        /// <summary>
        /// Subtitle string with date but not time
        /// </summary>
        public String NoTimeSubOutput
        {
            get
            {
                return notimesubfile;
            }
        }

        //methods

        public void MakeSubTitles() 
        {
            
            //call the c dll at this point and convert to a C# string
            IntPtr output = IntPtr.Zero;
            
            //filename = Marshal.StringToHGlobalAnsi(moviefile);  //doesn't apear necessary to marshal filname string to pointer
            //byte sep = (byte) '*';

            //IntPtr output = createsub(filename, 1, sep);
            output = createsub(moviefile, camera_type, '*');    //always flags a stack imbalace error in debug mode - ignore for now (shut off in exceptions)
            rawsubfile = (String)Marshal.PtrToStringAnsi(output);
            //freesub(output);                                    //use method in dll to free the results pointer - don't know if this matters, does work though
            //Marshal.FreeHGlobal(output);   //what is the right way to free the output pointer? This will throw exception. 
         
            //Throw exceptions for each possible error returned by the c dll

            if (string.Compare(rawsubfile, "file_open_error") == 0)
            {
                throw new System.Exception("The Movie File Could Not be Opened");
            }
            if (string.Compare(rawsubfile, "no_stream_info") == 0)
            {
                throw new System.Exception("Could Not Find Stream Information");
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
                throw new System.Exception("Video Stream Not Found");
            }
            if (string.Compare(rawsubfile, "codec_not_found_error") == 0)
            {
                throw new System.Exception("Unsupported Codec");
            }
            if (string.Compare(rawsubfile, "open_codec_error") == 0)
            {
                throw new System.Exception("Could Not Open Codec");
            }

            freesub(output);   //free pointer in c code here

            //StringBuilder editsubs = new StringBuilder(rawsubfile);
            //editsubs.Replace("*", "\n");
            //editsubs.Replace("\x0d", "\x0d\x0a");
            //collatedsubfile = editsubs.ToString();

            collatedsubfile = rawsubfile.Replace("\n", "\r\n");
            collatedsubfile = collatedsubfile.Replace("*", "\r\n");
            
        }

        /// <summary>
        /// Writes the raw subtitle string to the console - for debugging
        /// </summary>
        public void PrintOutput()  //writes the raw subfile to console - not usually what you want - good for debuging
        {
            Console.Write(rawsubfile);
        }

        /// <summary>
        /// Splits the subtitles by entry
        /// </summary>
        public void SplitSubTitles()
        {
            String tempstring;
            splitsubs = new List<string>();
            foreach (string substring in rawsubfile.Split('*'))
            {
                tempstring = substring.Replace("\n", "\r\n");
                splitsubs.Add(tempstring);
            }
        }

        /// <summary>
        /// Removes the time from subtitle string
        /// </summary>
        public void RemoveSubTime()
        {
            Regex rx = new Regex(@"\b\d{2}:\d{2}:\d{2}\r\n", RegexOptions.IgnoreCase);
            notimesubfile = rx.Replace(collatedsubfile, "\r\n");
        }
    }
}
