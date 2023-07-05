using System;
using System.Windows.Forms;

namespace GameDesign
{
    public partial class GameSettingForm : Form
    {
        private const string k_AiName = "Computer";
        GameSettings m_GameSettings = null;
        public GameSettings Settings { get => m_GameSettings; }

        public GameSettingForm()
        {
            InitializeComponent();
            FormClosing += GameSettingForm_FormClosing;
        }

        private void CheckBoxIsPlayingMode_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                m_TextBoxPlayerTwo.Text = "";
                m_TextBoxPlayerTwo.Enabled = true;
            }
            else
            {
                m_TextBoxPlayerTwo.Text = "[Computer]";
                m_TextBoxPlayerTwo.Enabled = false;
            }
        }

        // Shows MessageBox asking user if he is sure he wants to quit
        private void GameSettingForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            if (!m_CheckBoxIsPlayingMode.Checked)
            {
                m_TextBoxPlayerTwo.Text = k_AiName;
            }

            m_GameSettings = new GameSettings(m_TextBoxPlayerOne.Text,
                m_TextBoxPlayerTwo.Text, m_NumericUpDownRowsAmount.Value,
                m_NumericUpDownColsAmount.Value,
                m_CheckBoxIsPlayingMode.Checked);

            this.Dispose();
        }
    }
}
