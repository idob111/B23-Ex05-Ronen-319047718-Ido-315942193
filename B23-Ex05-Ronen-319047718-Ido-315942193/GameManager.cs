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
        private static GameSettings m_GameSettings;

        public static int Player1Score => m_Game.Player1Score;
        public static int Player2Score => m_Game.Player2Score;

        // Starts a new game with the given settings
        public static void InitGame(GameSettings i_Settings)
        {
            m_Game = new Game();
            m_Game.InitGame((int)i_Settings.NumberOfRows, i_Settings.IsModeAgainstPlayer);
            m_GameSettings = i_Settings;
        }

        
        // Updates the logic game board according to the player's chosen move
        public static void playHumanTurn(PointIndex i_ButtonPointIndex,Button i_ClickedButton)
        {
            switch (m_Game.CurrentPlayer.PlayerId)
            {
                case ePlayers.PlayerOne:
                    i_ClickedButton.Text = "X";
                    break;
                case ePlayers.PlayerTwo:
                    i_ClickedButton.Text = "O";
                    break;
            }

            m_Game.HumanTurn(i_ButtonPointIndex);
            checkGameEnded();
        }

        // TODO: Add listener for AI to play a turn 
        // Chooses an empty cell on the game board and updates it accordingly in the button board
        public static void playAiTurn()
        {

        }

        // If the game ended shows a game ended message and resets the game
        private static void checkGameEnded()
        {
            if (m_Game.GameEnded)
            {
                MessageBox.Show(m_Game.EndingMessage, string.Empty, MessageBoxButtons.OK);
                resetGame();
            }
        }

        // Resets the game Both logically and visually
        private static void resetGame()
        {
            m_Game.ResetGame();

            // TODO: This doesn't work currently, need to find another way to reset the form
            BoardGameForm.ActiveForm.Dispose();
            Application.Run(new BoardGameForm(m_GameSettings));
        }
    }
}
