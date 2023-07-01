using System;
using System.Drawing;
using System.Windows.Forms;
using B23_Ex05_Ronen_319047718_Ido_315942193;
using CSharp_Ex2;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    public partial class BoardGameForm : Form
    {

        public BoardGameForm(GameSettings i_Settings)
        {
            
            InitializeComponent(i_Settings);
            CreateButtonsTable(i_Settings.NumberOfRows, i_Settings.NumberOfCols);
            GameManager.InitGame(i_Settings);
        }

        private void BoardGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
