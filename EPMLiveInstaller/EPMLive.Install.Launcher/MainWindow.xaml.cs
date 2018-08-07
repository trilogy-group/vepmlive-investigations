using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using NewsGator.Install.Resources;
using NewsGator.Install.Resources.WpfMessageBox;

namespace EPMLive.Install.Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Visibility _collapsed = Visibility.Collapsed;
        private Visibility _visible = Visibility.Visible;
        string lineBreak = Environment.NewLine;
        int CountErrors = 0;
        int CountWarnings = 0;
        public ObservableCollection<WebApp> WebApplicationList { get; internal set; }

        public class WebApp
        {
            public string Url { get; set; }
            public bool IsSelected { get; set; }
        }

        public MainWindow()
        {
            if (!IsSharePointDllAvailable())
            {
                WpfMessageBoxInstance.Show(Exceptions.SharePointNotInstalledMessage, UserDisplay.TitleError, MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            //CheckGac();

            InitializeComponent();

            PopulateWebApplications();
            PopulateServiceApplicationPools();
        }

        private void PopulateServiceApplicationPools()
        {
            var appPools = NewsGator.Install.Common.Utilities.ApplicationPools.GetServiceApplicationPoolsNames();

            foreach (var appPool in appPools)
            {
                cbServiceApplicationPool.Items.Add(new ComboBoxItem { Tag = appPool, Content = appPool });
            }
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            txtApplicationTitle.Text = string.Format(CultureInfo.CurrentCulture, UserDisplay.ApplicationTitleLauncher, FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
            Title = txtApplicationTitle.Text;

            //txtInstallLog.Text = Directory.GetCurrentDirectory();

            Focus();
            Activate();
        }

        private static string CopyPowerShellExecutable(string path)
        {
            if (!path.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                path += "\\";

            var ngPSPath = path + "NGPS.exe";
            if (!File.Exists(ngPSPath))
                File.Copy(@"C:\Windows\System32\WindowsPowerShell\v1.0\PowerShell.exe", ngPSPath);

            return ngPSPath;
        }

        private static void WriteConfigFile(int version, string path, bool ngPSConfig = false)
        {
            if (!path.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                path += "\\";
            var installConfig = path + (ngPSConfig ? "NGPS.exe.config" : "Install.exe.config");

            string config;
            switch (version)
            {
                case 15:
                    config = Config.ExecutableConfig2013;
                    break;
                case 16:
                    config = Config.ExecutableConfig2016;
                    break;
                default:
                    config = Config.ExecutableConfig2010;
                    break;
            }

            File.WriteAllText(installConfig, config, UTF8Encoding.UTF8);
        }

        private string GetSenderName(FrameworkElement element, int depth = 0)
        {
            if (!string.IsNullOrEmpty(element.Name))
                return element.Name;

            if (element.Parent != null && depth < 100)
            {
                var parent = element.Parent as FrameworkElement;
                if (parent == null)
                    return string.Empty;

                depth++;
                return GetSenderName(parent, depth);
            }
            else
            {
                return string.Empty;
            }
        }

        private void actionMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var source = e.Source as FrameworkElement;
            var sourceName = GetSenderName(source);
            SomethingClicked(sourceName);
        }

        private static bool DisplayWarningContinue()
        {
            return WpfMessageBoxInstance.Show(UserDisplay.DisasterRecoverWarning, UserDisplay.TitleWarning, MessageBoxButton.OKCancel, MessageBoxImage.Warning) != MessageBoxResult.Cancel;
        }

        private void PopulateWebApplications()
        {
            var webAppUrls = NewsGator.Install.Common.Utilities.WebApplications.GetWebApplicationUrls();
            this.WebApplicationList = new ObservableCollection<WebApp>();

            foreach (var webApp in webAppUrls)
            {
                this.WebApplicationList.Add(new WebApp() { Url = webApp, IsSelected = true });
            }

            this.DataContext = this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private void SomethingClicked(string sourceName)
        {
            switch (sourceName)
            {
                case "btnInstallAdvanced":
                    scrollViewerAdvancedInstall.Visibility = _collapsed;
                    pnlInstallStatus.Visibility = _visible;
                    var psParams = GatherParameters();
                    RunSetup(psParams);
                    this.Height = 440;
                    btnInstallAdvanced.Visibility = Visibility.Hidden;

                    break;
                case "btnExit":
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void RunSetup(string psParams)
        {
            PowerShell powershell = PowerShell.Create();

            // Add a script to the PowerShell object. The script generates the 
            // numbers from 1 to 10 in half second intervals.
            var script = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force";
            script += "\r\n[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12";
            script += "\r\n[System.Net.ServicePointManager]::ServerCertificateValidationCallback = $null";
            script += "\r\nfunction Write-Host ($message) { Write-Output $message }";
            script += "\r\n.\\epmliveSilentInstaller.ps1" + psParams;
            //-deployGAC -deployCOM -deployTimer -deployPFE -inUsername 'social\\spuserprofile1' -comUsername 'spuserprofile1@social.com' -inPassword 'Pass@word1' -webAppName 'http://sp2016:29929/'";


            powershell.AddScript(script);// "1..10 | foreach {$_ ; start-sleep -milli 500}");

            // Add the event handlers.  If we did not care about hooking the DataAdded
            // event, we would let BeginInvoke create the output stream for us.
            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += new EventHandler<DataAddedEventArgs>(Output_DataAdded);

            powershell.Streams.Debug.DataAdded += new EventHandler<DataAddedEventArgs>(Debug_DataAdded);
            powershell.Streams.Error.DataAdded += new EventHandler<DataAddedEventArgs>(Error_DataAdded);
            powershell.Streams.Verbose.DataAdded += new EventHandler<DataAddedEventArgs>(Verbose_DataAdded);
            //powershell.Streams.Progress.DataAdded += new EventHandler<DataAddedEventArgs>(Progress_DataAdded);
            powershell.Streams.Warning.DataAdded += new EventHandler<DataAddedEventArgs>(Warning_DataAdded);

            powershell.InvocationStateChanged += new EventHandler<PSInvocationStateChangedEventArgs>(Powershell_InvocationStateChanged);

            //DispatcherISyncInvoke dis = new DispatcherISyncInvoke(this.Dispatcher);
            // Invoke the pipeline asynchronously.
            //IAsyncResult asyncResult = powershell.BeginInvoke<PSObject, PSObject>(null, output);

            Action action = delegate () {
                IAsyncResult asyncResult = powershell.BeginInvoke<PSObject, PSObject>(null, output);
            };

            //  dis.BeginInvoke(action, null);

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);

            // Wait for things to happen. If the user hits a key before the
            // script has completed, then call the PowerShell Stop() method
            // to halt processing.
            // Console.ReadKey();
            //if (powershell.InvocationStateInfo.State != PSInvocationState.Completed)
            //{
            //    // Stop the invocation of the pipeline.
            //   // Console.WriteLine("\nStopping the pipeline!\n");
            //    powershell.Stop();

            //    // Wait for the Windows PowerShell state change messages to be displayed.
            //    System.Threading.Thread.Sleep(500);
            //   // Console.WriteLine("\nPress a key to exit");
            //  //  Console.ReadKey();
            //}

        }

        private string GatherParameters()
        {
            string psParams = "";

            foreach (object child in spContainer.Children)
            {
                psParams += GetSingleParamter(child);

                if (child is StackPanel)
                {
                    foreach (object levelTwoChild in ((StackPanel)child).Children)
                    {
                        psParams += GetSingleParamter(levelTwoChild);
                    }
                }
            }
            return psParams;
        }

        private string GetSingleParamter(object child)
        {
            string childname = null;
            string param = "";

            if (child is FrameworkElement)
            {
                childname = (child as FrameworkElement).Name;
            }

            if (childname != null)
            {
                if (childname.StartsWith("txt"))
                {
                    var textbox = child as TextBox;
                    if (!string.IsNullOrEmpty(textbox.Text))
                        param += " -" + textbox.Tag + " '" + textbox.Text + "'";
                }
                else if (childname.StartsWith("password"))
                {
                    var textbox = child as PasswordBox;

                    if (!string.IsNullOrEmpty(textbox.Password))
                        param += " -" + textbox.Tag + " '" + textbox.Password + "'";
                }
                else if (childname.StartsWith("chk"))
                {
                    var chk = child as CheckBox;

                    if (chk.IsChecked ?? chk.IsChecked.Value)
                        param += " -" + chk.Tag;
                }
                else if (childname.StartsWith("cb"))
                {
                    var cb = child as ComboBox;

                    var webApp = cb.SelectedItem as WebApp;

                    if (webApp != null)
                        param += " -" + cb.Tag + " '" + webApp.Url + "'";
                }
            }

            return param;
        }

        private void Warning_DataAdded(object sender, DataAddedEventArgs e)
        {
            var records = (PSDataCollection<WarningRecord>)sender;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                txtInstallStatusWarnings.Text = txtInstallStatusWarnings.Text + lineBreak + records[e.Index].ToString();
                outputWarnings.ScrollToBottom();
                txtOutputWarnings.Text = string.Format(CultureInfo.CurrentCulture, UserDisplay.UIOutputWarnings, ++CountWarnings);
            }), DispatcherPriority.ContextIdle);
        }

        //private void Progress_DataAdded(object sender, DataAddedEventArgs e)
        //{
        //    var records = (PSDataCollection<VerboseRecord>)sender;

        //    txtInstallStatusVerbose.Text = txtInstallStatusErrors.Text + lineBreak + records[e.Index].ToString();
        //    outputErrors.ScrollToBottom();
        //}

        private void Verbose_DataAdded(object sender, DataAddedEventArgs e)
        {
            var records = (PSDataCollection<DebugRecord>)sender;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                txtInstallStatusVerbose.Text = txtInstallStatusVerbose.Text + lineBreak + records[e.Index].ToString();
                outputVerbose.ScrollToBottom();
            }), DispatcherPriority.ContextIdle);
        }

        private void Error_DataAdded(object sender, DataAddedEventArgs e)
        {
            var records = (PSDataCollection<ErrorRecord>)sender;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                txtInstallStatusErrors.Text = txtInstallStatusErrors.Text + lineBreak + records[e.Index].ToString();
                outputErrors.ScrollToBottom();

                txtOutputErrors.Text = string.Format(CultureInfo.CurrentCulture, UserDisplay.UIOutputErrors, ++CountErrors);
            }), DispatcherPriority.ContextIdle);
        }

        private void Debug_DataAdded(object sender, DataAddedEventArgs e)
        {
            var records = (PSDataCollection<DebugRecord>)sender;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                txtInstallStatusVerbose.Text = txtInstallStatusVerbose.Text + lineBreak + records[e.Index].ToString();
                outputVerbose.ScrollToBottom();
            }), DispatcherPriority.ContextIdle);

        }

        /// <summary>
        /// The output data added event handler. This event is called when
        /// data is added to the output pipe. It reads the data that is 
        /// available and displays it on the console.
        /// </summary>
        /// <param name="sender">The output pipe this event is associated with.</param>
        /// <param name="e">Parameter is not used.</param>
        private void Output_DataAdded(object sender, DataAddedEventArgs e)
        {
            PSDataCollection<PSObject> myp = (PSDataCollection<PSObject>)sender;

            Collection<PSObject> results = myp.ReadAll();
            foreach (PSObject result in results)
            {
                //Console.WriteLine(result.ToString());
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        txtInstallStatusVerbose.Text = txtInstallStatusVerbose.Text + lineBreak + result.ToString();
                    }
                    catch (Exception ex) { txtInstallStatusErrors.Text = txtInstallStatusErrors.Text + lineBreak + "Error: " + ex.Message; }
                    outputVerbose.ScrollToBottom();
                }), DispatcherPriority.ContextIdle);
            }
        }

        /// <summary>
        /// This event handler is called when the pipeline state is changed.
        /// If the state change is to Completed, the handler issues a message
        /// asking the user to exit the program.
        /// </summary>
        /// <param name="sender">This parameter is not used.</param>
        /// <param name="e">The PowerShell state information.</param>
        private void Powershell_InvocationStateChanged(object sender, PSInvocationStateChangedEventArgs e)
        {
            Console.WriteLine("PowerShell object state changed: state: {0}\n", e.InvocationStateInfo.State);
            if (e.InvocationStateInfo.State == PSInvocationState.Completed)
            {
                Console.WriteLine("Processing completed, press a key to exit!");
            }
        }
        //private void RunSetup1()
        //{
        //    // create Powershell runspace
        //    var runSpace = RunspaceFactory.CreateRunspace();
        //    // open it
        //    runSpace.Open();

        //    //var script = @"Get-ChildItem c:\ -recurse | Out-String -stream";
        //    //var script = @"Get-Process | Where-Object {$_.MainWindowTitle -ne ''} |Select-Object MainWindowTitle | Out-String -stream";
        //    var script = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force";
        //    script+="\r\n.\\epmliveSilentInstaller.ps1 -deployGAC -deployCOM -deployTimer -deployPFE -deploySolutions -inUsername 'administrator' -comUsername 'administrator' -inPassword '9DpsF%3C.&f' -webAppName 'http://sp2016:29929/'";

        //    //            var script = @"cd SilentInstaller_6.3.3.8
        //    //Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force
        //    //    .\epmliveSilentInstaller.ps1 -deployGAC -deployCOM -deployTimer -deployPFE -deploySolutions -inUsername 'administrator@social.com' -comUsername 'social\administrator' -inPassword '9DpsF%3C.&f' -webAppName 'http://sp2016:29929/'";

        //    DispatcherISyncInvoke dis = new DispatcherISyncInvoke(this.Dispatcher);

        //    pipelineExecutor = new PipelineExecutor(runSpace, dis, script);
        //    pipelineExecutor.OnDataReady += new PipelineExecutor.DataReadyDelegate(pipelineExecutor_OnDataReady);
        //    pipelineExecutor.OnDataEnd += new PipelineExecutor.DataEndDelegate(pipelineExecutor_OnDataEnd);
        //    pipelineExecutor.OnErrorReady += new PipelineExecutor.ErrorReadyDelegate(pipelineExecutor_OnErrorReady);
        //    pipelineExecutor.Start();

        //    //pipelineExecutor = new PipelineExecutor(runSpace, dis, script);
        //    //pipelineExecutor.Start();



        //}

        private void btnOutput_Click(object sender, RoutedEventArgs e)
        {
            var label = (Button)sender;
            var brushConverter = new BrushConverter();
            var defaultBrush = brushConverter.ConvertFromString("#FFFFFF") as Brush;

            //outputTasks.Visibility = _collapsed;
            outputVerbose.Visibility = _collapsed;
            outputErrors.Visibility = _collapsed;
            outputWarnings.Visibility = _collapsed;

            //lblOutputHide.FontWeight = FontWeights.Normal;
            //borderOutputHide.BorderBrush = defaultBrush;
            lblOutputVerbose.FontWeight = FontWeights.Normal;
            borderOutputVerbose.BorderBrush = defaultBrush;
            lblOutputErrors.FontWeight = FontWeights.Normal;
            borderOutputErrors.BorderBrush = defaultBrush;
            lblOutputWarnings.FontWeight = FontWeights.Normal;
            borderOutputWarnings.BorderBrush = defaultBrush;

            switch (label.Name)
            {
                case "btnOutputVerbose":
                    lblOutputVerbose.FontWeight = FontWeights.Bold;
                    borderOutputVerbose.BorderBrush = brushConverter.ConvertFromString("#666666") as Brush;
                    outputVerbose.Visibility = _visible;
                    break;
                case "btnOutputErrors":
                    lblOutputErrors.FontWeight = FontWeights.Bold;
                    borderOutputErrors.BorderBrush = brushConverter.ConvertFromString("#d30000") as Brush;
                    outputErrors.Visibility = _visible;
                    break;
                case "btnOutputWarnings":
                    lblOutputWarnings.FontWeight = FontWeights.Bold;
                    borderOutputWarnings.BorderBrush = brushConverter.ConvertFromString("#d3a400") as Brush;
                    outputWarnings.Visibility = _visible;
                    break;
                case "btnOutputHide":
                default:
                    // lblOutputHide.FontWeight = FontWeights.Bold;
                    //borderOutputHide.BorderBrush = brushConverter.ConvertFromString("#666666") as Brush;
                    //outputTasks.Visibility = _visible;
                    break;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private static int GetSharePointVersion()
        {
            try
            {
                if (File.Exists(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.dll"))
                    return 16;

                if (File.Exists(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.dll"))
                    return 15;

                if (File.Exists(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\ISAPI\Microsoft.SharePoint.dll"))
                    return 14;

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private static bool IsSharePointDllAvailable()
        {
            try
            {
                if (File.Exists(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.dll"))
                    return true;

                if (File.Exists(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.dll"))
                    return true;

                if (File.Exists(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\ISAPI\Microsoft.SharePoint.dll"))
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void CheckGac()
        {
            var assembliesFound = false;

            var assembliesToCheck = new Collection<string>()
                {
                    "NewsGator.Install.Common",
                    "NewsGator.Install.Cmdlets",
                    "NewsGator.Install.Resources"
                };

            var gac35 = "c:\\windows\\assembly\\gac_msil";
            var gac40 = "c:\\windows\\microsoft.net\\assembly\\gac_msil";

            var gacSubFormat = "{0}\\{1}.dll";
            var gacFormat = "{0}\\{1}";

            foreach (var assemblyToCheck in assembliesToCheck)
            {
                var directory35 = string.Format(CultureInfo.InvariantCulture, gacFormat, gac35, assemblyToCheck);
                var directory40 = string.Format(CultureInfo.InvariantCulture, gacFormat, gac40, assemblyToCheck);

                foreach (var directory in new Collection<string> { directory35, directory40 })
                {
                    if (Directory.Exists(directory))
                    {
                        foreach (var subdirectory in Directory.GetDirectories(directory))
                        {
                            var fileToCheck = string.Format(CultureInfo.InvariantCulture, gacSubFormat, subdirectory, assemblyToCheck);
                            if (File.Exists(fileToCheck))
                            {
                                assembliesFound = true;
                            }
                        }
                    }
                }
            }

            if (assembliesFound)
            {
                WpfMessageBoxInstance.Show("One or more of the NewsGator Social Sites Installer assemblies (NewsGator.Install.*) have been located in the Global Assembly Cache.  These must be removed from the Global Assembly Cache before continuing.", UserDisplay.TitleError, MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            var source = sender as Button;
            SomethingClicked(source.Name);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region Window Styling
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private const Int32 WM_SYSCOMMAND = 0x112;

        //private static readonly TimeSpan s_doubleClick = TimeSpan.FromMilliseconds(500);

        private HwndSource m_hwndSource;

        //bool ISynchronizeInvoke.InvokeRequired
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        protected override void OnInitialized(EventArgs e)
        {
            AllowsTransparency = false;
            ResizeMode = ResizeMode.NoResize;
            Height = 680;
            Width = 640;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;

            //SourceInitialized += HandleSourceInitialized;
            base.OnInitialized(e);
        }




        #endregion
    }


}
