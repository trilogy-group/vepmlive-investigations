using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NewsGator.Install.Common.Output;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Globalization;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Threading
    {
        // http://stackoverflow.com/questions/299198/implement-c-sharp-generic-timeout

        //Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

        //var result = WaitFor<OutputQueue>.Run(TimeSpan.FromMilliseconds(timeout), outputAction);
        //if (result != null)
        //    output.Add(result);

        //Thread.CurrentThread.Priority = ThreadPriority.Normal;

        public sealed class WaitFor<TResult>
        {
            readonly TimeSpan _timeout;

            /// <summary>
            /// Initializes a new instance of the <see cref="WaitFor{T}"/> class, 
            /// using the specified timeout for all operations.
            /// </summary>
            /// <param name="timeout">The timeout.</param>
            public WaitFor(TimeSpan timeout)
            {
                _timeout = timeout;
            }

            /// <summary>
            /// Executes the spcified function within the current thread, aborting it
            /// if it does not complete within the specified timeout interval. 
            /// </summary>
            /// <param name="function">The function.</param>
            /// <returns>result of the function</returns>
            /// <remarks>
            /// The performance trick is that we do not interrupt the current
            /// running thread. Instead, we just create a watcher that will sleep
            /// until the originating thread terminates or until the timeout is
            /// elapsed.
            /// </remarks>
            /// <exception cref="ArgumentNullException">if function is null</exception>
            /// <exception cref="TimeoutException">if the function does not finish in time </exception>
            public TResult Run(Func<TResult> function)
            {
                if (function == null) throw new ArgumentNullException("function");

                var sync = new object();
                var isCompleted = false;

                WaitCallback watcher = obj =>
                {
                    var watchedThread = obj as Thread;

                    lock (sync)
                    {
                        if (!isCompleted)
                        {
                            Monitor.Wait(sync, _timeout);
                        }
                    }
                    // CAUTION: the call to Abort() can be blocking in rare situations
                    // http://msdn.microsoft.com/en-us/library/ty8d3wta.aspx
                    // Hence, it should not be called with the 'lock' as it could deadlock
                    // with the 'finally' block below.

                    if (!isCompleted)
                    {
                        watchedThread.Abort();
                    }
                };

                try
                {
                    ThreadPool.QueueUserWorkItem(watcher, Thread.CurrentThread);
                    return function();
                }
                catch (ThreadAbortException)
                {
                    // This is our own exception.
                    Thread.ResetAbort();

                    throw new TimeoutException();
                }
                finally
                {
                    lock (sync)
                    {
                        isCompleted = true;
                        Monitor.Pulse(sync);
                    }
                }
            }

            /// <summary>
            /// Executes the spcified function within the current thread, aborting it
            /// if it does not complete within the specified timeout interval.
            /// </summary>
            /// <param name="timeout">The timeout.</param>
            /// <param name="function">The function.</param>
            /// <returns>result of the function</returns>
            /// <remarks>
            /// The performance trick is that we do not interrupt the current
            /// running thread. Instead, we just create a watcher that will sleep
            /// until the originating thread terminates or until the timeout is
            /// elapsed.
            /// </remarks>
            /// <exception cref="ArgumentNullException">if function is null</exception>
            /// <exception cref="TimeoutException">if the function does not finish in time </exception>
            public static TResult Run(TimeSpan timeout, Func<TResult> function)
            {
                Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

                var returnValue = new WaitFor<TResult>(timeout).Run(function);

                Thread.CurrentThread.Priority = ThreadPriority.Normal;
                return returnValue;
            }
        }

        // From: http://blogs.msdn.com/b/padmanr/archive/2010/05/08/execute-a-process-on-remote-machine-wait-for-it-to-exit-and-retrieve-its-exit-code-using-wmi.aspx
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
        public class ProcessWMI
        {
            public uint ProcessId;
            public int ExitCode;
            public bool EventArrived;
            public ManualResetEvent mre = new ManualResetEvent(false);
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object,System.Object)")]
            public void ProcessStoptEventArrived(object sender, EventArrivedEventArgs e)
            {
                if ((uint)e.NewEvent.Properties["ProcessId"].Value == ProcessId)
                {
                    //Console.WriteLine("Process: {0}, Stopped with Code: {1}", (int)(uint)e.NewEvent.Properties["ProcessId"].Value, (int)(uint)e.NewEvent.Properties["ExitStatus"].Value);
                    ExitCode = (int)(uint)e.NewEvent.Properties["ExitStatus"].Value;
                    EventArrived = true;
                    mre.Set();
                }
            }
            public ProcessWMI()
            {
                this.ProcessId = 0;
                ExitCode = -1;
                EventArrived = false;
            }
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Machinename"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ProcessName"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "RunAs"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String)")]
            public void ExecuteRemoteProcessWMI(string remoteComputerName, string arguments, int WaitTimePerCommand)
            {
                string strUserName = string.Empty;
                try
                {
                    ConnectionOptions connOptions = new ConnectionOptions();
                    connOptions.Impersonation = ImpersonationLevel.Impersonate;
                    connOptions.EnablePrivileges = true;
                    ManagementScope manScope = new ManagementScope(String.Format(CultureInfo.InvariantCulture, @"\\{0}\ROOT\CIMV2", remoteComputerName), connOptions);

                    try
                    {
                        manScope.Connect();
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("Management Connect to remote machine " + remoteComputerName + " as user " + strUserName + " failed with the following error " + e.Message);
                    }
                    ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                    ManagementPath managementPath = new ManagementPath("Win32_Process");
                    ManagementPath startupManagementPath = new ManagementPath("Win32_ProcessStartup");
                    using (ManagementClass startupClass = new ManagementClass(manScope, startupManagementPath, objectGetOptions))
                    {
                        ManagementObject startupInstance = startupClass.CreateInstance();
                        startupInstance["ShowWindow"] = 0;

                        using (ManagementClass processClass = new ManagementClass(manScope, managementPath, objectGetOptions))
                        {
                            using (ManagementBaseObject inParams = processClass.GetMethodParameters("Create"))
                            {
                                inParams["CommandLine"] = arguments;
                                inParams["ProcessStartupInformation"] = startupInstance;

                                using (ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null))
                                {

                                    if ((uint)outParams["returnValue"] != 0)
                                    {
                                        throw new InvalidOperationException("Error while starting process " + arguments + " creation returned an exit code of " + outParams["returnValue"] + ". It was launched as " + strUserName + " on " + remoteComputerName);
                                    }
                                    this.ProcessId = (uint)outParams["processId"];
                                }
                            }
                        }
                    }

                    SelectQuery CheckProcess = new SelectQuery("Select * from Win32_Process Where ProcessId = " + ProcessId);
                    using (ManagementObjectSearcher ProcessSearcher = new ManagementObjectSearcher(manScope, CheckProcess))
                    {
                        using (ManagementObjectCollection MoC = ProcessSearcher.Get())
                        {
                            if (MoC.Count == 0)
                            {
                                throw new InvalidOperationException("ERROR AS WARNING: Process " + arguments + " terminated before it could be tracked on " + remoteComputerName);
                            }
                        }
                    }

                    WqlEventQuery q = new WqlEventQuery("Win32_ProcessStopTrace");
                    using (ManagementEventWatcher w = new ManagementEventWatcher(manScope, q))
                    {
                        w.EventArrived += new EventArrivedEventHandler(this.ProcessStoptEventArrived);
                        w.Start();
                        if (!mre.WaitOne(WaitTimePerCommand, false))
                        {
                            w.Stop();
                            this.EventArrived = false;
                        }
                        else
                            w.Stop();
                    }
                    if (!this.EventArrived)
                    {
                        SelectQuery sq = new SelectQuery("Select * from Win32_Process Where ProcessId = " + ProcessId);
                        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(manScope, sq))
                        {
                            foreach (ManagementObject queryObj in searcher.Get())
                            {
                                queryObj.InvokeMethod("Terminate", null);
                                queryObj.Dispose();
                                throw new InvalidOperationException("Process " + arguments + " timed out and was killed on " + remoteComputerName);
                            }
                        }
                    }
                    else
                    {
                        if (this.ExitCode != 0)
                            throw new InvalidOperationException("Process " + arguments + "exited with exit code " + this.ExitCode + " on " + remoteComputerName + " run as " + strUserName);
                        //else
                            //Console.WriteLine("process exited with Exit code 0");
                    }

                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Execute process failed Machinename {0}, ProcessName {1}, RunAs {2}, Error is {3}, Stack trace {4}", remoteComputerName, arguments, strUserName, e.Message, e.StackTrace), e);
                }
            }
        }
    }
}
