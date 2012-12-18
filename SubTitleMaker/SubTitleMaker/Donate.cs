using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SubTitleMaker
{
    public partial class Donate : Form
    {
        public Donate()
        {
            InitializeComponent();
            linkLabel1.Links.Add(0,22,"http://www.bitcoin.org");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("1FM9t1cSU3Y9xnoQoUEjLVgo8ZCYHUJ7PW");
        }
    }
}
