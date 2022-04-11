namespace TK_Lab2
{
    partial class MainForm
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
            if (disposing && (components != null)) {
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenSourceFileButton = new System.Windows.Forms.Button();
            this.OpenEncryptedFileButton = new System.Windows.Forms.Button();
            this.MainRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OpenSourceFileButton
            // 
            this.OpenSourceFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenSourceFileButton.Location = new System.Drawing.Point(12, 12);
            this.OpenSourceFileButton.Name = "OpenSourceFileButton";
            this.OpenSourceFileButton.Size = new System.Drawing.Size(180, 100);
            this.OpenSourceFileButton.TabIndex = 0;
            this.OpenSourceFileButton.Text = "Open source file";
            this.OpenSourceFileButton.UseVisualStyleBackColor = true;
            this.OpenSourceFileButton.Click += new System.EventHandler(this.OpenSourceFileButton_Click);
            // 
            // OpenEncryptedFileButton
            // 
            this.OpenEncryptedFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenEncryptedFileButton.Location = new System.Drawing.Point(198, 12);
            this.OpenEncryptedFileButton.Name = "OpenEncryptedFileButton";
            this.OpenEncryptedFileButton.Size = new System.Drawing.Size(180, 100);
            this.OpenEncryptedFileButton.TabIndex = 1;
            this.OpenEncryptedFileButton.Text = "Open encrypted file";
            this.OpenEncryptedFileButton.UseVisualStyleBackColor = true;
            this.OpenEncryptedFileButton.Click += new System.EventHandler(this.OpenEncryptedFileButton_Click);
            // 
            // MainRichTextBox
            // 
            this.MainRichTextBox.Location = new System.Drawing.Point(13, 119);
            this.MainRichTextBox.Name = "MainRichTextBox";
            this.MainRichTextBox.Size = new System.Drawing.Size(365, 301);
            this.MainRichTextBox.TabIndex = 2;
            this.MainRichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainRichTextBox);
            this.Controls.Add(this.OpenEncryptedFileButton);
            this.Controls.Add(this.OpenSourceFileButton);
            this.Name = "MainForm";
            this.Text = "Fano-Shennon";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button OpenSourceFileButton;
        private System.Windows.Forms.Button OpenEncryptedFileButton;
        private System.Windows.Forms.RichTextBox MainRichTextBox;
    }
}

