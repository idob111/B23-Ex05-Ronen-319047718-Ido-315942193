using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using B23_Ex02_Ronen_319047718_Ido_315942193;
using CSharp_Ex2;

namespace B23_Ex05_Ronen_319047718_Ido_315942193
{
    public class GameManager
    {
        private Game m_Game;

        // Starts a new game with the given settings
        public GameManager(GameSettings i_Settings)
        {
            m_Game = new Game();
            m_Game.InitGame((int)i_Settings.NumberOfRows, i_Settings.IsModeAgainstPlayer);
        }


        // Updates the logic game board according to the player's chosen move
        public void playHumanTurn(PointIndex i_ButtonPointIndex, Button i_ClickedButton)
        {
            // TODO: Move to the form. We should actually implement the bonus Guy gave in the task file. It will deal with this much better.
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
        }

        public int PlayerOneScore()
        {
            return m_Game.GetScoringByPlayerId(ePlayers.PlayerOne);
        }
        public int PlayerTwoScore()
        {
            return m_Game.GetScoringByPlayerId(ePlayers.PlayerTwo);
        }

        // TODO: Add listener for AI to play a turn 
        // Chooses an empty cell on the game board and updates it accordingly in the button board
        public static void playAiTurn()
        {

        }

        // If the game ended shows a game ended message and resets the game
        public bool checkGameEnded()
        {
            bool isGameEnded = false;
            if (m_Game.GameEnded)
            {
                MessageBox.Show(m_Game.EndingMessage, string.Empty, MessageBoxButtons.OK);
                resetGame();
                isGameEnded = true;
            }
            return isGameEnded;
        }

        // Resets the game Both logically and visually
        private void resetGame()
        {
            m_Game.ResetGame();

            // TODO: Reset all buttons in BoardGameForm.designer.cs
        }
    }
}
