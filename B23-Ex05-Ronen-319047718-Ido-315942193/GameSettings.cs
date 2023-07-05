namespace GameDesign
{
    public class GameSettings
    {
        private readonly string m_PlayerOneName;
        private readonly string m_PlayerTwoName;
        private readonly decimal m_NumberOfRows;
        private readonly decimal m_NumberOfCols;
        private readonly bool _mIsModeAgainstPlayer;

        public GameSettings(string i_PlayerOneName, string i_PlayerTwoName, decimal i_NumberOfRows, decimal i_NumberOfCols, bool iIsModeAgainstPlayer)
        {
            m_PlayerOneName = i_PlayerOneName;
            m_PlayerTwoName = i_PlayerTwoName;
            m_NumberOfRows = i_NumberOfRows;
            m_NumberOfCols = i_NumberOfCols;
            _mIsModeAgainstPlayer = iIsModeAgainstPlayer;
        }

        public string PlayerOneName => m_PlayerOneName;

        public string PlayerTwoName => m_PlayerTwoName;

        public decimal NumberOfRows => m_NumberOfRows;

        public decimal NumberOfCols => m_NumberOfCols;

        public bool IsModeAgainstPlayer => _mIsModeAgainstPlayer;
    }
}
