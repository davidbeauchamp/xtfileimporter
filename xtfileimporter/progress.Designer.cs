﻿namespace xtfileimporter
{
    partial class progress
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._message = new System.Windows.Forms.Label();
            this._progress = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._progress);
            this.panel1.Controls.Add(this._message);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 85);
            this.panel1.TabIndex = 0;
            // 
            // _message
            // 
            this._message.AutoSize = true;
            this._message.Location = new System.Drawing.Point(13, 13);
            this._message.Name = "_message";
            this._message.Size = new System.Drawing.Size(0, 13);
            this._message.TabIndex = 0;
            // 
            // _progress
            // 
            this._progress.Location = new System.Drawing.Point(39, 48);
            this._progress.Name = "progressBar1";
            this._progress.Size = new System.Drawing.Size(400, 25);
            this._progress.Step = 1;
            this._progress.TabIndex = 1;
            // 
            // progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 85);
            this.Controls.Add(this.panel1);
            this.Name = "progress";
            this.Text = "progress";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar _progress;
        private System.Windows.Forms.Label _message;
    }
}