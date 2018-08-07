/*
 * From http://wpfmessagebox.codeplex.com/
 */

using System.Windows;
using System.Windows.Controls;

namespace NewsGator.Install.Resources.WpfMessageBox
{   
    public class WpfMessageBoxControl : Control
    {
        static WpfMessageBoxControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WpfMessageBoxControl), new FrameworkPropertyMetadata(typeof(WpfMessageBoxControl)));            
        }
    }
}
