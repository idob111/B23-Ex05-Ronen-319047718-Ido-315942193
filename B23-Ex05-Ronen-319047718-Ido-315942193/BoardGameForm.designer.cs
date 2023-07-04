
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using B23_Ex05_Ronen_319047718_Ido_315942193;
using CSharp_Ex2;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    partial class BoardGameForm
    {
        private Dictionary<Button, PointIndex> buttonPointIndexDictionary = new Dictionary<Button, PointIndex>();
        private const int k_ButtonWidth = 50;
        private const int k_ButtonHeight = 50;
        private const int k_ButtonMargin = 5;
        private const int k_LabelMargin = 30;

        private Label Player1NameLabel = new Label();
        private Label Player2NameLabel = new Label();

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(GameSettings i_settings)
        {
            this.SuspendLayout();
            // 
            // BoardGameForm
            // 
            this.Name = "BoardGameForm";
            this.ResumeLayout(false);
        }


        private void CreateButtonsTable(decimal i_Rows, decimal i_Cols)
        {
            for (int row = 0; row < i_Rows; row++)
            {
                for (int col = 0; col < i_Cols; col++)
                {
                    Button button = new Button();
                    button.Width = k_ButtonWidth;
                    button.Height = k_ButtonHeight;
                    button.Top = row * (k_ButtonHeight + k_ButtonMargin) + k_ButtonMargin;
                    button.Left = col * (k_ButtonWidth + k_ButtonMargin) + k_ButtonMargin;
                    button.Click += ButtonCell_Click;
                    button.TabStop = false;
                    buttonPointIndexDictionary.Add(button, new PointIndex(row, col));
                    Controls.Add(button);
                }
            }

            int formWidth = (int)i_Cols * (k_ButtonWidth + k_ButtonMargin) + k_ButtonMargin + 5;
            int formHeight = (int)i_Rows * (k_ButtonHeight + k_ButtonMargin) + k_ButtonMargin + k_LabelMargin + 5;
            this.ClientSize = new Size(formWidth, formHeight);
        }

        // TODO: from some reason, the labels added in the visual designer keep disappearing. need to find a way to keep them 
        // Until then we need to find some way to see the score tracker. this func DOESN'T work currently...
        private void CreateScoreTracking(GameSettings i_Settings)
        {
            Player1NameLabel.Text = string.Format("{0}: {1}", i_Settings.PlayerOneName, m_GameManager.PlayerOneScore());
            Player2NameLabel.Text = string.Format("{0}: {1}", i_Settings.PlayerTwoName, m_GameManager.PlayerTwoScore());

            int midScreenWidthIndex = this.ClientSize.Width / 2;
            int bothLabelLength = i_Settings.PlayerOneName.Length + i_Settings.PlayerTwoName.Length + 10;
            int firstWidthIndexOfLabels = midScreenWidthIndex - (bothLabelLength * 2);

            Player1NameLabel.Top = this.ClientSize.Height - 15;
            Player2NameLabel.Top = this.ClientSize.Height - 15;

            Player1NameLabel.Anchor = AnchorStyles.Bottom;
            Player2NameLabel.Anchor = AnchorStyles.Bottom;

            Player1NameLabel.Width = Player1NameLabel.Text.Length;
            Player2NameLabel.Width = Player2NameLabel.Text.Length;

            Player1NameLabel.AutoSize = true;
            Player2NameLabel.AutoSize = true;

            Player1NameLabel.Left = firstWidthIndexOfLabels;
            Player2NameLabel.Left = Player1NameLabel.Right + 30;

            Controls.Add(Player1NameLabel);
            Controls.Add(Player2NameLabel);


        }

        private void ButtonCell_Click(object sender, EventArgs e)
        {
            // Handle button click event
            Button clickedButton = sender as Button;
            if (sender != null)
            {
                clickedButton.Enabled = false;

                // Passes the button's row and col to play human turn
                m_GameManager.playHumanTurn(buttonPointIndexDictionary[clickedButton], clickedButton);
                if (m_GameManager.checkGameEnded())
                {
                    Controls.Clear();
                    CreateButtonsTable(m_Settings.NumberOfRows, m_Settings.NumberOfCols);
                    CreateScoreTracking(m_Settings);
                }
            }
        }

        #endregion
    }
}