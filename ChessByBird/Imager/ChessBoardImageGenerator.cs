/*******************************************************************************
 *  Penn State University Software Engineering Graduate ImagerProgram
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChessByBird.ImagingProject
{
    /// <summary>
    /// ChessBoardImageGenerator
    /// </summary>
    public class ChessBoardImageGenerator
    {
        /// <summary>
        /// Fields
        /// </summary>        
        private string chessWhitePlayerName;

        public string WhitePlayerName
        {
            get { return chessWhitePlayerName; }
            set { chessWhitePlayerName = value; }
        }

        private string chessBlackPlayerName;

        public string BlackPlayerName
        {
            get { return chessBlackPlayerName; }
            set { chessBlackPlayerName = value; }
        }

        private string chessblackPlayerButtonText;

        public string BlackPlayerButtonText
        {
            get { return chessblackPlayerButtonText; }
            set { chessblackPlayerButtonText = value; }
        }

        private string chessWhitePlayerButtonText;

        public string WhitePlayerButtonText
        {
            get { return chessWhitePlayerButtonText; }
            set { chessWhitePlayerButtonText = value; }
        }

        private string imageFileName;

        public string ImageFileName
        {
            get { return imageFileName; }
            set { imageFileName = value; }
        }

        private ImageFormat fileNameImageFormat;

        public ImageFormat FileNameImageFormat
        {
            get { return fileNameImageFormat; }
            set { fileNameImageFormat = value; }
        }

        /// <summary>
        /// Class Variables
        /// </summary>
        ///
        private ChessBoard chessBoard = null;
        private ChessPlayer chessWhitePlayer = null;
        private ChessPlayer chessBlackPlayer = null;
        private Font TitleFont = null;
        private SolidBrush TitleBrush = null;
        private PictureBox chessBoardPictureBox = null;
        private Button whitePlayerButton = null;
        private Button blackPlayerButton = null;
        private Form winForm = null;

        /// <summary>
        /// ChessBoardImageGenerator constructor
        /// </summary>
        public ChessBoardImageGenerator(Form aWinForm)
        {
            winForm = aWinForm;
            InitializeImageGenerator();
        }

        /// <summary>
        /// Destructor disposes of resources
        /// </summary>
        ~ChessBoardImageGenerator()
        {
            if (TitleBrush != null)
                TitleBrush.Dispose();

            if (TitleFont != null)
                TitleFont.Dispose();
        }

        /// <summary>
        /// paint method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void paint(object sender, PaintEventArgs eventArgs)
        {
            Graphics g = eventArgs.Graphics;
            try
            {
                chessBoard.Draw(g);
            }
            finally
            {
                // g.Dispose(); // Can not dispose here
            }
        }

        /// <summary>
        /// FindControl
        /// </summary>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        private Control FindControl(string strControlName)
        {
            if (strControlName.Length == 0 || winForm.Controls.Find(strControlName, true).Length == 0)
                return null;
            Control foundControl = winForm.Controls.Find(strControlName, true)[0];

            return foundControl;
        }

        /// <summary>
        /// InitializeImageGenerator
        /// </summary>
        public void InitializeImageGenerator()
        {
            try
            {
                if (null == (chessBoardPictureBox = (PictureBox)FindControl("pictureBoxCenter")))
                {
                    string errorMsg = "Null PictureBox Control:";
                    throw new Exception(errorMsg);
                }
            }
            catch (Exception E)
            {
                string errorMsg = E.ToString();
                throw new Exception(errorMsg);
            }
            try
            {
                if (null == (whitePlayerButton = (Button)FindControl("buttonWhitePlayer")))
                {
                    string errorMsg = "Null Bottom Button Control:";
                    throw new Exception(errorMsg);
                }
            }
            catch (Exception E)
            {
                string errorMsg = E.ToString();
                throw new Exception(errorMsg);
            }
            try
            {
                if (null == (blackPlayerButton = (Button)FindControl("buttonBlackPlayer")))
                {
                    string errorMsg = "Null Top Button Control:";
                    throw new Exception(errorMsg);
                }
            }
            catch (Exception E)
            {
                string errorMsg = E.ToString();
                throw new Exception(errorMsg);
            }
            try
            {
                if (WhitePlayerName == null)
                {
                    chessWhitePlayerName = WhitePlayerName;
                }
                else
                {
                    chessWhitePlayerName = whitePlayerButton.Text;
                }
                if (BlackPlayerName == null)
                {
                    chessBlackPlayerName = BlackPlayerName;
                }
                else
                {
                    chessBlackPlayerName = blackPlayerButton.Text;
                }

                chessBoard = new ChessBoard(this, chessBoardPictureBox);
                chessWhitePlayer = new ChessPlayer(EnumPlayerType.WhitePlayer, chessWhitePlayerName, EnumPieceColor.White);
                chessBlackPlayer = new ChessPlayer(EnumPlayerType.BlackPlayer, chessBlackPlayerName, EnumPieceColor.Black);

                chessBoard.InitializeChessBoard();

                SetChessBoardPlayerButtonText();

                chessWhitePlayer.SetPieceList(chessBoard.GetWhitePieceList());
                chessBlackPlayer.SetPieceList(chessBoard.GetBlackPieceList());
            }
            catch (Exception E)
            {
                string errorMsg = E.ToString();
                throw new Exception(errorMsg);
            }
        }

        /// <summary>
        /// SetChessBoardPlayerButtonText
        /// </summary>
        private void SetChessBoardPlayerButtonText()
        {
            /// Decorate whose turn it is
            string whiteText = "";
            string blackText = "";
            if (ChessImageConstants.parserSideToMove == EnumOpponentColor.White)
            {
                blackText = chessBlackPlayerName;
                whiteText = "➥";
                whiteText += chessWhitePlayerName;
            }
            else
            {
                whiteText = chessWhitePlayerName;
                blackText = "➥";
                blackText += chessBlackPlayerName;
            }
            whitePlayerButton.Text = whiteText;
            blackPlayerButton.Text = blackText;
        }

        /// <summary>
        /// EnsureDirectoryExists
        /// </summary>
        /// <param name="path"></param>
        public static void EnsureDirectoryExists(string path)
        {
            // Set to folder path we must ensure exists.
            try
            {
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                // Fail silently
            }
        }

        /// <summary>
        /// EnableChessPieces method
        /// </summary>
        internal void EnableChessPieces()
        {
            ArrayList whitePlayerList = chessWhitePlayer.GetPieceList();
            ArrayList blackPlayerList = chessBlackPlayer.GetPieceList();
            if (whitePlayerList.Count > 0 && blackPlayerList.Count > 0)
            {
                for (int i = 0; i < ChessImageConstants.ChessPieceCount; i++)
                {
                    ChessPiece whiteChessPiece = (ChessPiece)whitePlayerList[i];
                    ChessPiece blackChessPiece = (ChessPiece)blackPlayerList[i];

                    if (whiteChessPiece != null)
                    {
                        bool turn = chessWhitePlayer.GetTurn();
                        whiteChessPiece.SetIsEnabled(turn);
                    }

                    if (blackChessPiece != null)
                    {
                        bool turn = chessBlackPlayer.GetTurn();
                        blackChessPiece.SetIsEnabled(turn);
                    }
                }
            }
            else
            {
                throw new Exception("Error: Internal failure in EnableChessPieces");
            }
        }

        /// <summary>
        /// Process chessboard image from FEN state
        /// </summary>
        /// <param name="aPlayer1Name"></param>
        /// <param name="aPlayer2Name"></param>
        /// <param name="aChessBoardBox"></param>
        public void ProcessImage(string chessBoardStateFEN)
        {
            if (0 == ChessBoardParser.SetFEN(chessBoardStateFEN))
            {
                TitleFont = new Font("Arial", 10, GraphicsUnit.Point);
                TitleBrush = new SolidBrush(Color.Navy);
                SetChessBoardPlayerButtonText();
                chessBoard.DrawChessPieces();
            }
            else
            {
                string errorMsg = "Error: Invalid Chess Board State FEN String > " + chessBoardStateFEN;
                throw new Exception(errorMsg);
            }
        }

        /// <summary>
        /// CaptureAndSaveFormImage
        /// </summary>
        /// <param name="theForm"></param>
        public void CaptureAndSaveFormImage(Form theForm)
        {
            string directoryName = Path.GetDirectoryName(ImageFileName);
            EnsureDirectoryExists(directoryName);
            try
            {
                using (Bitmap bitmap = TakeAppWndSnapShot(theForm.Handle, true, ChessWin32API.WindowShowStyle.Restore))
                {
                    try
                    {
                        bitmap.Save(ImageFileName, FileNameImageFormat);
                    }
                    catch (Exception E)
                    {
                        string errorMsg = "Error: failed to save bitmap image to " + ImageFileName;
                        errorMsg += "\n" + E.ToString();
                        throw new Exception(errorMsg);
                    }
                }
            }
            catch (Exception E)
            {
                string errorMsg = "Error: failed to capture bitmap image of drawing";
                errorMsg += "\n" + E.ToString();
                throw new Exception(errorMsg);
            }
        }

        /// <summary>
        /// Take a SnapShot of the application window
        /// </summary>
        /// <Remark>
        /// http://www.codeproject.com/script/articles/list_articles.asp?userid=634640
        ///</Remark>
        /// <param name="AppWndHandle"></param>
        /// <param name="IsClientWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns>Bitmap of application window </returns>
        private static Bitmap TakeAppWndSnapShot(IntPtr AppWndHandle, bool IsClientWnd, ChessWin32API.WindowShowStyle nCmdShow)
        {
            if (AppWndHandle == IntPtr.Zero || !ChessWin32API.IsWindow(AppWndHandle) || !ChessWin32API.IsWindowVisible(AppWndHandle))
                return null;
            if (ChessWin32API.IsIconic(AppWndHandle))
                ChessWin32API.ShowWindow(AppWndHandle, nCmdShow); //show it
            if (!ChessWin32API.SetForegroundWindow(AppWndHandle))
                return null; //can't bring it to front

            System.Threading.Thread.Sleep(1000); //give it some time to redraw

            RECT appRect;
            bool res = IsClientWnd ? ChessWin32API.GetClientRect(AppWndHandle, out appRect) : ChessWin32API.GetWindowRect(AppWndHandle, out appRect);
            if (!res || appRect.Height == 0 || appRect.Width == 0)
            {
                return null; //some hidden window
            }
            if (IsClientWnd)
            {
                Point lt = new Point(appRect.Left, appRect.Top);
                Point rb = new Point(appRect.Right, appRect.Bottom);
                ChessWin32API.ClientToScreen(AppWndHandle, ref lt);
                ChessWin32API.ClientToScreen(AppWndHandle, ref rb);
                appRect.Left = lt.X;
                appRect.Top = lt.Y;
                appRect.Right = rb.X;
                appRect.Bottom = rb.Y;
            }

            // Intersect with the Desktop rectangle and get what's visible
            IntPtr DesktopHandle = ChessWin32API.GetDesktopWindow();
            RECT desktopRect;
            ChessWin32API.GetWindowRect(DesktopHandle, out desktopRect);
            RECT visibleRect;

            if (!ChessWin32API.IntersectRect(out visibleRect, ref desktopRect, ref appRect))
            {
                visibleRect = appRect;
            }
            if (ChessWin32API.IsRectEmpty(ref visibleRect))
                return null;

            int Width = visibleRect.Width;
            int Height = visibleRect.Height;
            IntPtr hdcTo = IntPtr.Zero;
            IntPtr hdcFrom = IntPtr.Zero;
            IntPtr hBitmap = IntPtr.Zero;
            try
            {
                Bitmap clsRet = null;

                // get device context of the window...
                hdcFrom = IsClientWnd ? ChessWin32API.GetDC(AppWndHandle) : ChessWin32API.GetWindowDC(AppWndHandle);

                // create dc that we can draw to...
                hdcTo = ChessWin32API.CreateCompatibleDC(hdcFrom);
                hBitmap = ChessWin32API.CreateCompatibleBitmap(hdcFrom, Width, Height);

                // validate...
                if (hBitmap != IntPtr.Zero)
                {
                    // copy...
                    int x = appRect.Left < 0 ? -appRect.Left : 0;
                    int y = appRect.Top < 0 ? -appRect.Top : 0;
                    IntPtr hLocalBitmap = ChessWin32API.SelectObject(hdcTo, hBitmap);
                    ChessWin32API.BitBlt(hdcTo, 0, 0, Width, Height, hdcFrom, x, y, ChessWin32API.SRCCOPY);
                    ChessWin32API.SelectObject(hdcTo, hLocalBitmap);
                    // create bitmap for window image...
                    clsRet = System.Drawing.Image.FromHbitmap(hBitmap);
                }

                //MessageBox.Show(string.Format("rect ={0} \n deskrect ={1} \n visiblerect = {2}",rct,drct,VisibleRCT));
                //return...
                return clsRet;
            }
            finally
            {
                // release ...
                if (hdcFrom != IntPtr.Zero)
                    ChessWin32API.ReleaseDC(AppWndHandle, hdcFrom);
                if (hdcTo != IntPtr.Zero)
                    ChessWin32API.DeleteDC(hdcTo);
                if (hBitmap != IntPtr.Zero)
                    ChessWin32API.DeleteObject(hBitmap);
            }
        }
    }
}
