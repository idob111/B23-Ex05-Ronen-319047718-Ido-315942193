
using System;
using System.Drawing;
using System.Windows.Forms;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    partial class BoardGameForm
    {


        private const int ButtonWidth = 50;
        private const int ButtonHeight = 50;
        private const int ButtonMargin = 5;

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
            this.Player1NameLabel = new System.Windows.Forms.Label();
            this.Player2NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.Player1NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player1NameLabel.AutoSize = true;
            this.Player1NameLabel.Location = new System.Drawing.Point(92, 203);
            this.Player1NameLabel.Name = "Player1NameLabel";
            this.Player1NameLabel.Size = new System.Drawing.Size(64, 17);
            this.Player1NameLabel.TabIndex = 0;
            this.Player1NameLabel.Text = "Player1: ";
            this.Player1NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player3NameLabel
            // 
            this.Player2NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player2NameLabel.AutoSize = true;
            this.Player2NameLabel.Location = new System.Drawing.Point(165, 203);
            this.Player2NameLabel.Name = "Player2NameLabel";
            this.Player2NameLabel.Size = new System.Drawing.Size(64, 17);
            this.Player2NameLabel.TabIndex = 1;
            this.Player2NameLabel.Text = "Player2: ";
            this.Player2NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoardGameForm
            // 
            this.ClientSize = new System.Drawing.Size(311, 246);
            this.Controls.Add(this.Player2NameLabel);
            this.Controls.Add(this.Player1NameLabel);
            this.Name = "BoardGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void CreateButtonsTable(decimal i_Rows, decimal i_Cols)
        {
            for (int row = 0; row < i_Rows; row++)
            {
                for (int col = 0; col < i_Cols; col++)
                {
                    Button button = new Button();
                    button.Width = ButtonWidth;
                    button.Height = ButtonHeight;
                    button.Top = row * (ButtonHeight + ButtonMargin) + ButtonMargin;
                    button.Left = col * (ButtonWidth + ButtonMargin) + ButtonMargin;
                    button.Click += ButtonCell_Click;

                    Controls.Add(button);
                }
            }

            int formWidth = (int)i_Cols * (ButtonWidth + ButtonMargin) + ButtonMargin;
            int formHeight = (int)i_Rows * (ButtonHeight + ButtonMargin) + ButtonMargin;
            this.ClientSize = new Size(formWidth, formHeight);
        }

        private void ButtonCell_Click(object sender, EventArgs e)
        {
            // Handle button click event
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            clickedButton.Text = "X";
        }

        #endregion

        private Label Player1NameLabel;
        private Label Player2NameLabel;
    }
}