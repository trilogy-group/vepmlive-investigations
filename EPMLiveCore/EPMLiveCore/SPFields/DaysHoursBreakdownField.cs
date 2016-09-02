using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.WebControls;
using System.Security;

namespace EPMLiveCore.SPFields
{
    [Guid("CE53ED15-50F5-410C-80E0-CC4160034104")]
    public class DaysHoursBreakdownField : SPFieldText
    {
        #region Fields (9)

        private static readonly Dictionary<int, Properties> PropertyDictionary = new Dictionary<int, Properties>();
        private int _contextId;
        private string _finishDateField;
        private string _holidaySchedulesField;
        private string _holidaysList;
        private string _hoursField;
        private string _resourcePoolList;
        private string _startDateField;
        private string _workHoursList;

        #endregion Fields

        #region Constructors (2)

        /// <summary>
        /// Initializes a new instance of the <see cref="DaysHoursBreakdownField"/> class.
        /// </summary>
        /// <param name="fields">An <see cref="T:Microsoft.SharePoint.SPFieldCollection"/> object that represents the field collection.</param>
        /// <param name="typeName">A string that contains the name of the field type, which can be a string representation of an <see cref="T:Microsoft.SharePoint.SPFieldType"/> value.</param>
        /// <param name="displayName">A string that contains the display name of the field.</param>
        public DaysHoursBreakdownField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DaysHoursBreakdownField"/> class.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <param name="fieldName">Name of the field.</param>
        public DaysHoursBreakdownField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
            Initialize();
        }

        #endregion Constructors

        #region Properties (9)

        protected int ContextId
        {
            get
            {
                SPContext spContext = SPContext.Current;

                if (spContext == null && _contextId != 0)
                {
                    return _contextId;
                }

                return spContext.GetHashCode();
            }
            set { _contextId = value; }
        }

        /// <summary>
        /// Gets the field type control that is used to render the field.
        /// </summary>
        /// <returns>A <see cref="T:Microsoft.SharePoint.WebControls.BaseFieldControl"/> object that represents the control.</returns>
        public override BaseFieldControl FieldRenderingControl
        {
            [SecurityCritical]
            get { return new DaysHoursBreakdownFieldControl { FieldName = InternalName }; }
        }

        public string FinishDateField
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].FinishDateField
                           : _finishDateField;
            }
            set { _finishDateField = value; }
        }

        public string HolidaySchedulesField
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].HolidaySchedulesField
                           : _holidaySchedulesField;
            }
            set { _holidaySchedulesField = value; }
        }

        public string HolidaysList
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].HolidaysList
                           : _holidaysList;
            }
            set { _holidaysList = value; }
        }

        public string HoursField
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].HoursField
                           : _hoursField;
            }
            set { _hoursField = value; }
        }

        public string ResourcePoolList
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].ResourcePoolList
                           : _resourcePoolList;
            }
            set { _resourcePoolList = value; }
        }

        public string StartDateField
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].StartDateField
                           : _startDateField;
            }
            set { _startDateField = value; }
        }

        public string WorkHoursList
        {
            get
            {
                return PropertyDictionary.ContainsKey(ContextId)
                           ? PropertyDictionary[ContextId].WorkHoursList
                           : _workHoursList;
            }
            set { _workHoursList = value; }
        }

        #endregion Properties

        #region Methods (5)

        // Public Methods (4) 

        /// <summary>
        /// Converts the specified value into a field type value object when the field type requires a complex data type that is different from the parent field type.
        /// </summary>
        /// <param name="value">A string to convert into a field type value object.</param>
        /// <returns>
        /// An object that repesents the field type value object.
        /// </returns>
        public override object GetFieldValue(string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }

        /// <summary>
        /// Occurs after a field is added.
        /// </summary>
        /// <param name="op">An <see cref="T:Microsoft.SharePoint.SPAddFieldOptions"/> value that specifies an option that is implemented after the field is created.</param>
        public override void OnAdded(SPAddFieldOptions op)
        {
            base.OnAdded(op);
            Update();
        }

        /// <summary>
        /// Updates the database with changes that are made to the field.
        /// </summary>
        public override void Update()
        {
            if (StartDateField != null && !string.IsNullOrEmpty(StartDateField))
            {
                SetCustomProperty("StartDateField", StartDateField);
            }

            if (FinishDateField != null && !string.IsNullOrEmpty(FinishDateField))
            {
                SetCustomProperty("FinishDateField", FinishDateField);
            }

            if (HoursField != null && !string.IsNullOrEmpty(HoursField))
            {
                SetCustomProperty("HoursField", HoursField);
            }

            if (HolidaySchedulesField != null && !string.IsNullOrEmpty(HolidaySchedulesField))
            {
                SetCustomProperty("HolidaySchedulesField", HolidaySchedulesField);
            }

            if (ResourcePoolList != null && !string.IsNullOrEmpty(ResourcePoolList))
            {
                SetCustomProperty("ResourcePoolList", ResourcePoolList);
            }

            if (WorkHoursList != null && !string.IsNullOrEmpty(WorkHoursList))
            {
                SetCustomProperty("WorkHoursList", WorkHoursList);
            }

            if (HolidaysList != null && !string.IsNullOrEmpty(HolidaysList))
            {
                SetCustomProperty("HolidaysList", HolidaysList);
            }

            base.Update();

            if (PropertyDictionary.ContainsKey(ContextId))
            {
                PropertyDictionary.Remove(ContextId);
            }
        }

        /// <summary>
        /// Updates the custom property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        public void UpdateCustomProperty(string propertyName, string propertyValue)
        {
            if (!PropertyDictionary.ContainsKey(ContextId))
            {
                PropertyDictionary.Add(ContextId, new Properties());
            }

            Properties properties = PropertyDictionary[ContextId];

            switch (propertyName)
            {
                case "StartDateField":
                    properties.StartDateField = propertyValue;
                    break;
                case "FinishDateField":
                    properties.FinishDateField = propertyValue;
                    break;
                case "HoursField":
                    properties.HoursField = propertyValue;
                    break;
                case "HolidaySchedulesField":
                    properties.HolidaySchedulesField = propertyValue;
                    break;
                case "ResourcePoolList":
                    properties.ResourcePoolList = propertyValue;
                    break;
                case "WorkHoursList":
                    properties.WorkHoursList = propertyValue;
                    break;
                case "HolidaysList":
                    properties.HolidaysList = propertyValue;
                    break;
            }
        }

        // Private Methods (1) 

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            _startDateField = (string)(GetCustomProperty("StartDateField") ?? string.Empty);
            _finishDateField = (string)(GetCustomProperty("FinishDateField") ?? string.Empty);
            _hoursField = (string)(GetCustomProperty("HoursField") ?? string.Empty);
            _holidaySchedulesField = (string)(GetCustomProperty("HolidaySchedulesField") ?? string.Empty);
            _resourcePoolList = (string)(GetCustomProperty("ResourcePoolList") ?? string.Empty);
            _workHoursList = (string)(GetCustomProperty("WorkHoursList") ?? string.Empty);
            _holidaysList = (string)(GetCustomProperty("HolidaysList") ?? string.Empty);

            if (SPContext.Current == null)
            {
                _contextId = System.Guid.NewGuid().GetHashCode();
            }
        }

        #endregion Methods

        #region Nested type: Properties

        private class Properties
        {
            public string FinishDateField { get; set; }

            public string StartDateField { get; set; }

            public string HoursField { get; set; }

            public string ResourcePoolList { get; set; }

            public string WorkHoursList { get; set; }

            public string HolidaysList { get; set; }

            public string HolidaySchedulesField { get; set; }
        }

        #endregion
    }
}