
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
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
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

            int formMargin = 5;
            int formWidth = (int)i_Cols * (k_ButtonWidth + k_ButtonMargin) + k_ButtonMargin + formMargin;
            int formHeight = (int)i_Rows * (k_ButtonHeight + k_ButtonMargin) + k_ButtonMargin + k_LabelMargin + formMargin;
            this.ClientSize = new Size(formWidth, formHeight);
        }

        // TODO: from some reason, the labels added in the visual designer keep disappearing. need to find a way to keep them 
        // Until then we need to find some way to see the score tracker. this func DOESN'T work currently...
        private void CreateScoreTracking(GameSettings i_Settings)
        {
            setNameLabelProperties(Player1NameLabel, string.Format("{0}: {1}", i_Settings.PlayerOneName, m_GameManager.PlayerOneScore()));
            setNameLabelProperties(Player2NameLabel, string.Format("{0}: {1}", i_Settings.PlayerTwoName, m_GameManager.PlayerTwoScore()));

            int formMiddle = this.ClientSize.Width / 2;
            int labelSpacing = 20;
            int bothLabelsWidth = Player1NameLabel.Width + Player2NameLabel.Width + labelSpacing;
            int p1NameLabelLeftMargin = formMiddle - (bothLabelsWidth / 2);

            Player1NameLabel.Left = p1NameLabelLeftMargin;
            Player2NameLabel.Left = Player1NameLabel.Right + labelSpacing;

            Controls.Add(Player1NameLabel);
            Controls.Add(Player2NameLabel);
        }

        // Sets the given player's name label to the required properties
        private void setNameLabelProperties(Label i_Label, string i_LabelText)
        {
            i_Label.Text = i_LabelText;

            int bottomMargin = 15;
            i_Label.Top = this.ClientSize.Height - bottomMargin;

            i_Label.Anchor = AnchorStyles.Bottom;

            Size labelTextSize = TextRenderer.MeasureText(i_Label.Text, i_Label.Font);
            int labelWidthPadding = 10;
            int labelWidth = labelTextSize.Width + labelWidthPadding;

            i_Label.Size = new Size(labelWidth, labelTextSize.Height);
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

        // Highlights the current player
        public void changeHighlightedPlayer(ePlayers i_CurrPlayer)
        {
            switch (i_CurrPlayer)
            {
                case ePlayers.PlayerOne:
                    switchLabelBold(Player1NameLabel, Player2NameLabel);
                    break;
                case ePlayers.PlayerTwo:
                    switchLabelBold(Player2NameLabel, Player1NameLabel);
                    break;
            }
        }

        private void switchLabelBold(Label i_ToBold, Label i_ToRegular)
        {
            i_ToBold.Font = new Font(i_ToBold.Font, FontStyle.Bold);
            i_ToRegular.Font = new Font(i_ToRegular.Font, FontStyle.Regular);
        }

        #endregion
    }
}