using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SubExtractor
{
    public enum videotype
    {
        avchd = 0,
    }
    
    public class videometadata
    {
        //private long framerate;   //should I use these or the struct.
        //private int estimated_num_frames;
        private String filename;
        private videotype movievidtype;
        private movieinfo moviedata;
        private metaframe[] metaframedata;  //was using with array return type - object type more general
        //private List<metaframe_avchd> metaframedata;   //using with list return type

        public long Calc_Number_of_Frames
        {
            get
            {
                return moviedata.calc_number_of_frames;
            }
        }

        public float Calc_Framerate
        {
            get
            {
                return moviedata.framerate;
            }
        }

        public float Calc_Movielength
        {
            get
            {
               return (((float)moviedata.movielength)/1000000);
            }
        }

        public String getmetaframeText(int framenumber)
        {
            return metaframedata[framenumber].getmetaframeText();
        }
        
        public videometadata(String filename, videotype newvidtype)
        {
            this.filename = filename;
            this.movievidtype = newvidtype;
            //should I call the load functions from constructer here?
            if (newvidtype == videotype.avchd)
            {
                metaframedata = LoadAVCHDfile.Readfile(filename, ref moviedata); 
                
            }
        }

        public DateTime getFrameDateTime(int framenumber)
        {
            return metaframedata[framenumber].getDateTime();
        }

        public void writemetadatafile (String filename)   //should I be doing this at calling level? Makes it easier to pull the formatting from the UI code
        {
            String framestring;
            StreamWriter metatext_stream = new StreamWriter(filename, false);  //open file
            //add code to start file with important info
            framestring = "Metadata from file: " + filename + "\r\n";
            metatext_stream.Write(framestring);
            //framestring = "Calculated number of frames = " + moviedata.calc_number_of_frames.ToString() + "\r\n";
            //metatext_stream.Write(framestring);
            framestring = "Framerate = " + moviedata.framerate.ToString() + "\r\n";
            metatext_stream.Write(framestring);
            framestring = "Movie length = " + moviedata.movielength.ToString() + "\r\n\r\n";
            metatext_stream.Write(framestring);
            
            foreach (metaframe frame in metaframedata)
            {
                if (frame.isRealFrame == true)
                {
                    framestring = frame.getmetaframeText();
                    metatext_stream.Write(framestring);
                }              
            }
            metatext_stream.Close();
        }

    }

    struct movieinfo
    {
        public long calc_number_of_frames;
        public float framerate;
        public long movielength;
    }

    static class LoadAVCHDfile
    {
        //public static metaframe [] Readfile (String filename, ref movieinfo moviedata)
        public static metaframe[] Readfile (String filename, ref movieinfo moviedata) //will need to edit this back to array type
        {
            //metaframe_avchd[] avchdreturnarray;
            MetaDataHandle metaframe;
            metaframe = new MetaDataHandle();
            metaframe.VideoFile = filename;
            metaframe.getmetaframe();   //must catch exceptions around here

            if (metaframe.isFramedecoded == true)
            {
                metaframe_avchd[] avchd_data = metaframe.getmetadata();   //must catch exceptions around here
                //List<metaframe_avchd> avchd_data = metaframe.getmetadata();
                moviedata.framerate = metaframe.Frame_rate;
                moviedata.movielength = metaframe.Movie_length;
                moviedata.calc_number_of_frames = metaframe.Est_total_frames;
                return avchd_data;
            }
            else
            {
                throw new System.Exception("Error Processing AVCHD File");
            }
        }
    }
}
