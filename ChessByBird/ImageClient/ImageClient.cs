using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ChessByBird.ImageClient
{
    public class ImageClient
    {
        
        /// <summary>
        /// Builds image for game state 
        /// </summary>
        /// <param name="gameState">FEN Value of the current game state</param>
        /// <param name="playerCurrentTurn">Name for the player who's turn it now is</param>
        /// <param name="playerNowWaiting">Name for player who just went</param>
        /// <returns>asset path for the new image</returns>
        public static string processImage(string gameBoardState, string whitePlayerName, string blackPlayerName)
        {
             // TODO: Do we need this as defaults
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup Objects
            ChessBoardImageForm cbbForm = new ChessBoardImageForm();
            ChessBoardImageGenerator cbbImgGen = new ChessBoardImageGenerator(cbbForm);
            cbbForm.ImageGenerator = cbbImgGen;

            // Setup Input Fields
            cbbImgGen.WhitePlayerLabel = whitePlayerName;
            cbbImgGen.BlackPlayerLabel = blackPlayerName;

            // Setup Output Fields
            cbbImgGen.FileNameImageFormat = ImageFormat.Png;
            cbbImgGen.ImageFileName = @"..\..\DigitalAssets\ChessBoardImage.png";

            // Set "updatedGameBoardState" expected in Forsyth-Edwards Notation
            cbbForm.ChessBoardStateFEN = gameBoardState;

            // Generate the game board
            Application.Run(cbbForm);

            return cbbImgGen.ImageFileName;
        }

        
    }
}
