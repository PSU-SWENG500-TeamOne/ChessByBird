namespace WindowsFormsApplication1
{
    partial class formChessBord
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
            this.panel1Main = new System.Windows.Forms.Panel();
            this.buttonWhitePlayer = new System.Windows.Forms.Button();
            this.buttonBlackPlayer = new System.Windows.Forms.Button();
            this.panel2Outer = new System.Windows.Forms.Panel();
            this.panel7Bottom = new System.Windows.Forms.Panel();
            this.pictureBoxBottomLetters = new System.Windows.Forms.PictureBox();
            this.panel6Right = new System.Windows.Forms.Panel();
            this.pictureBoxRightNumbers = new System.Windows.Forms.PictureBox();
            this.panel5Left = new System.Windows.Forms.Panel();
            this.pictureBoxLeftNumbers = new System.Windows.Forms.PictureBox();
            this.panel4Top = new System.Windows.Forms.Panel();
            this.pictureBoxTopLetters = new System.Windows.Forms.PictureBox();
            this.panel3Center = new System.Windows.Forms.Panel();
            this.pictureBoxCenter = new System.Windows.Forms.PictureBox();
            this.panel1Main.SuspendLayout();
            this.panel2Outer.SuspendLayout();
            this.panel7Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).BeginInit();
            this.panel6Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).BeginInit();
            this.panel5Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).BeginInit();
            this.panel4Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLetters)).BeginInit();
            this.panel3Center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1Main
            // 
            this.panel1Main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1Main.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1Main.Controls.Add(this.buttonWhitePlayer);
            this.panel1Main.Controls.Add(this.buttonBlackPlayer);
            this.panel1Main.Controls.Add(this.panel2Outer);
            this.panel1Main.Location = new System.Drawing.Point(0, 0);
            this.panel1Main.Name = "panel1Main";
            this.panel1Main.Size = new System.Drawing.Size(878, 878);
            this.panel1Main.TabIndex = 0;
            // 
            // buttonWhitePlayer
            // 
            this.buttonWhitePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWhitePlayer.Enabled = false;
            this.buttonWhitePlayer.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonWhitePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWhitePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWhitePlayer.Location = new System.Drawing.Point(50, 828);
            this.buttonWhitePlayer.Name = "buttonWhitePlayer";
            this.buttonWhitePlayer.Size = new System.Drawing.Size(778, 50);
            this.buttonWhitePlayer.TabIndex = 2;
            this.buttonWhitePlayer.Text = "White Player";
            this.buttonWhitePlayer.UseVisualStyleBackColor = false;
            // 
            // buttonBlackPlayer
            // 
            this.buttonBlackPlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBlackPlayer.Enabled = false;
            this.buttonBlackPlayer.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonBlackPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBlackPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlackPlayer.Location = new System.Drawing.Point(50, 0);
            this.buttonBlackPlayer.Name = "buttonBlackPlayer";
            this.buttonBlackPlayer.Size = new System.Drawing.Size(778, 50);
            this.buttonBlackPlayer.TabIndex = 1;
            this.buttonBlackPlayer.Text = "Black Player";
            this.buttonBlackPlayer.UseVisualStyleBackColor = false;
            // 
            // panel2Outer
            // 
            this.panel2Outer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2Outer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2Outer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2Outer.Controls.Add(this.panel7Bottom);
            this.panel2Outer.Controls.Add(this.panel6Right);
            this.panel2Outer.Controls.Add(this.panel5Left);
            this.panel2Outer.Controls.Add(this.panel4Top);
            this.panel2Outer.Controls.Add(this.panel3Center);
            this.panel2Outer.Location = new System.Drawing.Point(50, 50);
            this.panel2Outer.Name = "panel2Outer";
            this.panel2Outer.Size = new System.Drawing.Size(778, 778);
            this.panel2Outer.TabIndex = 0;
            // 
            // panel7Bottom
            // 
            this.panel7Bottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7Bottom.Controls.Add(this.pictureBoxBottomLetters);
            this.panel7Bottom.Location = new System.Drawing.Point(50, 728);
            this.panel7Bottom.Name = "panel7Bottom";
            this.panel7Bottom.Size = new System.Drawing.Size(678, 50);
            this.panel7Bottom.TabIndex = 4;
            // 
            // pictureBoxBottomLetters
            // 
            this.pictureBoxBottomLetters.BackColor = System.Drawing.Color.Red;
            this.pictureBoxBottomLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBottomLetters.Image = global::WindowsFormsApplication1.Properties.Resources.Letters;
            this.pictureBoxBottomLetters.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBottomLetters.Name = "pictureBoxBottomLetters";
            this.pictureBoxBottomLetters.Size = new System.Drawing.Size(678, 50);
            this.pictureBoxBottomLetters.TabIndex = 0;
            this.pictureBoxBottomLetters.TabStop = false;
            // 
            // panel6Right
            // 
            this.panel6Right.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6Right.Controls.Add(this.pictureBoxRightNumbers);
            this.panel6Right.Location = new System.Drawing.Point(728, 50);
            this.panel6Right.Name = "panel6Right";
            this.panel6Right.Size = new System.Drawing.Size(50, 678);
            this.panel6Right.TabIndex = 3;
            // 
            // pictureBoxRightNumbers
            // 
            this.pictureBoxRightNumbers.BackColor = System.Drawing.Color.PeachPuff;
            this.pictureBoxRightNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRightNumbers.Image = global::WindowsFormsApplication1.Properties.Resources.Numbers2;
            this.pictureBoxRightNumbers.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRightNumbers.Name = "pictureBoxRightNumbers";
            this.pictureBoxRightNumbers.Size = new System.Drawing.Size(50, 678);
            this.pictureBoxRightNumbers.TabIndex = 0;
            this.pictureBoxRightNumbers.TabStop = false;
            // 
            // panel5Left
            // 
            this.panel5Left.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5Left.Controls.Add(this.pictureBoxLeftNumbers);
            this.panel5Left.Location = new System.Drawing.Point(0, 50);
            this.panel5Left.Name = "panel5Left";
            this.panel5Left.Size = new System.Drawing.Size(50, 678);
            this.panel5Left.TabIndex = 2;
            // 
            // pictureBoxLeftNumbers
            // 
            this.pictureBoxLeftNumbers.BackColor = System.Drawing.Color.PeachPuff;
            this.pictureBoxLeftNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeftNumbers.Image = global::WindowsFormsApplication1.Properties.Resources.Numbers2;
            this.pictureBoxLeftNumbers.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeftNumbers.Name = "pictureBoxLeftNumbers";
            this.pictureBoxLeftNumbers.Size = new System.Drawing.Size(50, 678);
            this.pictureBoxLeftNumbers.TabIndex = 0;
            this.pictureBoxLeftNumbers.TabStop = false;
            // 
            // panel4Top
            // 
            this.panel4Top.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4Top.Controls.Add(this.pictureBoxTopLetters);
            this.panel4Top.Location = new System.Drawing.Point(50, 0);
            this.panel4Top.Name = "panel4Top";
            this.panel4Top.Size = new System.Drawing.Size(678, 50);
            this.panel4Top.TabIndex = 1;
            // 
            // pictureBoxTopLetters
            // 
            this.pictureBoxTopLetters.BackColor = System.Drawing.Color.Red;
            this.pictureBoxTopLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTopLetters.Image = global::WindowsFormsApplication1.Properties.Resources.Letters;
            this.pictureBoxTopLetters.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTopLetters.Name = "pictureBoxTopLetters";
            this.pictureBoxTopLetters.Size = new System.Drawing.Size(678, 50);
            this.pictureBoxTopLetters.TabIndex = 0;
            this.pictureBoxTopLetters.TabStop = false;
            // 
            // panel3Center
            // 
            this.panel3Center.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3Center.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3Center.BackColor = System.Drawing.Color.Black;
            this.panel3Center.Controls.Add(this.pictureBoxCenter);
            this.panel3Center.Location = new System.Drawing.Point(50, 50);
            this.panel3Center.Name = "panel3Center";
            this.panel3Center.Size = new System.Drawing.Size(678, 678);
            this.panel3Center.TabIndex = 0;
            // 
            // pictureBoxCenter
            // 
            this.pictureBoxCenter.BackColor = System.Drawing.Color.Peru;
            this.pictureBoxCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCenter.InitialImage = null;
            this.pictureBoxCenter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCenter.Name = "pictureBoxCenter";
            this.pictureBoxCenter.Size = new System.Drawing.Size(678, 678);
            this.pictureBoxCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCenter.TabIndex = 0;
            this.pictureBoxCenter.TabStop = false;
            // 
            // formChessBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(880, 880);
            this.Controls.Add(this.panel1Main);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formChessBord";
            this.Text = "formChessBoard";
            this.panel1Main.ResumeLayout(false);
            this.panel2Outer.ResumeLayout(false);
            this.panel7Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLetters)).EndInit();
            this.panel6Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightNumbers)).EndInit();
            this.panel5Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftNumbers)).EndInit();
            this.panel4Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLetters)).EndInit();
            this.panel3Center.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1Main;
        private System.Windows.Forms.Panel panel2Outer;
        private System.Windows.Forms.Panel panel7Bottom;
        private System.Windows.Forms.PictureBox pictureBoxBottomLetters;
        private System.Windows.Forms.Panel panel6Right;
        private System.Windows.Forms.PictureBox pictureBoxRightNumbers;
        private System.Windows.Forms.Panel panel5Left;
        private System.Windows.Forms.Panel panel4Top;
        private System.Windows.Forms.PictureBox pictureBoxTopLetters;
        private System.Windows.Forms.Panel panel3Center;
        private System.Windows.Forms.PictureBox pictureBoxCenter;
        private System.Windows.Forms.PictureBox pictureBoxLeftNumbers;
        private System.Windows.Forms.Button buttonBlackPlayer;
        private System.Windows.Forms.Button buttonWhitePlayer;


    }
}

