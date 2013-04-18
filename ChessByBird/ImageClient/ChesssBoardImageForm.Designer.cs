using ChessByBird.ImageClient;

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
            this.panelChessBoard = new System.Windows.Forms.Panel();
            this.pictureBoxCenter = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.pictureBoxRightNumbers = new System.Windows.Forms.PictureBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pictureBoxLeftNumbers = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxTopLetters = new System.Windows.Forms.PictureBox();
            this.whitePlayerLabel = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.pictureBoxBottomLetters = new System.Windows.Forms.PictureBox();
            this.blackPlayerLabel = new System.Windows.Forms.Label();
            this.timerSnapShot = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panelChessBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLetters)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelChessBoard);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(778, 828);
            this.panelMain.TabIndex = 0;
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.BackColor = System.Drawing.Color.Black;
            this.panelChessBoard.Controls.Add(this.pictureBoxCenter);
            this.panelChessBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChessBoard.Location = new System.Drawing.Point(50, 75);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(678, 678);
            this.panelChessBoard.TabIndex = 14;
            // 
            // pictureBoxCenter
            // 
            this.pictureBoxCenter.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCenter.InitialImage = null;
            this.pictureBoxCenter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCenter.Name = "pictureBoxCenter";
            this.pictureBoxCenter.Size = new System.Drawing.Size(678, 678);
            this.pictureBoxCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCenter.TabIndex = 0;
            this.pictureBoxCenter.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.pictureBoxRightNumbers);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(728, 75);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(50, 678);
            this.panelRight.TabIndex = 13;
            // 
            // pictureBoxRightNumbers
            // 
            this.pictureBoxRightNumbers.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxRightNumbers.Enabled = false;
            this.pictureBoxRightNumbers.Image = global::ChessByBird.Properties.Resources.RowsRed;
            this.pictureBoxRightNumbers.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRightNumbers.Name = "pictureBoxRightNumbers";
            this.pictureBoxRightNumbers.Size = new System.Drawing.Size(50, 678);
            this.pictureBoxRightNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxRightNumbers.TabIndex = 0;
            this.pictureBoxRightNumbers.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.pictureBoxLeftNumbers);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 75);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(50, 678);
            this.panelLeft.TabIndex = 12;
            // 
            // pictureBoxLeftNumbers
            // 
            this.pictureBoxLeftNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeftNumbers.Enabled = false;
            this.pictureBoxLeftNumbers.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeftNumbers.Image")));
            this.pictureBoxLeftNumbers.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeftNumbers.Name = "pictureBoxLeftNumbers";
            this.pictureBoxLeftNumbers.Size = new System.Drawing.Size(50, 678);
            this.pictureBoxLeftNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeftNumbers.TabIndex = 0;
            this.pictureBoxLeftNumbers.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Navy;
            this.panelTop.Controls.Add(this.pictureBoxTopLetters);
            this.panelTop.Controls.Add(this.whitePlayerLabel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(778, 75);
            this.panelTop.TabIndex = 10;
            // 
            // pictureBoxTopLetters
            // 
            this.pictureBoxTopLetters.BackColor = System.Drawing.Color.White;
            this.pictureBoxTopLetters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxTopLetters.Enabled = false;
            this.pictureBoxTopLetters.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTopLetters.Image")));
            this.pictureBoxTopLetters.Location = new System.Drawing.Point(0, 25);
            this.pictureBoxTopLetters.Name = "pictureBoxTopLetters";
            this.pictureBoxTopLetters.Size = new System.Drawing.Size(778, 50);
            this.pictureBoxTopLetters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTopLetters.TabIndex = 2;
            this.pictureBoxTopLetters.TabStop = false;
            // 
            // whitePlayerLabel
            // 
            this.whitePlayerLabel.AutoSize = true;
            this.whitePlayerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.whitePlayerLabel.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whitePlayerLabel.ForeColor = System.Drawing.Color.White;
            this.whitePlayerLabel.Location = new System.Drawing.Point(0, 0);
            this.whitePlayerLabel.Name = "whitePlayerLabel";
            this.whitePlayerLabel.Size = new System.Drawing.Size(144, 23);
            this.whitePlayerLabel.TabIndex = 1;
            this.whitePlayerLabel.Text = "White Player";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Navy;
            this.panelBottom.Controls.Add(this.pictureBoxBottomLetters);
            this.panelBottom.Controls.Add(this.blackPlayerLabel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 753);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(778, 75);
            this.panelBottom.TabIndex = 11;
            // 
            // pictureBoxBottomLetters
            // 
            this.pictureBoxBottomLetters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxBottomLetters.Enabled = false;
            this.pictureBoxBottomLetters.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBottomLetters.Image")));
            this.pictureBoxBottomLetters.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBottomLetters.Name = "pictureBoxBottomLetters";
            this.pictureBoxBottomLetters.Size = new System.Drawing.Size(778, 50);
            this.pictureBoxBottomLetters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxBottomLetters.TabIndex = 2;
            this.pictureBoxBottomLetters.TabStop = false;
            // 
            // blackPlayerLabel
            // 
            this.blackPlayerLabel.AutoSize = true;
            this.blackPlayerLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.blackPlayerLabel.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackPlayerLabel.ForeColor = System.Drawing.Color.White;
            this.blackPlayerLabel.Location = new System.Drawing.Point(0, 52);
            this.blackPlayerLabel.Name = "blackPlayerLabel";
            this.blackPlayerLabel.Size = new System.Drawing.Size(140, 23);
            this.blackPlayerLabel.TabIndex = 1;
            this.blackPlayerLabel.Text = "Black Player";
            // 
            // timerSnapShot
            // 
            this.timerSnapShot.Tick += new System.EventHandler(this.timerSnapShot_Tick);
            // 
            // ChessBoardImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 828);
            this.Controls.Add(this.panelMain);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChessBoardImageForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "CBBImage";
            this.Text = "CBBImage";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelChessBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLetters)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelChessBoard;
        private System.Windows.Forms.PictureBox pictureBoxCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxRightNumbers;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeftNumbers;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxTopLetters;
        private System.Windows.Forms.Label whitePlayerLabel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox pictureBoxBottomLetters;
        private System.Windows.Forms.Label blackPlayerLabel;
        private System.Windows.Forms.Timer timerSnapShot;


    }
}

