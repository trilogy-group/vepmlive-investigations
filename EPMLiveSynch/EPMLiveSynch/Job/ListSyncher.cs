using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.IO;
using System.Xml;
using System.Collections;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Utilities;
using System.Web.UI.WebControls.WebParts;
using EPMLiveCore;
using System.Reflection;

namespace EPMLiveSynch
{
    class ListSyncher : SyncItemBaseType
    {
        public SPList oFromList;
        private string sListName;
        private List<string> sSynchedFields;
        private bool bSyncViewGroupBySettings = false;
        public bool bErrors;

        public ListSyncher()
        {
        }

        public ListSyncher(object[] oParams)
        {
            SyncItems = (string)oParams[0];
            FromWeb = (SPWeb)oParams[1];

            ToWeb = (SPWeb)oParams[2];
        }

        //public SPList FromList
        //{
        //    get 
        //    {
        //        if (oFromList == null)
        //        {
        //            oFromList = FromWeb.GetList(FromWeb.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sListName);
        //        }
        //        return oFromList; 
        //    }
        //    set { oFromList = value; }
        //}

        public string ListName
        {
            get { return sListName; }
            set { sListName = value; }
        }

        public bool SyncViewGroupBySettings
        {
            get { return bSyncViewGroupBySettings; }
            set { bSyncViewGroupBySettings = value; }
        }

        protected internal override bool Sync()
        {
            try
            {
                SPList oToList = null;

                //if (oFromList == null) oFromList = getFromList(FromWeb, sListName);
                if(oToList == null && oFromList != null) oToList = getToList(ToWeb, oFromList, sListName);

                if(oToList != null)
                {

                    synchList(FromWeb, ToWeb, oToList);

                    string sListId;
                    if(oFromList != null)
                    {
                        sListId = oFromList.ID.ToString();
                    }
                    else
                    {
                        sListId = FromWeb.GetList(FromWeb.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sListName).ID.ToString();
                    }

                    string sDVurl;

                    if(FromWeb.Properties.ContainsKey("EPMLiveSynchedViews-{" + sListId + "}"))
                    {
                        string sEPMLiveSynchedViews = FromWeb.Properties["EPMLiveSynchedViews-{" + sListId + "}"].ToString();
                        if(sEPMLiveSynchedViews.Length > 0)
                        {
                            string[] arrVals = sEPMLiveSynchedViews.Split(chrCommaSeparator, StringSplitOptions.RemoveEmptyEntries);

                            if(oToList != null)
                            {
                                if(oFromList.DefaultView != null)
                                {
                                    sDVurl = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);
                                    if(FromWeb.Properties.ContainsKey("EPMLiveSyncViewGroupBySettings-" + sDVurl))
                                    {
                                        string sSyncViewGroupBySettings = FromWeb.Properties["EPMLiveSyncViewGroupBySettings-" + sDVurl];
                                        if(sSyncViewGroupBySettings.Length > 0 && sSyncViewGroupBySettings.ToUpper() == "TRUE")
                                        {
                                            bSyncViewGroupBySettings = true;
                                        }
                                        else
                                        {
                                            bSyncViewGroupBySettings = false;
                                        }
                                    }

                                    synchViews(FromWeb, oFromList, ToWeb, oToList, arrVals);
                                }
                            }
                        }
                    }


                    if(oFromList.DefaultView != null)
                    {

                        sDVurl = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);

                        if(FromWeb.Properties.ContainsKey("EPMLiveSyncPermissionsAndMgmtSettings-" + sDVurl))
                        {
                            string sSyncPermissionsAndMgmtSettings = FromWeb.Properties["EPMLiveSyncPermissionsAndMgmtSettings-" + sDVurl];
                            if(sSyncPermissionsAndMgmtSettings.Length > 0 && sSyncPermissionsAndMgmtSettings.ToUpper() == "TRUE")
                            {
                                syncViewPermissionSettings(FromWeb, oFromList, ToWeb, oToList, true);
                            }
                        }
                        else
                            syncViewPermissionSettings(FromWeb, oFromList, ToWeb, oToList, true);
                    }

                    Results += sSiteResults;
                    sSiteResults = "";
                    return true;
                }
                else
                {
                    Results += sSiteResults;
                    return false;
                }

            }
            catch(Exception ex)
            {
                bErrors = true;
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Synching " + ToWeb.Title + " website - Not synched. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                return false;
            }
        }

        private void synchList(SPWeb oFromWeb, SPWeb oToWeb, SPList oToList)
        {
            try
            {
                //SPList oToList = getToList(oToWeb, FromList, sListName);

                if(oToList != null)
                {



                    //================================================

                    oToWeb.AllowUnsafeUpdates = true;
                    bool bTodayFieldCreated = false;
                    try
                    {
                        // workaround for Today function - create a Today field
                        try
                        {
                            SPField fldToday = oToList.Fields.GetFieldByInternalName("Today");
                        }
                        catch(Exception ex)
                        {
                            oToList.Fields.Add("Today", SPFieldType.Text, false);
                            bTodayFieldCreated = true;
                            oToList.Update();
                        }

                        bool bSynchEditable = false;
                        string sListURL = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);
                        string sSynchEditable = CoreFunctions.getConfigSetting(oFromWeb, "EPMLiveSyncEditableFieldsSettings-" + sListURL);
                        if(sSynchEditable != "")
                        {
                            bool.TryParse(sSynchEditable, out bSynchEditable);
                        }
                        //bool bSyncShowInEditProperty = false;
                        //bool bSyncHiddenProperty = false;

                        //if (oFromList.DefaultView != null)
                        //{
                        //    
                        //    if (CoreFunctions.getConfigSetting(oFromWeb, "EPMLiveSyncEditableFieldsSettings-" + sListURL).ToUpper() == "TRUE")
                        //    {
                        //        bSyncShowInNewProperty = bool.Parse(sSyncEditableFieldsProperty);
                        //        bSyncShowInEditProperty = bool.Parse(sSyncEditableFieldsProperty);
                        //        bSyncHiddenProperty = bool.Parse(sSyncEditableFieldsProperty);
                        //    }
                        //}

                        // loop thru all fields in FromList and update or create them in the ToList
                        //SPField fld;
                        sSynchedFields = new List<string>();
                        List<SPField> firstFields = new List<SPField>();
                        //for (int i = 0; i < FromList.Fields.Count; i++)
                        foreach(SPField fld in oFromList.Fields)
                        {
                            //fld = oFromList.Fields[i];
                            if(!fld.Hidden && fld.Type != SPFieldType.Attachments && fld.InternalName != "Today" && fld.InternalName != "Created" && fld.InternalName != "Modified" && fld.InternalName != "Author" && fld.InternalName != "Editor" && fld.InternalName != "ContentType" && fld.InternalName != "Order" && fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo" && (!fld.ReadOnlyField || fld.Type == SPFieldType.Calculated))
                            {
                                createOrUpdateFieldRecursive(oToWeb, fld.InternalName, oToList, bSynchEditable);
                            }
                            if(fld.Reorderable)
                            {
                                firstFields.Add(fld);
                            }

                        }
                        oToList.Update();
                        //oToWeb.Update();
                        if(!oFromList.ContentTypesEnabled)
                            ReorderFieldsPrep(oToList, firstFields);

                        oToWeb.AllowUnsafeUpdates = true;
                        //oToWeb.Update();
                        // unseal & delete fields that exist in ToList but not in FromList
                        if((SyncType)enSyncType == SyncType.List)
                        {
                            SPList oNewToList;
                            oNewToList = getToList(oToWeb, oFromList, sListName);
                            string[] arrFields = new string[oNewToList.Fields.Count];
                            int iCnt = 0;

                            //for (int i = 0; i < oNewToList.Fields.Count; i++)
                            foreach(SPField fld in oNewToList.Fields)
                            {
                                //fld = oNewToList.Fields[i];
                                if(fld.Sealed && !fld.Hidden && fld.Type != SPFieldType.Attachments && fld.InternalName != "Created" && fld.InternalName != "Modified" && fld.InternalName != "Author" && fld.InternalName != "Editor" && fld.InternalName != "Order" && !fld.FromBaseType && fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo" && (!fld.ReadOnlyField || fld.Type == SPFieldType.Calculated))
                                {
                                    if(!oFromList.Fields.ContainsField(fld.InternalName) && fld.InternalName != "Today")
                                    {
                                        arrFields[iCnt] = fld.Title;
                                        iCnt++;
                                    }
                                }
                            }
                            string sFld;
                            for(int i = 0; i < arrFields.Length; i++)
                            {
                                sFld = arrFields[i];
                                if(sFld != null && !String.IsNullOrEmpty(sFld))
                                {
                                    try
                                    {
                                        SPField oToField = oToWeb.GetList(oToWeb.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + oNewToList.Title).Fields[sFld];
                                        if(oToField.Sealed) oToField.Sealed = false;
                                        oToField.AllowDeletion = true;
                                        oToField.Update();
                                        oToField.Delete();
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + sFld + "): Deleted.<br>";
                                    }
                                    catch(Exception exc)
                                    {
                                        bErrors = true;
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Delete field " + sFld + " - Not synched. Error message: " + exc.Message.Replace("'", "") + "</font><br>";
                                    }
                                }
                            }
                        }

                        if(bTodayFieldCreated || oToList.Fields.ContainsField("Today"))
                        {
                            try
                            {
                                oToList.Fields.Delete("Today");
                            }
                            catch { } // sometimes will get SQL Server error 'The SQL Server has not started'
                        }

                        // Sync List Settings (Description & Navigation, Versioning, Advanced, and Permissions & Mgmt


                        // Sync Editable Fields settings
                        if(oFromList != null && oFromList.DefaultView != null && oToList != null && oToList.DefaultView != null)
                        {
                            try
                            {
                                syncListSettings(oFromWeb, oFromList, oToList, "", true);
                            }
                            catch(Exception e)
                            {
                            }
                            //EPMLiveCore.CoreFunctions.setListSetting(oToList, "TotalSettings", EPMLiveCore.CoreFunctions.getListSetting(oFromList, "TotalSettings"));
                            //EPMLiveCore.CoreFunctions.setListSetting(oToList, "GeneralSettings", EPMLiveCore.CoreFunctions.getListSetting(oFromList, "GeneralSettings"));
                            EPMLiveCore.CoreFunctions.setListSetting("DisplaySettings", EPMLiveCore.CoreFunctions.getListSetting("DisplaySettings", oFromList), oToList);
                            //EPMLiveCore.CoreFunctions.setListSetting(oToList, "EnableResourcePlan", EPMLiveCore.CoreFunctions.getListSetting(oFromList, "EnableResourcePlan"));

                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (Editable Fields) Success.<br>";
                        }
                        else
                        {
                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Editable Fields) - Not synched. Default view is not set on either the sync from or sync to list.</font><br>";
                        }
                    }
                    catch(Exception exc)
                    {
                        bErrors = true;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Synching " + sListName + " list - Not synched. Error message: " + exc.Message.Replace("'", "") + "</font><br>";
                    }
                    //================Content Types====================

                    if(oFromList.ContentTypesEnabled)
                    {
                        foreach(SPContentType fromCT in oFromList.ContentTypes)
                        {
                            try
                            {
                                if(oToList.ContentTypes[fromCT.Name] == null)
                                {
                                    try
                                    {
                                        oToList.ContentTypes.Add(fromCT);
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Added Content Type (" + fromCT.Name + ") Success<br>";
                                    }
                                    catch(Exception ex)
                                    {
                                        bErrors = true;
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\">Failed to add Content Type " + fromCT.Name + ": " + ex.Message + "</font><br>";
                                    }
                                }
                                else
                                {
                                    if(fromCT.Name != "Folder")
                                    {
                                        string location = "";
                                        try
                                        {
                                            SPContentType toCT = oToList.ContentTypes[fromCT.Name];
                                            ArrayList arrFields = new ArrayList();
                                            ArrayList arrOrder = new ArrayList();
                                            foreach(SPFieldLink fl in toCT.FieldLinks)
                                            {
                                                location = "Add Field " + fl.Name;
                                                arrFields.Add(fl.Name);
                                            }

                                            foreach(SPFieldLink fl in fromCT.FieldLinks)
                                            {
                                                arrOrder.Add(fl.Name);

                                                if(arrFields.Contains(fl.Name))
                                                    arrFields.Remove(fl.Name);

                                                if(toCT.FieldLinks[fl.Name] == null && toCT.FieldLinks[fl.Id] == null)
                                                {
                                                    location = "Add Link " + fl.Name;
                                                    toCT.FieldLinks.Add(fl);
                                                }
                                            }
                                            foreach(string fl in arrFields)
                                            {
                                                location = "Delete Link " + fl;
                                                toCT.FieldLinks.Delete(fl);
                                            }

                                            string[] sOrder = (string[])arrOrder.ToArray(typeof(string));
                                            location = "Reorder";
                                            toCT.FieldLinks.Reorder(sOrder);
                                            toCT.Update();
                                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content Type (" + fromCT.Name + ") Success<br>";
                                        }
                                        catch(Exception ex)
                                        {
                                            bErrors = true;
                                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\">Content Type (" + fromCT.Name + ") Failed at (" + location + "): " + ex.Message + "</font><br>";
                                        }
                                    }
                                }
                            }
                            catch
                            { }
                        }
                        oToList.Update();
                    }
                    Results += sSiteResults;
                    sSiteResults = "";
                }
            }
            catch { }
        }

        private void setAttr(ref XmlDocument newDocXml, XmlDocument oldDocXml, string attribute)
        {
            if(oldDocXml.FirstChild.Attributes[attribute] != null)
            {
                if(newDocXml.FirstChild.Attributes[attribute] != null)
                {
                    newDocXml.FirstChild.Attributes[attribute].Value = oldDocXml.FirstChild.Attributes[attribute].Value;
                }
                else
                {
                    XmlAttribute attr = newDocXml.CreateAttribute(attribute);
                    attr.Value = oldDocXml.FirstChild.Attributes[attribute].Value;
                    newDocXml.FirstChild.Attributes.Append(attr);
                }
            }
            else if(newDocXml.FirstChild.Attributes[attribute] != null)
            {
                newDocXml.FirstChild.Attributes.Remove(newDocXml.FirstChild.Attributes[attribute]);
            }
        }

        private void createOrUpdateFieldRecursive(SPWeb webTo, string sFldName, SPList oToList, bool bSynchEditable)
        {
            if(!sSynchedFields.Contains(sFldName)) // check if this field has already been processed.  if so, skip
            {
                SPField fldFromField = null;

                try
                {
                    fldFromField = oFromList.Fields.GetFieldByInternalName(sFldName);
                }
                catch { }

                if(fldFromField != null)
                {
                    SPField fldToTest = null;
                    bool? bShowInEditForm;
                    bool? bShowInNewForm;
                    bool bReadOnly;
                    bool bHidden;
                    int iVersion;


                    try
                    {

                        sSynchedFields.Add(sFldName);

                        try
                        {
                            fldToTest = oToList.Fields.GetFieldByInternalName(sFldName);
                        }
                        catch { }

                        if(fldToTest != null)
                        {
                            // backup current field properties
                            bShowInEditForm = (bool?)fldToTest.ShowInEditForm;
                            bShowInNewForm = (bool?)fldToTest.ShowInNewForm;
                            bReadOnly = (bool)fldToTest.ReadOnlyField;
                            bHidden = (bool)fldToTest.Hidden;
                            iVersion = fldToTest.Version;

                            // only for Title field
                            if(sFldName == "Title")
                            {
                                try
                                {
                                    fldToTest.Title = fldFromField.Title;
                                    fldToTest.Description = fldFromField.Description;
                                    fldToTest.Update();
                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldToTest.Title + "): Success.<br>";
                                    // exit here. do nothing else
                                }
                                catch(Exception exc)
                                {
                                    bErrors = true;
                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (Title) - Not synched: Display name not synched.  " + exc.Message.Replace("'", "") + "</font><br>";
                                }
                            }

                            Boolean bIsUpdatable = false;
                            if(!fldToTest.Sealed)
                            {
                                bIsUpdatable = true;
                            }
                            else
                            {
                                try
                                {
                                    fldToTest.Sealed = false; // some sealed fields will error here: Operation is not valid due to the current state of the object.
                                    bIsUpdatable = true;
                                }
                                catch(Exception e)
                                {
                                }
                            }

                            if(bIsUpdatable)
                            {
                                bool bCreatedNewField = false;
                                if(fldToTest.TypeAsString != fldFromField.TypeAsString)
                                {
                                    if(fldFromField.Type == SPFieldType.Invalid)
                                    {
                                        sSynchedFields.Remove(sFldName);
                                        fldToTest.Delete();
                                        createOrUpdateFieldRecursive(webTo, sFldName, oToList, bSynchEditable);
                                        bCreatedNewField = true;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            fldToTest.Type = fldFromField.Type;
                                        }
                                        catch(Exception ex)
                                        {
                                            sSynchedFields.Remove(sFldName);
                                            fldToTest.Delete();
                                            createOrUpdateFieldRecursive(webTo, sFldName, oToList, bSynchEditable);
                                            bCreatedNewField = true;
                                        }
                                    }
                                }
                                if(!bCreatedNewField)
                                {
                                    if((SyncType)enSyncType == SyncType.List)
                                    {
                                        if(fldFromField.Type == SPFieldType.Calculated)
                                        {
                                            SPFieldCalculated fldFromFieldCalculated = (SPFieldCalculated)fldFromField;
                                            SPFieldCalculated fldNewFieldCalculated = (SPFieldCalculated)fldToTest;
                                            if(fldFromFieldCalculated.FieldReferences != null)
                                            {
                                                foreach(string sFieldRef in fldFromFieldCalculated.FieldReferences)
                                                {
                                                    if(sFieldRef != "Today" && sFieldRef != "Created" && sFieldRef != "Modified" && sFieldRef != "Author" && sFieldRef != "Editor" && sFieldRef != "ContentType" && sFieldRef != "Order")
                                                    {
                                                        createOrUpdateFieldRecursive(webTo, sFieldRef, oToList, bSynchEditable);
                                                    }
                                                }
                                            }
                                            fldNewFieldCalculated.Formula = fldFromFieldCalculated.Formula;
                                            fldNewFieldCalculated.CurrencyLocaleId = fldFromFieldCalculated.CurrencyLocaleId;


                                            XmlDocument newDocXml = new XmlDocument();
                                            newDocXml.LoadXml(fldNewFieldCalculated.SchemaXml);

                                            XmlDocument oldDocXml = new XmlDocument();
                                            oldDocXml.LoadXml(fldFromFieldCalculated.SchemaXml);

                                            setAttr(ref newDocXml, oldDocXml, "ResultType");
                                            setAttr(ref newDocXml, oldDocXml, "Percentage");
                                            setAttr(ref newDocXml, oldDocXml, "Decimals");
                                            setAttr(ref newDocXml, oldDocXml, "Format");
                                            setAttr(ref newDocXml, oldDocXml, "OutputType");

                                            //fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("ResultType=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "ResultType") + "\"", "ResultType=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "ResultType") + "\"");
                                            //if (fldNewFieldCalculated.SchemaXml.Contains("Format"))
                                            //{
                                            //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("Format=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "Format") + "\"", "Format=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Format") + "\"");
                                            //}
                                            //else
                                            //{
                                            //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("<Field ", "<Field Format=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Format") + "\" ");
                                            //}
                                            //if (fldNewFieldCalculated.SchemaXml.Contains("Percentage"))
                                            //{
                                            //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("Percentage=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "Percentage") + "\"", "Percentage=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Percentage") + "\"");
                                            //}
                                            //else
                                            //{
                                            //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("<Field ", "<Field Percentage=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Percentage") + "\" ");
                                            //}
                                            //if (fldNewFieldCalculated.SchemaXml.Contains("Decimals"))
                                            //{
                                            //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("Decimals=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "Decimals") + "\"", "Decimals=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Decimals") + "\"");
                                            //}
                                            //else
                                            //{
                                            //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("<Field ", "<Field Decimals=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Decimals") + "\" ");
                                            //}


                                            fldNewFieldCalculated.SchemaXml = newDocXml.OuterXml;
                                            fldNewFieldCalculated.Title = fldFromFieldCalculated.Title;
                                            fldNewFieldCalculated.Description = fldFromFieldCalculated.Description;
                                            if(!bSynchEditable) fldNewFieldCalculated.ShowInNewForm = bShowInNewForm;
                                            if(!bSynchEditable) fldNewFieldCalculated.ShowInEditForm = bShowInEditForm;
                                            if(!bSynchEditable && fldToTest.CanToggleHidden) fldNewFieldCalculated.Hidden = bHidden;
                                            fldNewFieldCalculated.ReadOnlyField = bReadOnly;
                                            //fldNewFieldCalculated.Update();
                                        }
                                        else
                                        {
                                            fldToTest.SchemaXml = fldFromField.SchemaXml.Replace(oFromList.ID.ToString(), oToList.ID.ToString());
                                            fldToTest.SchemaXml = fldToTest.SchemaXml.Replace("Version=\"" + fldFromField.Version + "\"", "Version=\"" + iVersion + "\"");
                                            fldToTest.DefaultValue = fldFromField.DefaultValue;
                                            fldToTest.Title = fldFromField.Title;
                                            fldToTest.Required = fldFromField.Required;
                                        }
                                        if(fldFromField.Type == SPFieldType.Lookup)
                                        {
                                            string sTopListId = getFieldSchemaAttribValue(fldFromField.SchemaXml, "List");
                                            string sTopListName = "";
                                            try
                                            {
                                                sTopListName = FromWeb.Lists[new Guid(sTopListId)].Title;
                                                string sSubListId = "";
                                                try
                                                {
                                                    sSubListId = webTo.GetList(webTo.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sTopListName).ID.ToString();
                                                    fldToTest.SchemaXml = fldFromField.SchemaXml.Replace(sTopListId, "{" + sSubListId + "}");
                                                }
                                                catch(Exception exLkUp)
                                                {
                                                    bErrors = true;
                                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: the Lookup field could not find & reference list " + sTopListName + " in the child synch to site.</font><br>";
                                                    return;
                                                }
                                            }
                                            catch(Exception exFromList)
                                            {
                                                bErrors = true;
                                                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: the Lookup field could not find & reference list " + sTopListName + " in the template site.</font><br>";
                                                return;
                                            }
                                        }
                                    }

                                    // do for both List & Template sync
                                    if(!bSynchEditable) fldToTest.ShowInNewForm = bShowInNewForm;
                                    if(!bSynchEditable) fldToTest.ShowInEditForm = bShowInEditForm;
                                    if(!bSynchEditable && fldToTest.CanToggleHidden) fldToTest.Hidden = bHidden;
                                    fldToTest.ReadOnlyField = bReadOnly;

                                    try
                                    {
                                        if(fldFromField.TypeAsString == "FilteredLookup")
                                        {
                                            // get custom props for this custom field
                                            //FilteredLookupField fldFromFilteredLkup = (FilteredLookupField)fldFromField;
                                            try
                                            {
                                                //FilteredLookupField fldToFilteredLkup = (FilteredLookupField)fldToTest;
                                                //fldToFilteredLkup.ListViewFilter = fldFromFilteredLkup.ListViewFilter;
                                                //fldToFilteredLkup.QueryFilterAsString = fldFromFilteredLkup.QueryFilterAsString;
                                                //fldToFilteredLkup.AllowMultipleValues = fldFromFilteredLkup.AllowMultipleValues;
                                                //fldToFilteredLkup.IsFilterRecursive = fldFromFilteredLkup.IsFilterRecursive;
                                                //fldToFilteredLkup.ListViewFilter = fldFromFilteredLkup.ListViewFilter;
                                                //fldToTest = fldToFilteredLkup;
                                                //fldToFilteredLkup = null;
                                                //fldFromFilteredLkup = null;


                                                fldToTest.SetCustomProperty("ListViewFilter", fldFromField.GetCustomProperty("ListViewFilter"));
                                                fldToTest.SetCustomProperty("QueryFilterAsString", fldFromField.GetCustomProperty("QueryFilterAsString"));
                                                fldToTest.SetCustomProperty("QueryFilterAsString", fldFromField.GetCustomProperty("QueryFilterAsString"));
                                                fldToTest.SetCustomProperty("AllowMultipleValues", fldFromField.GetCustomProperty("AllowMultipleValues"));
                                                fldToTest.SetCustomProperty("IsFilterRecursive", fldFromField.GetCustomProperty("IsFilterRecursive"));
                                            }
                                            catch(Exception ex)
                                            {
                                                bErrors = true;
                                                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: Could not sync field " + fldToTest.Title + "(" + fldToTest.TypeAsString + ") as type FilteredLookup.</font><br>";
                                            }
                                        }
                                        else if(fldFromField.TypeAsString == "TotalRollup")
                                        {
                                            //TotalsRollupField fldFromTRlup = (TotalsRollupField)fldFromField;
                                            try
                                            {
                                                //TotalsRollupField fldToTRlup = (TotalsRollupField)fldToTest;
                                                //fldToTRlup.ListName = fldFromTRlup.ListName;
                                                //fldToTRlup.ListQuery = fldFromTRlup.ListQuery;
                                                //fldToTRlup.AggType = fldFromTRlup.AggType;
                                                //fldToTRlup.AggColumn = fldFromTRlup.AggColumn;
                                                //fldToTRlup.Decimals = fldFromTRlup.Decimals;
                                                //fldToTRlup.LookupColumn = fldFromTRlup.LookupColumn;
                                                //fldToTest = fldToTRlup;
                                                //fldToTRlup = null;
                                                //fldFromTRlup = null;

                                                fldToTest.SetCustomProperty("ListName", fldFromField.GetCustomProperty("ListName"));
                                                fldToTest.SetCustomProperty("ListQuery", fldFromField.GetCustomProperty("ListQuery"));
                                                fldToTest.SetCustomProperty("AggType", fldFromField.GetCustomProperty("AggType"));
                                                fldToTest.SetCustomProperty("AggColumn", fldFromField.GetCustomProperty("AggColumn"));
                                                fldToTest.SetCustomProperty("Decimals", fldFromField.GetCustomProperty("Decimals"));
                                                fldToTest.SetCustomProperty("LookupColumn", fldFromField.GetCustomProperty("LookupColumn"));
                                                fldToTest.SetCustomProperty("OutputType", fldFromField.GetCustomProperty("OutputType"));
                                            }
                                            catch(Exception ex)
                                            {
                                                bErrors = true;
                                                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: Could not sync field " + fldToTest.Title + "(" + fldToTest.TypeAsString + ") as type TotalRollup.</font><br>";
                                            }
                                        }

                                        //fldToTest.Update();

                                        if((SyncType)enSyncType == SyncType.List)
                                        {
                                            try
                                            {
                                                fldToTest.AllowDeletion = false;
                                                fldToTest.Sealed = true;
                                                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldToTest.Title + "): Success.<br>";
                                            }
                                            catch(Exception exc)
                                            {
                                                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldToTest.Title + "): Synched but could not seal.<br>";
                                            }
                                        }
                                        else
                                        {
                                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldToTest.Title + "): Success.<br>";
                                        }
                                    }
                                    catch(Exception exc)
                                    {
                                        if(!exc.Message.Contains("The SQL Server might not be started"))
                                        {
                                            bErrors = true;
                                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched rrr: " + exc.Message.Replace("'", "") + "</font><br>";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if(sFldName != "Title")
                                {
                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: the " + sFldName + " field cannot be synched since it is sealed.</font><br>";
                                }
                            }
                        }
                        else//New Field
                        {
                            if(fldFromField.Type == SPFieldType.Calculated)
                            {
                                try
                                {
                                    SPFieldCalculated fldNewFieldCalculated = null;
                                    if(fldFromField.InternalName.Contains("_x0020"))
                                    {
                                        oToList.Fields.Add(fldFromField.Title, SPFieldType.Calculated, false);
                                        fldNewFieldCalculated = (SPFieldCalculated)oToList.Fields[fldFromField.Title];
                                    }
                                    else
                                    {
                                        oToList.Fields.Add(fldFromField.InternalName, SPFieldType.Calculated, false);
                                        fldNewFieldCalculated = (SPFieldCalculated)oToList.Fields.GetFieldByInternalName(fldFromField.InternalName);
                                    }
                                    SPFieldCalculated fldFromFieldCalculated = (SPFieldCalculated)fldFromField;
                                    if(fldFromFieldCalculated.FieldReferences != null)
                                    {
                                        foreach(string sFieldRef in fldFromFieldCalculated.FieldReferences)
                                        {
                                            if(sFieldRef != "Today" && sFieldRef != "Created" && sFieldRef != "Modified" && sFieldRef != "Author" && sFieldRef != "Editor" && sFieldRef != "ContentType" && sFieldRef != "Order")
                                            {
                                                createOrUpdateFieldRecursive(webTo, sFieldRef, oToList, bSynchEditable);
                                            }
                                        }
                                    }
                                    fldNewFieldCalculated.Formula = fldFromFieldCalculated.Formula;
                                    fldNewFieldCalculated.CurrencyLocaleId = fldFromFieldCalculated.CurrencyLocaleId;

                                    XmlDocument newDocXml = new XmlDocument();
                                    newDocXml.LoadXml(fldNewFieldCalculated.SchemaXml);

                                    XmlDocument oldDocXml = new XmlDocument();
                                    oldDocXml.LoadXml(fldFromFieldCalculated.SchemaXml);

                                    setAttr(ref newDocXml, oldDocXml, "ResultType");
                                    setAttr(ref newDocXml, oldDocXml, "Percentage");
                                    setAttr(ref newDocXml, oldDocXml, "Decimals");
                                    setAttr(ref newDocXml, oldDocXml, "Format");

                                    //fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("ResultType=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "ResultType") + "\"", "ResultType=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "ResultType") + "\"");
                                    //if (fldNewFieldCalculated.SchemaXml.Contains("Format"))
                                    //{
                                    //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("Format=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "Format") + "\"", "Format=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Format") + "\"");
                                    //}
                                    //else
                                    //{
                                    //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("<Field ", "<Field Format=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Format") + "\" ");
                                    //}
                                    //if (fldNewFieldCalculated.SchemaXml.Contains("Percentage"))
                                    //{
                                    //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("Percentage=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "Percentage") + "\"", "Percentage=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Percentage") + "\"");
                                    //}
                                    //else
                                    //{
                                    //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("<Field ", "<Field Percentage=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Percentage") + "\" ");
                                    //}
                                    //if (fldNewFieldCalculated.SchemaXml.Contains("Decimals"))
                                    //{
                                    //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("Decimals=\"" + getFieldSchemaAttribValue(fldNewFieldCalculated.SchemaXml, "Decimals") + "\"", "Decimals=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Decimals") + "\"");
                                    //}
                                    //else
                                    //{
                                    //    fldNewFieldCalculated.SchemaXml = fldNewFieldCalculated.SchemaXml.Replace("<Field ", "<Field Decimals=\"" + getFieldSchemaAttribValue(fldFromFieldCalculated.SchemaXml, "Decimals") + "\" ");
                                    //}

                                    fldNewFieldCalculated.SchemaXml = newDocXml.OuterXml;

                                    fldNewFieldCalculated.Description = fldFromFieldCalculated.Description;
                                    string sNewFldName = fldFromFieldCalculated.Title;
                                    fldNewFieldCalculated.Title = sNewFldName;
                                    fldNewFieldCalculated.Update();
                                    if((SyncType)enSyncType == SyncType.List)
                                    {
                                        fldNewFieldCalculated.Sealed = true;
                                    }
                                    if(fldNewFieldCalculated.InternalName != fldFromField.InternalName)
                                    {
                                        bErrors = true;
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: the internal name of this field does not match to top field.  This field will be deleted and views referencing this field will not be synched.</font><br>";
                                    }
                                    else
                                    {
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + sNewFldName + "): Success.<br>";
                                    }
                                }
                                catch(Exception ex)
                                {
                                }
                            }
                            else
                            {
                                SPField fldCheck = null;
                                try
                                {
                                    fldCheck = oToList.Fields[sFldName];
                                }
                                catch { }
                                if(fldCheck != null)
                                {
                                    oToList.Fields[sFldName].Delete();
                                }

                                //                                SPField field = new SPField(oToList.Fields, fldFromField.TypeAsString, fldFromField.InternalName);
                                if(fldFromField.Type == SPFieldType.Invalid)
                                {
                                    try
                                    {
                                        oToList.Fields.Add(fldFromField);
                                    }
                                    catch { }
                                }
                                else
                                {
                                    oToList.Fields.Add(fldFromField);
                                }

                                SPField fldNewField = oToList.Fields.GetFieldByInternalName(sFldName);
                                fldNewField.SchemaXml = fldFromField.SchemaXml.Replace(oFromList.ID.ToString(), oToList.ID.ToString());
                                if(fldFromField.Type == SPFieldType.Lookup)
                                {
                                    string sTopListId = getFieldSchemaAttribValue(fldFromField.SchemaXml, "List");
                                    string sTopListName = "";
                                    try
                                    {
                                        sTopListName = oFromList.ParentWeb.Lists[new Guid(sTopListId)].Title;
                                        string sSubListId = "";
                                        try
                                        {
                                            sSubListId = webTo.GetList(webTo.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sTopListName).ID.ToString();
                                            fldNewField.SchemaXml = fldFromField.SchemaXml.Replace(sTopListId, "{" + sSubListId + "}");
                                        }
                                        catch(Exception exLkUpNew)
                                        {
                                            bErrors = true;
                                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: the Lookup field could not find the reference list (" + sTopListName + ") in the child synch to site.</font><br>";
                                        }
                                    }
                                    catch(Exception exFromList)
                                    {
                                        bErrors = true;
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: the Lookup field could not find the reference list (" + sTopListName + ") in the parent synch from site.</font><br>";
                                    }
                                }
                                //else if (fldFromField.TypeAsString == "FilteredLookup")
                                //{
                                //    // get custom props for this custom field
                                //    //FilteredLookupField fldFromFilteredLkup = (FilteredLookupField)fldFromField;
                                //    //FilteredLookupField fldNewFilteredLkup = (FilteredLookupField)fldNewField;
                                //    //fldNewFilteredLkup.ListViewFilter = fldFromFilteredLkup.ListViewFilter;
                                //    //fldNewFilteredLkup.QueryFilterAsString = fldFromFilteredLkup.QueryFilterAsString;
                                //    //fldNewFilteredLkup.AllowMultipleValues = fldFromFilteredLkup.AllowMultipleValues;
                                //    //fldNewFilteredLkup.IsFilterRecursive = fldFromFilteredLkup.IsFilterRecursive;
                                //    //fldNewFilteredLkup.ListViewFilter = fldFromFilteredLkup.ListViewFilter;
                                //    //fldNewField = fldNewFilteredLkup;
                                //    //fldNewFilteredLkup = null;
                                //    //fldFromFilteredLkup = null;

                                //    fldNewField.SetCustomProperty("ListViewFilter", fldFromField.GetCustomProperty("ListViewFilter"));
                                //    fldNewField.SetCustomProperty("QueryFilterAsString", fldFromField.GetCustomProperty("QueryFilterAsString"));
                                //    fldNewField.SetCustomProperty("QueryFilterAsString", fldFromField.GetCustomProperty("QueryFilterAsString"));
                                //    fldNewField.SetCustomProperty("AllowMultipleValues", fldFromField.GetCustomProperty("AllowMultipleValues"));
                                //    fldNewField.SetCustomProperty("IsFilterRecursive", fldFromField.GetCustomProperty("IsFilterRecursive"));
                                //}
                                //else if (fldFromField.TypeAsString == "TotalRollup")
                                //{
                                //    //TotalsRollupField fldFromTRlup = (TotalsRollupField)fldFromField;
                                //    //TotalsRollupField fldNewTRlup = (TotalsRollupField)fldNewField;
                                //    //fldNewTRlup.ListName = fldFromTRlup.ListName;
                                //    //fldNewTRlup.ListQuery = fldFromTRlup.ListQuery;
                                //    //fldNewTRlup.AggType = fldFromTRlup.AggType;
                                //    //fldNewTRlup.AggColumn = fldFromTRlup.AggColumn;
                                //    //fldNewTRlup.Decimals = fldFromTRlup.Decimals;
                                //    //fldNewTRlup.LookupColumn = fldFromTRlup.LookupColumn;
                                //    //fldNewField = fldNewTRlup;
                                //    //fldNewTRlup = null;
                                //    //fldFromTRlup = null;

                                //    //fldNewField.SetCustomProperty("ListName", fldFromField.GetCustomProperty("ListName"));
                                //    //fldNewField.SetCustomProperty("ListQuery", fldFromField.GetCustomProperty("ListQuery"));
                                //    //fldNewField.SetCustomProperty("AggType", fldFromField.GetCustomProperty("AggType"));
                                //    //fldNewField.SetCustomProperty("AggColumn", fldFromField.GetCustomProperty("AggColumn"));
                                //    //fldNewField.SetCustomProperty("Decimals", fldFromField.GetCustomProperty("Decimals"));
                                //    //fldNewField.SetCustomProperty("LookupColumn", fldFromField.GetCustomProperty("LookupColumn"));
                                //}
                                fldNewField.Sealed = true;
                                if((SyncType)enSyncType == SyncType.List)
                                {
                                    try
                                    {
                                        fldNewField.Sealed = true;
                                        fldNewField.Update();
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldNewField.Title + "): Success.<br>";
                                    }
                                    catch(Exception exc)
                                    {
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldNewField.Title + "): Synched but could not seal.<br>";
                                    }
                                }
                                else
                                {
                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Field (" + fldNewField.Title + "): Success.<br>";
                                }
                            }
                        }
                    }
                    catch(Exception exc)
                    {
                        if(!exc.Message.Contains("The SQL Server might not be started"))
                        {
                            bErrors = true;
                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: " + exc.Message.Replace("'", "") + "</font><br>";
                        }
                    }

                }
                else
                {
                    bErrors = true;
                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Field (" + sFldName + ") - Not synched: Field does not exist in from list.</font><br>";
                }
            }
        }

        private void synchViews(SPWeb oTemplateWeb, SPList oFromList, SPWeb oToWeb, SPList oToList, string[] arrViews)
        {

            SPView oFromView;
            SPView oToView;
            string[] arrViewURLs = new string[arrViews.Length];
            Dictionary<string, string> arrViewGroupByXML = new Dictionary<string, string>();

            string sCurrViewName = "";
            XmlDocument xOldToViewQuery = new XmlDocument();
            XmlDocument xToViewQuery = new XmlDocument();
            SPViewCollection.SPViewType oVType;
            SPFile fFromView;
            SPFile fToView = null;
            SPLimitedWebPartManager oFromWebpartManager;
            SPLimitedWebPartManager oToWebpartManager = null;
            Microsoft.SharePoint.WebPartPages.WebPart[] arrOldWebParts;
            Microsoft.SharePoint.WebPartPages.WebPart wp;
            SPLimitedWebPartCollection wpcFrom;
            SPViewStyleCollection vStyleCol;

            string sViewId;
            for(int i = 0; i < arrViews.Length; i++)
            {
                sViewId = arrViews[i];
                try
                {
                    Guid vGuid = new Guid(sViewId);
                    oFromView = oFromList.GetView(vGuid);

                    if(oFromView != null && (!oFromView.Hidden || !String.IsNullOrEmpty(oFromView.Title)))
                    {
                        arrViewURLs[i] = oFromView.Url.Substring(oFromView.Url.LastIndexOf("/") + 1).Replace(".aspx", "");
                    }
                }
                catch(Exception ex)
                {
                }
            }

            List<Guid> arrViewIDs = new List<Guid>();
            foreach(SPView v in oToList.Views)
            {
                if(isSynchedView(v.Url.Substring(v.Url.LastIndexOf("/") + 1).Replace(".aspx", ""), arrViewURLs))
                {
                    arrViewIDs.Add(v.ID);
                }
            }
            foreach(Guid iViewID in arrViewIDs)
            {
                try
                {
                    string sViewURL = oToList.GetView(iViewID).Url;
                    arrViewGroupByXML.Add(sViewURL.Substring(sViewURL.LastIndexOf("/") + 1).Replace(".aspx", ""), oToList.GetView(iViewID).Query);
                    oToList.Views.Delete(iViewID);
                }
                catch(Exception ex) { }
            }

            bool bSyncListSettings = false;
            for(int i = 0; i < arrViews.Length; i++)
            {
                try
                {
                    oFromView = oFromList.GetView(new Guid(arrViews[i]));
                    sCurrViewName = oFromView.Title;

                    oToWeb.AllowUnsafeUpdates = true;
                    bool bIsDefaultView = false;
                    bool bIsDefaultViewForContentType = false;
                    bIsDefaultView = oFromView.DefaultView;
                    bIsDefaultViewForContentType = oFromView.DefaultViewForContentType;
                    // save old groupings/filter
                    if(!bSyncViewGroupBySettings)
                    {
                        if(arrViewGroupByXML.Count > 0)
                        {
                            try
                            {
                                xOldToViewQuery.LoadXml("<Query>" + arrViewGroupByXML[oFromView.Url.Substring(oFromView.Url.LastIndexOf("/") + 1).Replace(".aspx", "")] + "</Query>");
                            }
                            catch { }
                        }
                    }

                    string sViewNameInURL = oFromView.Url.Substring(oFromView.Url.LastIndexOf("/") + 1).Replace(".aspx", "");

                    string sViewType = FirstLetterUCase(oFromView.Type);
                    oVType = (SPViewCollection.SPViewType)Enum.Parse(typeof(SPViewCollection.SPViewType), sViewType);
                    oToView = oToList.Views.Add(sViewNameInURL, oFromView.ViewFields.ToStringCollection(), oFromView.Query, oFromView.RowLimit, oFromView.Paged, oFromView.DefaultView, oVType, oFromView.PersonalView);
                    oToView.Title = oFromView.Title;
                    oToView.Update();
                    oToView.Aggregations = oFromView.Aggregations;
                    oToView.MobileView = oFromView.MobileView;
                    oToView.MobileDefaultView = oFromView.MobileDefaultView;
                    if(oFromView.StyleID != null)
                    {
                        vStyleCol = oToWeb.ViewStyles;
                        oToView.ApplyStyle(vStyleCol.StyleByID(int.Parse(oFromView.StyleID)));
                    }

                    oToView.DefaultView = bIsDefaultView;
                    oToView.DefaultViewForContentType = bIsDefaultViewForContentType;
                    oToView.Update();

                    // apply old groupings/filter
                    if(!bSyncViewGroupBySettings)
                    {
                        try
                        {
                            xToViewQuery.RemoveAll();
                            xToViewQuery.LoadXml("<Query>" + oToView.Query + "</Query>");
                            if(xOldToViewQuery.SelectSingleNode("//GroupBy") != null)
                            {
                                xOldToViewQuery.FirstChild.RemoveChild(xOldToViewQuery.SelectSingleNode("//GroupBy"));
                            }
                            string sViewURL = oToView.Url;
                            if(arrViewGroupByXML.ContainsKey(sViewURL.Substring(sViewURL.LastIndexOf("/") + 1).Replace(".aspx", "")))
                            {
                                string oldg = arrViewGroupByXML[sViewURL.Substring(sViewURL.LastIndexOf("/") + 1).Replace(".aspx", "")];
                                XmlDocument docOldGroup = new XmlDocument();
                                docOldGroup.LoadXml("<Query>" + oldg + "</Query>");
                                if(docOldGroup.SelectSingleNode("//GroupBy") != null)
                                {
                                    XmlNode ndGroup = xOldToViewQuery.CreateNode(XmlNodeType.Element, "GroupBy", xOldToViewQuery.NamespaceURI);
                                    ndGroup.InnerXml = docOldGroup.SelectSingleNode("//GroupBy").InnerXml;

                                    if(docOldGroup.SelectSingleNode("//GroupBy").Attributes["Collapse"] != null)
                                    {
                                        XmlAttribute attr = xOldToViewQuery.CreateAttribute("Collapse");
                                        attr.Value = docOldGroup.SelectSingleNode("//GroupBy").Attributes["Collapse"].Value;
                                        ndGroup.Attributes.Append(attr);
                                    }
                                    if(docOldGroup.SelectSingleNode("//GroupBy").Attributes["GroupLimit"] != null)
                                    {
                                        XmlAttribute attr = xOldToViewQuery.CreateAttribute("GroupLimit");
                                        attr.Value = docOldGroup.SelectSingleNode("//GroupBy").Attributes["GroupLimit"].Value;
                                        ndGroup.Attributes.Append(attr);
                                    }

                                    xOldToViewQuery.FirstChild.PrependChild(ndGroup);
                                }
                            }
                            if(xOldToViewQuery.FirstChild != null)
                                oToView.Query = xOldToViewQuery.FirstChild.InnerXml;

                            oToView.Update();
                        }
                        catch(Exception exc)
                        {
                            bErrors = true;
                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >View (" + oFromView.Title + ") - local view Group By settings not saved. Message: " + exc.Message.Replace("'", "") + "</font><br>";
                        }
                    }

                    if(!bSyncListSettings)
                    {
                        try
                        {
                            syncListSettings(oTemplateWeb, oFromList, oToList, "", false);
                            bSyncListSettings = true;
                        }
                        catch(Exception e)
                        {
                        }
                    }

                    oToWeb.Update();

                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;View (" + oFromView.Title + "): Success.<br>";

                    // copy web parts
                    fFromView = oTemplateWeb.GetFile(oFromView.Url);
                    oFromWebpartManager = fFromView.GetLimitedWebPartManager(PersonalizationScope.Shared);
                    bool viewCheckedOut = false;
                    try
                    {
                        // Check out the page so it can be modified.
                        fToView = oToWeb.GetFile(oToView.Url);
                        fToView.CheckOut();
                        viewCheckedOut = true;

                        oToWebpartManager = fToView.GetLimitedWebPartManager(PersonalizationScope.Shared);
                        // Delete old web parts
                        arrOldWebParts = null;
                        arrOldWebParts = new Microsoft.SharePoint.WebPartPages.WebPart[oToWebpartManager.WebParts.Count];
                        int iCnt = 0;

                        Guid oCurrentToXLST = Guid.Empty;

                        for(int iWebParts = 0; iWebParts < oToWebpartManager.WebParts.Count; iWebParts++)
                        {
                            wp = (Microsoft.SharePoint.WebPartPages.WebPart)oToWebpartManager.WebParts[iWebParts];
                            if(typeof(Microsoft.SharePoint.WebPartPages.XsltListViewWebPart) == wp.GetType())
                            {
                                oCurrentToXLST = wp.StorageKey;
                            }
                            else if(wp.IsShared)
                            {
                                arrOldWebParts[iCnt] = wp;
                                iCnt++;
                            }
                        }
                        for(int iOldWebParts = 0; iOldWebParts < arrOldWebParts.Length; iOldWebParts++)
                        {
                            wp = arrOldWebParts[iOldWebParts];
                            if(wp != null && typeof(Microsoft.SharePoint.WebPartPages.XsltListViewWebPart) != wp.GetType() && wp.GetType().ToString() != "Microsoft.SharePoint.WebPartPages.ErrorWebPart" && wp.IsShared)
                            {
                                try
                                {
                                    oToWebpartManager.DeleteWebPart(wp);
                                }
                                catch(Exception exc)
                                {
                                    bErrors = true;
                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Webpart (" + wp.Title + ") - Not synched. Error message(1): " + exc.Message.Replace("'", "") + "</font><br>";
                                }
                            }
                        }

                        // Add the Web Parts
                        wpcFrom = oFromWebpartManager.WebParts;
                        for(int iFromWebParts = 0; iFromWebParts < wpcFrom.Count; iFromWebParts++)
                        {
                            wp = (Microsoft.SharePoint.WebPartPages.WebPart)wpcFrom[iFromWebParts];
                            if(typeof(Microsoft.SharePoint.WebPartPages.XsltListViewWebPart) == wp.GetType())
                            {
                                //if(oCurrentToXLST != Guid.Empty)
                                //{
                                //    setToolbar((Microsoft.SharePoint.WebPartPages.XsltListViewWebPart)oToWebpartManager.WebParts[oCurrentToXLST]);
                                //}
                            }
                            else if(wp != null && wp.GetType().ToString() != "Microsoft.SharePoint.WebPartPages.ErrorWebPart" && wp.IsShared)
                            {
                                try
                                {
                                    oToWebpartManager.AddWebPart(wp, wp.ZoneID, 0);
                                }
                                catch(Exception exc)
                                {
                                    bErrors = true;
                                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Webpart (" + wp.Title + ") (" + wp.GetType().ToString() + ") - Not synched. Error message (2): " + exc.Message.Replace("'", "") + "</font><br>";
                                }
                            }
                        }
                        setToolbar((Microsoft.SharePoint.WebPartPages.XsltListViewWebPart)oToWebpartManager.WebParts[oCurrentToXLST], oFromView.ToolbarType);
                    }
                    catch(Exception exc)
                    {
                        bErrors = true;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >View (" + oFromView.Title + ") - Not synched. Message: " + exc.Message.Replace("'", "") + "</font><br>";
                    }
                    finally
                    {
                        // Check in and publish the page.
                        if(viewCheckedOut)
                        {
                            fToView.CheckIn("Added web parts.", SPCheckinType.MajorCheckIn);
                        }
                        wpcFrom = null;
                        arrOldWebParts = null;
                        oToWebpartManager.Web.Close();
                        oFromWebpartManager.Web.Close();
                        oFromWebpartManager.Dispose();
                        oToWebpartManager.Dispose();
                        fFromView = null;
                        GC.Collect();
                    }
                    //fToView.Update();
                    //fToView = null;
                }
                catch(Exception exc)
                {
                    if(sCurrViewName != "")
                    {
                        bErrors = true;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >View (" + sCurrViewName + ") - Not synched. Message: " + exc.Message.Replace("'", "") + "</font><br>";
                    }
                }

                oToWeb.Update();
                oToWeb.AllowUnsafeUpdates = false;
            }

            oToView = null;
            oFromView = null;
        }

        public void setToolbar(XsltListViewWebPart lvwpTo, string sShow)
        {
            MethodInfo ensureViewMethod = lvwpTo.GetType().GetMethod("EnsureView", BindingFlags.Instance | BindingFlags.NonPublic);
            object[] ensureViewParams = { };
            ensureViewMethod.Invoke(lvwpTo, ensureViewParams);
            FieldInfo viewFieldInfo = lvwpTo.GetType().GetField("view", BindingFlags.NonPublic | BindingFlags.Instance);
            SPView view = viewFieldInfo.GetValue(lvwpTo) as SPView;
            Type[] toolbarMethodParamTypes = { Type.GetType("System.String") };
            MethodInfo setToolbarTypeMethod = view.GetType().GetMethod("SetToolbarType", BindingFlags.Instance | BindingFlags.NonPublic, null, toolbarMethodParamTypes, null);
            object[] setToolbarParam = { sShow }; //set the type here
            object ret = setToolbarTypeMethod.Invoke(view, setToolbarParam);
            view.Update();

        }

        public string FirstLetterUCase(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }

        private void synchViews(SPWeb oTemplateWeb, SPList oFromList, SPWeb oToWeb, SPList oToList)
        {
            SPView oToView;
            SPView oFromView;
            string sViewName;

            XmlDocument xOldToViewQuery = new XmlDocument();
            XmlDocument xToViewQuery = new XmlDocument();

            string sViewType;
            string sViewNameInURL;
            SPViewCollection.SPViewType oVType;
            SPViewStyleCollection vStyleCol;

            SPFile fFromView;
            SPLimitedWebPartManager oFromWebpartManager;
            SPFile fToView = null;
            bool viewCheckedOut = false;
            SPLimitedWebPartManager oToWebpartManager = null;
            Microsoft.SharePoint.WebPartPages.WebPart[] arrOldWebParts;
            SPLimitedWebPartCollection wpcFrom;

            bool bSyncListSettings = false;
            for(int i = 0; i < oFromList.Views.Count; i++)
            {
                oFromView = oFromList.Views[i];
                sViewName = oFromView.Title;
                if(!oFromView.Hidden || !String.IsNullOrEmpty(oFromView.Title))
                {
                    try
                    {
                        oToWeb.AllowUnsafeUpdates = true;
                        bool bIsDefaultView = false;
                        bool bIsDefaultViewForContentType = false;
                        bIsDefaultView = oFromView.DefaultView;
                        bIsDefaultViewForContentType = oFromView.DefaultViewForContentType;

                        sViewType = FirstLetterUCase(oFromView.Type);
                        sViewNameInURL = oFromView.Url.Substring(oFromView.Url.LastIndexOf("/") + 1).Replace(".aspx", "");
                        oVType = (SPViewCollection.SPViewType)Enum.Parse(typeof(SPViewCollection.SPViewType), sViewType);

                        try
                        {
                            Guid ViewID = new Guid();
                            bool bHasView = false;
                            foreach(SPView v in oToList.Views)
                            {
                                if(v.Url.Substring(v.Url.LastIndexOf("/") + 1).Replace(".aspx", "") == sViewNameInURL)
                                {
                                    ViewID = v.ID;
                                    bHasView = true;
                                    break;
                                }
                            }
                            if(bHasView)
                            {
                                if(!bSyncViewGroupBySettings)
                                {
                                    // save old groupings/filter
                                    try
                                    {
                                        xOldToViewQuery.RemoveAll();
                                        xOldToViewQuery.LoadXml("<Query>" + oToList.GetView(ViewID).Query + "</Query>");
                                    }
                                    catch { }
                                }
                                oToList.Views.Delete(ViewID);
                            }
                        }
                        catch(Exception ex)
                        {
                        }

                        oToView = oToList.Views.Add(sViewNameInURL, oFromView.ViewFields.ToStringCollection(), oFromView.Query, oFromView.RowLimit, oFromView.Paged, oFromView.DefaultView, oVType, oFromView.PersonalView);
                        oToView.Title = oFromView.Title;
                        oToView.Update();
                        oToView.Aggregations = oFromView.Aggregations;
                        oToView.MobileView = oFromView.MobileView;
                        oToView.MobileDefaultView = oFromView.MobileDefaultView;
                        if(oFromView.StyleID != null)
                        {
                            vStyleCol = oToWeb.ViewStyles;
                            oToView.ApplyStyle(vStyleCol.StyleByID(int.Parse(oFromView.StyleID)));
                        }

                        oToView.DefaultView = bIsDefaultView;
                        oToView.DefaultViewForContentType = bIsDefaultViewForContentType;
                        // apply old groupings/filter
                        if(!bSyncViewGroupBySettings)
                        {
                            try
                            {
                                xToViewQuery.LoadXml("<Query>" + oToView.Query + "</Query>");
                                if(xOldToViewQuery.SelectSingleNode("//GroupBy") != null)
                                {
                                    string sNewQuery = "";
                                    if(xToViewQuery.SelectSingleNode("//OrderBy") != null) sNewQuery = xToViewQuery.SelectSingleNode("//OrderBy").OuterXml;
                                    if(xToViewQuery.SelectSingleNode("//Where") != null) sNewQuery = sNewQuery + xToViewQuery.SelectSingleNode("//Where").OuterXml;
                                    oToView.Query = xOldToViewQuery.SelectSingleNode("//GroupBy").OuterXml + sNewQuery;
                                    oToView.Update();
                                }
                            }
                            catch(Exception exc)
                            {
                                bErrors = true;
                                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >View (" + oFromView.Title + ") - local view Group By settings not saved. Message: " + exc.Message.Replace("'", "") + "</font><br>";
                            }
                        }

                        if(!bSyncListSettings)
                        {
                            try
                            {
                                syncListSettings(oTemplateWeb, oFromList, oToList, "", false);
                                bSyncListSettings = true;
                            }
                            catch(Exception e)
                            {
                            }
                        }

                        oToList.Update();
                        oToWeb.Update();

                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;View (" + oFromView.Title + "): Success.<br>";

                        // copy web parts
                        fFromView = oTemplateWeb.GetFile(oFromView.Url);
                        oFromWebpartManager = fFromView.GetLimitedWebPartManager(PersonalizationScope.Shared);
                        fToView = null;
                        viewCheckedOut = false;
                        oToWebpartManager = null;
                        try
                        {
                            // Check out the page so it can be modified.
                            fToView = oToWeb.GetFile(oToView.Url);
                            fToView.CheckOut();
                            viewCheckedOut = true;

                            oToWebpartManager = fToView.GetLimitedWebPartManager(PersonalizationScope.Shared);

                            // Delete old web parts
                            arrOldWebParts = new Microsoft.SharePoint.WebPartPages.WebPart[oToWebpartManager.WebParts.Count];
                            int iCnt = 0;
                            Microsoft.SharePoint.WebPartPages.WebPart wp;
                            for(int iWebParts = 0; iWebParts < oToWebpartManager.WebParts.Count; iWebParts++)
                            {
                                wp = (Microsoft.SharePoint.WebPartPages.WebPart)oToWebpartManager.WebParts[iWebParts];
                                if(typeof(Microsoft.SharePoint.WebPartPages.XsltListViewWebPart) != wp.GetType() && wp.IsShared)
                                {
                                    arrOldWebParts[iCnt] = wp;
                                    iCnt++;
                                }
                            }
                            for(int iOldWebParts = 0; iOldWebParts < arrOldWebParts.Length; iOldWebParts++)
                            {
                                wp = arrOldWebParts[iOldWebParts];
                                if(wp != null && typeof(Microsoft.SharePoint.WebPartPages.XsltListViewWebPart) != wp.GetType() && wp.IsShared)
                                {
                                    try
                                    {
                                        oToWebpartManager.DeleteWebPart(wp);
                                    }
                                    catch(Exception exc)
                                    {
                                        bErrors = true;
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Webpart (" + wp.Title + ") - Not synched. Error message (3): " + exc.Message.Replace("'", "") + "</font><br>";
                                    }
                                }
                            }

                            // Add the Web Parts
                            wpcFrom = oFromWebpartManager.WebParts;
                            for(int iFromWebParts = 0; iFromWebParts < wpcFrom.Count; iFromWebParts++)
                            {
                                wp = (Microsoft.SharePoint.WebPartPages.WebPart)wpcFrom[iFromWebParts];
                                if(wp != null && typeof(Microsoft.SharePoint.WebPartPages.XsltListViewWebPart) != wp.GetType() && wp.IsShared)
                                {
                                    try
                                    {
                                        oToWebpartManager.AddWebPart(wp, wp.ZoneID, 0);
                                    }
                                    catch(Exception exc)
                                    {
                                        bErrors = true;
                                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Webpart (" + wp.Title + ") - Not synched. Error message (4): " + exc.Message.Replace("'", "") + "</font><br>";
                                    }
                                }
                            }
                        }
                        catch(Exception exc)
                        {
                            bErrors = true;
                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >View (" + oFromView.Title + ") - Not synched. Message: " + exc.Message.Replace("'", "") + "</font><br>";
                        }
                        finally
                        {
                            // Check in and publish the page.
                            if(viewCheckedOut)
                            {
                                fToView.CheckIn("Added web parts.", SPCheckinType.MajorCheckIn);
                            }
                            wpcFrom = null;
                            arrOldWebParts = null;
                            oFromWebpartManager.Web.Dispose();
                            oToWebpartManager.Web.Dispose();
                            oFromWebpartManager.Dispose();
                            oToWebpartManager.Dispose();
                            fFromView = null;
                            GC.Collect();
                        }

                        fToView.Update();
                        fToView = null;

                        oToWeb.Update();
                        oToWeb.AllowUnsafeUpdates = false;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >View (" + sViewName + ") - Not synched. Message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                }
            }

            xOldToViewQuery = null;
            xToViewQuery = null;
            oToView = null;
            oFromView = null;
        }

        //private void syncGridGanttSettingsOld(SPList oFromList, SPList oToList)
        //{
        //    string sDVurl = oFromList.DefaultView.Url.ToLower();
        //    if (!String.IsNullOrEmpty(sDVurl))
        //    {
        //        string sGridGanttSettingsProperty = System.IO.Path.GetDirectoryName(sDVurl) + "-gridsettings";
        //        if (ToWeb.Properties.ContainsKey(sGridGanttSettingsProperty) && FromWeb.Properties.ContainsKey(sGridGanttSettingsProperty))
        //        {
        //            ToWeb.AllowUnsafeUpdates = true;
        //            ToWeb.Properties[sGridGanttSettingsProperty] = FromWeb.Properties[sGridGanttSettingsProperty];
        //            ToWeb.Properties.Update();
        //            ToWeb.AllowUnsafeUpdates = false;
        //        }
        //        else
        //        {
        //            if (FromWeb.Properties.ContainsKey(sGridGanttSettingsProperty))
        //            {
        //                ToWeb.AllowUnsafeUpdates = true;
        //                ToWeb.Properties.Add(sGridGanttSettingsProperty, FromWeb.Properties[sGridGanttSettingsProperty].ToString());
        //                ToWeb.Properties.Update();
        //                ToWeb.AllowUnsafeUpdates = false;
        //            }
        //        }
        //        LeftPadding += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"; // add tab spacing
        //        sSiteResults += LeftPadding + "General Settings: Success.<br>";
        //        if (LeftPadding.Length > 29) LeftPadding = LeftPadding.Substring(0, LeftPadding.Length - 30); // reverse tab
        //    }
        //}

        private void syncGridGanttSettings(SPList oFromList, SPList oToList)
        {
            string sDVurl = oFromList.DefaultView.Url.ToLower();
            if(!String.IsNullOrEmpty(sDVurl))
            {

                string sGeneralFrom = EPMLiveCore.CoreFunctions.getListSetting("GeneralSettings", oFromList);
                string sGeneralTo = EPMLiveCore.CoreFunctions.getListSetting("GeneralSettings", oToList);

                EPMLiveCore.CoreFunctions.setListSetting("EnableResourcePlan", EPMLiveCore.CoreFunctions.getListSetting("EnableResourcePlan", oFromList), oToList);


                if(sGeneralFrom != "" && sGeneralTo != "")
                {
                    string[] arrFromGridGanttSettings = sGeneralFrom.Split(chrNewlineSeparator, StringSplitOptions.None);
                    string[] arrToGridGanttSettings = sGeneralTo.Split(chrNewlineSeparator, StringSplitOptions.None);

                    // keep og (sync to site) rollup settings
                    if(arrFromGridGanttSettings.Length > 7 && arrToGridGanttSettings.Length > 7)
                    {
                        arrFromGridGanttSettings[7] = ""; // Item Link Type
                    }
                    if(arrFromGridGanttSettings.Length > 8 && arrToGridGanttSettings.Length > 8)
                    {
                        arrFromGridGanttSettings[8] = arrToGridGanttSettings[8]; // Rollup Lists
                    }
                    if(arrFromGridGanttSettings.Length > 9 && arrToGridGanttSettings.Length > 9)
                    {
                        arrFromGridGanttSettings[9] = arrToGridGanttSettings[9]; // Rollup Sites
                    }

                    string sCombinedGridGanttSettings = "";
                    for(int iCombine = 0; iCombine < arrFromGridGanttSettings.Length; iCombine++)
                    {
                        sCombinedGridGanttSettings += arrFromGridGanttSettings[iCombine] + "\n";
                    }
                    EPMLiveCore.CoreFunctions.setListSetting("GeneralSettings", sCombinedGridGanttSettings, oToList);
                    //ToWeb.AllowUnsafeUpdates = true;
                    //ToWeb.Properties[sGridGanttSettingsProperty] = sCombinedGridGanttSettings;
                    //ToWeb.Properties.Update();
                    //ToWeb.AllowUnsafeUpdates = false;
                }
                else if(sGeneralFrom != "")
                {

                    string[] arrFromGridGanttSettings = sGeneralFrom.Split(chrNewlineSeparator, StringSplitOptions.None);

                    if(arrFromGridGanttSettings.Length > 7)
                    {
                        arrFromGridGanttSettings[7] = ""; // Item Link Type
                    }
                    // strip rollup settings
                    if(arrFromGridGanttSettings.Length > 8)
                    {
                        arrFromGridGanttSettings[8] = ""; // Rollup Lists
                    }
                    if(arrFromGridGanttSettings.Length > 9)
                    {
                        arrFromGridGanttSettings[9] = ""; // Rollup Sites
                    }

                    string sStrippedRollupGridGanttSettings = "";
                    for(int iStrip = 0; iStrip < arrFromGridGanttSettings.Length; iStrip++)
                    {
                        sStrippedRollupGridGanttSettings += arrFromGridGanttSettings[iStrip] + "\n";
                    }
                    EPMLiveCore.CoreFunctions.setListSetting("GeneralSettings", sStrippedRollupGridGanttSettings, oToList);
                    //ToWeb.AllowUnsafeUpdates = true;
                    //ToWeb.Properties.Add(sGridGanttSettingsProperty, sStrippedRollupGridGanttSettings);
                    //ToWeb.Properties.Update();
                    //ToWeb.AllowUnsafeUpdates = false;

                }

                //string sResPlanProperty = sDVurl + "-EnableResPlan";
                //if (ToWeb.Properties.ContainsKey(sResPlanProperty) && FromWeb.Properties.ContainsKey(sResPlanProperty))
                //{
                //    ToWeb.AllowUnsafeUpdates = true;
                //    ToWeb.Properties[sResPlanProperty] = FromWeb.Properties[sResPlanProperty];
                //    ToWeb.Properties.Update();
                //    ToWeb.AllowUnsafeUpdates = false;
                //}
                //else
                //{
                //    if (FromWeb.Properties.ContainsKey(sResPlanProperty))
                //    {
                //        ToWeb.AllowUnsafeUpdates = true;
                //        ToWeb.Properties.Add(sResPlanProperty, FromWeb.Properties[sResPlanProperty]);
                //        ToWeb.Properties.Update();
                //        ToWeb.AllowUnsafeUpdates = false;
                //    }
                //}

                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (General): Success.<br>";
            }
        }

        private void syncViewPermissionSettings(SPWeb oFromWeb, SPList oFromList, SPWeb oToWeb, SPList oToList, bool bLog)
        {
            string sListURL = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);


            try
            {
                if(oFromWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", oFromList.ID.ToString())))
                {
                    oToWeb.AllowUnsafeUpdates = true;

                    string sPropVal = oFromWeb.Properties[String.Format("ViewPermissions{0}", oFromList.ID.ToString())];
                    //string[] arrPermissions = sPropVal.Split(chrPipeSeparator);
                    //foreach (string sPerm in arrPermissions)
                    //{
                    //    string[] arrViewIDs = sPerm.Substring(sPerm.LastIndexOf("#") + 1).Split(chrSemiColonSeparator);
                    //    foreach (string sViewId in arrViewIDs)
                    //    {
                    //        sPropVal = sPropVal.Replace(sViewId, getToListViewGuid(oFromList, oToList, sViewId).ToString());
                    //    }
                    //}

                    if(oToWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", oToList.ID.ToString())))
                    {

                        oToWeb.Properties[String.Format("ViewPermissions{0}", oToList.ID.ToString())] = sPropVal;
                    }
                    else
                    {
                        oToWeb.Properties.Add(String.Format("ViewPermissions{0}", oToList.ID.ToString()), sPropVal);
                    }
                    oToWeb.Properties.Update();
                    oToWeb.AllowUnsafeUpdates = false;
                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (Permissions & Management) Success.<br>";
                }
            }
            catch(Exception ex)
            {
                bErrors = true;
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Permissions & Management) - Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
            }
        }

        private Guid getToListViewGuid(SPList oFromList, SPList oToList, string sViewId)
        {
            SPView oFromView;
            Guid vGuid = new Guid(sViewId);
            try
            {
                oFromView = oFromList.GetView(vGuid);
                if(oFromView != null && (!oFromView.Hidden || !String.IsNullOrEmpty(oFromView.Title)))
                {
                    string sViewURL = oFromView.Url.Substring(oFromView.Url.LastIndexOf("/") + 1).Replace(".aspx", "");
                    foreach(SPView v in oToList.Views)
                    {
                        if(v.Url.Substring(v.Url.LastIndexOf("/") + 1).Replace(".aspx", "") == sViewURL)
                        {
                            vGuid = v.ID;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            }
            return vGuid;
        }

        private void syncTotalSettings(SPList oFromList, SPList oToList)
        {
            string sDVurl = oFromList.DefaultView.Url.ToLower();
            if(!String.IsNullOrEmpty(sDVurl))
            {
                EPMLiveCore.CoreFunctions.setListSetting("TotalSettings", EPMLiveCore.CoreFunctions.getListSetting("TotalSettings", oFromList), oToList);
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (Total Field) Success.<br>";
            }
        }

        private void syncListSettings(SPWeb oFromWeb, SPList oFromList, SPList oToList, string sSetting, bool bLog)
        {
            string sListURL = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);
            bool bSyncSuccess = true;
            try
            {
                // General Settings
                // Description & Navigation Settings
                bool bSyncDescAndNavSettings = false;
                if(sSetting.Length > 0 && sSetting.ToUpper() == "DESCRIPTIONANDNAV")
                {
                    bSyncDescAndNavSettings = true;
                }
                if(sSetting.Length == 0 && oFromWeb.Properties.ContainsKey("EPMLiveSyncDescriptionAndNavSettings-" + sListURL))
                {
                    string sSyncDescriptionAndNavSettings = oFromWeb.Properties["EPMLiveSyncDescriptionAndNavSettings-" + sListURL];
                    if(sSyncDescriptionAndNavSettings.Length > 0 && sSyncDescriptionAndNavSettings.ToUpper() == "TRUE")
                    {
                        bSyncDescAndNavSettings = true;
                    }
                }
                else
                    bSyncDescAndNavSettings = true;

                if(bSyncDescAndNavSettings)
                {
                    try
                    {
                        oToList.OnQuickLaunch = oFromList.OnQuickLaunch;
                        oToList.Description = oFromList.Description;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (Description & Navigation) Success.<br>";
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Description & Navigation) - Quick Launch: Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                }

                // Versioning Settings
                bSyncSuccess = true;
                bool bSyncVersioningSettings = false;
                if(sSetting.Length > 0 && sSetting.ToUpper() == "VERSIONING")
                {
                    bSyncVersioningSettings = true;
                }
                if(sSetting.Length == 0 && oFromWeb.Properties.ContainsKey("EPMLiveSyncVersioningSettings-" + sListURL))
                {
                    string sSyncVersioningSettings = oFromWeb.Properties["EPMLiveSyncVersioningSettings-" + sListURL];
                    if(sSyncVersioningSettings.Length > 0 && sSyncVersioningSettings.ToUpper() == "TRUE")
                    {
                        bSyncVersioningSettings = true;
                    }
                }
                else
                    bSyncVersioningSettings = true;

                if(bSyncVersioningSettings)
                {
                    try
                    {
                        oToList.DraftVersionVisibility = oFromList.DraftVersionVisibility;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Versioning) - Draft Version Visibility: Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.AllowEveryoneViewItems = oFromList.AllowEveryoneViewItems;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Versioning) - Allow Everyone To View Items: Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.EnableModeration = oFromList.EnableModeration;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Versioning) - Enable Content Approval: Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.EnableSyndication = oFromList.EnableSyndication;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Versioning) - Enable Syndication: Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.EnableVersioning = oFromList.EnableVersioning;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Versioning) - Enable Versioning: Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    if(bSyncSuccess) sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (Versioning) Success.<br>";
                }
                // Advanced Settings
                bSyncSuccess = true;
                bool bSyncAdvancedSettings = false;
                if(sSetting.Length > 0 && sSetting.ToUpper() == "ADVANCED")
                {
                    bSyncAdvancedSettings = true;
                }
                if(sSetting.Length == 0 && oFromWeb.Properties.ContainsKey("EPMLiveSyncAdvancedSettings-" + sListURL))
                {
                    string sSyncAdvancedSettings = oFromWeb.Properties["EPMLiveSyncAdvancedSettings-" + sListURL];
                    if(sSyncAdvancedSettings.Length > 0 && sSyncAdvancedSettings.ToUpper() == "TRUE")
                    {
                        bSyncAdvancedSettings = true;
                    }
                }
                else
                    bSyncAdvancedSettings = true;

                if(bSyncAdvancedSettings)
                {
                    try
                    {
                        oToList.ContentTypesEnabled = oFromList.ContentTypesEnabled;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Enable Content Types) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.EnableAttachments = oFromList.EnableAttachments;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Enable Attachments) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.EnableFolderCreation = oFromList.EnableFolderCreation;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Enable Folders) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.NoCrawl = oFromList.NoCrawl;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Enable Crawling) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.EnableAssignToEmail = oFromList.EnableAssignToEmail;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Enable Email Notification) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.AllowDeletion = oFromList.AllowDeletion;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Allow Delete List) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.ReadSecurity = oFromList.ReadSecurity;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Read Security) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.WriteSecurity = oFromList.WriteSecurity;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Write Security) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    try
                    {
                        oToList.ForceCheckout = oFromList.ForceCheckout;
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        bSyncSuccess = false;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Settings (Advanced - Enable Forced Checkout) Fail. Error message: " + ex.Message.Replace("'", "") + "</font><br>";
                    }
                    if(bSyncSuccess) sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings (Advanced) Success.<br>";
                }

                string sDVurl = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);
                if(FromWeb.Properties.ContainsKey("EPMLiveSyncGeneralSettings-" + sDVurl))
                {
                    string sSyncGeneralSettings = FromWeb.Properties["EPMLiveSyncGeneralSettings-" + sDVurl];
                    if(sSyncGeneralSettings.Length > 0 && sSyncGeneralSettings.ToUpper() == "TRUE")
                    {
                        syncGridGanttSettings(oFromList, oToList);
                    }
                }
                else
                    syncGridGanttSettings(oFromList, oToList);

                if(FromWeb.Properties.ContainsKey("EPMLiveSyncTotalSettings-" + sDVurl))
                {
                    string sSyncTotalSettings = FromWeb.Properties["EPMLiveSyncTotalSettings-" + sDVurl];
                    if(sSyncTotalSettings.Length > 0 && sSyncTotalSettings.ToUpper() == "TRUE")
                    {
                        syncTotalSettings(oFromList, oToList);
                    }
                }
                else
                    syncTotalSettings(oFromList, oToList);

                oToList.Update();
            }
            catch(Exception e)
            {
            }
        }

        public void ReorderFieldsPrep(SPList list, List<SPField> firstFields)
        {
            string sListName = list.Title;
            try
            {

                List<SPField> fields = new List<SPField>();
                int iReOrdAdded = 0;
                string sFld;
                for(int i = 0; i < firstFields.Count; i++)
                {
                    sFld = firstFields[i].InternalName;
                    if(list.Fields.ContainsField(sFld))
                    {
                        SPField oFld = null;
                        try
                        {
                            oFld = list.Fields.GetFieldByInternalName(sFld);
                        }
                        catch { }
                        if(oFld != null && oFld.Reorderable)
                        {
                            fields.Add(oFld);
                            iReOrdAdded++;
                        }
                    }
                }
                int iAllOtherFieldsAdded = 0;
                foreach(SPField field in list.Fields)
                {
                    if(!fields.Contains(field))
                    {
                        fields.Add(field);
                        iAllOtherFieldsAdded++;
                    }
                }

                StringBuilder sb = new StringBuilder();

                XmlTextWriter xmlWriter = new XmlTextWriter(new StringWriter(sb));
                xmlWriter.Formatting = Formatting.Indented;

                xmlWriter.WriteStartElement("Fields");

                for(int i = 0; i < fields.Count; i++)
                {
                    xmlWriter.WriteStartElement("Field");
                    xmlWriter.WriteAttributeString("Name", fields[i].InternalName);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.Flush();

                using(SPWeb web = list.ParentWeb)
                {
                    ReorderFields(web, list, sb.ToString());
                }
            }
            catch(Exception exc)
            {
                bErrors = true;
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Error in preparation for re-ordering columns in " + sListName + " list. Error message: " + exc.Message.Replace("'", "") + "</font><br>";
            }
        }

        private void ReorderFields(SPWeb web, SPList list, string xmlFieldsOrdered)
        {
            try
            {
                string fpRPCMethod = @"<?xml version=""1.0"" encoding=""UTF-8""?>  
	                                    <Method ID=""0,REORDERFIELDS"">  
	                                    <SetList Scope=""Request"">{0}</SetList>  
	                                    <SetVar Name=""Cmd"">REORDERFIELDS</SetVar>  
	                                    <SetVar Name=""ReorderedFields"">{1}</SetVar>  
	                                    <SetVar Name=""owshiddenversion"">{2}</SetVar>  
	                                    </Method>";

                // relookup list version in order to be able to update it
                list = web.Lists[list.ID];

                int currentVersion = list.Version;

                string version = currentVersion.ToString();
                string RpcCall = string.Format(fpRPCMethod, list.ID.ToString(), SPHttpUtility.HtmlEncode(xmlFieldsOrdered), version);

                web.AllowUnsafeUpdates = true;
                string sResult = web.ProcessBatchData(RpcCall);
                web.Update();
                if(sResult.ToUpper().Contains("ERROR"))
                {
                    bErrors = true;
                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Error in re-ordering columns in " + sListName + " list. Error message: " + sResult + "</font><br>";
                }
            }
            catch(System.Net.WebException err)
            {
                bErrors = true;
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Error in re-ordering columns in " + sListName + " list. Web exception error message: " + err.Message + "</font><br>";
            }
        }

        private string getFieldSchemaAttribValue(string sStringToSearch, string sAttribName)
        {
            string sAttribVal = "";
            try
            {
                int iFindPos = sStringToSearch.ToUpper().IndexOf(sAttribName.ToUpper() + "=");
                int iSubStrStart = iFindPos + sAttribName.Length + 2;
                int iSubStrEnd = sStringToSearch.IndexOf("\"", iSubStrStart);
                sAttribVal = sStringToSearch.Substring(iSubStrStart, iSubStrEnd - iSubStrStart);
            }
            catch { }
            return sAttribVal;
        }

        protected SPList getFromList(SPWeb webFrom, string sListName)
        {
            try
            {
                SPList oFromList = null;
                try
                {
                    oFromList = webFrom.Lists[sListName] as SPList;
                }
                catch
                {
                    try
                    {
                        if(webFrom.Properties.ContainsKey("EPMLiveSyncAltListName-" + sListName))
                        {
                            if(FromWeb.Properties["EPMLiveSyncAltListName-" + sListName].ToString() != "")
                            {
                                sListName = webFrom.Properties["EPMLiveSyncAltListName-" + sListName]; // set the new or alternate name for the list
                                try
                                {
                                    oFromList = webFrom.GetList(webFrom.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sListName) as SPList; // try alt list name
                                }
                                catch(Exception e)
                                {
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Error getting From List " + sListName + ": " + ex.Message.Replace("'", "") + "</font><br>";
                        return null;
                    }
                }
                return oFromList;
            }
            catch(Exception exc)
            {
                bErrors = true;
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Error getting From List " + sListName + ": " + exc.Message.Replace("'", "") + "</font><br>";
                return null;
            }
        }

        protected SPList getToList(SPWeb webTo, SPList oFromList, string sListName)
        {
            try
            {
                SPList oToList = null;
                try
                {
                    //bool bCreateNewList = false;
                    //string sAltListName = "";

                    try
                    {
                        oToList = webTo.Lists[sListName];
                    }
                    catch { }
                    if(oToList == null)
                    {
                        if(CreateNewList)
                        {
                            sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Creating list...";

                            try
                            {
                                webTo.AllowUnsafeUpdates = true;

                                XmlDocument docList = new XmlDocument();
                                docList.LoadXml(oFromList.PropertiesXml);

                                string rootFolder = docList.FirstChild.Attributes["RootFolder"].Value.Remove(0, oFromList.ParentWeb.ServerRelativeUrl.Length).Trim('/');

                                webTo.Lists.Add(sListName, oFromList.Description, rootFolder, docList.FirstChild.Attributes["FeatureId"].Value, int.Parse(docList.FirstChild.Attributes["ServerTemplate"].Value), "");

                                webTo.Update();
                                oToList = webTo.Lists[sListName];
                                sSiteResults += "Success";

                            }
                            catch(Exception ex)
                            {
                                sSiteResults += "Failed: " + ex.Message;
                            }


                            sSiteResults += "<br>";
                        }
                        else
                        {
                            //bErrors = true;
                            //sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Unable to find list " + sListName + " in web " + webTo.Title + "</font><br>";
                        }
                    }
                    return oToList;
                    //if (FromWeb.Properties.ContainsKey("EPMLiveSyncAltListName-" + sListName)) // list sync
                    //{
                    //    if (FromWeb.Properties["EPMLiveSyncAltListName-" + sListName].ToString() != "")
                    //    {
                    //        sAltListName = FromWeb.Properties["EPMLiveSyncAltListName-" + sListName]; // set the new or alternate name for the list
                    //        try
                    //        {
                    //            oToList = webTo.GetList(webTo.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sAltListName) as SPList; // try alt list name before trying From List name or creating one
                    //        }
                    //        catch // no such list
                    //        {
                    //        }
                    //    }
                    //}
                    //else // template sync
                    //{
                    //    try
                    //    {
                    //        oToList = webTo.GetList(webTo.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sListName) as SPList;
                    //    }
                    //    catch // no such list
                    //    {
                    //    }
                    //}
                    //if (oToList == null)
                    //{
                    //    // check to see if configured to create a new list in the ToWeb if it doesn't exist
                    //    string sListURL = System.IO.Path.GetDirectoryName(oFromList.DefaultView.ServerRelativeUrl);
                    //    if (FromWeb.Properties.ContainsKey("EPMLiveSyncCreateNew-" + sListURL))
                    //    {
                    //        string sSyncCreateNewList = FromWeb.Properties["EPMLiveSyncCreateNew-" + sListURL].ToString();
                    //        if (sSyncCreateNewList.Length > 0 && (sSyncCreateNewList.ToUpper() == "TRUE" || sSyncCreateNewList.ToUpper() == "FALSE"))
                    //        {
                    //            bCreateNewList = bool.Parse(FromWeb.Properties["EPMLiveSyncCreateNew-" + sListURL]);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        bCreateNewList = true;
                    //        sAltListName = sListName;
                    //    }
                    //}
                    //if (bCreateNewList)
                    //{
                    //    SPListTemplateCollection oLstColl = FromWeb.ListTemplates;
                    //    SPListTemplate oLstTmplt = null;
                    //    for (int i = 0; i < FromWeb.ListTemplates.Count; i++)
                    //    {
                    //        if (FromWeb.ListTemplates[i].Type == FromList.BaseTemplate)
                    //        {
                    //            oLstTmplt = FromWeb.ListTemplates[i];
                    //            break;
                    //        }
                    //    }
                    //    if (oLstTmplt != null)
                    //    {
                    //        webTo.AllowUnsafeUpdates = true;
                    //        webTo.Lists.Add(sAltListName, oFromList.Description, oLstTmplt);
                    //        webTo.Update();
                    //        webTo.AllowUnsafeUpdates = false;
                    //        oToList = webTo.GetList(webTo.ServerRelativeUrl.TrimEnd('/') + "/Lists/" + sAltListName) as SPList;
                    //    }
                    //}
                }
                catch(Exception ex)
                {
                    bErrors = true;
                    sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Failed getting To List " + sListName + ": " + ex.Message.Replace("'", "") + "</font><br>";
                    return null;
                }
                return oToList;
            }
            catch(Exception exc)
            {
                bErrors = true;
                sSiteResults += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"black\" >Failed getting To List " + sListName + ": " + exc.Message.Replace("'", "") + "</font><br>";
                return null;
            }
        }

        private void setCustomProperties(SPField oFromFld, SPField oToFld)
        {
            XmlDocument docCustomProps = new XmlDocument();
            docCustomProps.LoadXml(oFromFld.SchemaXml);
            try
            {
                XmlNode ndCustomization = docCustomProps.SelectSingleNode("//ArrayOfProperty");
                foreach(XmlNode nd in ndCustomization.ChildNodes)
                {
                    if(nd != null)
                    {
                        oToFld.SetCustomProperty(nd.ChildNodes[0].InnerText, nd.ChildNodes[1].InnerText);
                    }
                }
            }
            catch { } // node doesn't exist

        }

        protected bool isSynchedView(string sURL, string[] arrViewURLs)
        {
            try
            {
                for(int i = 0; i < arrViewURLs.Length; i++)
                {
                    if(arrViewURLs[i] == sURL)
                    {
                        return true;
                        break;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
