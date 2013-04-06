using ChessByBird.ImagingProject;

namespace ChessByBird
{
    partial class ChessBoardImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessBoardImageForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxBottomLetters = new System.Windows.Forms.PictureBox();
            this.whitePlayerLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.blackPlayerLabel = new System.Windows.Forms.Label();
            this.pictureBoxTopLeters = new System.Windows.Forms.PictureBox();
            this.panelChessBoard = new System.Windows.Forms.Panel();
            this.pictureBoxCenter = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.pictureBoxRightNumbers = new System.Windows.Forms.PictureBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pictureBoxLeftNumbers = new System.Windows.Forms.PictureBox();
            this.timerSnapShot = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeters)).BeginInit();
            this.panelChessBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.splitContainer2);
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Controls.Add(this.panelChessBoard);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Enabled = false;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(438, 488);
            this.panelMain.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer2.Location = new System.Drawing.Point(50, 413);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBottomLetters);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Peru;
            this.splitContainer2.Panel2.Controls.Add(this.whitePlayerLabel);
            this.splitContainer2.Size = new System.Drawing.Size(338, 75);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 16;
            // 
            // pictureBoxBottomLetters
            // 
            this.pictureBoxBottomLetters.BackColor = System.Drawing.Color.White;
            this.pictureBoxBottomLetters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxBottomLetters.Enabled = false;
            this.pictureBoxBottomLetters.Image = global::ChessByBird.Properties.Resources.ColsRedNew;
            this.pictureBoxBottomLetters.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBottomLetters.Name = "pictureBoxBottomLetters";
            this.pictureBoxBottomLetters.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.pictureBoxBottomLetters.Size = new System.Drawing.Size(338, 25);
            this.pictureBoxBottomLetters.TabIndex = 18;
            this.pictureBoxBottomLetters.TabStop = false;
            // 
            // whitePlayerLabel
            // 
            this.whitePlayerLabel.BackColor = System.Drawing.Color.White;
            this.whitePlayerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whitePlayerLabel.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whitePlayerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.whitePlayerLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.whitePlayerLabel.Location = new System.Drawing.Point(0, 0);
            this.whitePlayerLabel.Name = "whitePlayerLabel";
            this.whitePlayerLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.whitePlayerLabel.Size = new System.Drawing.Size(338, 49);
            this.whitePlayerLabel.TabIndex = 0;
            this.whitePlayerLabel.Text = "WhitePlayer";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(50, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.blackPlayerLabel);
            this.splitContainer1.Panel1.Enabled = false;
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxTopLeters);
            this.splitContainer1.Size = new System.Drawing.Size(338, 75);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 15;
            // 
            // blackPlayerLabel
            // 
            this.blackPlayerLabel.BackColor = System.Drawing.Color.White;
            this.blackPlayerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.blackPlayerLabel.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackPlayerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.blackPlayerLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.blackPlayerLabel.Location = new System.Drawing.Point(0, 0);
            this.blackPlayerLabel.Name = "blackPlayerLabel";
            this.blackPlayerLabel.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.blackPlayerLabel.Size = new System.Drawing.Size(338, 47);
            this.blackPlayerLabel.TabIndex = 0;
            this.blackPlayerLabel.Text = "Black Player";
            // 
            // pictureBoxTopLeters
            // 
            this.pictureBoxTopLeters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTopLeters.Enabled = false;
            this.pictureBoxTopLeters.Image = global::ChessByBird.Properties.Resources.ColsRedNew;
            this.pictureBoxTopLeters.InitialImage = global::ChessByBird.Properties.Resources.ColsRed1;
            this.pictureBoxTopLeters.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTopLeters.Name = "pictureBoxTopLeters";
            this.pictureBoxTopLeters.Size = new System.Drawing.Size(338, 28);
            this.pictureBoxTopLeters.TabIndex = 0;
            this.pictureBoxTopLeters.TabStop = false;
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelChessBoard.BackColor = System.Drawing.Color.Black;
            this.panelChessBoard.Controls.Add(this.pictureBoxCenter);
            this.panelChessBoard.Location = new System.Drawing.Point(50, 75);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(338, 338);
            this.panelChessBoard.TabIndex = 14;
            // 
            // pictureBoxCenter
            // 
            this.pictureBoxCenter.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCenter.InitialImage = null;
            this.pictureBoxCenter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCenter.Name = "pictureBoxCenter";
            this.pictureBoxCenter.Size = new System.Drawing.Size(338, 338);
            this.pictureBoxCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxCenter.TabIndex = 1;
            this.pictureBoxCenter.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.pictureBoxRightNumbers);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Enabled = false;
            this.panelRight.Location = new System.Drawing.Point(388, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(50, 488);
            this.panelRight.TabIndex = 13;
            // 
            // pictureBoxRightNumbers
            // 
            this.pictureBoxRightNumbers.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxRightNumbers.Enabled = false;
            this.pictureBoxRightNumbers.Image = global::ChessByBird.Properties.Resources.RowsRed;
            this.pictureBoxRightNumbers.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRightNumbers.Name = "pictureBoxRightNumbers";
            this.pictureBoxRightNumbers.Size = new System.Drawing.Size(25, 488);
            this.pictureBoxRightNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRightNumbers.TabIndex = 0;
            this.pictureBoxRightNumbers.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.pictureBoxLeftNumbers);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Enabled = false;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(50, 488);
            this.panelLeft.TabIndex = 12;
            // 
            // pictureBoxLeftNumbers
            // 
            this.pictureBoxLeftNumbers.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxLeftNumbers.Enabled = false;
            this.pictureBoxLeftNumbers.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeftNumbers.Image")));
            this.pictureBoxLeftNumbers.Location = new System.Drawing.Point(25, 0);
            this.pictureBoxLeftNumbers.Name = "pictureBoxLeftNumbers";
            this.pictureBoxLeftNumbers.Size = new System.Drawing.Size(25, 488);
            this.pictureBoxLeftNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeftNumbers.TabIndex = 0;
            this.pictureBoxLeftNumbers.TabStop = false;
            // 
            // timerSnapShot
            // 
            this.timerSnapShot.Interval = 1000;
            this.timerSnapShot.Tick += new System.EventHandler(this.timerSnapShot_Tick);
            // 
            // ChessBoardImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 488);
            this.Controls.Add(this.panelMain);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChessBoardImageForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "CBBImage";
            this.Text = "CBBImage";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.panelMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeters)).EndInit();
            this.panelChessBoard.ResumeLayout(false);
            this.panelChessBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelChessBoard;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Timer timerSnapShot;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label blackPlayerLabel;
        private System.Windows.Forms.PictureBox pictureBoxTopLeters;
        private System.Windows.Forms.PictureBox pictureBoxCenter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label whitePlayerLabel;
        private System.Windows.Forms.PictureBox pictureBoxBottomLetters;
        private System.Windows.Forms.PictureBox pictureBoxRightNumbers;
        private System.Windows.Forms.PictureBox pictureBoxLeftNumbers;


    }
}

