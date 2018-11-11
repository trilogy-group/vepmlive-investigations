using System;

namespace NewsGator.Install.Common.Constants
{
    /// <summary>
    /// Unique identifiers used by various objects stored by SharePoint
    /// </summary>
    internal static class FarmIdentifiers
    {
        internal static readonly Guid SocialDatabaseIdentifier = new Guid("93927536-1BCF-4C47-A912-E77289060F36");
        internal static readonly Guid SocialServiceApplicationIdentifier = new Guid("A7DB0A11-76E7-4D74-9693-0E006E13E144");
        internal static readonly Guid SocialReportingDatabaseIdentifier = new Guid("DF0678F4-D635-4194-98CE-201D993464AE");
        internal static readonly Guid NewsManagerDatabaseIdentifier = new Guid("13F06968-69B7-4176-817E-A6938D0C3658");
        internal static readonly Guid NewsManagerServiceApplicationIdentifier = new Guid("7401DD41-AA02-414B-BE95-3ECF27E6F688");
        internal static readonly Guid SocialAppConfigIdentifier = new Guid("B33BB9B2-92A7-4276-A271-A19DDD34F608");
        internal static readonly Guid PersistedLicenseIdentifier = new Guid("983F332D-4558-4347-88A7-5C8249352598");
    }
}
