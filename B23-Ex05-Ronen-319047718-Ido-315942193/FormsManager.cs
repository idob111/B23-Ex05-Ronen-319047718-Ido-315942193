using System;
using System.Windows.Forms;

namespace GameDesign
{
    public static class FormsManager
    {
        public static void Run()
        {
            GameSettingForm gameSettingsForm = new GameSettingForm();
            Application.Run(gameSettingsForm);
            GameSettings settings = gameSettingsForm.Settings;
            if (settings != null)
            {
                if (validateSettings(settings))
                {
                    Application.Run(new BoardGameForm(settings));
                }
                else 
                {
                    throw new FormatException("Insert Invalid Parameter");
                }
            }
        }

        // Returns that all of the user's selected setting are valid (all users have a name and number of rows and cols is matching)
        private static bool validateSettings(GameSettings i_Settings)
        {
            bool isValid = true;

            if (i_Settings.PlayerOneName.Equals(string.Empty))
            {
                isValid = false;
            }

            if (!i_Settings.IsModeAgainstPlayer && i_Settings.PlayerTwoName.Equals(string.Empty))
            {
                isValid = false;
            }

            if (i_Settings.NumberOfRows != i_Settings.NumberOfCols)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
