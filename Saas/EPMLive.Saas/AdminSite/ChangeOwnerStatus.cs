using System;

namespace AdminSite
{
    public enum ChangeOwnerStatus
    {
        NotExecuted = -100,
        SecondaryOwnerFailedToExecute = -10,
        PrimaryOwnerCurrentOwnerNotFound = -2,
        PrimaryOwnerFailedToExecute = -1,
        Success = 0,
        PrimaryOwnerDataMismatch = 1,
        PrimaryOwnerNoChange = 2,
        PrimaryOwnerNewOwnerDoesNotExist = 3
    }
}