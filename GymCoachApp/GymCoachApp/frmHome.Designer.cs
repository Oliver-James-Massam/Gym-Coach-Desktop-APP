namespace GymCoachApp
{
    partial class frmHome
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
            this.cbxGoal = new System.Windows.Forms.ComboBox();
            this.cbxDays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lstOverview = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbxGoal
            // 
            this.cbxGoal.FormattingEnabled = true;
            this.cbxGoal.Location = new System.Drawing.Point(12, 25);
            this.cbxGoal.Name = "cbxGoal";
            this.cbxGoal.Size = new System.Drawing.Size(181, 21);
            this.cbxGoal.TabIndex = 0;
            // 
            // cbxDays
            // 
            this.cbxDays.FormattingEnabled = true;
            this.cbxDays.Location = new System.Drawing.Point(12, 67);
            this.cbxDays.Name = "cbxDays";
            this.cbxDays.Size = new System.Drawing.Size(181, 21);
            this.cbxDays.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Training Goal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Workout Days Per Week:";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 95);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 23);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Change Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lstOverview
            // 
            this.lstOverview.FormattingEnabled = true;
            this.lstOverview.Location = new System.Drawing.Point(12, 134);
            this.lstOverview.Name = "lstOverview";
            this.lstOverview.Size = new System.Drawing.Size(181, 303);
            this.lstOverview.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(511, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(81, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Exercise Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(585, 234);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lstOverview);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxDays);
            this.Controls.Add(this.cbxGoal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxGoal;
        private System.Windows.Forms.ComboBox cbxDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ListBox lstOverview;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox1;
    }
}

