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
                String chessmove = "a2 a3";
                String boardFN = null;
                Process newProcess = new Process();
                String newBoard = newProcess.processChess(chessmove, boardFN);
                Console.WriteLine(newBoard);
                System.Console.Write("");
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
            }
        }
    }
}
