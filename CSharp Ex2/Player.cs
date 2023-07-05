namespace GameLogic
{
    public enum ePlayers
    {
        PlayerOne,
        PlayerTwo
    }

    public class Player
    {
        private ePlayers m_PlayerId;
        private int m_Score;
        private string m_Name;

        public string Name => m_Name;

        public Player(ePlayers i_PlayerId, int i_Score, string i_Name)
        {
            m_PlayerId = i_PlayerId;
            m_Score = i_Score;
            m_Name = i_Name;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public ePlayers PlayerId
        {
            get
            {
                return m_PlayerId;
            }

            set
            {
                m_PlayerId = value;
            }
        }
    }
}
