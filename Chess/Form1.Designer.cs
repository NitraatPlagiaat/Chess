
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
            this.lbBlack = new System.Windows.Forms.ListBox();
            this.lbWhite = new System.Windows.Forms.ListBox();
            this.chessPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.endCurrentGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamepiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeSetNumericInput = new System.Windows.Forms.NumericUpDown();
            this.lbConqueredBlack = new System.Windows.Forms.ListBox();
            this.lbConqueredWhite = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSetNumericInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimeStop
            // 
            this.btnTimeStop.Location = new System.Drawing.Point(508, 247);
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
            this.lblBlackMin.Location = new System.Drawing.Point(508, 203);
            this.lblBlackMin.Name = "lblBlackMin";
            this.lblBlackMin.Size = new System.Drawing.Size(13, 13);
            this.lblBlackMin.TabIndex = 1;
            this.lblBlackMin.Text = "5";
            // 
            // lblWhiteMin
            // 
            this.lblWhiteMin.AutoSize = true;
            this.lblWhiteMin.Location = new System.Drawing.Point(508, 300);
            this.lblWhiteMin.Name = "lblWhiteMin";
            this.lblWhiteMin.Size = new System.Drawing.Size(13, 13);
            this.lblWhiteMin.TabIndex = 2;
            this.lblWhiteMin.Text = "5";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblBlackSec
            // 
            this.lblBlackSec.AutoSize = true;
            this.lblBlackSec.Location = new System.Drawing.Point(533, 203);
            this.lblBlackSec.Name = "lblBlackSec";
            this.lblBlackSec.Size = new System.Drawing.Size(19, 13);
            this.lblBlackSec.TabIndex = 3;
            this.lblBlackSec.Text = "00";
            // 
            // lblWhiteSec
            // 
            this.lblWhiteSec.AutoSize = true;
            this.lblWhiteSec.Location = new System.Drawing.Point(533, 300);
            this.lblWhiteSec.Name = "lblWhiteSec";
            this.lblWhiteSec.Size = new System.Drawing.Size(19, 13);
            this.lblWhiteSec.TabIndex = 4;
            this.lblWhiteSec.Text = "00";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(639, 203);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCheckmate
            // 
            this.btnCheckmate.Location = new System.Drawing.Point(639, 290);
            this.btnCheckmate.Name = "btnCheckmate";
            this.btnCheckmate.Size = new System.Drawing.Size(75, 23);
            this.btnCheckmate.TabIndex = 6;
            this.btnCheckmate.Text = "Checkmate";
            this.btnCheckmate.UseVisualStyleBackColor = true;
            this.btnCheckmate.Click += new System.EventHandler(this.btnCheckmate_Click);
            // 
            // lbBlack
            // 
            this.lbBlack.FormattingEnabled = true;
            this.lbBlack.Location = new System.Drawing.Point(555, 27);
            this.lbBlack.Name = "lbBlack";
            this.lbBlack.Size = new System.Drawing.Size(120, 160);
            this.lbBlack.TabIndex = 7;
            // 
            // lbWhite
            // 
            this.lbWhite.FormattingEnabled = true;
            this.lbWhite.Location = new System.Drawing.Point(555, 331);
            this.lbWhite.Name = "lbWhite";
            this.lbWhite.Size = new System.Drawing.Size(120, 160);
            this.lbWhite.TabIndex = 8;
            // 
            // chessPanel
            // 
            this.chessPanel.Location = new System.Drawing.Point(9, 27);
            this.chessPanel.Name = "chessPanel";
            this.chessPanel.Size = new System.Drawing.Size(493, 451);
            this.chessPanel.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewGame,
            this.endCurrentGameToolStripMenuItem,
            this.pauseResumeToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // menuNewGame
            // 
            this.menuNewGame.Name = "menuNewGame";
            this.menuNewGame.Size = new System.Drawing.Size(172, 22);
            this.menuNewGame.Text = "Prepare new game";
            this.menuNewGame.Click += new System.EventHandler(this.menuNewGame_Click);
            // 
            // endCurrentGameToolStripMenuItem
            // 
            this.endCurrentGameToolStripMenuItem.Name = "endCurrentGameToolStripMenuItem";
            this.endCurrentGameToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.endCurrentGameToolStripMenuItem.Text = "End current game";
            this.endCurrentGameToolStripMenuItem.Click += new System.EventHandler(this.endCurrentGameToolStripMenuItem_Click);
            // 
            // pauseResumeToolStripMenuItem
            // 
            this.pauseResumeToolStripMenuItem.Name = "pauseResumeToolStripMenuItem";
            this.pauseResumeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pauseResumeToolStripMenuItem.Text = "Pause/Resume";
            this.pauseResumeToolStripMenuItem.Click += new System.EventHandler(this.pauseResumeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamepiecesToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gamepiecesToolStripMenuItem
            // 
            this.gamepiecesToolStripMenuItem.Name = "gamepiecesToolStripMenuItem";
            this.gamepiecesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gamepiecesToolStripMenuItem.Text = "Gamepieces";
            this.gamepiecesToolStripMenuItem.Click += new System.EventHandler(this.gamepiecesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timeSetNumericInput
            // 
            this.timeSetNumericInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timeSetNumericInput.Location = new System.Drawing.Point(639, 247);
            this.timeSetNumericInput.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.timeSetNumericInput.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timeSetNumericInput.Name = "timeSetNumericInput";
            this.timeSetNumericInput.Size = new System.Drawing.Size(75, 20);
            this.timeSetNumericInput.TabIndex = 11;
            this.timeSetNumericInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lbConqueredBlack
            // 
            this.lbConqueredBlack.FormattingEnabled = true;
            this.lbConqueredBlack.Location = new System.Drawing.Point(715, 27);
            this.lbConqueredBlack.Name = "lbConqueredBlack";
            this.lbConqueredBlack.Size = new System.Drawing.Size(48, 160);
            this.lbConqueredBlack.TabIndex = 12;
            // 
            // lbConqueredWhite
            // 
            this.lbConqueredWhite.FormattingEnabled = true;
            this.lbConqueredWhite.Location = new System.Drawing.Point(715, 331);
            this.lbConqueredWhite.Name = "lbConqueredWhite";
            this.lbConqueredWhite.Size = new System.Drawing.Size(48, 160);
            this.lbConqueredWhite.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 505);
            this.Controls.Add(this.lbConqueredWhite);
            this.Controls.Add(this.lbConqueredBlack);
            this.Controls.Add(this.timeSetNumericInput);
            this.Controls.Add(this.chessPanel);
            this.Controls.Add(this.lbWhite);
            this.Controls.Add(this.lbBlack);
            this.Controls.Add(this.btnCheckmate);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblWhiteSec);
            this.Controls.Add(this.lblBlackSec);
            this.Controls.Add(this.lblWhiteMin);
            this.Controls.Add(this.lblBlackMin);
            this.Controls.Add(this.btnTimeStop);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Chess (BETA V1.1)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSetNumericInput)).EndInit();
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
        private System.Windows.Forms.ListBox lbBlack;
        private System.Windows.Forms.ListBox lbWhite;
        private System.Windows.Forms.Panel chessPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNewGame;
        private System.Windows.Forms.ToolStripMenuItem endCurrentGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamepiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown timeSetNumericInput;
        private System.Windows.Forms.ToolStripMenuItem pauseResumeToolStripMenuItem;
        private System.Windows.Forms.ListBox lbConqueredBlack;
        private System.Windows.Forms.ListBox lbConqueredWhite;
    }
}

