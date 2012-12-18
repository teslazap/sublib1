using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubExtractor
{
    public class metaframe_avchd: metaframe
    {
        private int p_flags;
        private int p_dur;
        private long p_pts;
        private long p_dts;
        private long p_pos;
        

        public int PacketFlags
        {
            get
            {
                return p_flags;
            }
            set
            {
                p_flags = value;
            }
        }

        public int PacketDuration
        {
            get
            {
                return p_dur;
            }
            set
            {
                p_dur = value;
            }
        }

        public long PacketPts
        {
            get
            {
                return p_pts;
            }
            set
            {
                p_pts = value;
            }
        }

        public long PacketDts
        {
            get
            {
                return p_dts;
            }
            set
            {
                p_dts = value;
            }
        }

        public long PacketPos
        {
            get
            {
                return p_pos;
            }
            set
            {
                p_pos = value;
            }
        }


        

        public metaframe_avchd (int framenum, int framelength, byte [] metadatain):
        base(framenum, framelength, metadatain)
        {
            //this.metadata_array = (byte[]) metadatain.Clone();
            //metadatain.CopyTo(this.metadata_array, 0);
        }
        

        public override DateTime getDateTime()
        {
            //throw new NotImplementedException();
            String S_yr_msd = "", S_yr_yr = "", S_month = "";
            String S_day = "", S_hr = "", S_min = "", S_sec = "";
            for (int i =0; i < framelength ; i++)
            {
                if (metadata_array[i] == 0x18)
                {
                    S_yr_msd = BitConverter.ToString(metadata_array, i + 2, 1);
                    S_yr_yr = BitConverter.ToString(metadata_array, i + 3, 1);
                    S_month = BitConverter.ToString(metadata_array, i + 4, 1);
                    break;
                }
            }

            for (int i =0; i < framelength ; i++)
            {
                if (metadata_array[i] == 0x19)
                {
                    S_day = BitConverter.ToString(metadata_array, i + 1, 1);
                    S_hr = BitConverter.ToString(metadata_array, i + 2, 1);
                    S_min = BitConverter.ToString(metadata_array, i + 3, 1);
                    S_sec = BitConverter.ToString(metadata_array, i + 4, 1);
                    break;
                }
            }
                    
            string year = S_yr_msd + S_yr_yr;
            return new DateTime(Convert.ToInt32(year), Convert.ToInt32(S_month), Convert.ToInt32(S_day), Convert.ToInt32(S_hr), Convert.ToInt32(S_min), Convert.ToInt32(S_sec));
        }

        public override string getmetaframeText()
        {
            //throw new NotImplementedException();
            StringBuilder Result = new StringBuilder ();

            Result.Append("FrameNumber: " + framenum.ToString() + "\r\n");
            Result.Append("PTS: " + p_pts.ToString() + "\r\n");
            Result.Append ("DTS: " + p_dts.ToString() + "\r\n");
            Result.Append("POS: " + p_pos.ToString() + "\r\n");
            Result.Append("Data: " + this.ToString() + "\r\n\r\n");

            return Result.ToString();
        }
        
        public override void searchframe()
        {
            throw new NotImplementedException();
        }
    }
}
