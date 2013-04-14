/*******************************************************************************
 *  Penn State University Software Engineering Graduate ImagerProgram
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ChessByBird.ImagingProject;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace ChessByBird
{
    public partial class ChessBoardForm : Form
    {
        public ChessBoardForm()
        {
            InitializeComponent();
        }

        private void ChessBoardForm_Load(object sender, EventArgs e)
        {
            RenderChessBoard();
            timerSnapShot.Start();
        }

        void timerSnipIt_Tick(object sender, EventArgs e)
        {
            if (sender == timerSnapShot)
            {
                SaveChessBoardImage();
                this.Close();
                timerSnapShot.Dispose();
            }
        }

        public void RenderChessBoard()
        {
            try
            {
                imageGenerator.ProcessImage(chessBoardStateFEN);
            }
            catch (Exception E)
            {
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(E.ToString(), caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close(); // Closes the parent form. 
                }
            }
        }

        private void SaveChessBoardImage()
        {
            try
            {
                if (imageGenerator != null)
                {
                    SetTargetImage(pictureBoxCenter);
                    imageGenerator.CaptureAndSaveFormImage(this);
                }
            }
            catch (Exception E)
            {
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(E.ToString(), caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close(); // Closes the parent form. 
                }
            }
        }

        /// <summary>
        /// Calculate Image Dimensions
        /// Provide currentWidth & currentHeight from our image, and the finalWidth & finalHeight from the 
        /// dimensions of the PictureBox housing the image. Also ensure the proper scaling using a multip
        /// that is calculated based on whether the image is in landscape or portrait mode.
        /// </summary>
        /// 
        /// <param name="currentWidth"></param>
        /// <param name="currentHeight"></param>
        /// <param name="finalWidth"></param>
        /// <param name="finalHeight"></param>
        /// <returns></returns>
        public Size CalculateImageDimensions(int currentWidth, int currentHeight, int finalWidth, int finalHeight)
        {
            double scaleFactor = 0; // final scale factor to use when scaling the image
            string layoutMode;

            // determine if it's Portrait or Landscape Mode
            if (currentHeight > currentWidth) layoutMode = "portrait";
            else layoutMode = "landscape";

            switch (layoutMode.ToLower())
            {
                case "portrait":
                    // calculate scaleFactor on heights
                    if (finalHeight > finalWidth)
                    {
                        scaleFactor = (double)finalWidth / (double)currentWidth;
                    }
                    else
                    {
                        scaleFactor = (double)finalHeight / (double)currentHeight;
                    }
                    break;
                case "landscape":
                    // calculate scaleFactor on widths
                    if (finalHeight > finalWidth)
                    {
                        scaleFactor = (double)finalWidth / (double)currentWidth;
                    }
                    else
                    {
                        scaleFactor = (double)finalHeight / (double)currentHeight;
                    }
                    break;
            }

            // return the new image dimensions
            return new Size((int)(currentWidth * scaleFactor), (int)(currentHeight * scaleFactor));
        }

        /// <summary>
        /// Set the target image scaled appropriately for the target pictureBox
        /// </summary>
        /// <param name="targetPictureBox"></param>
        private void SetTargetImage(PictureBox targetPictureBox)
        {
            try
            {
                // Temporary image
                Image temporaryImage = targetPictureBox.Image;

                // Calculate image size
                Size imageSize = CalculateImageDimensions(temporaryImage.Width, temporaryImage.Height, this.pictureBoxCenter.Width, this.pictureBoxCenter.Height);

                // Make a new Bitmap with the proper dimensions
                Bitmap finalImage = new Bitmap(temporaryImage, imageSize.Width, imageSize.Height);

                // Create a Graphics object from the image
                Graphics g = Graphics.FromImage(temporaryImage);

                // Clean up the image by take care of any image loss from resizing. HighQualityBicubic mode is used to make sure the 
                // quality stays constant while shrinking the image.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Empty the PictureBox
                targetPictureBox.Image = null;

                // Center the new image
                targetPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

                // Set the new image
                targetPictureBox.Image = finalImage;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private ChessBoardImageGenerator imageGenerator;

        public ChessBoardImageGenerator ImageGenerator
        {
            get { return imageGenerator; }
            set { imageGenerator = value; }
        }

        private string chessBoardStateFEN;

        public string ChessBoardStateFEN
        {
            get { return chessBoardStateFEN; }
            set { chessBoardStateFEN = value; }
        }
    }
}


