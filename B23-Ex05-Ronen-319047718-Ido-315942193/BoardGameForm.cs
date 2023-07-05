using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameLogic;

namespace GameDesign
{
    public partial class BoardGameForm : Form
    {
        private readonly GameManager r_GameManager;
        private GameSettings m_Settings;
        public BoardGameForm(GameSettings i_Settings)
        {
            m_Settings = i_Settings;
            InitializeComponent();
            r_GameManager = new GameManager(m_Settings, this);
            FormClosing += BoardGameForm_FormClosing;
            CreateButtonsTable(m_Settings.NumberOfRows, m_Settings.NumberOfCols);
            CreateScoreTracking();
        }

        private void ButtonCell_Click(object sender, EventArgs e)
        {
            // Handle button click event
            Button clickedButton = sender as Button;
            if (sender != null)
            {
                // Passes the button's row and col to play human turn
                r_GameManager.playHumanTurn(buttonToPointDictionary[clickedButton], clickedButton);
            }
        }

        // Receives a point and returns the corresponding button
        public Button ConvertPointToButton(Point i_PointToButton)
        {
            return buttonToPointDictionary.FirstOrDefault(x => x.Value.Equals(i_PointToButton)).Key; ;
        }

        // Resets the form board 
        public void HandleEndGame()
        {
            Controls.Clear();
            buttonToPointDictionary.Clear();
            CreateButtonsTable(m_Settings.NumberOfRows, m_Settings.NumberOfCols);
            changeHighlightedPlayer(ePlayers.PlayerOne);
            CreateScoreTracking();
        }

        // Shows MessageBox asking user if he is sure he wants to quit
        private void BoardGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }

    
}
