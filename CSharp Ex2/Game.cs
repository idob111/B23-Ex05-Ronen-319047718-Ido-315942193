using System.Drawing;

namespace GameLogic
{
    public class Game
    {
        private const string k_BoardFullMessage = "Board full. No Winners.";

        private Player m_FirstPlayer;
        private int m_BoardSize;
        private Board m_Board;
        private Player m_SecondPlayer;
        private AiPlayer m_AiPlayer;
        private bool m_GameEnded;
        private string m_EndingMessage = string.Empty;
        private Player m_CurrentPlayer;

        public Player CurrentPlayer => m_CurrentPlayer;
        public bool GameEnded => m_GameEnded;
        public string EndingMessage => m_EndingMessage;

        public enum eMode
        {
            Human,
            Computer,
            Exit
        }

        public Game()
        {
            m_GameEnded = false;
            m_BoardSize = 0;
            m_Board = null;
        }

        public int GetScoringByPlayerId(ePlayers i_PlayerId)
        {
            int score;
            if (i_PlayerId.Equals(ePlayers.PlayerOne))
            {
                score = m_FirstPlayer.Score;
            }
            else
            {
                score = m_SecondPlayer.Score;
            }
            return score;
        }


        // Initializes the game board and the players.
        public void InitGame(int i_BoardSize, bool i_IsGameAgainstPlayer, string i_PlayerOneName, string i_PlayerTwoName)
        {
            eMode gameMode;
            if (i_IsGameAgainstPlayer)
            {
                gameMode = eMode.Human;
            }
            else
            {
                gameMode = eMode.Computer;
            }

            m_FirstPlayer =  new Player(ePlayers.PlayerOne, 0, eCellType.Cross, i_PlayerOneName);
            m_CurrentPlayer = m_FirstPlayer;
            m_BoardSize = i_BoardSize;
            m_Board = new Board(i_BoardSize);
            switch (gameMode)
            {
                case eMode.Human:
                    m_SecondPlayer = new Player(ePlayers.PlayerTwo, 0, eCellType.Circle, i_PlayerTwoName);
                    break;
                case eMode.Computer:
                    m_AiPlayer = new AiPlayer(ePlayers.PlayerTwo, 0, eCellType.Circle);
                    m_SecondPlayer = m_AiPlayer.PlayerData;
                    break;
            }
        }

        // Receive the index of the button pressed and update it in the logic game board
        public void HumanTurn(Point i_PlayerMove)
        {
            updateBoardAndPlayers(i_PlayerMove);
        }

        // Ai does it's move and updates it on the logical board
        public Point AiTurn()
        {
            Point playerMove = m_AiPlayer.PlayTurn(m_Board, m_BoardSize);
            updateBoardAndPlayers(playerMove);
            return playerMove;
        }

        // Updates the board and ends the game if the player lost. If player won then updates his score.
        private void updateBoardAndPlayers(Point i_Cell)
        {
            m_Board.UpdateBoardCell(i_Cell, m_CurrentPlayer.PlayerId);

            if (isPlayerLost(i_Cell))
            {
                m_GameEnded = true;
                ChangePlayer();
                CurrentPlayer.Score++;
                m_EndingMessage = string.Format("{0} Won!", m_CurrentPlayer.Name);
                ChangePlayer();
            }
            else if (isBoardFullWithoutWinners())
            {
                m_GameEnded = true;
                m_EndingMessage = k_BoardFullMessage;
            }
        }

        private bool isBoardFullWithoutWinners()
        {
            return m_Board.TurnsLeft == 0;
        }

        // The algorithm responsible for checking if the player that did the current move lost.
        // Checks if a given Row/Column/Diagonal is full using the bucket arrays in Board.
        // If they are then checks if the given Row/Column/Diagonal is the same shape.
        // If so then returns true, false otherwise.
        private bool isPlayerLost(Point i_Cell)
        {
            bool rowSameShape = false, columnSameShape = false, topLeftBottomRightDiagonalSameShape = false, BottomLeftTopRightDiagonalSameShape = false;

            if (m_Board.OccupiedCellsInColumnBucket[i_Cell.Y] == m_BoardSize)
            {
                columnSameShape = m_Board.IsColumnSameShape(i_Cell.Y);
            }

            if (m_Board.OccupiedCellsInRowBucket[i_Cell.X] == m_BoardSize)
            {
                rowSameShape = m_Board.IsRowSameShape(i_Cell.X);
            }

            if (i_Cell.X == i_Cell.Y) // Check if the given point is on the top left to bottom right diagonal 
            {
                if (m_Board.OccupiedCellsInDiagonalBucketBucket[0] == m_BoardSize)
                {
                    topLeftBottomRightDiagonalSameShape = m_Board.IsDiagonalSameShape(eDiagonal.TopLeftToBottomRight);
                }
            }

            if (i_Cell.X == (m_BoardSize - i_Cell.Y - 1)) // Check if the given point is on the bottom left to top right diagonal
            {
                if (m_Board.OccupiedCellsInDiagonalBucketBucket[1] == m_BoardSize)
                {
                    BottomLeftTopRightDiagonalSameShape = m_Board.IsDiagonalSameShape(eDiagonal.BottomLeftToTopRight);
                }
            }

            return rowSameShape || columnSameShape || topLeftBottomRightDiagonalSameShape || BottomLeftTopRightDiagonalSameShape;
        }

        // Resets the game board and keeps the score as is
        public void ResetGame()
        {
            m_Board.ResetBoard();
            m_GameEnded = false;
            m_CurrentPlayer = m_FirstPlayer;
        }

        // Changes the current player to the other player
        public void ChangePlayer()
        {
            if (m_CurrentPlayer.PlayerId.Equals(ePlayers.PlayerOne))
            {
                m_CurrentPlayer = m_SecondPlayer;
            }
            else
            {
                m_CurrentPlayer = m_FirstPlayer;
            }
        }
    }
}
