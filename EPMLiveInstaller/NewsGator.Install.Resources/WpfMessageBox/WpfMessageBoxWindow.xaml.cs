using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsGator.Install.Resources.WpfMessageBox
{
    /// <summary>
    /// Interaction logic for WpfMessageBoxWindow.xaml
    /// </summary>
    public partial class WpfMessageBoxWindow : Window
    {

        public WpfMessageBoxWindow()
        {
            InitializeComponent();
        }

        private MessageBoxViewModel _viewModel;

        public static MessageBoxResult Show(
            Action<Window> setOwner,
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon,
            MessageBoxResult defaultResult,
            MessageBoxOptions options)
        {
            if ((options & MessageBoxOptions.DefaultDesktopOnly) == MessageBoxOptions.DefaultDesktopOnly)
            {
                throw new NotImplementedException();
            }

            if ((options & MessageBoxOptions.ServiceNotification) == MessageBoxOptions.ServiceNotification)
            {
                throw new NotImplementedException();
            }

            _messageBoxWindow = new WpfMessageBoxWindow();

            if (setOwner != null)
                setOwner(_messageBoxWindow);

            PlayMessageBeep(icon);

            _messageBoxWindow._viewModel = new MessageBoxViewModel(_messageBoxWindow, caption, messageBoxText, button, icon, defaultResult, options);
            _messageBoxWindow.DataContext = _messageBoxWindow._viewModel;
            _messageBoxWindow.ShowDialog();
            return _messageBoxWindow._viewModel.Result;
        }

        private static void PlayMessageBeep(MessageBoxImage icon)
        {
            switch (icon)
            {
                //case MessageBoxImage.Hand:
                //case MessageBoxImage.Stop:
                case MessageBoxImage.Error:
                    SystemSounds.Hand.Play();
                    break;

                //case MessageBoxImage.Exclamation:
                case MessageBoxImage.Warning:
                    SystemSounds.Exclamation.Play();
                    break;

                case MessageBoxImage.Question:
                    SystemSounds.Question.Play();
                    break;

                //case MessageBoxImage.Asterisk:
                case MessageBoxImage.Information:
                    SystemSounds.Asterisk.Play();
                    break;

                default:
                    SystemSounds.Beep.Play();
                    break;
            }
        }

        [ThreadStatic]
        private static WpfMessageBoxWindow _messageBoxWindow;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _viewModel.EscapeCommand.Execute(null);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _viewModel.CloseCommand.Execute(null);
        }

        #region Window Styling
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private const Int32 WM_SYSCOMMAND = 0x112;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private static readonly TimeSpan s_doubleClick = TimeSpan.FromMilliseconds(500);

        private HwndSource m_hwndSource;

        protected override void OnInitialized(EventArgs e)
        {
            AllowsTransparency = false;
            ResizeMode = ResizeMode.NoResize;
            Height = 480;
            Width = 640;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;

            SourceInitialized += HandleSourceInitialized;

            base.OnInitialized(e);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
        private void HandleSourceInitialized(Object sender, EventArgs e)
        {
            m_hwndSource = (HwndSource)PresentationSource.FromVisual(this);

            HwndSource.FromHwnd(m_hwndSource.Handle).AddHook(
                new HwndSourceHook(NativeMethods.WindowProc));

            Int32 DWMWA_NCRENDERING_POLICY = 2;
            NativeMethods.DwmSetWindowAttribute(
                m_hwndSource.Handle,
                DWMWA_NCRENDERING_POLICY,
                ref DWMWA_NCRENDERING_POLICY,
                4);

            NativeMethods.ShowShadowUnderWindow(m_hwndSource.Handle);
        }

        private sealed class NativeMethods
        {
            [DllImport("dwmapi.dll", PreserveSig = true)]
            internal static extern Int32 DwmSetWindowAttribute(
                IntPtr hwnd,
                Int32 attr,
                ref Int32 attrValue,
                Int32 attrSize);

            [DllImport("dwmapi.dll")]
            internal static extern Int32 DwmExtendFrameIntoClientArea(
                IntPtr hWnd,
                ref MARGINS pMarInset);

            [DllImport("user32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern Boolean GetMonitorInfo(
                IntPtr hMonitor,
                MONITORINFO lpmi);

            [DllImport("User32")]
            internal static extern IntPtr MonitorFromWindow(
                IntPtr handle,
                Int32 flags);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern IntPtr SendMessage(
                IntPtr hWnd,
                UInt32 msg,
                IntPtr wParam,
                IntPtr lParam);

            [DebuggerStepThrough]
            internal static IntPtr WindowProc(
                IntPtr hwnd,
                Int32 msg,
                IntPtr wParam,
                IntPtr lParam,
                ref Boolean handled)
            {
                switch (msg)
                {
                    case 0x0024:
                        WmGetMinMaxInfo(hwnd, lParam);
                        handled = true;
                        break;
                }

                return (IntPtr)0;
            }

            internal static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
            {
                MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

                Int32 MONITOR_DEFAULTTONEAREST = 0x00000002;

                IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
                if (monitor != IntPtr.Zero)
                {
                    MONITORINFO monitorInfo = new MONITORINFO();
                    GetMonitorInfo(monitor, monitorInfo);

                    RECT rcWorkArea = monitorInfo.m_rcWork;
                    RECT rcMonitorArea = monitorInfo.m_rcMonitor;

                    mmi.m_ptMaxPosition.m_x = Math.Abs(rcWorkArea.m_left - rcMonitorArea.m_left);
                    mmi.m_ptMaxPosition.m_y = Math.Abs(rcWorkArea.m_top - rcMonitorArea.m_top);

                    mmi.m_ptMaxSize.m_x = Math.Abs(rcWorkArea.m_right - rcWorkArea.m_left);
                    mmi.m_ptMaxSize.m_y = Math.Abs(rcWorkArea.m_bottom - rcWorkArea.m_top);
                }

                Marshal.StructureToPtr(mmi, lParam, true);
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
            internal static void ShowShadowUnderWindow(IntPtr intPtr)
            {
                MARGINS marInset = new MARGINS();
                marInset.m_bottomHeight = -1;
                marInset.m_leftWidth = -1;
                marInset.m_rightWidth = -1;
                marInset.m_topHeight = -1;

                DwmExtendFrameIntoClientArea(intPtr, ref marInset);
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            internal sealed class MONITORINFO
            {
                public Int32 m_cbSize;
                public RECT m_rcMonitor;
                public RECT m_rcWork;
                public Int32 m_dwFlags;

                public MONITORINFO()
                {
                    m_cbSize = Marshal.SizeOf(typeof(MONITORINFO));
                    m_rcMonitor = new RECT();
                    m_rcWork = new RECT();
                    m_dwFlags = 0;
                }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 0)]
            internal struct RECT
            {
                public static readonly RECT Empty = new RECT();

                public Int32 m_left;
                public Int32 m_top;
                public Int32 m_right;
                public Int32 m_bottom;

                public RECT(Int32 left, Int32 top, Int32 right, Int32 bottom)
                {
                    m_left = left;
                    m_top = top;
                    m_right = right;
                    m_bottom = bottom;
                }

                public RECT(RECT rcSrc)
                {
                    m_left = rcSrc.m_left;
                    m_top = rcSrc.m_top;
                    m_right = rcSrc.m_right;
                    m_bottom = rcSrc.m_bottom;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct MARGINS
            {
                public Int32 m_leftWidth;
                public Int32 m_rightWidth;
                public Int32 m_topHeight;
                public Int32 m_bottomHeight;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public Int32 m_x;
                public Int32 m_y;

                public POINT(Int32 x, Int32 y)
                {
                    m_x = x;
                    m_y = y;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct MINMAXINFO
            {
                public POINT m_ptReserved;
                public POINT m_ptMaxSize;
                public POINT m_ptMaxPosition;
                public POINT m_ptMinTrackSize;
                public POINT m_ptMaxTrackSize;
            };
        }

        #endregion
    }
}
