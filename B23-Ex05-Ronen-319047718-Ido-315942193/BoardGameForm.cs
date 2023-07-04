using System;
using System.Drawing;
using System.Windows.Forms;
using B23_Ex05_Ronen_319047718_Ido_315942193;
using CSharp_Ex2;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    public partial class BoardGameForm : Form
    {
        private GameManager m_GameManager;
        private GameSettings m_Settings;

        public BoardGameForm(GameSettings i_Settings)
        {
            m_Settings = i_Settings;
            m_GameManager = new GameManager(i_Settings);

        }

        public void runBoard()
        {
            InitializeComponent(m_Settings);
            CreateButtonsTable(m_Settings.NumberOfRows, m_Settings.NumberOfCols);
            CreateScoreTracking(m_Settings);
            Application.Run(this);
        }

    }
}
