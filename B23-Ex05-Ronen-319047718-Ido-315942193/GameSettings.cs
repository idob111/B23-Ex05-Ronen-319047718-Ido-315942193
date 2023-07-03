using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    public class GameSettings
    {
        private readonly string m_PlayerOneName;
        private readonly string m_PlayerTwoName;
        private readonly decimal m_NumberOfRows;
        private readonly decimal m_NumberOfCols;
        private readonly bool m_IsModeAgainstPlayer;

        public GameSettings(string i_PlayerOneName, string i_PlayerTwoName, decimal i_NumberOfRows, decimal i_NumberOfCols, bool i_IsModeAgainstPlayer)
        {
            m_PlayerOneName = i_PlayerOneName;
            m_PlayerTwoName = i_PlayerTwoName;
            m_NumberOfRows = i_NumberOfRows;
            m_NumberOfCols = i_NumberOfCols;
            m_IsModeAgainstPlayer = i_IsModeAgainstPlayer;
        }

        public string PlayerOneName => m_PlayerOneName;

        public string PlayerTwoName => m_PlayerTwoName;

        public decimal NumberOfRows => m_NumberOfRows;

        public decimal NumberOfCols => m_NumberOfCols;

        public bool IsModeAgainstPlayer => m_IsModeAgainstPlayer;

    }
}
