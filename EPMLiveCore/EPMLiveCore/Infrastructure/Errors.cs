namespace EPMLiveCore.Infrastructure
{
    internal enum Errors
    {
        GridViewCannotChangeId = 999100,
        GlobalGVMAdd,
        GlobalGVMAddNoPermission,
        GlobalGVMFindById,
        GlobalGVMList,
        GlobalGVMRemove,
        GlobalGVMRemoveNoAccess,
        GlobalGVMUpdate,
        GlobalGVMUpdateNoAccess,
        GlobalGVMValidateAuthorization,
        PersonalGVMList,
        PersonalGVMGetViews,
        PersonalGVMAdd,
        PersonalGVMFindById,
        PersonalGVMRemove,
        PersonalGVMUpdate,
        PersonalGVMSaveViews,
        GVFNoRoot,
        GVFNoIsPersonalAttr,
        GVFInvalidComponent,
        GVFViewKindNotFound,
        RMGetResourcesList = 999200,
        SPLIM = 999300,
        SPLIMListNotFound,
        SPLIMBatchProcessLimit,
        SPLIMGetAll,
        SPLIMAdd,
        SPLIMUpdate,
        SPLIMDelete,
        SPLIMBatchOp,
        SPLIMBatchOpRootEleNotFound,
        SPLIMBatchOpIdNotFound,
        SPLIMBatchOpFieldAttrNotFound
    }
}