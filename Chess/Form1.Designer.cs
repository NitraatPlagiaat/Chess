
namespace Chess
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
            this.components = new System.ComponentModel.Container();
            this.btnTimeStop = new System.Windows.Forms.Button();
            this.lblBlackMin = new System.Windows.Forms.Label();
            this.lblWhiteMin = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblBlackSec = new System.Windows.Forms.Label();
            this.lblWhiteSec = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCheckmate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTimeStop
            // 
            this.btnTimeStop.Location = new System.Drawing.Point(511, 225);
            this.btnTimeStop.Name = "btnTimeStop";
            this.btnTimeStop.Size = new System.Drawing.Size(75, 23);
            this.btnTimeStop.TabIndex = 0;
            this.btnTimeStop.Text = "Time";
            this.btnTimeStop.UseVisualStyleBackColor = true;
            this.btnTimeStop.Click += new System.EventHandler(this.btnTimeStop_Click);
            // 
            // lblBlackMin
            // 
            this.lblBlackMin.AutoSize = true;
            this.lblBlackMin.Location = new System.Drawing.Point(508, 193);
            this.lblBlackMin.Name = "lblBlackMin";
            this.lblBlackMin.Size = new System.Drawing.Size(19, 13);
            this.lblBlackMin.TabIndex = 1;
            this.lblBlackMin.Text = "10";
            // 
            // lblWhiteMin
            // 
            this.lblWhiteMin.AutoSize = true;
            this.lblWhiteMin.Location = new System.Drawing.Point(508, 271);
            this.lblWhiteMin.Name = "lblWhiteMin";
            this.lblWhiteMin.Size = new System.Drawing.Size(19, 13);
            this.lblWhiteMin.TabIndex = 2;
            this.lblWhiteMin.Text = "10";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblBlackSec
            // 
            this.lblBlackSec.AutoSize = true;
            this.lblBlackSec.Location = new System.Drawing.Point(533, 193);
            this.lblBlackSec.Name = "lblBlackSec";
            this.lblBlackSec.Size = new System.Drawing.Size(19, 13);
            this.lblBlackSec.TabIndex = 3;
            this.lblBlackSec.Text = "00";
            // 
            // lblWhiteSec
            // 
            this.lblWhiteSec.AutoSize = true;
            this.lblWhiteSec.Location = new System.Drawing.Point(533, 271);
            this.lblWhiteSec.Name = "lblWhiteSec";
            this.lblWhiteSec.Size = new System.Drawing.Size(19, 13);
            this.lblWhiteSec.TabIndex = 4;
            this.lblWhiteSec.Text = "00";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(639, 193);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCheckmate
            // 
            this.btnCheckmate.Location = new System.Drawing.Point(639, 261);
            this.btnCheckmate.Name = "btnCheckmate";
            this.btnCheckmate.Size = new System.Drawing.Size(75, 23);
            this.btnCheckmate.TabIndex = 6;
            this.btnCheckmate.Text = "Checkmate";
            this.btnCheckmate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 475);
            this.Controls.Add(this.btnCheckmate);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblWhiteSec);
            this.Controls.Add(this.lblBlackSec);
            this.Controls.Add(this.lblWhiteMin);
            this.Controls.Add(this.lblBlackMin);
            this.Controls.Add(this.btnTimeStop);
            this.Name = "Form1";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimeStop;
        private System.Windows.Forms.Label lblBlackMin;
        private System.Windows.Forms.Label lblWhiteMin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblBlackSec;
        private System.Windows.Forms.Label lblWhiteSec;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCheckmate;
    }
}

