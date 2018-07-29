namespace EmguFR.Train
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
            this.btnEnroll = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(179, 148);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(75, 23);
            this.btnEnroll.TabIndex = 0;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 148);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 73);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(91, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Choose Photo";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 111);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 13);
            this.lblFile.TabIndex = 3;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(274, 13);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(250, 251);
            this.lstFiles.TabIndex = 4;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(179, 223);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 5;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 285);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnEnroll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnTrain;
    }
}

