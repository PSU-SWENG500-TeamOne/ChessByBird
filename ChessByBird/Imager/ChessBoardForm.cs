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


