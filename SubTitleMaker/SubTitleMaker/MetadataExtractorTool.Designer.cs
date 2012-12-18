namespace SubTitleMaker
{
    partial class MetadataExtractorTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataExtractorTool));
            this.btn_openfile = new System.Windows.Forms.Button();
            this.lb_path = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.btn_savemetadata = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lb_results = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_openfile
            // 
            this.btn_openfile.Location = new System.Drawing.Point(12, 16);
            this.btn_openfile.Name = "btn_openfile";
            this.btn_openfile.Size = new System.Drawing.Size(113, 32);
            this.btn_openfile.TabIndex = 0;
            this.btn_openfile.Text = "Select Movie File";
            this.btn_openfile.UseVisualStyleBackColor = true;
            this.btn_openfile.Click += new System.EventHandler(this.btn_openfile_Click);
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Location = new System.Drawing.Point(150, 26);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(32, 13);
            this.lb_path.TabIndex = 1;
            this.lb_path.Text = "Path:";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(188, 23);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(434, 20);
            this.tb_path.TabIndex = 2;
            // 
            // btn_analyze
            // 
            this.btn_analyze.Enabled = false;
            this.btn_analyze.Location = new System.Drawing.Point(14, 62);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(110, 28);
            this.btn_analyze.TabIndex = 3;
            this.btn_analyze.Text = "Analyze File";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // btn_savemetadata
            // 
            this.btn_savemetadata.Enabled = false;
            this.btn_savemetadata.Location = new System.Drawing.Point(14, 107);
            this.btn_savemetadata.Name = "btn_savemetadata";
            this.btn_savemetadata.Size = new System.Drawing.Size(111, 30);
            this.btn_savemetadata.TabIndex = 4;
            this.btn_savemetadata.Text = "Save Metadata";
            this.btn_savemetadata.UseVisualStyleBackColor = true;
            this.btn_savemetadata.Click += new System.EventHandler(this.btn_savemetadata_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(552, 255);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(69, 28);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lb_results
            // 
            this.lb_results.FormattingEnabled = true;
            this.lb_results.Location = new System.Drawing.Point(188, 77);
            this.lb_results.Name = "lb_results";
            this.lb_results.Size = new System.Drawing.Size(432, 147);
            this.lb_results.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Elapsed Time:";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(271, 254);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(13, 13);
            this.label_time.TabIndex = 8;
            this.label_time.Text = "0";
            // 
            // MetadataExtractorTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 290);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_results);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_savemetadata);
            this.Controls.Add(this.btn_analyze);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.lb_path);
            this.Controls.Add(this.btn_openfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MetadataExtractorTool";
            this.Text = "Extract MetaData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_openfile;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.Button btn_savemetadata;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ListBox lb_results;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_time;
    }
}