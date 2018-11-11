using System;

namespace WorkEnginePPM.Layouts.ppm
{
    internal enum CustomFieldTable
    {
        Unknown = 0,
        ResourceINT = 101,
        ResourceTEXT = 102,
        ResourceDEC = 103,
        ResourceNTEXT = 104,
        ResourceDATE = 105,
        ResourceMV = 151,
        PortfolioINT = 201,
        PortfolioTEXT = 202,
        PortfolioDEC = 203,
        PortfolioNTEXT = 204,
        PortfolioDATE = 205,
        Program = 251,
        ProjectINT = 301,
        ProjectTEXT = 302,
        ProjectDEC = 303,
        ProjectNTEXT = 304,
        ProjectDATE = 305,
        ProgramText = 402, //  ??
        TaskWIINT = 801,
        TaskWITEXT = 802,
        TaskWIDEC = 803
    }

    internal enum FieldType
    {
        TypeCost = 8,
        TypeCode = 4,
        TypeMVCode = 40,
        TypeFlag = 13,
        TypeText = 9,
        TypeNumber = 3,
        TypeDate = 1,
        TypeNText = 19,
    }

    internal enum EntityID
    {
        Resource = 1,
        Portfolio = 2,
        Program = 3,
        Project = 4,
        Task = 5,
        Unknown = 0
    }

    internal class EPKClass01
    {

        public static int GetEntityID(int iTable)
        {
            EntityID nEntity;
            CustomFieldTable nTable = (CustomFieldTable)iTable;
            if (nTable >= CustomFieldTable.ResourceINT && nTable <= CustomFieldTable.ResourceMV)
                nEntity = EntityID.Resource;
            else if (nTable >= CustomFieldTable.PortfolioINT && nTable <= CustomFieldTable.PortfolioDATE)
                nEntity = EntityID.Portfolio;
            else if (nTable == CustomFieldTable.Program)
                nEntity = EntityID.Program;
            else if (nTable >= CustomFieldTable.ProjectINT && nTable <= CustomFieldTable.ProjectDATE)
                nEntity = EntityID.Project;
            else if (nTable >= CustomFieldTable.TaskWIINT && nTable <= CustomFieldTable.TaskWIDEC)
                nEntity = EntityID.Task;
            else
                nEntity = EntityID.Unknown;
            int iEntity = (Int32)nEntity;
            return iEntity;
        }

        public static string GetEntity(int iEntity)
        {
            string sEntity = "";
            EntityID nEntity = (EntityID)iEntity;

            if (nEntity == EntityID.Resource)
                sEntity = "Resource";
            else if (nEntity == EntityID.Portfolio)
                sEntity = "Portfolio";
            else if (nEntity == EntityID.Program)
                sEntity = "Program";
            else if (nEntity == EntityID.Project)
                sEntity = "Project";
            else if (nEntity == EntityID.Task)
                sEntity = "Task";
            else
                sEntity = "Unknown";
            return sEntity;
        }
        public static string GetDataType(int iFieldType)
        {
            string sDataType = "";
            FieldType nFieldType = (FieldType)iFieldType;

            switch (nFieldType)
            {
                case FieldType.TypeCost:
                    sDataType = "Cost";
                    break;
                case FieldType.TypeCode:
                    sDataType = "Code";
                    break;
                case FieldType.TypeDate:
                    sDataType = "Date";
                    break;
                case FieldType.TypeFlag:
                    sDataType = "Flag";
                    break;
                case FieldType.TypeNumber:
                    sDataType = "Number";
                    break;
                case FieldType.TypeText:
                    sDataType = "Text";
                    break;
                case FieldType.TypeNText:
                    sDataType = "RTF";
                    break;
                default:
                    sDataType = "Unknown";
                    break;

            }
            return sDataType;
        }

        public static string GetFieldFormat(int iDataType)
        {
            string sdatatype = "";
            FieldType nDataType = (FieldType)iDataType;
            switch (nDataType)
            {
                case FieldType.TypeCost:
                    sdatatype = "Cost";
                    break;
                case FieldType.TypeCode:
                    sdatatype = "Code";
                    break;
                case FieldType.TypeMVCode:
                    sdatatype = "MV Code";
                    break;
                case FieldType.TypeFlag:
                    sdatatype = "Flag";
                    break;
                case FieldType.TypeText:
                    sdatatype = "Text";
                    break;
                case FieldType.TypeNumber:
                    sdatatype = "Number";
                    break;
                case FieldType.TypeDate:
                    sdatatype = "Date";
                    break;
                case FieldType.TypeNText:
                    sdatatype = "NText";
                    break;
                default:
                    sdatatype = "Unknown Type";
                    break;
            }
            return sdatatype;
        }

        public static bool GetTableAndField(int iTable, int iField, out string sTable, out string sField)
        {
            bool bFound = true;
            string stable = "";
            string sfield = "";
            CustomFieldTable nTable = (CustomFieldTable)iTable;
            switch (nTable)
            {
                case CustomFieldTable.ResourceINT:
                    stable = "EPGC_RESOURCE_INT_VALUES";
                    sfield = "RI_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceTEXT:
                    stable = "EPGC_RESOURCE_TEXT_VALUES";
                    sfield = "RT_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceDEC:
                    stable = "EPGC_RESOURCE_DEC_VALUES";
                    sfield = "RC_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceNTEXT:
                    stable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sfield = "RN_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceDATE:
                    stable = "EPGC_RESOURCE_DATE_VALUES";
                    sfield = "RD_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.ResourceMV:
                    stable = "EPGC_RESOURCE_MV_VALUES";
                    sfield = "MVR_UID";
                    break;
                case CustomFieldTable.PortfolioINT:
                    stable = "EPGP_PROJECT_INT_VALUES";
                    sfield = "PI_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioTEXT:
                    stable = "EPGP_PROJECT_TEXT_VALUES";
                    sfield = "PT_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioDEC:
                    stable = "EPGP_PROJECT_DEC_VALUES";
                    sfield = "PC_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioNTEXT:
                    stable = "EPGP_PROJECT_NTEXT_VALUES";
                    sfield = "PN_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldTable.PortfolioDATE:
                    stable = "EPGP_PROJECT_DATE_VALUES";
                    sfield = "PD_" + String.Format("{0:d3}", iField);
                    break;
                default:
                    stable = "Unknown Table";
                    sfield = "";
                    bFound = false;
                    break;
            }

            sTable = stable;
            sField = sfield;
            return bFound;
        }

        public static int GetTableID(int iEntity, int iDataType)
        {
            CustomFieldTable nTable = 0;
            FieldType nDataType = (FieldType)iDataType;
            EntityID nEntity = (EntityID)iEntity;

            switch (nEntity)
            {
                case EntityID.Resource:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldTable.ResourceDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldTable.ResourceDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.ResourceINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.ResourceTEXT;
                            break;
                        case FieldType.TypeMVCode:
                            nTable = CustomFieldTable.ResourceMV;
                            break;
                    }
                    break;
                case EntityID.Portfolio:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldTable.PortfolioDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldTable.PortfolioDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.PortfolioINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.PortfolioTEXT;
                            break;
                        case FieldType.TypeNText:
                            nTable = CustomFieldTable.PortfolioNTEXT;
                            break;
                    }
                    break;
                case EntityID.Program:
                    nTable = CustomFieldTable.Program;
                    break;
                case EntityID.Project:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldTable.ProjectDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldTable.ProjectDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.ProjectINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.ProjectTEXT;
                            break;
                        case FieldType.TypeNText:
                            nTable = CustomFieldTable.ProjectNTEXT;
                            break;
                    }
                    break;
                case EntityID.Task:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                            nTable = CustomFieldTable.TaskWIDEC;
                            break;
                        case FieldType.TypeFlag:
                            nTable = CustomFieldTable.TaskWIINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldTable.TaskWITEXT;
                            break;
                    }
                    break;
                default:
                    nTable = CustomFieldTable.Unknown;
                    break;
            }
            return (int)nTable;
        }

    }
}