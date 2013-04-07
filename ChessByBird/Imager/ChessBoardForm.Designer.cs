namespace ChessByBird
{
    partial class ChessBoardForm
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelBottomLabel = new System.Windows.Forms.Panel();
            this.buttonWhitePlayer = new System.Windows.Forms.Button();
            this.panelTopLabel = new System.Windows.Forms.Panel();
            this.buttonBlackPlayer = new System.Windows.Forms.Button();
            this.panelOuterBox = new System.Windows.Forms.Panel();
            this.pictureBoxRightNumbers = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeftNumbers = new System.Windows.Forms.PictureBox();
            this.pictureBoxBottomLetters = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopLetters = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.pictureBoxCenter = new System.Windows.Forms.PictureBox();
            this.timerSnapShot = new System.Windows.Forms.Timer(this.components);
            this.panelForm.SuspendLayout();
            this.panelBottomLabel.SuspendLayout();
            this.panelTopLabel.SuspendLayout();
            this.panelOuterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLetters)).BeginInit();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelForm.BackColor = System.Drawing.Color.SteelBlue;
            this.panelForm.Controls.Add(this.panelBottomLabel);
            this.panelForm.Controls.Add(this.panelTopLabel);
            this.panelForm.Controls.Add(this.panelOuterBox);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Enabled = false;
            this.panelForm.ForeColor = System.Drawing.Color.SteelBlue;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(864, 864);
            this.panelForm.TabIndex = 0;
            // 
            // panelBottomLabel
            // 
            this.panelBottomLabel.AutoSize = true;
            this.panelBottomLabel.BackColor = System.Drawing.Color.White;
            this.panelBottomLabel.Controls.Add(this.buttonWhitePlayer);
            this.panelBottomLabel.Enabled = false;
            this.panelBottomLabel.Location = new System.Drawing.Point(50, 814);
            this.panelBottomLabel.Name = "panelBottomLabel";
            this.panelBottomLabel.Size = new System.Drawing.Size(764, 50);
            this.panelBottomLabel.TabIndex = 2;
            // 
            // buttonWhitePlayer
            // 
            this.buttonWhitePlayer.AutoSize = true;
            this.buttonWhitePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWhitePlayer.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonWhitePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonWhitePlayer.Enabled = false;
            this.buttonWhitePlayer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.buttonWhitePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWhitePlayer.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWhitePlayer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonWhitePlayer.Location = new System.Drawing.Point(0, 0);
            this.buttonWhitePlayer.Margin = new System.Windows.Forms.Padding(0);
            this.buttonWhitePlayer.Name = "buttonWhitePlayer";
            this.buttonWhitePlayer.Size = new System.Drawing.Size(764, 50);
            this.buttonWhitePlayer.TabIndex = 0;
            this.buttonWhitePlayer.Text = "White Player";
            this.buttonWhitePlayer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonWhitePlayer.UseVisualStyleBackColor = false;
            // 
            // panelTopLabel
            // 
            this.panelTopLabel.AutoSize = true;
            this.panelTopLabel.BackColor = System.Drawing.Color.White;
            this.panelTopLabel.Controls.Add(this.buttonBlackPlayer);
            this.panelTopLabel.Enabled = false;
            this.panelTopLabel.Location = new System.Drawing.Point(50, 0);
            this.panelTopLabel.Name = "panelTopLabel";
            this.panelTopLabel.Size = new System.Drawing.Size(764, 50);
            this.panelTopLabel.TabIndex = 1;
            // 
            // buttonBlackPlayer
            // 
            this.buttonBlackPlayer.AutoSize = true;
            this.buttonBlackPlayer.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBlackPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBlackPlayer.Enabled = false;
            this.buttonBlackPlayer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.buttonBlackPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBlackPlayer.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlackPlayer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBlackPlayer.Location = new System.Drawing.Point(0, 0);
            this.buttonBlackPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBlackPlayer.Name = "buttonBlackPlayer";
            this.buttonBlackPlayer.Size = new System.Drawing.Size(764, 50);
            this.buttonBlackPlayer.TabIndex = 0;
            this.buttonBlackPlayer.Text = "Black Player";
            this.buttonBlackPlayer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonBlackPlayer.UseVisualStyleBackColor = false;
            // 
            // panelOuterBox
            // 
            this.panelOuterBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOuterBox.BackColor = System.Drawing.Color.White;
            this.panelOuterBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelOuterBox.Controls.Add(this.pictureBoxRightNumbers);
            this.panelOuterBox.Controls.Add(this.pictureBoxLeftNumbers);
            this.panelOuterBox.Controls.Add(this.pictureBoxBottomLetters);
            this.panelOuterBox.Controls.Add(this.pictureBoxTopLetters);
            this.panelOuterBox.Controls.Add(this.panelRight);
            this.panelOuterBox.Controls.Add(this.panelLeft);
            this.panelOuterBox.Controls.Add(this.panelBottom);
            this.panelOuterBox.Controls.Add(this.panelTop);
            this.panelOuterBox.Controls.Add(this.panelCenter);
            this.panelOuterBox.Enabled = false;
            this.panelOuterBox.ForeColor = System.Drawing.Color.White;
            this.panelOuterBox.Location = new System.Drawing.Point(50, 50);
            this.panelOuterBox.Margin = new System.Windows.Forms.Padding(0);
            this.panelOuterBox.Name = "panelOuterBox";
            this.panelOuterBox.Size = new System.Drawing.Size(764, 764);
            this.panelOuterBox.TabIndex = 0;
            // 
            // pictureBoxRightNumbers
            // 
            this.pictureBoxRightNumbers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRightNumbers.Enabled = false;
            this.pictureBoxRightNumbers.Image = global::ChessByBird.Properties.Resources.Numbers;
            this.pictureBoxRightNumbers.Location = new System.Drawing.Point(714, 50);
            this.pictureBoxRightNumbers.Name = "pictureBoxRightNumbers";
            this.pictureBoxRightNumbers.Size = new System.Drawing.Size(50, 664);
            this.pictureBoxRightNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRightNumbers.TabIndex = 8;
            this.pictureBoxRightNumbers.TabStop = false;
            // 
            // pictureBoxLeftNumbers
            // 
            this.pictureBoxLeftNumbers.Enabled = false;
            this.pictureBoxLeftNumbers.Image = global::ChessByBird.Properties.Resources.Numbers;
            this.pictureBoxLeftNumbers.Location = new System.Drawing.Point(0, 50);
            this.pictureBoxLeftNumbers.Name = "pictureBoxLeftNumbers";
            this.pictureBoxLeftNumbers.Size = new System.Drawing.Size(50, 664);
            this.pictureBoxLeftNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLeftNumbers.TabIndex = 7;
            this.pictureBoxLeftNumbers.TabStop = false;
            // 
            // pictureBoxBottomLetters
            // 
            this.pictureBoxBottomLetters.Enabled = false;
            this.pictureBoxBottomLetters.ErrorImage = null;
            this.pictureBoxBottomLetters.Image = global::ChessByBird.Properties.Resources.Letters;
            this.pictureBoxBottomLetters.Location = new System.Drawing.Point(50, 714);
            this.pictureBoxBottomLetters.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBottomLetters.Name = "pictureBoxBottomLetters";
            this.pictureBoxBottomLetters.Size = new System.Drawing.Size(664, 50);
            this.pictureBoxBottomLetters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBottomLetters.TabIndex = 6;
            this.pictureBoxBottomLetters.TabStop = false;
            // 
            // pictureBoxTopLetters
            // 
            this.pictureBoxTopLetters.Enabled = false;
            this.pictureBoxTopLetters.Image = global::ChessByBird.Properties.Resources.Letters;
            this.pictureBoxTopLetters.Location = new System.Drawing.Point(50, 0);
            this.pictureBoxTopLetters.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTopLetters.Name = "pictureBoxTopLetters";
            this.pictureBoxTopLetters.Size = new System.Drawing.Size(664, 50);
            this.pictureBoxTopLetters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTopLetters.TabIndex = 5;
            this.pictureBoxTopLetters.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.AutoSize = true;
            this.panelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Enabled = false;
            this.panelRight.Location = new System.Drawing.Point(714, 50);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 0);
            this.panelRight.TabIndex = 4;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoSize = true;
            this.panelLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Enabled = false;
            this.panelLeft.Location = new System.Drawing.Point(0, 50);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 0);
            this.panelLeft.TabIndex = 3;
            // 
            // panelBottom
            // 
            this.panelBottom.AutoSize = true;
            this.panelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Enabled = false;
            this.panelBottom.ForeColor = System.Drawing.Color.White;
            this.panelBottom.Location = new System.Drawing.Point(50, 714);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(0, 0);
            this.panelBottom.TabIndex = 2;
            // 
            // panelTop
            // 
            this.panelTop.AutoSize = true;
            this.panelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Enabled = false;
            this.panelTop.ForeColor = System.Drawing.Color.White;
            this.panelTop.Location = new System.Drawing.Point(50, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(0, 0);
            this.panelTop.TabIndex = 1;
            // 
            // panelCenter
            // 
            this.panelCenter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCenter.BackColor = System.Drawing.Color.White;
            this.panelCenter.Controls.Add(this.pictureBoxCenter);
            this.panelCenter.Enabled = false;
            this.panelCenter.Location = new System.Drawing.Point(50, 50);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(664, 664);
            this.panelCenter.TabIndex = 0;
            // 
            // pictureBoxCenter
            // 
            this.pictureBoxCenter.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCenter.Enabled = false;
            this.pictureBoxCenter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCenter.Name = "pictureBoxCenter";
            this.pictureBoxCenter.Size = new System.Drawing.Size(664, 664);
            this.pictureBoxCenter.TabIndex = 0;
            this.pictureBoxCenter.TabStop = false;
            // 
            // timerSnapShot
            // 
            this.timerSnapShot.Interval = 3000;
            this.timerSnapShot.Tick += new System.EventHandler(this.timerSnipIt_Tick);
            // 
            // ChessBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(864, 864);
            this.Controls.Add(this.panelForm);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChessBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChessBoardForm";
            this.Load += new System.EventHandler(this.ChessBoardForm_Load);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelBottomLabel.ResumeLayout(false);
            this.panelBottomLabel.PerformLayout();
            this.panelTopLabel.ResumeLayout(false);
            this.panelTopLabel.PerformLayout();
            this.panelOuterBox.ResumeLayout(false);
            this.panelOuterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLetters)).EndInit();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel panelOuterBox;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelBottomLabel;
        private System.Windows.Forms.Panel panelTopLabel;
        private System.Windows.Forms.Button buttonBlackPlayer;
        private System.Windows.Forms.Button buttonWhitePlayer;
        private System.Windows.Forms.Timer timerSnapShot;
        private System.Windows.Forms.PictureBox pictureBoxCenter;
        private System.Windows.Forms.PictureBox pictureBoxRightNumbers;
        private System.Windows.Forms.PictureBox pictureBoxLeftNumbers;
        private System.Windows.Forms.PictureBox pictureBoxTopLetters;
        private System.Windows.Forms.PictureBox pictureBoxBottomLetters;

    }
}

