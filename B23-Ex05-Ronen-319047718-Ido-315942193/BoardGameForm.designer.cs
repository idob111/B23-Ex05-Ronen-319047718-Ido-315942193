
using System;
using System.Drawing;
using System.Windows.Forms;
using B23_Ex05_Ronen_319047718_Ido_315942193;
using CSharp_Ex2;

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
            this.SuspendLayout();
            // 
            // BoardGameForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BoardGameForm";
            this.Load += new System.EventHandler(this.BoardGameForm_Load);
            this.ResumeLayout(false);

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

            GameManager.playTurn();
        }

        #endregion

        private Label Player1NameLabel;
        private Label Player2NameLabel;
    }
}