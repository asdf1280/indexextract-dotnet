namespace indexextract_cs {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.Button7 = new System.Windows.Forms.Button();
            this.nowt = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Dotdotdot = new System.Windows.Forms.Timer(this.components);
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.nowt.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label2.Location = new System.Drawing.Point(131, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 21);
            this.Label2.TabIndex = 42;
            this.Label2.Text = "Progress: ";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(143, 211);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(114, 15);
            this.Label13.TabIndex = 39;
            this.Label13.Text = "An update available.";
            this.Label13.Visible = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Segoe UI Symbol", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(3, 35);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 50);
            this.Label8.TabIndex = 20;
            this.Label8.Text = "0";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.Label9.Location = new System.Drawing.Point(3, 7);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(52, 15);
            this.Label9.TabIndex = 19;
            this.Label9.Text = "I/O 오류";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Red;
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Location = new System.Drawing.Point(135, 94);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(116, 103);
            this.Panel1.TabIndex = 38;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI Symbol", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(3, 35);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(42, 50);
            this.Label7.TabIndex = 20;
            this.Label7.Text = "0";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI Symbol", 8F);
            this.Label6.Location = new System.Drawing.Point(3, 7);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(54, 13);
            this.Label6.TabIndex = 19;
            this.Label6.Text = "파일 중복";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Gold;
            this.Panel2.Controls.Add(this.Label7);
            this.Panel2.Controls.Add(this.Label6);
            this.Panel2.Location = new System.Drawing.Point(255, 94);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(116, 103);
            this.Panel2.TabIndex = 37;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(9, 52);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(103, 31);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "0%";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label1.Visible = false;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(135, 44);
            this.ProgressBar1.MarqueeAnimationSpeed = 10;
            this.ProgressBar1.Maximum = 10000;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(237, 43);
            this.ProgressBar1.TabIndex = 41;
            // 
            // Button7
            // 
            this.Button7.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button7.Location = new System.Drawing.Point(281, 207);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(90, 25);
            this.Button7.TabIndex = 40;
            this.Button7.Text = "Update";
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Visible = false;
            // 
            // nowt
            // 
            this.nowt.BackColor = System.Drawing.Color.Orange;
            this.nowt.Controls.Add(this.Label4);
            this.nowt.Controls.Add(this.Label1);
            this.nowt.Controls.Add(this.Label3);
            this.nowt.Location = new System.Drawing.Point(7, 94);
            this.nowt.Name = "nowt";
            this.nowt.Size = new System.Drawing.Size(118, 106);
            this.nowt.TabIndex = 36;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(9, -4);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(103, 62);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Extract\r\nprogress : ";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label3.Location = new System.Drawing.Point(15, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(88, 38);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "......";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Label3.Visible = false;
            // 
            // Dotdotdot
            // 
            this.Dotdotdot.Enabled = true;
            this.Dotdotdot.Interval = 500;
            this.Dotdotdot.Tick += new System.EventHandler(this.Dotdotdot_Tick);
            // 
            // Button5
            // 
            this.Button5.BackColor = System.Drawing.Color.DodgerBlue;
            this.Button5.Enabled = false;
            this.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button5.Font = new System.Drawing.Font("바탕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button5.ForeColor = System.Drawing.Color.Black;
            this.Button5.Location = new System.Drawing.Point(8, 44);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(117, 43);
            this.Button5.TabIndex = 35;
            this.Button5.Text = "Open";
            this.Button5.UseVisualStyleBackColor = false;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Button4
            // 
            this.Button4.BackColor = System.Drawing.Color.Transparent;
            this.Button4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button4.Location = new System.Drawing.Point(8, 207);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(45, 25);
            this.Button4.TabIndex = 34;
            this.Button4.Text = "한국어";
            this.Button4.UseVisualStyleBackColor = false;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.BackColor = System.Drawing.Color.Transparent;
            this.Button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(57, 207);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(69, 25);
            this.Button3.TabIndex = 33;
            this.Button3.Text = "English";
            this.Button3.UseVisualStyleBackColor = false;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.DefaultExt = "json";
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.Filter = "json|*.json";
            this.OpenFileDialog1.Title = "Select version json 버전 선택하기";
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.Transparent;
            this.Button2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button2.Location = new System.Drawing.Point(7, 13);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(62, 25);
            this.Button2.TabIndex = 32;
            this.Button2.Text = "Browse";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.Transparent;
            this.Button1.Enabled = false;
            this.Button1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button1.Location = new System.Drawing.Point(74, 13);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(51, 25);
            this.Button1.TabIndex = 31;
            this.Button1.Text = "Start";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 243);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.Button7);
            this.Controls.Add(this.nowt);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Index Extractor 20.04e0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.nowt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Button Button7;
        internal System.Windows.Forms.Panel nowt;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Timer Dotdotdot;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
    }
}

