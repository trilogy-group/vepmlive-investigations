using System;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for ClosePubWindow.
	/// </summary>
	public class ClosePubWindow
	{

		public class WindowApi
		{
			[DllImport("user32.dll")] 
			public static extern IntPtr FindWindow(string strclassName, string strWindowName);

			[DllImport("user32.dll")]
			public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

			[DllImport("user32.dll", EntryPoint="FindWindowExW",  SetLastError=true, CharSet=CharSet.Unicode)]
			public static extern IntPtr FindWindowEx( IntPtr Ph,IntPtr Ch, IntPtr Ph1,String lpWindowName);

			[DllImport("user32.dll")]
			public static extern bool IsWindowEnabled(IntPtr hWnd);

		};

		public ClosePubWindow()
		{
			
		}

		public void closeWindow()
		{
			IntPtr hwnd = WindowApi.FindWindow("JWinproj-MLSDialog",null);
			// ptrChild = GetWindow(hwnd, GW_CHILD);
			if (!hwnd.Equals(IntPtr.Zero))
			{
				IntPtr ptrChild = WindowApi.FindWindowEx(hwnd,IntPtr.Zero,IntPtr.Zero,"&Do not create a site at this time");
				if (!ptrChild.Equals(IntPtr.Zero))
				{
					if(WindowApi.IsWindowEnabled(ptrChild))
					{
						WindowApi.SendMessage(ptrChild, 0x0201, IntPtr.Zero, IntPtr.Zero); 
						WindowApi.SendMessage(ptrChild, 0x0202, IntPtr.Zero, IntPtr.Zero); 
						WindowApi.SendMessage(ptrChild, 0x00F3, IntPtr.Zero, IntPtr.Zero); 

						ptrChild = WindowApi.FindWindowEx(hwnd,IntPtr.Zero,IntPtr.Zero,"&Publish");

						if (!ptrChild.Equals(IntPtr.Zero))
						{
							WindowApi.SendMessage(ptrChild, 0x0201, IntPtr.Zero, IntPtr.Zero); 
							WindowApi.SendMessage(ptrChild, 0x0202, IntPtr.Zero, IntPtr.Zero); 
							WindowApi.SendMessage(ptrChild, 0x00F3, IntPtr.Zero, IntPtr.Zero); 
						}

					}
				}
			}
		}
	}
}
