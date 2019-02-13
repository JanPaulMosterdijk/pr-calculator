namespace pr_calculator
{
    partial class PR
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
            this.run = new System.Windows.Forms.Button();
            this.fromPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tillPicker = new System.Windows.Forms.DateTimePicker();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addDateCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.run.Location = new System.Drawing.Point(279, 60);
            this.run.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(286, 39);
            this.run.TabIndex = 0;
            this.run.Text = "run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.button1_Click);
            // 
            // fromPicker
            // 
            this.fromPicker.Location = new System.Drawing.Point(124, 58);
            this.fromPicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fromPicker.Name = "fromPicker";
            this.fromPicker.Size = new System.Drawing.Size(151, 20);
            this.fromPicker.TabIndex = 2;
            this.fromPicker.ValueChanged += new System.EventHandler(this.fromPicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "from";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "till";
            // 
            // tillPicker
            // 
            this.tillPicker.Location = new System.Drawing.Point(124, 79);
            this.tillPicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tillPicker.Name = "tillPicker";
            this.tillPicker.Size = new System.Drawing.Size(151, 20);
            this.tillPicker.TabIndex = 5;
            this.tillPicker.ValueChanged += new System.EventHandler(this.tillPicker_ValueChanged);
            // 
            // pathBox
            // 
            this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathBox.Location = new System.Drawing.Point(124, 12);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(359, 20);
            this.pathBox.TabIndex = 6;
            this.pathBox.TextChanged += new System.EventHandler(this.pathBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Team.mdb location";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(487, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // titleBox
            // 
            this.titleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBox.Location = new System.Drawing.Point(124, 36);
            this.titleBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(359, 20);
            this.titleBox.TabIndex = 9;
            this.titleBox.Text = "pr competitie";
            this.titleBox.TextChanged += new System.EventHandler(this.titleBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "title";
            // 
            // addDateCheck
            // 
            this.addDateCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addDateCheck.AutoSize = true;
            this.addDateCheck.Checked = true;
            this.addDateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addDateCheck.Location = new System.Drawing.Point(496, 37);
            this.addDateCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addDateCheck.Name = "addDateCheck";
            this.addDateCheck.Size = new System.Drawing.Size(68, 17);
            this.addDateCheck.TabIndex = 12;
            this.addDateCheck.Text = "add date";
            this.addDateCheck.UseVisualStyleBackColor = true;
            this.addDateCheck.CheckedChanged += new System.EventHandler(this.addDateCheck_CheckedChanged);
            // 
            // PR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 104);
            this.Controls.Add(this.addDateCheck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.tillPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromPicker);
            this.Controls.Add(this.run);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PR";
            this.Text = "PR Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run;
        private System.Windows.Forms.DateTimePicker fromPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tillPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox addDateCheck;
    }
}

