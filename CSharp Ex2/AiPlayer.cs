using System;
using System.Drawing;

namespace GameLogic
{
    public class AiPlayer
    {
        private Player m_AiPlayer;
        private const string k_AiName = "Computer";

        public AiPlayer(ePlayers i_PlayerId, int i_Score)
        {
            m_AiPlayer = new Player(i_PlayerId, i_Score, k_AiName);
        }

        public Player PlayerData
        {
            get
            {
                return m_AiPlayer;
            }

            set
            {
                m_AiPlayer = value;
            }
        }

        // Randomize the computer turn
        public Point PlayTurn(Board i_GameBoard, int i_BoardSize)
        {
            Point aiMove = new Point();
            do
            {
                Random random = new Random();
                aiMove.X = random.Next(0, i_BoardSize);
                aiMove.Y = random.Next(0, i_BoardSize);
            }
            while (!i_GameBoard.IsCellEmpty(aiMove));

            return aiMove;
        }
    }
}
