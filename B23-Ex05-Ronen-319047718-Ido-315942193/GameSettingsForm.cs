using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    public partial class GameSettingForm : Form
    {
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
            m_GameSettings = new GameSettings(m_TextBoxPlayerOne.Text,
                m_TextBoxPlayerTwo.Text, m_NumericUpDownRowsAmount.Value,
                m_NumericUpDownColsAmount.Value,
                m_CheckBoxIsPlayingMode.Checked);

            this.Dispose();
        }
    }
}
