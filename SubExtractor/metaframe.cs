using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubExtractor
{
    abstract public class metaframe
    {
        protected int framenum;
        protected int framelength;
        protected byte[] metadata_array;
        private bool isLiveFrame = false;

/*        public int FrameNumber
        {
            get
            {
                return framenum;
            }
            set
            {
                framenum = value;
            }
        }

        public int FrameLength
        {
            get
            {
                return framelength;
            }
            set
            {
                framelength = value;
            }
        }*/

        public bool isRealFrame
        {
            get
            {
                return isLiveFrame;
            }
            set
            {
                isLiveFrame = value;
            }
        }

        public metaframe(int framenum, int framelength, byte[] metadatain)
        {
            this.framenum = framenum;
            this.framelength = framelength;
            metadata_array = new byte[framelength];
            this.metadata_array = (byte[])metadatain.Clone();

        }

        virtual public byte[] getrawframe()
        {
            return metadata_array;
        }
        abstract public DateTime getDateTime();
        abstract public void searchframe();
        abstract public String getmetaframeText();
        public override string ToString()
        {
            return BitConverter.ToString(metadata_array);
            //return base.ToString();
        }

    }
}
