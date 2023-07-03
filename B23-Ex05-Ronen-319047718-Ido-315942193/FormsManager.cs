using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B23_Ex02_Ronen_319047718_Ido_315942193
{
    public static class FormsManager
    {
        public static void Run()
        {
            GameSettings settings;
            do
            {
                GameSettingForm gameSettingsForm = new GameSettingForm();
                Application.Run(gameSettingsForm);
                settings = gameSettingsForm.Settings;
                try
                {
                    if (settings == null)
                    {
                        Environment.Exit(0);
                    }
                    validateSettings(settings);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Input error", MessageBoxButtons.OK);
                    settings = null;
                }
            } while (settings == null);
            BoardGameForm boardGameForm = new BoardGameForm(settings);
            boardGameForm.runBoard();
            

        }

        private static void validateSettings(GameSettings i_Settings)
        {
            string k_NoPlayerNameMsg = "Player name cannot be empty";
            if (i_Settings.PlayerOneName == string.Empty)
            {
                throw new FormatException(k_NoPlayerNameMsg);
            }

            if (!playerTwoHasName(i_Settings))
            {
                throw new FormatException(k_NoPlayerNameMsg);
            }

            if (i_Settings.NumberOfRows != i_Settings.NumberOfCols)
            {
                throw new ArgumentException("Number of rows must match number of cols");
            }
        }

        private static bool playerTwoHasName(GameSettings i_Settings)
        {
            return (i_Settings.IsModeAgainstPlayer && (i_Settings.PlayerTwoName != string.Empty));
        }
    }
}
