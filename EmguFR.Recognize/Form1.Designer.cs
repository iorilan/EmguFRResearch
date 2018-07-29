namespace EmguFR.Recognize
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
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.btnSelectModel = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Location = new System.Drawing.Point(13, 44);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(97, 23);
            this.btnUploadPhoto.TabIndex = 0;
            this.btnUploadPhoto.Text = "Upload Photo";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // btnSelectModel
            // 
            this.btnSelectModel.Location = new System.Drawing.Point(13, 128);
            this.btnSelectModel.Name = "btnSelectModel";
            this.btnSelectModel.Size = new System.Drawing.Size(97, 23);
            this.btnSelectModel.TabIndex = 1;
            this.btnSelectModel.Text = "Select Model";
            this.btnSelectModel.UseVisualStyleBackColor = true;
            this.btnSelectModel.Click += new System.EventHandler(this.btnSelectModel_Click);
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(13, 202);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(97, 23);
            this.btnRecognize.TabIndex = 2;
            this.btnRecognize.Text = "Recognize";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(164, 212);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnSelectModel);
            this.Controls.Add(this.btnUploadPhoto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnSelectModel;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

