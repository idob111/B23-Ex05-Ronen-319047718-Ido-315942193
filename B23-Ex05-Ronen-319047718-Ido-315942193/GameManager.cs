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
        private readonly BoardGameForm r_GameBoardForm;

        // Starts a new game with the given settings
        public GameManager(GameSettings i_Settings, BoardGameForm i_BoardGameForm)
        {
            m_Game = new Game();
            m_Game.InitGame((int)i_Settings.NumberOfRows, i_Settings.IsModeAgainstPlayer);
            r_GameBoardForm = i_BoardGameForm;
            r_GameBoardForm.changeHighlightedPlayer(m_Game.CurrentPlayer.PlayerId);
        }

        // Updates the logic game board according to the player's chosen move
        public void playHumanTurn(PointIndex i_ButtonPointIndex, Button i_ClickedButton)
        {
            changeButtonText(i_ClickedButton);
            m_Game.HumanTurn(i_ButtonPointIndex);
            r_GameBoardForm.changeHighlightedPlayer(m_Game.CurrentPlayer.PlayerId);
        }

        //Change given button text
        private void changeButtonText(Button i_ClickedButton)
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
        }
        
        //return the scoring of player one
        public int PlayerOneScore()
        {
            return m_Game.GetScoringByPlayerId(ePlayers.PlayerOne);
        }
        //return the scoring of player Two
        public int PlayerTwoScore()
        {
            return m_Game.GetScoringByPlayerId(ePlayers.PlayerTwo);
        }

        // TODO: Add listener for AI to play a turn 
        // Chooses an empty cell on the game board and updates it accordingly in the button board
        public PointIndex playAiTurn()
        {
            PointIndex pointIndex = m_Game.aiTurn();
            r_GameBoardForm.changeHighlightedPlayer(m_Game.CurrentPlayer.PlayerId);
            return pointIndex;
        }

        // If the game ended shows a game ended message and resets the game
        public bool checkGameEnded()
        {
            bool isGameEnded = false;
            if (m_Game.GameEnded)
            {
                DialogResult userConfiramtion = MessageBox.Show(string.Format("{0}\nPlay another round?", m_Game.EndingMessage), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userConfiramtion == DialogResult.No)
                {
                    Application.Exit();
                }
                m_Game.ResetGame();
                isGameEnded = true;
            }
            return isGameEnded;
        }

    }
}
