namespace SimpleClientWordProcessor
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
            this.richTxtLongFile = new System.Windows.Forms.RichTextBox();
            this.richTxtShortFile = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTxtLongFile
            // 
            this.richTxtLongFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtLongFile.Location = new System.Drawing.Point(36, 56);
            this.richTxtLongFile.Name = "richTxtLongFile";
            this.richTxtLongFile.Size = new System.Drawing.Size(468, 180);
            this.richTxtLongFile.TabIndex = 0;
            this.richTxtLongFile.Text = "";
            // 
            // richTxtShortFile
            // 
            this.richTxtShortFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtShortFile.Location = new System.Drawing.Point(36, 267);
            this.richTxtShortFile.Name = "richTxtShortFile";
            this.richTxtShortFile.Size = new System.Drawing.Size(468, 180);
            this.richTxtShortFile.TabIndex = 1;
            this.richTxtShortFile.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "LONG FILES";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SHORT FILES";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(81, 14);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(264, 20);
            this.urlTextBox.TabIndex = 4;
            this.urlTextBox.Text = "http://localhost:4040/FileOperation/data/fileoperation";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(532, 11);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "URL:";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(389, 14);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(118, 20);
            this.Path.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Path:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 429);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTxtShortFile);
            this.Controls.Add(this.richTxtLongFile);
            this.Name = "Form1";
            this.Text = "SimpleClientWordProcessor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTxtLongFile;
        private System.Windows.Forms.RichTextBox richTxtShortFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label4;
    }
}

