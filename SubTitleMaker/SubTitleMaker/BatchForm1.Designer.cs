namespace SubTitleMaker
{
    partial class BatchForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchForm1));
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lb_test = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lb_results = new System.Windows.Forms.ListBox();
            this.lb_directories = new System.Windows.Forms.ListBox();
            this.btn_adddir = new System.Windows.Forms.Button();
            this.btn_removedir = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lb_text1 = new System.Windows.Forms.Label();
            this.lb_text2 = new System.Windows.Forms.Label();
            this.lb_text3 = new System.Windows.Forms.Label();
            this.cb_recursive = new System.Windows.Forms.CheckBox();
            this.cb_overwrite = new System.Windows.Forms.CheckBox();
            this.rb_type0 = new System.Windows.Forms.RadioButton();
            this.rb_type1 = new System.Windows.Forms.RadioButton();
            this.gb_cameratype = new System.Windows.Forms.GroupBox();
            this.cb_showtime = new System.Windows.Forms.CheckBox();
            this.gb_cameratype.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(141, 610);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(84, 39);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(694, 611);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(88, 38);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lb_test
            // 
            this.lb_test.AutoSize = true;
            this.lb_test.Location = new System.Drawing.Point(30, 611);
            this.lb_test.Name = "lb_test";
            this.lb_test.Size = new System.Drawing.Size(38, 13);
            this.lb_test.TabIndex = 2;
            this.lb_test.Text = "Ready";
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(241, 610);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(81, 39);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // lb_results
            // 
            this.lb_results.FormattingEnabled = true;
            this.lb_results.Location = new System.Drawing.Point(141, 265);
            this.lb_results.Name = "lb_results";
            this.lb_results.Size = new System.Drawing.Size(641, 329);
            this.lb_results.TabIndex = 5;
            // 
            // lb_directories
            // 
            this.lb_directories.FormattingEnabled = true;
            this.lb_directories.Location = new System.Drawing.Point(141, 57);
            this.lb_directories.Name = "lb_directories";
            this.lb_directories.Size = new System.Drawing.Size(641, 173);
            this.lb_directories.TabIndex = 6;
            // 
            // btn_adddir
            // 
            this.btn_adddir.Location = new System.Drawing.Point(12, 57);
            this.btn_adddir.Name = "btn_adddir";
            this.btn_adddir.Size = new System.Drawing.Size(112, 30);
            this.btn_adddir.TabIndex = 7;
            this.btn_adddir.Text = "Add Directory";
            this.btn_adddir.UseVisualStyleBackColor = true;
            this.btn_adddir.Click += new System.EventHandler(this.btn_adddir_Click);
            // 
            // btn_removedir
            // 
            this.btn_removedir.Location = new System.Drawing.Point(12, 93);
            this.btn_removedir.Name = "btn_removedir";
            this.btn_removedir.Size = new System.Drawing.Size(112, 31);
            this.btn_removedir.TabIndex = 8;
            this.btn_removedir.Text = "Remove Directory";
            this.btn_removedir.UseVisualStyleBackColor = true;
            this.btn_removedir.Click += new System.EventHandler(this.btn_removedir_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(570, 611);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(96, 37);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save Log";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(12, 130);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(112, 31);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lb_text1
            // 
            this.lb_text1.AutoSize = true;
            this.lb_text1.Location = new System.Drawing.Point(17, 593);
            this.lb_text1.Name = "lb_text1";
            this.lb_text1.Size = new System.Drawing.Size(40, 13);
            this.lb_text1.TabIndex = 11;
            this.lb_text1.Text = "Status:";
            // 
            // lb_text2
            // 
            this.lb_text2.AutoSize = true;
            this.lb_text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_text2.Location = new System.Drawing.Point(137, 34);
            this.lb_text2.Name = "lb_text2";
            this.lb_text2.Size = new System.Drawing.Size(164, 20);
            this.lb_text2.TabIndex = 12;
            this.lb_text2.Text = "Directories to Process";
            // 
            // lb_text3
            // 
            this.lb_text3.AutoSize = true;
            this.lb_text3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_text3.Location = new System.Drawing.Point(137, 242);
            this.lb_text3.Name = "lb_text3";
            this.lb_text3.Size = new System.Drawing.Size(94, 20);
            this.lb_text3.TabIndex = 13;
            this.lb_text3.Text = "Results Log";
            // 
            // cb_recursive
            // 
            this.cb_recursive.AutoSize = true;
            this.cb_recursive.Location = new System.Drawing.Point(20, 177);
            this.cb_recursive.Name = "cb_recursive";
            this.cb_recursive.Size = new System.Drawing.Size(91, 30);
            this.cb_recursive.TabIndex = 14;
            this.cb_recursive.Text = "process\r\nsubdirectories";
            this.cb_recursive.UseVisualStyleBackColor = true;
            // 
            // cb_overwrite
            // 
            this.cb_overwrite.AutoSize = true;
            this.cb_overwrite.Location = new System.Drawing.Point(20, 219);
            this.cb_overwrite.Name = "cb_overwrite";
            this.cb_overwrite.Size = new System.Drawing.Size(71, 43);
            this.cb_overwrite.TabIndex = 15;
            this.cb_overwrite.Text = "Overwrite\r\nexisting\r\nfiles";
            this.cb_overwrite.UseVisualStyleBackColor = true;
            // 
            // rb_type0
            // 
            this.rb_type0.AutoSize = true;
            this.rb_type0.Location = new System.Drawing.Point(8, 30);
            this.rb_type0.Name = "rb_type0";
            this.rb_type0.Size = new System.Drawing.Size(58, 17);
            this.rb_type0.TabIndex = 16;
            this.rb_type0.Text = "Type 0";
            this.rb_type0.UseVisualStyleBackColor = true;
            // 
            // rb_type1
            // 
            this.rb_type1.AutoSize = true;
            this.rb_type1.Checked = true;
            this.rb_type1.Location = new System.Drawing.Point(8, 67);
            this.rb_type1.Name = "rb_type1";
            this.rb_type1.Size = new System.Drawing.Size(58, 17);
            this.rb_type1.TabIndex = 17;
            this.rb_type1.TabStop = true;
            this.rb_type1.Text = "Type 1";
            this.rb_type1.UseVisualStyleBackColor = true;
            // 
            // gb_cameratype
            // 
            this.gb_cameratype.Controls.Add(this.rb_type1);
            this.gb_cameratype.Controls.Add(this.rb_type0);
            this.gb_cameratype.Location = new System.Drawing.Point(12, 323);
            this.gb_cameratype.Name = "gb_cameratype";
            this.gb_cameratype.Size = new System.Drawing.Size(99, 90);
            this.gb_cameratype.TabIndex = 18;
            this.gb_cameratype.TabStop = false;
            this.gb_cameratype.Text = "Camera Type";
            // 
            // cb_showtime
            // 
            this.cb_showtime.AutoSize = true;
            this.cb_showtime.Location = new System.Drawing.Point(20, 278);
            this.cb_showtime.Name = "cb_showtime";
            this.cb_showtime.Size = new System.Drawing.Size(75, 17);
            this.cb_showtime.TabIndex = 19;
            this.cb_showtime.Text = "Show time";
            this.cb_showtime.UseVisualStyleBackColor = true;
            // 
            // BatchForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 661);
            this.Controls.Add(this.cb_showtime);
            this.Controls.Add(this.gb_cameratype);
            this.Controls.Add(this.cb_overwrite);
            this.Controls.Add(this.cb_recursive);
            this.Controls.Add(this.lb_text3);
            this.Controls.Add(this.lb_text2);
            this.Controls.Add(this.lb_text1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_removedir);
            this.Controls.Add(this.btn_adddir);
            this.Controls.Add(this.lb_directories);
            this.Controls.Add(this.lb_results);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lb_test);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatchForm1";
            this.Text = "Date/Time Batch Tool";
            this.gb_cameratype.ResumeLayout(false);
            this.gb_cameratype.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lb_test;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ListBox lb_results;
        private System.Windows.Forms.ListBox lb_directories;
        private System.Windows.Forms.Button btn_adddir;
        private System.Windows.Forms.Button btn_removedir;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label lb_text1;
        private System.Windows.Forms.Label lb_text2;
        private System.Windows.Forms.Label lb_text3;
        private System.Windows.Forms.CheckBox cb_recursive;
        private System.Windows.Forms.CheckBox cb_overwrite;
        private System.Windows.Forms.RadioButton rb_type0;
        private System.Windows.Forms.RadioButton rb_type1;
        private System.Windows.Forms.GroupBox gb_cameratype;
        private System.Windows.Forms.CheckBox cb_showtime;
    }
}