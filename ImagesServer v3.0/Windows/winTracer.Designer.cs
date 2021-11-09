namespace ImagesServer_v3._0
{
    partial class WinTracer
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
            this.btnExit = new System.Windows.Forms.Button();
            this.txtTracer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 48);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(1214, 5);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 37);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // txtTracer
            // 
            this.txtTracer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTracer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.txtTracer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTracer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTracer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtTracer.Location = new System.Drawing.Point(768, 502);
            this.txtTracer.MaxLength = 8;
            this.txtTracer.Name = "txtTracer";
            this.txtTracer.Size = new System.Drawing.Size(285, 32);
            this.txtTracer.TabIndex = 1;
            this.txtTracer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTracer.Click += new System.EventHandler(this.TxtTracer_Click);
            this.txtTracer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTracer_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(746, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escanea el tracer de la unidad:";
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(813, 599);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 32);
            this.lblError.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(727, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Introduce tu numero de empleado:";
            // 
            // txtEmployeNum
            // 
            this.txtEmployeNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmployeNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.txtEmployeNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmployeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeNum.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtEmployeNum.Location = new System.Drawing.Point(768, 385);
            this.txtEmployeNum.MaxLength = 100;
            this.txtEmployeNum.Name = "txtEmployeNum";
            this.txtEmployeNum.Size = new System.Drawing.Size(285, 32);
            this.txtEmployeNum.TabIndex = 0;
            this.txtEmployeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmployeNum.Click += new System.EventHandler(this.TxtEmployeNum_Click);
            this.txtEmployeNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEmployeNum_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datos de la unidad:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(954, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "enter para validar";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(954, 550);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "enter para validar";
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btn7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn7.FlatAppearance.BorderSize = 0;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn7.Location = new System.Drawing.Point(6, 6);
            this.btn7.Margin = new System.Windows.Forms.Padding(6);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(108, 106);
            this.btn7.TabIndex = 145;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.Btn7_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btn8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn8.FlatAppearance.BorderSize = 0;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn8.Location = new System.Drawing.Point(126, 6);
            this.btn8.Margin = new System.Windows.Forms.Padding(6);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(108, 106);
            this.btn8.TabIndex = 146;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btn9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn9.FlatAppearance.BorderSize = 0;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn9.Location = new System.Drawing.Point(246, 6);
            this.btn9.Margin = new System.Windows.Forms.Padding(6);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(108, 106);
            this.btn9.TabIndex = 147;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.Btn9_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btn4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn4.FlatAppearance.BorderSize = 0;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn4.Location = new System.Drawing.Point(6, 124);
            this.btn4.Margin = new System.Windows.Forms.Padding(6);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(108, 106);
            this.btn4.TabIndex = 148;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btn5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn5.Location = new System.Drawing.Point(126, 124);
            this.btn5.Margin = new System.Windows.Forms.Padding(6);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(108, 106);
            this.btn5.TabIndex = 149;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.Btn5_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btn6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn6.FlatAppearance.BorderSize = 0;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn6.Location = new System.Drawing.Point(246, 124);
            this.btn6.Margin = new System.Windows.Forms.Padding(6);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(108, 106);
            this.btn6.TabIndex = 150;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.Btn6_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn1.Location = new System.Drawing.Point(6, 242);
            this.btn1.Margin = new System.Windows.Forms.Padding(6);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(108, 106);
            this.btn1.TabIndex = 151;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn2.Location = new System.Drawing.Point(126, 242);
            this.btn2.Margin = new System.Windows.Forms.Padding(6);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(108, 106);
            this.btn2.TabIndex = 152;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn3.Location = new System.Drawing.Point(246, 242);
            this.btn3.Margin = new System.Windows.Forms.Padding(6);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(108, 106);
            this.btn3.TabIndex = 153;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEnter.Location = new System.Drawing.Point(366, 6);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(6);
            this.btnEnter.Name = "btnEnter";
            this.tableLayoutPanel1.SetRowSpan(this.btnEnter, 3);
            this.btnEnter.Size = new System.Drawing.Size(111, 342);
            this.btnEnter.TabIndex = 154;
            this.btnEnter.Text = "ENTER";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btn0, 3);
            this.btn0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn0.FlatAppearance.BorderSize = 0;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn0.Location = new System.Drawing.Point(6, 360);
            this.btn0.Margin = new System.Windows.Forms.Padding(6);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(348, 107);
            this.btn0.TabIndex = 155;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.Btn0_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnClear.Location = new System.Drawing.Point(366, 360);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 107);
            this.btnClear.TabIndex = 156;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn0, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEnter, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(169, 217);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 473);
            this.tableLayoutPanel1.TabIndex = 157;
            // 
            // WinTracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1275, 892);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmployeNum);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTracer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinTracer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "winTracer";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WinTracer_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtTracer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}