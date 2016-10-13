using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

#region Public MapiMailMessage Class

/// <summary>
/// Represents an email message to be sent through MAPI.
/// </summary>
public class MapiMailMessage
{
	#region Private MapiFileDescriptor Class

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	private class MapiFileDescriptor
	{
		public int reserved = 0;
		public int flags = 0;
		public int position = 0;
		public string path = null;
		public string name = null;
		public IntPtr type = IntPtr.Zero;
	}

	#endregion Private MapiFileDescriptor Class

	#region Enums

	/// <summary>
	/// Specifies the valid RecipientTypes for a Recipient.
	/// </summary>
	public enum RecipientType : int
	{
		/// <summary>
		/// Recipient will be in the TO list.
		/// </summary>
		To = 1,

		/// <summary>
		/// Recipient will be in the CC list.
		/// </summary>
		CC = 2,

		/// <summary>
		/// Recipient will be in the BCC list.
		/// </summary>
		BCC = 3
	};

	#endregion Enums

	private string subject;
	private string body;
	private RecipientCollection recipientCollection;
	private ArrayList _files;
	private ManualResetEvent _manualResetEvent;

	public MapiMailMessage(string subject, string body)
	{
		this.subject = subject;
		this.body = body;
		_files = new ArrayList();
		this.recipientCollection = new RecipientCollection();
		_manualResetEvent = new ManualResetEvent(false);
	}
	public RecipientCollection Recipients
	{
		get { return recipientCollection; }
	}

	public ArrayList Files
	{
		get { return _files; }
	}

	#region Public Methods


	public void ShowDialog()
	{
		MAPIHelperInterop.MapiMessage message = new MAPIHelperInterop.MapiMessage();

		using (RecipientCollection.InteropRecipientCollection interopRecipients
				   = recipientCollection.GetInteropRepresentation())
		{

			message.Subject = subject;
			message.NoteText = body;

			message.Recipients = interopRecipients.Handle;
			message.RecipientCount = recipientCollection.Count;

			// Check if we need to add attachments
			if (_files.Count > 0)
			{
				// Add attachments
				message.Files = _AllocAttachments(out message.FileCount);
			}

			// Signal the creating thread (make the remaining code async)
			_manualResetEvent.Set();

			const int MAPI_DIALOG = 0x8;
			//const int MAPI_LOGON_UI = 0x1;
			const int SUCCESS_SUCCESS = 0;
			int error = MAPIHelperInterop.MAPISendMail(IntPtr.Zero, IntPtr.Zero, message, MAPI_DIALOG, 0);

			if (_files.Count > 0)
			{
				// Deallocate the files
				_DeallocFiles(message);
			}

			// Check for error
			if (error != SUCCESS_SUCCESS)
			{
				_LogErrorMapi(error);
			}
		}
		_manualResetEvent.WaitOne();
		_manualResetEvent.Reset();
	}

	#endregion Public Methods

	#region Private Methods
	/// <summary>
	/// Deallocates the files in a message.
	/// </summary>
	/// <param name="message">The message to deallocate the files from.</param>
	private void _DeallocFiles(MAPIHelperInterop.MapiMessage message)
	{
		if (message.Files != IntPtr.Zero)
		{
			Type fileDescType = typeof(MapiFileDescriptor);
			int fsize = Marshal.SizeOf(fileDescType);

			// Get the ptr to the files
			int runptr = (int)message.Files;
			// Release each file
			for (int i = 0; i < message.FileCount; i++)
			{
				Marshal.DestroyStructure((IntPtr)runptr, fileDescType);
				runptr += fsize;
			}
			// Release the file
			Marshal.FreeHGlobal(message.Files);
		}
	}

	/// <summary>
	/// Allocates the file attachments
	/// </summary>
	/// <param name="fileCount"></param>
	/// <returns></returns>
	private IntPtr _AllocAttachments(out int fileCount)
	{
		fileCount = 0;
		if (_files == null)
		{
			return IntPtr.Zero;
		}
		if ((_files.Count <= 0) || (_files.Count > 100))
		{
			return IntPtr.Zero;
		}

		Type atype = typeof(MapiFileDescriptor);
		int asize = Marshal.SizeOf(atype);
		IntPtr ptra = Marshal.AllocHGlobal(_files.Count * asize);

		MapiFileDescriptor mfd = new MapiFileDescriptor();
		mfd.position = -1;
		int runptr = (int)ptra;
		for (int i = 0; i < _files.Count; i++)
		{
			string path = _files[i] as string;
			mfd.name = Path.GetFileName(path);
			mfd.path = path;
			Marshal.StructureToPtr(mfd, (IntPtr)runptr, false);
			runptr += asize;
		}

		fileCount = _files.Count;
		return ptra;
	}

	/// <summary>
	/// Logs any Mapi errors.
	/// </summary>
	private void _LogErrorMapi(int errorCode)
	{
		const int MAPI_USER_ABORT = 1;
		const int MAPI_E_FAILURE = 2;
		const int MAPI_E_LOGIN_FAILURE = 3;
		const int MAPI_E_DISK_FULL = 4;
		const int MAPI_E_INSUFFICIENT_MEMORY = 5;
		const int MAPI_E_BLK_TOO_SMALL = 6;
		const int MAPI_E_TOO_MANY_SESSIONS = 8;
		const int MAPI_E_TOO_MANY_FILES = 9;
		const int MAPI_E_TOO_MANY_RECIPIENTS = 10;
		const int MAPI_E_ATTACHMENT_NOT_FOUND = 11;
		const int MAPI_E_ATTACHMENT_OPEN_FAILURE = 12;
		const int MAPI_E_ATTACHMENT_WRITE_FAILURE = 13;
		const int MAPI_E_UNKNOWN_RECIPIENT = 14;
		const int MAPI_E_BAD_RECIPTYPE = 15;
		const int MAPI_E_NO_MESSAGES = 16;
		const int MAPI_E_INVALID_MESSAGE = 17;
		const int MAPI_E_TEXT_TOO_LARGE = 18;
		const int MAPI_E_INVALID_SESSION = 19;
		const int MAPI_E_TYPE_NOT_SUPPORTED = 20;
		const int MAPI_E_AMBIGUOUS_RECIPIENT = 21;
		const int MAPI_E_MESSAGE_IN_USE = 22;
		const int MAPI_E_NETWORK_FAILURE = 23;
		const int MAPI_E_INVALID_EDITFIELDS = 24;
		const int MAPI_E_INVALID_RECIPS = 25;
		const int MAPI_E_NOT_SUPPORTED = 26;
		const int MAPI_E_NO_LIBRARY = 999;
		const int MAPI_E_INVALID_PARAMETER = 998;

		string error = string.Empty;
		switch (errorCode)
		{
			case MAPI_USER_ABORT:
				error = "";
				break;
			case MAPI_E_FAILURE:
				error = "MAPI Failure.";
				break;
			case MAPI_E_LOGIN_FAILURE:
				error = "Login Failure.";
				break;
			case MAPI_E_DISK_FULL:
				error = "MAPI Disk full.";
				break;
			case MAPI_E_INSUFFICIENT_MEMORY:
				error = "MAPI Insufficient memory.";
				break;
			case MAPI_E_BLK_TOO_SMALL:
				error = "MAPI Block too small.";
				break;
			case MAPI_E_TOO_MANY_SESSIONS:
				error = "MAPI Too many sessions.";
				break;
			case MAPI_E_TOO_MANY_FILES:
				error = "MAPI too many files.";
				break;
			case MAPI_E_TOO_MANY_RECIPIENTS:
				error = "MAPI too many recipients.";
				break;
			case MAPI_E_ATTACHMENT_NOT_FOUND:
				error = "MAPI Attachment not found.";
				break;
			case MAPI_E_ATTACHMENT_OPEN_FAILURE:
				error = "MAPI Attachment open failure.";
				break;
			case MAPI_E_ATTACHMENT_WRITE_FAILURE:
				error = "MAPI Attachment Write Failure.";
				break;
			case MAPI_E_UNKNOWN_RECIPIENT:
				error = "MAPI Unknown recipient.";
				break;
			case MAPI_E_BAD_RECIPTYPE:
				error = "MAPI Bad recipient type.";
				break;
			case MAPI_E_NO_MESSAGES:
				error = "MAPI No messages.";
				break;
			case MAPI_E_INVALID_MESSAGE:
				error = "MAPI Invalid message.";
				break;
			case MAPI_E_TEXT_TOO_LARGE:
				error = "MAPI Text too large.";
				break;
			case MAPI_E_INVALID_SESSION:
				error = "MAPI Invalid session.";
				break;
			case MAPI_E_TYPE_NOT_SUPPORTED:
				error = "MAPI Type not supported.";
				break;
			case MAPI_E_AMBIGUOUS_RECIPIENT:
				error = "MAPI Ambiguous recipient.";
				break;
			case MAPI_E_MESSAGE_IN_USE:
				error = "MAPI Message in use.";
				break;
			case MAPI_E_NETWORK_FAILURE:
				error = "MAPI Network failure.";
				break;
			case MAPI_E_INVALID_EDITFIELDS:
				error = "MAPI Invalid edit fields.";
				break;
			case MAPI_E_INVALID_RECIPS:
				error = "MAPI Invalid Recipients.";
				break;
			case MAPI_E_NOT_SUPPORTED:
				error = "MAPI Not supported.";
				break;
			case MAPI_E_NO_LIBRARY:
				error = "MAPI No Library.";
				break;
			case MAPI_E_INVALID_PARAMETER:
				error = "MAPI Invalid parameter.";
				break;
		}
		if(error != "")
			System.Windows.Forms.MessageBox.Show("Error sending Email.\n\nError: " + error);
	}
	#endregion Private Methods

	#region Private MAPIHelperInterop Class

	/// <summary>
	/// Internal class for calling MAPI APIs
	/// </summary>
	internal class MAPIHelperInterop
	{
		#region Constructors

		/// <summary>
		/// Private constructor.
		/// </summary>
		private MAPIHelperInterop()
		{
			// Intenationally blank
		}

		#endregion Constructors

		#region Constants

		public const int MAPI_LOGON_UI = 0x1;

		#endregion Constants

		#region APIs

		[DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
		public static extern int MAPILogon(IntPtr hwnd, string prf, string pw, int flg, int rsv, ref IntPtr sess);

		#endregion APIs

		#region Structs

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
			public class MapiMessage
		{
			public int Reserved = 0;
			public string Subject = null;
			public string NoteText = null;
			public string MessageType = null;
			public string DateReceived = null;
			public string ConversationID = null;
			public int Flags = 0;
			public IntPtr Originator = IntPtr.Zero;
			public int RecipientCount = 0;
			public IntPtr Recipients = IntPtr.Zero;
			public int FileCount = 0;
			public IntPtr Files = IntPtr.Zero;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
			public class MapiRecipDesc
		{
			public int Reserved = 0;
			public int RecipientClass = 0;
			public string Name = null;
			public string Address = null;
			public int eIDSize = 0;
			public IntPtr EntryID = IntPtr.Zero;
		}

		[DllImport("MAPI32.DLL")]
		public static extern int MAPISendMail(IntPtr session, IntPtr hwnd, MapiMessage message, int flg, int rsv);

		#endregion Structs
	}

	#endregion Private MAPIHelperInterop Class
}

#endregion Public MapiMailMessage Class

public class Recipient
{
	public string Address = null;
	public string DisplayName = null;
	public MapiMailMessage.RecipientType RecipientType = MapiMailMessage.RecipientType.To;

	public Recipient(string address)
	{
		Address = address;
	}

	internal MapiMailMessage.MAPIHelperInterop.MapiRecipDesc GetInteropRepresentation()
	{
		MapiMailMessage.MAPIHelperInterop.MapiRecipDesc interop = new MapiMailMessage.MAPIHelperInterop.MapiRecipDesc();

		if (DisplayName == null)
		{
			interop.Name = Address;
		}
		else
		{
			interop.Name = DisplayName;
			interop.Address = Address;
		}

		interop.RecipientClass = (int)RecipientType;

		return interop;
	}
}
#region Public RecipientCollection Class

public class RecipientCollection : CollectionBase
{
	public void Add(Recipient value)
	{
		List.Add(value);
	}
	public void Add(string address)
	{
		this.Add(new Recipient(address));
	}

	internal InteropRecipientCollection GetInteropRepresentation()
	{
		return new InteropRecipientCollection(this);
	}

	/// <summary>
	/// Struct which contains an interop representation of a colleciton of recipients.
	/// </summary>
	internal struct InteropRecipientCollection : IDisposable
	{
		#region Member Variables

		private IntPtr _handle;
		private int _count;

		#endregion Member Variables

		#region Constructors

		/// <summary>
		/// Default constructor for creating InteropRecipientCollection.
		/// </summary>
		/// <param name="outer"></param>
		public InteropRecipientCollection(RecipientCollection outer)
		{
			_count = outer.Count;

			if (_count == 0)
			{
				_handle = IntPtr.Zero;
				return;
			}

			// allocate enough memory to hold all recipients
			int size = Marshal.SizeOf(typeof(MapiMailMessage.MAPIHelperInterop.MapiRecipDesc));
			_handle = Marshal.AllocHGlobal(_count * size);

			// place all interop recipients into the memory just allocated
			int ptr = (int)_handle;
			foreach (Recipient native in outer)
			{
				MapiMailMessage.MAPIHelperInterop.MapiRecipDesc interop = native.GetInteropRepresentation();

				// stick it in the memory block
				Marshal.StructureToPtr(interop, (IntPtr)ptr, false);
				ptr += size;
			}
		}

		#endregion Costructors

		#region Public Properties

		public IntPtr Handle
		{
			get { return _handle; }
		}

		#endregion Public Properties

		#region Public Methods

		/// <summary>
		/// Disposes of resources.
		/// </summary>
		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				Type type = typeof(MapiMailMessage.MAPIHelperInterop.MapiRecipDesc);
				int size = Marshal.SizeOf(type);

				// destroy all the structures in the memory area
				int ptr = (int)_handle;
				for (int i = 0; i < _count; i++)
				{
					Marshal.DestroyStructure((IntPtr)ptr, type);
					ptr += size;
				}

				// free the memory
				Marshal.FreeHGlobal(_handle);

				_handle = IntPtr.Zero;
				_count = 0;
			}
		}

		#endregion Public Methods
	}
}

#endregion Public RecipientCollection Class