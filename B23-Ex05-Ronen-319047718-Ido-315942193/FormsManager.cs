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

        //Validate the setting we got from user are valid
        private static void validateSettings(GameSettings i_Settings)
        {
            string k_NoPlayerNameMsg = "Player name cannot be empty";
            if (!playerHasName(i_Settings.PlayerOneName))
            {
                throw new FormatException(k_NoPlayerNameMsg);
            }

            if (i_Settings.IsModeAgainstPlayer && !playerHasName(i_Settings.PlayerTwoName))
            {
                throw new FormatException(k_NoPlayerNameMsg);
            }

            if (i_Settings.NumberOfRows != i_Settings.NumberOfCols)
            {
                throw new ArgumentException("Number of rows must match number of cols");
            }
        }

        //check if given player has name
        private static bool playerHasName(string i_PlayerName)
        {
            return i_PlayerName != string.Empty;
        }
    }
}
