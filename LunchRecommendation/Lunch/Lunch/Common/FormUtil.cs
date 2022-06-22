using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lunch.Common
{
    internal class FormUtil
    {
        public static void SwitchForm(Form currentForm, Form switchForm)
        {
            switchForm.Show();
            Program.ac.MainForm = switchForm;
            currentForm.Close();
        }
    }
}
