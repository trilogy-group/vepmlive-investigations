using System;
using System.Web.UI;

namespace EPMLiveCore
{
    public static class ControlExtensions
    {
        public static Control FindControlRecursive(this Control control, Func<Control, bool> evaluate)
        {
            if (evaluate.Invoke(control))
            {
                return control;
            }

            foreach (Control childControl in control.Controls)
            {
                Control foundControl = FindControlRecursive(childControl, evaluate);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }

            return null;
        }
    }
}