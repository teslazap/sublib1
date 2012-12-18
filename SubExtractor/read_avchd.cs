using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SubExtractor
{
    class read_avchd
    {
    }

    public class MetaDataHandle
    {
        [DllImport("Sublib1.dll")]
        private static extern IntPtr getmetaframe([MarshalAs(UnmanagedType.LPStr)]String filename, System.Int32 cameratype, ref System.Int32 number_of_tags, ref System.Int32 metalength, ref System.Int64 totalframes,
            ref System.Int64 movielength, ref float framerate, ref IntPtr framedata);
        //private static extern void getmetaframe([MarshalAs(UnmanagedType.LPStr)]String filename, ref System.Int32 number_of_tags, ref System.Int32 framelength, [MarshalAs(UnmanagedType.LPStr)]String return_data);
        //private static extern void getmetaframe([MarshalAs(UnmanagedType.LPStr)]String filename, ref System.Int32 number_of_tags, ref System.Int32 framelength, IntPtr return_data);
        //private static extern IntPtr getmetaframe([MarshalAs(UnmanagedType.LPStr)]String filename, ref System.Int32 number_of_tags, ref System.Int32 framelength, IntPtr returndata2);

        [DllImport("Sublib1.dll")]
        private static extern IntPtr getmetadata([MarshalAs(UnmanagedType.LPStr)]String filename, System.Int32 cameratype, System.Int32 number_of_tags, System.Int32 metalength, System.Int32 numofframes,
            [In, Out] metaframe[] framedata);
        //private static extern IntPtr getmetadata([MarshalAs(UnmanagedType.LPStr)]String filename, System.Int32 cameratype, System.Int32 number_of_tags, System.Int32 metalength, System.Int32 numofframes,
        //ref metaframe[] framedata);

        [DllImport("Sublib1.dll")]
        private static extern void freemetaframe(ref IntPtr metaframepointer);

        public string testresult;
        private String moviefile;
        private int numtags;
        private int metalength;
        private long movielength;
        private float framerate;
        private byte[] firstframemetadata;
        //private byte[] fullmetaframeset;
        private bool infoset = false;
        private long totalframes;
        public string testoutput;

        //[StructLayout(LayoutKind.Sequential)]
        /*       private struct metaframe
              {
            
                   public int frameno;
                   public byte[] metaframedata;
                   public metaframe(int framelength)
                   {
                       this.metaframedata = new byte[framelength];
                       this.frameno = 0;
                   }
                   //IntPtr metaframeptr;
               }*/
        [StructLayout(LayoutKind.Sequential)]
        private struct metaframe
        {
            public int frameno;
            public int p_flags;
            public System.Int64 p_pts;
            public System.Int64 p_dts;
            public System.Int64 p_pos;
            public int p_dur;
            public IntPtr framedataptr;
        }

        metaframe[] fullmetadata;

        public MetaDataHandle()
        {

        }

        //class properties follow
        public String VideoFile
        {
            get
            {
                return moviefile;
            }
            set
            {
                if (moviefile == null)
                {
                    moviefile = value;
                }
                else
                {
                    throw new System.Exception("Video File Previously Set on this Instance");
                }
            }
        }

        public int Number_of_tags
        {
            get
            {
                return numtags;
            }
        }

        public int Metaframe_size
        {
            get
            {
                return metalength;
            }
        }

        public byte[] First_metaframe_raw
        {
            get
            {
                return firstframemetadata;
            }
        }
        public bool isFramedecoded
        {
            get
            {
                return infoset;
            }
        }
        public long Movie_length
        {
            get
            {
                return movielength;
            }
        }
        public float Frame_rate
        {
            get
            {
                return framerate;
            }
        }

        public long Est_total_frames
        {
            get
            {
                return totalframes;
            }
        }



        //class methods follow
        public void getmetaframe()
        {

            IntPtr returndata = IntPtr.Zero;
            IntPtr framedata = IntPtr.Zero;
            //framedata = Marshal.AllocCoTaskMem(1024);   //doing memory allocation on unmanaged size, don't forget to free pointers
            //StringBuilder returnstring2 = new StringBuilder(500);   //doing memory allocation on unmanaged size
            returndata = getmetaframe(moviefile, 0, ref numtags, ref metalength, ref totalframes, ref movielength, ref framerate, ref framedata);
            testresult = (String)Marshal.PtrToStringAnsi(returndata);
            if (string.Compare(testresult, "found_metaframe") == 0)
            {
                byte[] metaframe = new byte[metalength];
                Marshal.Copy(framedata, metaframe, 0, metalength);
                firstframemetadata = metaframe;
                infoset = true;
            }

            if (string.Compare(testresult, "file_open_error") == 0)
            {
                throw new System.Exception("The Movie File Could Not be Opened");
            }
            if (string.Compare(testresult, "no_stream_info") == 0)
            {
                throw new System.Exception("Could Not Find Stream Information");
            }
            if (string.Compare(testresult, "memory_error") == 0)
            {
                throw new System.Exception("Memory Error");
            }
            if (string.Compare(testresult, "camera_not_supported_error") == 0)
            {
                throw new System.Exception("Camera Not Supported");
            }
            if (string.Compare(testresult, "videostream_not_found_error") == 0)
            {
                throw new System.Exception("Video Stream Not Found");
            }
            if (string.Compare(testresult, "codec_not_found_error") == 0)
            {
                throw new System.Exception("Unsupported Codec");
            }
            if (string.Compare(testresult, "open_codec_error") == 0)
            {
                throw new System.Exception("Could Not Open Codec");
            }

            freemetaframe(ref framedata);
        }

        public metaframe_avchd[] getmetadata()  //use this with the array type return
        //public List<metaframe_avchd> getmetadata()   //testing a list return, but can't figure out inheritance
        {
            int estimatedframes = (int)(((movielength / 1000000) * framerate) * 1.10);   //change the last number to add some buffer
            totalframes = estimatedframes;
            int framesize = numtags * 5;
            fullmetadata = new metaframe[estimatedframes];
            //for (int i = 1; i< estimatedframes; i++)  //for use with byte array version
            //{
            //    //fullmetadata[i].metaframedata = new byte[framesize];
            //    fullmetadata[i] = new metaframe(framesize);
            //}
            for (int i = 0; i < estimatedframes; i++)   //for use with inptr version  //don't forget to free memory
            {
                fullmetadata[i].frameno = 0;
                fullmetadata[i].p_flags = 0;
                fullmetadata[i].p_dur = 0;
                fullmetadata[i].p_pts = 0;
                fullmetadata[i].p_dts = 0;
                fullmetadata[i].p_pos = 0;
                fullmetadata[i].framedataptr = Marshal.AllocHGlobal(framesize);
            }
            IntPtr test = getmetadata(moviefile, 0, numtags, metalength, estimatedframes, fullmetadata);
            testresult = (String)Marshal.PtrToStringAnsi(test);

            if (string.Compare(testresult, "file_open_error") == 0)
            {
                throw new System.Exception("The Movie File Could Not be Opened");
            }
            if (string.Compare(testresult, "no_stream_info") == 0)
            {
                throw new System.Exception("Could Not Find Stream Information");
            }
            if (string.Compare(testresult, "memory_error") == 0)
            {
                throw new System.Exception("Memory Error");
            }
            if (string.Compare(testresult, "camera_not_supported_error") == 0)
            {
                throw new System.Exception("Camera Not Supported");
            }
            if (string.Compare(testresult, "videostream_not_found_error") == 0)
            {
                throw new System.Exception("Video Stream Not Found");
            }
            if (string.Compare(testresult, "codec_not_found_error") == 0)
            {
                throw new System.Exception("Unsupported Codec");
            }
            if (string.Compare(testresult, "open_codec_error") == 0)
            {
                throw new System.Exception("Could Not Open Codec");
            }

            if (string.Compare(testresult, "metadata_copied") == 0)  //check for correct return flag
            {
                testoutput = testresult;    //need code here to process internal metadata pointers - assuming proper return code
                byte [] temp = new byte[framesize];
                metaframe_avchd[] resultsarray = new metaframe_avchd[estimatedframes];
                for (int i = 0; i < estimatedframes; i++)   //for use with inptr version  //don't forget to free memory
                {
                    //must marshal ptr to byte array here
                    Marshal.Copy(fullmetadata[i].framedataptr,temp,0,framesize);
                    resultsarray[i] = new metaframe_avchd(i, framesize, temp);
                    resultsarray[i].PacketFlags = fullmetadata[i].p_flags;
                    resultsarray[i].PacketDuration = fullmetadata[i].p_dur;
                    resultsarray[i].PacketPts = fullmetadata[i].p_pts;
                    resultsarray[i].PacketPos = fullmetadata[i].p_pos;
                    resultsarray[i].PacketDts = fullmetadata[i].p_dts;
                    resultsarray[i].PacketDuration = fullmetadata[i].p_dur;
                    if (fullmetadata[i].p_dur != 0) resultsarray[i].isRealFrame = true;
                    Marshal.FreeHGlobal(fullmetadata[i].framedataptr);
                    
                }
                return resultsarray;
                //List<metaframe_avchd> metalist = resultsarray.ToList();
                //return metalist;
            }
            else
            {
                throw new System.Exception("Error Processing AVCHD video file");
            }



        }
    }


}

