using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{   
    [UpgradeStep(Version = EPMLiveVersion.V5612, Order = 1.0, Description = "Adding Department Events")]
    internal class AddEventHandlersToLocalDepartmentList : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public AddEventHandlersToLocalDepartmentList(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    // get a local list called "Departments"
                    SPList deptList = _spWeb.Lists.TryGetList("Departments");

                    // if "Departments" exists locally, add 
                    // ItemAdding, ItemUpdating, and ItemDeleted events
                    if (deptList != null)
                    {
                        _spWeb.AllowUnsafeUpdates = true;
                        string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                        string className = "EPMLiveCore.DepartmentEvent";


                        List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(deptList,
                                                                                      assemblyName,
                                                                                      className,
                                                                                      new List<SPEventReceiverType> { SPEventReceiverType.ItemAdding,
                                                                                                              SPEventReceiverType.ItemUpdating,
                                                                                                              SPEventReceiverType.ItemDeleted });
                        LogMessage("Department Events Deleting", MessageKind.SUCCESS, 4);

                        foreach (SPEventReceiverDefinition e in evts)
                        {
                            e.Delete();
                        }
                        LogMessage("Department Events Deleted Successfully", MessageKind.SUCCESS, 4);

                        LogMessage("Department Events Adding.", MessageKind.SUCCESS, 4);

                        deptList.EventReceivers.Add(SPEventReceiverType.ItemAdding, assemblyName, className);
                        deptList.EventReceivers.Add(SPEventReceiverType.ItemUpdating, assemblyName, className);
                        deptList.EventReceivers.Add(SPEventReceiverType.ItemDeleted, assemblyName, className);

                        List<SPEventReceiverDefinition> newEvts = CoreFunctions.GetListEvents(deptList,
                                                                                      assemblyName,
                                                                                      className,
                                                                                      new List<SPEventReceiverType> { SPEventReceiverType.ItemAdding,
                                                                                                              SPEventReceiverType.ItemUpdating,
                                                                                                              SPEventReceiverType.ItemDeleted });

                        foreach (SPEventReceiverDefinition e in newEvts)
                        {
                            e.SequenceNumber = 10000;
                            e.Update();
                        }

                        deptList.Update();

                        LogMessage("Department Events Added Successfully.", MessageKind.SUCCESS, 4);

                    }
                }
                catch (Exception ex)
                {
                    string message = ex.InnerException != null
                        ? ex.InnerException.Message
                        : ex.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);
                }
            });
            _spWeb.AllowUnsafeUpdates = false;
            return true;
        }

        #endregion
    }
}
