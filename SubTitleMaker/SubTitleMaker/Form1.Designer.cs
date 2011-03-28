namespace SubTitleMaker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openfile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_subgen = new System.Windows.Forms.Button();
            this.btn_savesubs = new System.Windows.Forms.Button();
            this.rtb_subcontent = new System.Windows.Forms.RichTextBox();
            this.groupBox_cameratype = new System.Windows.Forms.GroupBox();
            this.radioButton_type1 = new System.Windows.Forms.RadioButton();
            this.radioButton_type0 = new System.Windows.Forms.RadioButton();
            this.btn_exit = new System.Windows.Forms.Button();
            this.ttip_camera = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lb_elapsedtime = new System.Windows.Forms.Label();
            this.menu_mainmenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_timedisp = new System.Windows.Forms.CheckBox();
            this.ttip_displaytime = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_cameratype.SuspendLayout();
            this.menu_mainmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(13, 34);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(121, 30);
            this.openfile.TabIndex = 0;
            this.openfile.Text = "Select Movie File";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path:";
            // 
            // btn_subgen
            // 
            this.btn_subgen.Enabled = false;
            this.btn_subgen.Location = new System.Drawing.Point(14, 73);
            this.btn_subgen.Name = "btn_subgen";
            this.btn_subgen.Size = new System.Drawing.Size(119, 32);
            this.btn_subgen.TabIndex = 3;
            this.btn_subgen.Text = "Generate Subtitles";
            this.btn_subgen.UseVisualStyleBackColor = true;
            this.btn_subgen.Click += new System.EventHandler(this.btn_subgen_Click);
            // 
            // btn_savesubs
            // 
            this.btn_savesubs.Enabled = false;
            this.btn_savesubs.Location = new System.Drawing.Point(17, 439);
            this.btn_savesubs.Name = "btn_savesubs";
            this.btn_savesubs.Size = new System.Drawing.Size(117, 32);
            this.btn_savesubs.TabIndex = 4;
            this.btn_savesubs.Text = "Save Subtitles";
            this.btn_savesubs.UseVisualStyleBackColor = true;
            this.btn_savesubs.Click += new System.EventHandler(this.btn_savesubs_Click);
            // 
            // rtb_subcontent
            // 
            this.rtb_subcontent.Enabled = false;
            this.rtb_subcontent.Location = new System.Drawing.Point(218, 62);
            this.rtb_subcontent.Name = "rtb_subcontent";
            this.rtb_subcontent.Size = new System.Drawing.Size(381, 359);
            this.rtb_subcontent.TabIndex = 5;
            this.rtb_subcontent.Text = "";
            // 
            // groupBox_cameratype
            // 
            this.groupBox_cameratype.Controls.Add(this.radioButton_type1);
            this.groupBox_cameratype.Controls.Add(this.radioButton_type0);
            this.groupBox_cameratype.Location = new System.Drawing.Point(19, 120);
            this.groupBox_cameratype.Name = "groupBox_cameratype";
            this.groupBox_cameratype.Size = new System.Drawing.Size(113, 98);
            this.groupBox_cameratype.TabIndex = 6;
            this.groupBox_cameratype.TabStop = false;
            this.groupBox_cameratype.Text = "Camera Type";
            // 
            // radioButton_type1
            // 
            this.radioButton_type1.AutoSize = true;
            this.radioButton_type1.Checked = true;
            this.radioButton_type1.Location = new System.Drawing.Point(13, 61);
            this.radioButton_type1.Name = "radioButton_type1";
            this.radioButton_type1.Size = new System.Drawing.Size(58, 17);
            this.radioButton_type1.TabIndex = 1;
            this.radioButton_type1.TabStop = true;
            this.radioButton_type1.Text = "Type 1";
            this.radioButton_type1.UseVisualStyleBackColor = true;
            // 
            // radioButton_type0
            // 
            this.radioButton_type0.AutoSize = true;
            this.radioButton_type0.Location = new System.Drawing.Point(13, 26);
            this.radioButton_type0.Name = "radioButton_type0";
            this.radioButton_type0.Size = new System.Drawing.Size(58, 17);
            this.radioButton_type0.TabIndex = 0;
            this.radioButton_type0.Text = "Type 0";
            this.radioButton_type0.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(489, 437);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(110, 34);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // ttip_camera
            // 
            this.ttip_camera.ToolTipTitle = "Camera Type";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Elapsed Time:";
            // 
            // lb_elapsedtime
            // 
            this.lb_elapsedtime.AutoSize = true;
            this.lb_elapsedtime.Location = new System.Drawing.Point(295, 439);
            this.lb_elapsedtime.Name = "lb_elapsedtime";
            this.lb_elapsedtime.Size = new System.Drawing.Size(13, 13);
            this.lb_elapsedtime.TabIndex = 9;
            this.lb_elapsedtime.Text = "0";
            // 
            // menu_mainmenu
            // 
            this.menu_mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu_mainmenu.Location = new System.Drawing.Point(0, 0);
            this.menu_mainmenu.Name = "menu_mainmenu";
            this.menu_mainmenu.Size = new System.Drawing.Size(624, 24);
            this.menu_mainmenu.TabIndex = 10;
            this.menu_mainmenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // cb_timedisp
            // 
            this.cb_timedisp.AutoSize = true;
            this.cb_timedisp.Enabled = false;
            this.cb_timedisp.Location = new System.Drawing.Point(32, 241);
            this.cb_timedisp.Name = "cb_timedisp";
            this.cb_timedisp.Size = new System.Drawing.Size(86, 17);
            this.cb_timedisp.TabIndex = 11;
            this.cb_timedisp.Text = "Display Time";
            this.cb_timedisp.UseVisualStyleBackColor = true;
            this.cb_timedisp.Click += new System.EventHandler(this.cb_timedisp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(624, 489);
            this.Controls.Add(this.cb_timedisp);
            this.Controls.Add(this.lb_elapsedtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.groupBox_cameratype);
            this.Controls.Add(this.rtb_subcontent);
            this.Controls.Add(this.btn_savesubs);
            this.Controls.Add(this.btn_subgen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.openfile);
            this.Controls.Add(this.menu_mainmenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_mainmenu;
            this.MaximumSize = new System.Drawing.Size(640, 525);
            this.MinimumSize = new System.Drawing.Size(640, 525);
            this.Name = "Form1";
            this.Text = "Date and Time Subtitle Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_cameratype.ResumeLayout(false);
            this.groupBox_cameratype.PerformLayout();
            this.menu_mainmenu.ResumeLayout(false);
            this.menu_mainmenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_subgen;
        private System.Windows.Forms.Button btn_savesubs;
        private System.Windows.Forms.RichTextBox rtb_subcontent;
        private System.Windows.Forms.GroupBox groupBox_cameratype;
        private System.Windows.Forms.RadioButton radioButton_type1;
        private System.Windows.Forms.RadioButton radioButton_type0;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ToolTip ttip_camera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_elapsedtime;
        private System.Windows.Forms.MenuStrip menu_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.CheckBox cb_timedisp;
        private System.Windows.Forms.ToolTip ttip_displaytime;
    }
}

