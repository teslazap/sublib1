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
            this.groupBox_cameratype.SuspendLayout();
            this.SuspendLayout();
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(13, 15);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(121, 37);
            this.openfile.TabIndex = 0;
            this.openfile.Text = "Select Movie File";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 27);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(624, 489);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.groupBox_cameratype);
            this.Controls.Add(this.rtb_subcontent);
            this.Controls.Add(this.btn_savesubs);
            this.Controls.Add(this.btn_subgen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.openfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(640, 525);
            this.MinimumSize = new System.Drawing.Size(640, 525);
            this.Name = "Form1";
            this.Text = "Date and Time Subtitle Generator";
            this.groupBox_cameratype.ResumeLayout(false);
            this.groupBox_cameratype.PerformLayout();
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
    }
}

