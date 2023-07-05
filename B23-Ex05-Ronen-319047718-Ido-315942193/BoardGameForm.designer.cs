using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameDesign;
using GameLogic;

namespace GameDesign
{
    partial class BoardGameForm
    {
        private Dictionary<Button, Point> buttonToPointDictionary = new Dictionary<Button, Point>();

        private const int k_ButtonWidth = 50;
        private const int k_ButtonHeight = 50;
        private const int k_ButtonMargin = 5;
        private const int k_LabelMargin = 30;
        private const int k_LabelSpacing = 20;
        private const int k_FormMargin = 5;
        private const int k_BottomMargin = 15;
        private const int k_LabelWidthPadding = 10;

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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoardGameForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "BoardGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        private void CreateButtonsTable(decimal i_Rows, decimal i_Cols)
        {
            for (int row = 0; row < i_Rows; row++)
            {
                for (int col = 0; col < i_Cols; col++)
                {
                    Button button = new Button();
                    Point buttonIndex = new Point(row, col);
                    button.Width = k_ButtonWidth;
                    button.Height = k_ButtonHeight;
                    button.Top = row * (k_ButtonHeight + k_ButtonMargin) + k_ButtonMargin;
                    button.Left = col * (k_ButtonWidth + k_ButtonMargin) + k_ButtonMargin;
                    button.Click += ButtonCell_Click;
                    button.TabStop = false;
                    buttonToPointDictionary.Add(button, buttonIndex);
                    Controls.Add(button);
                }
            }

            int formWidth = (int)i_Cols * (k_ButtonWidth + k_ButtonMargin) + k_ButtonMargin + k_FormMargin;
            int formHeight = (int)i_Rows * (k_ButtonHeight + k_ButtonMargin) + k_ButtonMargin + k_LabelMargin + k_FormMargin;
            this.ClientSize = new Size(formWidth, formHeight);
        }

        // Creates the labels with the score tracking and positions on the bottom center of the board
        private void CreateScoreTracking()
        {
            setNameLabelProperties(Player1NameLabel, string.Format("{0}: {1}", m_Settings.PlayerOneName, r_GameManager.PlayerOneScore()));
            setNameLabelProperties(Player2NameLabel, string.Format("{0}: {1}", m_Settings.PlayerTwoName, r_GameManager.PlayerTwoScore()));

            int formMiddle = this.ClientSize.Width / 2;
            
            int bothLabelsWidth = Player1NameLabel.Width + Player2NameLabel.Width + k_LabelSpacing;
            int p1NameLabelLeftMargin = formMiddle - (bothLabelsWidth / 2);

            Player1NameLabel.Left = p1NameLabelLeftMargin;
            Player2NameLabel.Left = Player1NameLabel.Right + k_LabelSpacing;

            Controls.Add(Player1NameLabel);
            Controls.Add(Player2NameLabel);
        }

        // Sets the given player's name label to the required properties
        private void setNameLabelProperties(Label i_Label, string i_LabelText)
        {
            i_Label.Text = i_LabelText;
            i_Label.Top = this.ClientSize.Height - k_BottomMargin;
            i_Label.Anchor = AnchorStyles.Bottom;
            Size labelTextSize = TextRenderer.MeasureText(i_Label.Text, i_Label.Font);
            int labelWidth = labelTextSize.Width + k_LabelWidthPadding;
            i_Label.Size = new Size(labelWidth, labelTextSize.Height);
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