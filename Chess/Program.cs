using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessProject.Chess;

namespace ChessProject.ChessProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //    [STAThread]

        static void Main(string[] args)
        {
            try
            {               
                  String boardFN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
                  Process newProcess = new Process();
                while (true)
               {
                   Console.WriteLine("BoardFN:" + boardFN);
                   Console.WriteLine("new move: ");
                   String chessmove = System.Console.ReadLine();
                   String newBoard = newProcess.processChess(chessmove, boardFN);
                   boardFN = newBoard;
                   Console.WriteLine("complete run: ");
               }
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
            }
        }
    }
}
