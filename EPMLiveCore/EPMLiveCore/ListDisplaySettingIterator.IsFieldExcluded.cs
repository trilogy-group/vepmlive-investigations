using System;
using System.Diagnostics;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class ListDisplaySettingIterator
    {
        protected override bool IsFieldExcluded(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (!isFeatureActivated)
            {
                return base.IsFieldExcluded(field);
            }

            if (isResList)
            {
                try
                {
                    switch (field.InternalName)
                    {
                        case ResourceLevelTitle:
                            return IsFieldExcludedResourcesLevel();
                        case PermissionsTitle:
                            return IsFieldExcludedPermissions();
                        case TitleKey:
                            return IsFieldExcludedTitle();
                        case FirstNameKey:
                        case LastNameKey:
                            return IsFieldExcludedName();
                        case EmailKey:
                            return mode != SPControlMode.New;
                        case CanLoginTitle:
                            return true;
                        case GenericTitle:
                            return mode != SPControlMode.New;
                        case Approved:
                            return IsFieldExcludedApproved(field);
                        default:
                            if (IsFieldExcludedInternalName(field.InternalName))
                            {
                                return true;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }

            if (fieldProperties == null)
            {
                return base.IsFieldExcluded(field);
            }

            if (!fieldProperties.ContainsKey(field.InternalName))
            {
                return base.IsFieldExcluded(field);
            }

            switch (mode)
            {
                case SPControlMode.Display:
                    return IsFieldExcluded(field, Display);
                case SPControlMode.Edit:
                    return IsFieldExcludedEdit(field);
                case SPControlMode.New:
                    return IsFiedlExcludedNew(field);
                default:
                    return base.IsFieldExcluded(field);
            }
        }

        private bool IsFieldExcludedResourcesLevel()
        {
            if (Web.CurrentUser.IsSiteAdmin ||
                string.Equals(
                    CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName),
                    ownerusername,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                var act = new Act(Web);
                var actType = 0;

                var levels = act.GetLevelsFromSite(out actType, string.Empty);

                return actType <= 2;
            }

            return true;
        }

        private bool IsFieldExcludedPermissions()
        {
            if (mode == SPControlMode.New)
            {
                return false;
            }

            var generic = string.Empty;
            try
            {
                generic = ListItem[GenericTitle].ToString();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return generic != FalseConst;
        }

        private bool IsFieldExcludedTitle()
        {
            if (mode != SPControlMode.Edit)
            {
                return false;
            }

            try
            {
                if (!bool.Parse(ListItem[GenericTitle].ToString()))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool IsFieldExcludedName()
        {
            if (mode == SPControlMode.New)
            {
                return false;
            }
            try
            {
                if (bool.Parse(ListItem[GenericTitle].ToString()))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool IsFieldExcludedApproved(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (field.ParentList.Fields.ContainsFieldWithInternalName(ResourceLevelTitle))
            {
                return true;
            }
            var approved = No;
            try
            {
                approved = ListItem[Approved].ToString();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return !SPContext.Current.Web.UserIsSiteAdmin || approved != FalseConst || mode == SPControlMode.New;
        }

        private bool IsFieldExcludedInternalName(string fieldInternalName)
        {
            if (isOnline)
            {
                switch (fieldInternalName)
                {
                    case SharePointAccount:
                        return true;
                }
            }
            if (!isOnline)
            {
                switch (fieldInternalName)
                {
                    case CanLoginTitle:
                    case EmailKey:
                        return true;
                }
            }
            return false;
        }

        private bool IsFieldExcluded(SPField field, string key)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            var displaySettings = fieldProperties[field.InternalName][key];
            if (displaySettings.Split(Separator.ToCharArray())[0].Equals(Where, StringComparison.InvariantCultureIgnoreCase))
            {
                return IsFieldExcluded2(field, displaySettings);
            }

            return base.IsFieldExcluded(field);
        }

        private bool IsFieldExcludedEdit(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            if (!fieldProperties[field.InternalName].ContainsKey(Edit))
            {
                return base.IsFieldExcluded(field);
            }
            var displaySettings = fieldProperties[field.InternalName][Edit];
            if (displaySettings.Split(Separator.ToCharArray())[0].Equals(Where, StringComparison.InvariantCultureIgnoreCase))
            {
                return IsFieldExcluded2(field, displaySettings);
            }

            if (field.Type == SPFieldType.Calculated &&
                displaySettings.Split(Separator.ToCharArray())[0].Equals(Always, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            return base.IsFieldExcluded(field);
        }

        private bool IsFiedlExcludedNew(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (!fieldProperties[field.InternalName].ContainsKey(New))
            {
                return base.IsFieldExcluded(field);
            }

            var displaySettings = fieldProperties[field.InternalName][New];
            if (displaySettings.Split(Separator.ToCharArray())[0].Equals(Where, StringComparison.InvariantCultureIgnoreCase))
            {
                return IsFieldExcluded2(field, displaySettings);
            }
            return base.IsFieldExcluded(field);
        }

        private bool IsFieldExcluded2(SPField field, string displaySettings)
        {
            var whereField = displaySettings.Split(Separator.ToCharArray())[1];
            var conditionField = string.Empty;
            string condition;
            var groupField = string.Empty;
            var valueCondition = string.Empty;
            if (whereField.Equals(Me))
            {
                condition = displaySettings.Split(Separator.ToCharArray())[2];
                groupField = displaySettings.Split(Separator.ToCharArray())[3];
            }
            else
            {
                conditionField = displaySettings.Split(Separator.ToCharArray())[2];
                condition = displaySettings.Split(Separator.ToCharArray())[3];
                valueCondition = displaySettings.Split(Separator.ToCharArray())[4];
            }
            return !EditableFieldDisplay.RenderField(
                field,
                whereField,
                conditionField,
                condition,
                groupField,
                valueCondition,
                ListItem);
        }
    }
}