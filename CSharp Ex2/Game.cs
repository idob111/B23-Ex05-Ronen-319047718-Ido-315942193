﻿namespace CSharp_Ex2
{
    public class Game
    {
        private const string k_BoardFullMessage = "Board full. No Winners.";
        private readonly Player r_FirstPlayer = new Player(ePlayers.PlayerOne, 0, eCellType.Cross);

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
            m_CurrentPlayer = r_FirstPlayer;
            m_Board = null;
        }

        public int GetScoringByPlayerId(ePlayers i_PlayerId)
        {
            int score;
            if (i_PlayerId.Equals(ePlayers.PlayerOne))
            {
                score = r_FirstPlayer.Score;
            }
            else
            {
                score = m_SecondPlayer.Score;
            }
            return score;
        }


        // Initializes the game board and the players.
        public void InitGame(int i_BoardSize, bool i_IsGameAgainstPlayer)
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

            m_BoardSize = i_BoardSize;
            m_Board = new Board(i_BoardSize);
            switch (gameMode)
            {
                case eMode.Human:
                    m_SecondPlayer = new Player(ePlayers.PlayerTwo, 0, eCellType.Circle);
                    break;
                case eMode.Computer:
                    m_AiPlayer = new AiPlayer(ePlayers.PlayerTwo, 0, eCellType.Circle);
                    m_SecondPlayer = m_AiPlayer.PlayerData;
                    break;
            }
        }

        // Receive the index of the button pressed and update it in the logic game board
        public void HumanTurn(PointIndex i_PlayerMove)
        {
            updateBoardAndPlayers(i_PlayerMove);
            changePlayer();
        }

        // 1) Prints the current game board and prompts the player to make a move.
        // 2) Receives Player position input and validates it (valid location and valid string)
        //private PointIndex getCurrentPlayerMove()
        //{
        //    PointIndex playerMove;
        //    playerMove = m_CurrentPlayer.PlayTurn(m_Board, r_FirstPlayer, m_SecondPlayer);

        //    return playerMove;
        //}

        // Ai does it's move and updates it on the logical board
        public void aiTurn()
        {
            PointIndex playerMove = m_AiPlayer.PlayTurn(m_Board, m_BoardSize);
            updateBoardAndPlayers(playerMove);
            changePlayer();
        }

        // Updates the board and ends the game if the player lost. If player won then updates his score.
        private void updateBoardAndPlayers(PointIndex i_Cell)
        {
            m_Board.UpdateBoardCell(i_Cell, m_CurrentPlayer.PlayerId);
            m_GameEnded = isPlayerLost(i_Cell);

            if (m_GameEnded)
            {
                changePlayer();
                CurrentPlayer.Score++;
                m_EndingMessage = string.Format("{0} Won!", m_CurrentPlayer.ToString());
            }
        }

        // The algorithm responsible for checking if the player that did the current move lost.
        // Checks if a given Row/Column/Diagonal is full using the bucket arrays in Board.
        // If they are then checks if the given Row/Column/Diagonal is the same shape.
        // If so then returns true, false otherwise.
        private bool isPlayerLost(PointIndex i_Cell)
        {
            bool rowSameShpe = false, columnSameShape = false, topLeftBottomRightDiagonalSameShape = false, BottomLeftTopRightDiagonalSameShape = false;

            if (m_Board.OccupiedCellsInColumnBucket[i_Cell.Column] == m_BoardSize)
            {
                columnSameShape = m_Board.IsColumnSameShape(i_Cell.Column);
            }

            if (m_Board.OccupiedCellsInRowBucket[i_Cell.Row] == m_BoardSize)
            {
                rowSameShpe = m_Board.IsRowSameShape(i_Cell.Row);
            }

            if (i_Cell.Row == i_Cell.Column) // Check if the given point is on the top left to bottom right diagonal 
            {
                if (m_Board.OccupiedCellsInDiagonalBucketBucket[0] == m_BoardSize)
                {
                    topLeftBottomRightDiagonalSameShape = m_Board.IsDiagonalSameShape(eDiagonal.TopLeftToBottomRight);
                }
            }

            if (i_Cell.Row == (m_BoardSize - i_Cell.Column - 1)) // Check if the given point is on the bottom left to top right diagonal
            {
                if (m_Board.OccupiedCellsInDiagonalBucketBucket[1] == m_BoardSize)
                {
                    BottomLeftTopRightDiagonalSameShape = m_Board.IsDiagonalSameShape(eDiagonal.BottomLeftToTopRight);
                }
            }

            return rowSameShpe || columnSameShape || topLeftBottomRightDiagonalSameShape || BottomLeftTopRightDiagonalSameShape;
        }

        // Returns true or false based on if the game ended.
        private bool isGameEnded()
        {
            if (m_Board.TurnsLeft == 0 && !m_GameEnded) // If there are no moves and the game didn't end because someone won
            {
                m_GameEnded = true;
                m_EndingMessage = k_BoardFullMessage;
            }

            return m_GameEnded;
        }

        // Resets the game board and keeps the score as is
        public void ResetGame()
        {
            m_Board.ResetBoard();
            m_GameEnded = false;
            m_CurrentPlayer = r_FirstPlayer;
        }

        // Changes the current player to the other player
        private void changePlayer()
        {
            if (m_CurrentPlayer.PlayerId.Equals(ePlayers.PlayerOne))
            {
                m_CurrentPlayer = m_SecondPlayer;
            }
            else
            {
                m_CurrentPlayer = r_FirstPlayer;
            }
        }
    }
}
