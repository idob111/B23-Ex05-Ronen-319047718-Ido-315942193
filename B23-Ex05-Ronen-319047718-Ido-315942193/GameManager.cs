using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using B23_Ex02_Ronen_319047718_Ido_315942193;
using CSharp_Ex2;

namespace B23_Ex05_Ronen_319047718_Ido_315942193
{
    public static class GameManager
    {
        private static Game m_Game;
        private static Button[,] m_ButtonBoard = null;
        public static Player CurrentPlayer => m_Game.CurrentPlayer;

        // Starts a new game with the given settings
        public static void InitGame(GameSettings i_Settings)
        {
            m_Game = new Game();
            m_Game.InitGame((int)i_Settings.NumberOfRows, i_Settings.IsModeAgainstPlayer);
        }

        // TODO: Find a way to get the button index when pressed and pass into this function
        // Updates the logic game board according to the player's chosen move
        public static void playHumanTurn(PointIndex i_ButtonIndex)
        {

        }

        // TODO: Add listener for AI to play a turn 
        // Chooses an empty cell on the game board and updates it accordingly in the button board
        public static void playAiTurn()
        {

        }
    }
}
