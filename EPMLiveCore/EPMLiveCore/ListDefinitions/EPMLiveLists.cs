using System;

namespace EPMLiveCore.ListDefinitions
{
    public enum EPMLiveLists
    {
        [List(Name = "My Work")] MyWork = 10115,

        [List(Name = "Roles")] Roles = 60000,

        [List(Name = "Departments")] Departments = 60001,

        [List(Name = "WorkHours")] WorkHours = 60002,

        [List(Name = "HolidaySchedules")] HolidaySchedules = 60003,

        [List(Name = "Holidays")] Holidays = 60004
    }

    public class ListAttribute : Attribute
    {
        #region Properties (1) 

        public string Name { get; set; }

        #endregion Properties 
    }
}