namespace ImagesServer_v3._0
{
    partial class ImageXGUI
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
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblFunctions = new System.Windows.Forms.Label();
            this.lblHandleError = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label30 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEvents
            // 
            this.lblEvents.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEvents.AutoSize = true;
            this.lblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEvents.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblEvents.Location = new System.Drawing.Point(44, 323);
            this.lblEvents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(24, 20);
            this.lblEvents.TabIndex = 8;
            this.lblEvents.Text = "...";
            // 
            // lblFunctions
            // 
            this.lblFunctions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFunctions.AutoSize = true;
            this.lblFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFunctions.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFunctions.Location = new System.Drawing.Point(50, 180);
            this.lblFunctions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFunctions.Name = "lblFunctions";
            this.lblFunctions.Size = new System.Drawing.Size(91, 20);
            this.lblFunctions.TabIndex = 7;
            this.lblFunctions.Text = "Functions";
            // 
            // lblHandleError
            // 
            this.lblHandleError.AutoSize = true;
            this.lblHandleError.ForeColor = System.Drawing.Color.Black;
            this.lblHandleError.Location = new System.Drawing.Point(10, 237);
            this.lblHandleError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHandleError.Name = "lblHandleError";
            this.lblHandleError.Size = new System.Drawing.Size(0, 20);
            this.lblHandleError.TabIndex = 10;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblElapsedTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblElapsedTime.Location = new System.Drawing.Point(32, 23);
            this.lblElapsedTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(129, 20);
            this.lblElapsedTime.TabIndex = 14;
            this.lblElapsedTime.Text = "Elapsed Time:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(44, 227);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(786, 67);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPercent.AutoSize = true;
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPercent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPercent.Location = new System.Drawing.Point(672, 199);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(25, 20);
            this.lblPercent.TabIndex = 16;
            this.lblPercent.Text = "%";
            this.lblPercent.Click += new System.EventHandler(this.LblPercent_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label30.Location = new System.Drawing.Point(339, 101);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(145, 32);
            this.label30.TabIndex = 64;
            this.label30.Text = "JIMAGEX";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.lblElapsedTime);
            this.panel1.Location = new System.Drawing.Point(532, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 63);
            this.panel1.TabIndex = 65;
            // 
            // ImageXGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(879, 514);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblHandleError);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.lblFunctions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageXGUI";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageXGUI";
            this.Load += new System.EventHandler(this.ImageXGUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblFunctions;
        private System.Windows.Forms.Label lblHandleError;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblPercent;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel1;
    }
}