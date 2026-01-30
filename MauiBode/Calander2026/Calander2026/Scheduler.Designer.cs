namespace Calander2026
{
    partial class fScheduler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRecalculate = new System.Windows.Forms.Button();
            this.btnUpdateEndDate = new System.Windows.Forms.Button();
            this.btnUpdateStartDate = new System.Windows.Forms.Button();
            this.txtbEndDate = new System.Windows.Forms.TextBox();
            this.lblEndOfMonth = new System.Windows.Forms.Label();
            this.txtbStartDate = new System.Windows.Forms.TextBox();
            this.lblStartOfMonth = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRecalculate);
            this.groupBox1.Controls.Add(this.btnUpdateEndDate);
            this.groupBox1.Controls.Add(this.btnUpdateStartDate);
            this.groupBox1.Controls.Add(this.txtbEndDate);
            this.groupBox1.Controls.Add(this.lblEndOfMonth);
            this.groupBox1.Controls.Add(this.txtbStartDate);
            this.groupBox1.Controls.Add(this.lblStartOfMonth);
            this.groupBox1.Location = new System.Drawing.Point(417, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(202, 163);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Month Configuration";
            // 
            // btnRecalculate
            // 
            this.btnRecalculate.Location = new System.Drawing.Point(4, 106);
            this.btnRecalculate.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecalculate.Name = "btnRecalculate";
            this.btnRecalculate.Size = new System.Drawing.Size(170, 34);
            this.btnRecalculate.TabIndex = 15;
            this.btnRecalculate.Text = "Recalculate";
            this.btnRecalculate.UseVisualStyleBackColor = true;
            this.btnRecalculate.Click += new System.EventHandler(this.btnRecalculate_Click);
            // 
            // btnUpdateEndDate
            // 
            this.btnUpdateEndDate.Location = new System.Drawing.Point(119, 70);
            this.btnUpdateEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateEndDate.Name = "btnUpdateEndDate";
            this.btnUpdateEndDate.Size = new System.Drawing.Size(55, 20);
            this.btnUpdateEndDate.TabIndex = 14;
            this.btnUpdateEndDate.Text = "Update";
            this.btnUpdateEndDate.UseVisualStyleBackColor = true;
            this.btnUpdateEndDate.Click += new System.EventHandler(this.btnUpdateEndDate_Click);
            // 
            // btnUpdateStartDate
            // 
            this.btnUpdateStartDate.Location = new System.Drawing.Point(119, 32);
            this.btnUpdateStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateStartDate.Name = "btnUpdateStartDate";
            this.btnUpdateStartDate.Size = new System.Drawing.Size(55, 20);
            this.btnUpdateStartDate.TabIndex = 13;
            this.btnUpdateStartDate.Text = "Update";
            this.btnUpdateStartDate.UseVisualStyleBackColor = true;
            this.btnUpdateStartDate.Click += new System.EventHandler(this.btnUpdateStartDate_Click);
            // 
            // txtbEndDate
            // 
            this.txtbEndDate.Location = new System.Drawing.Point(4, 70);
            this.txtbEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtbEndDate.Name = "txtbEndDate";
            this.txtbEndDate.Size = new System.Drawing.Size(111, 20);
            this.txtbEndDate.TabIndex = 10;
            // 
            // lblEndOfMonth
            // 
            this.lblEndOfMonth.AutoSize = true;
            this.lblEndOfMonth.Location = new System.Drawing.Point(4, 54);
            this.lblEndOfMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndOfMonth.Name = "lblEndOfMonth";
            this.lblEndOfMonth.Size = new System.Drawing.Size(71, 13);
            this.lblEndOfMonth.TabIndex = 12;
            this.lblEndOfMonth.Text = "End of Month";
            // 
            // txtbStartDate
            // 
            this.txtbStartDate.Location = new System.Drawing.Point(4, 32);
            this.txtbStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtbStartDate.Name = "txtbStartDate";
            this.txtbStartDate.Size = new System.Drawing.Size(111, 20);
            this.txtbStartDate.TabIndex = 9;
            // 
            // lblStartOfMonth
            // 
            this.lblStartOfMonth.AutoSize = true;
            this.lblStartOfMonth.Location = new System.Drawing.Point(4, 16);
            this.lblStartOfMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartOfMonth.Name = "lblStartOfMonth";
            this.lblStartOfMonth.Size = new System.Drawing.Size(77, 13);
            this.lblStartOfMonth.TabIndex = 11;
            this.lblStartOfMonth.Text = "Start of Month:";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(181, 222);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbOutput.Size = new System.Drawing.Size(198, 560);
            this.rtbOutput.TabIndex = 22;
            this.rtbOutput.Text = "";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(15, 15);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 21;
            this.lblYear.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(18, 30);
            this.cmbYear.Margin = new System.Windows.Forms.Padding(2);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(155, 21);
            this.cmbYear.TabIndex = 20;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(16, 99);
            this.lblWeek.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 19;
            this.lblWeek.Text = "Week";
            // 
            // cmbWeek
            // 
            this.cmbWeek.FormattingEnabled = true;
            this.cmbWeek.Items.AddRange(new object[] {
            "Choose a week...",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbWeek.Location = new System.Drawing.Point(18, 115);
            this.cmbWeek.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(155, 21);
            this.cmbWeek.TabIndex = 18;
            this.cmbWeek.SelectedIndexChanged += new System.EventHandler(this.cmbWeek_SelectedIndexChanged);
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(179, 206);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(62, 13);
            this.lblFeedback.TabIndex = 17;
            this.lblFeedback.Text = "HERE I AM";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(15, 51);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 16;
            this.lblMonth.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(18, 71);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(155, 21);
            this.cmbMonth.TabIndex = 15;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(181, 30);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(7);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 14;
            // 
            // fScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 804);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.cmbWeek);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "fScheduler";
            this.Text = "Date Scheduler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRecalculate;
        private System.Windows.Forms.Button btnUpdateEndDate;
        private System.Windows.Forms.Button btnUpdateStartDate;
        private System.Windows.Forms.TextBox txtbEndDate;
        private System.Windows.Forms.Label lblEndOfMonth;
        private System.Windows.Forms.TextBox txtbStartDate;
        private System.Windows.Forms.Label lblStartOfMonth;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.ComboBox cmbWeek;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}

