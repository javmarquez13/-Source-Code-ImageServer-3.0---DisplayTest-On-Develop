namespace ImagesServer_v3._0
{
    partial class WaitWin
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTaskOnProcess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(47, 183);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(864, 88);
            this.progressBar1.Step = 50;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // lblTaskOnProcess
            // 
            this.lblTaskOnProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTaskOnProcess.AutoSize = true;
            this.lblTaskOnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskOnProcess.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTaskOnProcess.Location = new System.Drawing.Point(365, 80);
            this.lblTaskOnProcess.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.lblTaskOnProcess.Name = "lblTaskOnProcess";
            this.lblTaskOnProcess.Size = new System.Drawing.Size(146, 20);
            this.lblTaskOnProcess.TabIndex = 62;
            this.lblTaskOnProcess.Text = "PLEASE WAIT...";
            // 
            // WaitWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(996, 372);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTaskOnProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WaitWin";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitWin";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTaskOnProcess;
    }
}