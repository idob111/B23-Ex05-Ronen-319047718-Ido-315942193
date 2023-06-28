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

        private static bool validateSettings(GameSettings i_Settings)
        {
            bool isValid = true;
            if (i_Settings.PlayerOneName == "")
                isValid = false;
            if (!i_Settings.IsModeAgainstComputer && i_Settings.PlayerTwoName == "")
                isValid = false;
            if (i_Settings.NumberOfRows != i_Settings.NumberOfCols)
                isValid = false;
            return isValid;
        }
    }
}
