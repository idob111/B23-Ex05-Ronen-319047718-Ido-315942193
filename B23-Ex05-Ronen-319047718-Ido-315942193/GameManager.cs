using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace GameDesign
{
    public class GameManager
    {
        private Game m_Game;
        private GameSettings m_Settings;
        private readonly BoardGameForm r_GameBoardForm;

        // Starts a new game with the given settings
        public GameManager(GameSettings i_Settings, BoardGameForm i_BoardGameForm)
        {
            m_Game = new Game();
            m_Game.InitGame((int)i_Settings.NumberOfRows, i_Settings.IsModeAgainstPlayer, i_Settings.PlayerOneName, i_Settings.PlayerTwoName);
            r_GameBoardForm = i_BoardGameForm;
            r_GameBoardForm.changeHighlightedPlayer(m_Game.CurrentPlayer.PlayerId);
            m_Settings = i_Settings;
        }

        // Updates the logic game board according to the player's chosen move
        public void playHumanTurn(Point i_ButtonPoint, Button i_ClickedButton)
        {
            m_Game.HumanTurn(i_ButtonPoint);
            updateMoveOnBoard(i_ClickedButton);

            if (checkGameEnded())
            {
                r_GameBoardForm.HandleEndGame();
            }
            else if (!m_Settings.IsModeAgainstPlayer)
            {
                playAiTurn();
            }
        }

        // Chooses an empty cell on the game board and updates it accordingly in the button board
        private void playAiTurn()
        {
            Point aiMoveIndex = m_Game.AiTurn();
            updateMoveOnBoard(r_GameBoardForm.ConvertPointToButton(aiMoveIndex));

            if (checkGameEnded())
            {
                r_GameBoardForm.HandleEndGame();
            }
        }


        //Change given button text based on the current player
        private void changeButtonText(Button i_ClickedButton)
        {
            i_ClickedButton.Enabled = false;
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

        // Updates the selected button text, changes the player and highlights him
        private void updateMoveOnBoard(Button i_ClickedButton)
        {
            changeButtonText(i_ClickedButton);
            m_Game.ChangePlayer();
            r_GameBoardForm.changeHighlightedPlayer(m_Game.CurrentPlayer.PlayerId);
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
