
namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    partial class GameSettingForm
    {
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
            this.m_labelPlayersText = new System.Windows.Forms.Label();
            this.m_LabelPlayerOne = new System.Windows.Forms.Label();
            this.m_CheckBoxIsPlayingMode = new System.Windows.Forms.CheckBox();
            this.m_LabelPlayerTwo = new System.Windows.Forms.Label();
            this.m_TextBoxPlayerOne = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayerTwo = new System.Windows.Forms.TextBox();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_NumericUpDownRowsAmount = new System.Windows.Forms.NumericUpDown();
            this.m_NumericUpDownColsAmount = new System.Windows.Forms.NumericUpDown();
            this.m_LabelRows = new System.Windows.Forms.Label();
            this.m_LabelCols = new System.Windows.Forms.Label();
            this.m_ButtonStartGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRowsAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownColsAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // m_labelPlayersText
            // 
            this.m_labelPlayersText.AutoSize = true;
            this.m_labelPlayersText.Location = new System.Drawing.Point(11, 21);
            this.m_labelPlayersText.Name = "m_labelPlayersText";
            this.m_labelPlayersText.Size = new System.Drawing.Size(59, 17);
            this.m_labelPlayersText.TabIndex = 0;
            this.m_labelPlayersText.Text = "Players:";
            // 
            // m_LabelPlayerOne
            // 
            this.m_LabelPlayerOne.AutoSize = true;
            this.m_LabelPlayerOne.Location = new System.Drawing.Point(29, 53);
            this.m_LabelPlayerOne.Name = "m_LabelPlayerOne";
            this.m_LabelPlayerOne.Size = new System.Drawing.Size(64, 17);
            this.m_LabelPlayerOne.TabIndex = 1;
            this.m_LabelPlayerOne.Text = "Player 1:";
            // 
            // m_CheckBoxIsPlayingMode
            // 
            this.m_CheckBoxIsPlayingMode.AutoSize = true;
            this.m_CheckBoxIsPlayingMode.Location = new System.Drawing.Point(32, 87);
            this.m_CheckBoxIsPlayingMode.Name = "m_CheckBoxIsPlayingMode";
            this.m_CheckBoxIsPlayingMode.Size = new System.Drawing.Size(18, 17);
            this.m_CheckBoxIsPlayingMode.TabIndex = 2;
            this.m_CheckBoxIsPlayingMode.UseVisualStyleBackColor = true;
            this.m_CheckBoxIsPlayingMode.CheckedChanged += new System.EventHandler(this.CheckBoxIsPlayingMode_CheckedChanged);
            // 
            // m_LabelPlayerTwo
            // 
            this.m_LabelPlayerTwo.AutoSize = true;
            this.m_LabelPlayerTwo.Location = new System.Drawing.Point(56, 87);
            this.m_LabelPlayerTwo.Name = "m_LabelPlayerTwo";
            this.m_LabelPlayerTwo.Size = new System.Drawing.Size(64, 17);
            this.m_LabelPlayerTwo.TabIndex = 3;
            this.m_LabelPlayerTwo.Text = "Player 2:";
            // 
            // m_TextBoxPlayerOne
            // 
            this.m_TextBoxPlayerOne.Location = new System.Drawing.Point(148, 53);
            this.m_TextBoxPlayerOne.Name = "m_TextBoxPlayerOne";
            this.m_TextBoxPlayerOne.Size = new System.Drawing.Size(133, 22);
            this.m_TextBoxPlayerOne.TabIndex = 4;
            // 
            // m_TextBoxPlayerTwo
            // 
            this.m_TextBoxPlayerTwo.Enabled = false;
            this.m_TextBoxPlayerTwo.Location = new System.Drawing.Point(148, 87);
            this.m_TextBoxPlayerTwo.Name = "m_TextBoxPlayerTwo";
            this.m_TextBoxPlayerTwo.Size = new System.Drawing.Size(133, 22);
            this.m_TextBoxPlayerTwo.TabIndex = 5;
            this.m_TextBoxPlayerTwo.Text = "[Computer]";
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(14, 158);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(81, 17);
            this.m_LabelBoardSize.TabIndex = 6;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_LabelRow
            // 
            this.m_LabelRows.AutoSize = true;
            this.m_LabelRows.Location = new System.Drawing.Point(32, 194);
            this.m_LabelRows.Name = "m_LabelRow";
            this.m_LabelRows.Size = new System.Drawing.Size(46, 17);
            this.m_LabelRows.TabIndex = 7;
            this.m_LabelRows.Text = "Rows:";
            // 
            // m_numericUpDownRowsAmount
            // 
            this.m_NumericUpDownRowsAmount.Location = new System.Drawing.Point(84, 192);
            this.m_NumericUpDownRowsAmount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumericUpDownRowsAmount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_NumericUpDownRowsAmount.Name = "m_numericUpDownRowsAmount";
            this.m_NumericUpDownRowsAmount.Size = new System.Drawing.Size(45, 22);
            this.m_NumericUpDownRowsAmount.TabIndex = 8;
            this.m_NumericUpDownRowsAmount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_numericUpDownColsAmount
            // 
            this.m_NumericUpDownColsAmount.Location = new System.Drawing.Point(236, 192);
            this.m_NumericUpDownColsAmount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumericUpDownColsAmount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_NumericUpDownColsAmount.Name = "m_numericUpDownColsAmount";
            this.m_NumericUpDownColsAmount.Size = new System.Drawing.Size(45, 22);
            this.m_NumericUpDownColsAmount.TabIndex = 10;
            this.m_NumericUpDownColsAmount.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // m_LabelCols
            // 
            this.m_LabelCols.AutoSize = true;
            this.m_LabelCols.Location = new System.Drawing.Point(184, 194);
            this.m_LabelCols.Name = "m_LabelCols";
            this.m_LabelCols.Size = new System.Drawing.Size(39, 17);
            this.m_LabelCols.TabIndex = 9;
            this.m_LabelCols.Text = "Cols:";
            // 
            // m_ButtonStartGame
            // 
            this.m_ButtonStartGame.Location = new System.Drawing.Point(17, 256);
            this.m_ButtonStartGame.Name = "m_ButtonStartGame";
            this.m_ButtonStartGame.Size = new System.Drawing.Size(264, 36);
            this.m_ButtonStartGame.TabIndex = 11;
            this.m_ButtonStartGame.Text = "Start!";
            this.m_ButtonStartGame.UseVisualStyleBackColor = true;
            this.m_ButtonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // GameSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(296, 304);
            this.Controls.Add(this.m_ButtonStartGame);
            this.Controls.Add(this.m_NumericUpDownColsAmount);
            this.Controls.Add(this.m_LabelCols);
            this.Controls.Add(this.m_NumericUpDownRowsAmount);
            this.Controls.Add(this.m_LabelRows);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_TextBoxPlayerTwo);
            this.Controls.Add(this.m_TextBoxPlayerOne);
            this.Controls.Add(this.m_LabelPlayerTwo);
            this.Controls.Add(this.m_CheckBoxIsPlayingMode);
            this.Controls.Add(this.m_LabelPlayerOne);
            this.Controls.Add(this.m_labelPlayersText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRowsAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownColsAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_labelPlayersText;
        private System.Windows.Forms.Label m_LabelPlayerOne;
        private System.Windows.Forms.CheckBox m_CheckBoxIsPlayingMode;
        private System.Windows.Forms.Label m_LabelPlayerTwo;
        private System.Windows.Forms.TextBox m_TextBoxPlayerOne;
        private System.Windows.Forms.TextBox m_TextBoxPlayerTwo;
        private System.Windows.Forms.Label m_LabelBoardSize;
        private System.Windows.Forms.Label m_LabelRows;
        private System.Windows.Forms.NumericUpDown m_NumericUpDownRowsAmount;
        private System.Windows.Forms.NumericUpDown m_NumericUpDownColsAmount;
        private System.Windows.Forms.Label m_LabelCols;
        private System.Windows.Forms.Button m_ButtonStartGame;
    }
}

