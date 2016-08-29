using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using PortfolioEngineCore.Infrastructure.Fields;

namespace PortfolioEngineCore
{
    public class Resource
    {
        #region Fields (1) 

        private const string EmailRegExPattern =
            @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// </summary>
        public Resource()
        {
            PermissionsDictionary = new Dictionary<int, string>();
            CustomFields = new Collection<IField>();
        }

        #endregion Constructors 

        #region Properties (30) 

        [FieldInfo(Id = 3007, Name = "WRES_AVAILABLEFROM")]
        public DateTime? AvailableFrom { get; set; }

        [FieldInfo(Id = 3008, Name = "WRES_AVAILABLETO")]
        public DateTime? AvailableTo { get; set; }

        [FieldInfo(Name = "WRES_CAN_LOGIN")]
        public byte? CanLogin { get; set; }

        [FieldInfo(Id = 3103)]
        public int? CostCategoryRoleId { get; set; }

        public ICollection<IField> CustomFields { get; set; }

        [FieldInfo(Id = 3011, Name = "WRES_EMAIL")]
        [RegularExpression(EmailRegExPattern, ErrorMessage = "Unknown email format.")]
        [StringLength(255, ErrorMessage = "Email address cannot be more than 255 characters long.")]
        public string Email { get; set; }

        [FieldInfo(Id = 3013, Name = "WRES_EXT_UID")]
        [StringLength(64, ErrorMessage = "External UID cannot be more than 64 characters long.")]
        public string ExternalUId { get; set; }

        [FieldInfo(Id = 3201)]
        public int? HolidaysListId { get; set; }

        public string HolidaysListName { get; set; }

        [FieldInfo(Id = 3001, Name = "WRES_ID")]
        public int Id { get; set; }

        [FieldInfo(Id = 3002, Name = "WRES_INACTIVE")]
        public byte? InActive { get; set; }

        [FieldInfo(Id = 3006, Name = "WRES_IS_GENERIC")]
        public byte? IsGeneric { get; set; }

        [FieldInfo(Id = 3005, Name = "WRES_IS_RESOURCE")]
        public byte? IsResource { get; set; }

        [FieldInfo(Id = 3000, Name = "RES_NAME")]
        [Required(ErrorMessage = "Name is a required field.")]
        [StringLength(255, ErrorMessage = "Name cannot be more than 255 characters long.")]
        public string Name { get; set; }

        [FieldInfo(Name = "WRES_NOTES")]
        [StringLength(255, ErrorMessage = "Notes cannot be more than 255 characters long.")]
        public string Notes { get; set; }

        [FieldInfo(Id = 3014, Name = "WRES_NT_ACCOUNT")]
        [StringLength(255, ErrorMessage = "Username cannot be more than 255 characters long.")]
        public string NTAccount { get; set; }

        [FieldInfo(Name = "WRES_PASSWORD")]
        [StringLength(255, ErrorMessage = "Password cannot be more than 255 characters long.")]
        public string Password { get; set; }

        [FieldInfo(Id = 3200)]
        public string Permissions
        {
            get
            {
                return string.Join(",",
                                   PermissionsDictionary.Select(d => string.Format("{0}:{1}", d.Key, d.Value)).ToArray());
            }
        }

        public Dictionary<int, string> PermissionsDictionary { get; set; }

        [FieldInfo(Id = 3104)]
        public int? RateId { get; set; }

        [FieldInfo(Id = 3020, Name = "WRES_RP_DEPT")]
        public int? RPDepartment { get; set; }

        [FieldInfo(Id = 3203)]
        public int? TimesheetListId { get; set; }

        public string TimesheetListName { get; set; }

        [FieldInfo(Name = "WRES_TRACE")]
        public int? Trace { get; set; }

        [FieldInfo(Id = 3010, Name = "WRES_DEPT")]
        public int? TSDepartment { get; set; }

        [FieldInfo(Name = "WRES_USE_NT_LOGON")]
        public byte? UseNTLogin { get; set; }

        [FieldInfo(Id = 3202)]
        public int? WorkingHoursListId { get; set; }

        public string WorkingHoursListName { get; set; }

        #endregion Properties 

        #region Methods (1) 

        // Public Methods (1) 

        /// <summary>
        /// Validates the specified error messages.
        /// </summary>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public bool Validate(out IList<string> errorMessages)
        {
            errorMessages = new List<string>();
            foreach (PropertyInfo propertyInfo in GetType().GetProperties())
            {
                foreach (ValidationAttribute validationAttribute in propertyInfo.GetCustomAttributes(typeof (ValidationAttribute), false).Cast<ValidationAttribute>())
                {
                    object value = propertyInfo.GetValue(this, null);

                    if (validationAttribute.IsValid(value)) continue;
                    if (propertyInfo.Name.Equals("Email") && value == null) continue;

                    errorMessages.Add(validationAttribute.ErrorMessage);
                }
            }
            if (!string.IsNullOrEmpty(Email) && Email.Contains("'"))
            {
                errorMessages.Add(string.Format("Apostrophes are not supported in email addresses."));
            }

            if (AvailableFrom.HasValue && AvailableTo.HasValue && AvailableTo < AvailableFrom)
            {
                errorMessages.Add(
                    string.Format("The 'Available From' date ({0}) must come before the 'Available To' date ({1}).",
                                  AvailableFrom.Value.ToString(CultureInfo.InvariantCulture),
                                  AvailableTo.Value.ToString(CultureInfo.InvariantCulture)));
            }

            return !errorMessages.Any();
        }

        #endregion Methods 
    }
}