﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortfolioEngineCore.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PortfolioEngineCore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /****************************************************************************************************
        ///**   Copyright 2012 EPM Live
        ///**   Filename  : 01_PE_CRTTBLS.SQL
        ///**
        ///**   This script will create and update the PortfolioEngine SQL Server tables  
        ///**
        ///**   Privileges needed: member of db_owner or db_ddladmin
        ///**
        ///****************************************************************************************************/
        ///
        ///if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = &apos;EP [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _01_PE_CRTTBLS {
            get {
                return ResourceManager.GetString("_01_PE_CRTTBLS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /****************************************************************************************************
        ///**   Copyright 2012 EPM Live
        ///**
        ///**   Filename  : 02_PE_CRTINDS.SQL
        ///**
        ///**   This script will create the PortfolioEngine SQL Server table indexes
        ///**
        ///**   Privileges needed: member of db_owner or db_ddladmin
        ///**
        ///****************************************************************************************************/
        ///-- Drop existing indexes --
        ///
        ///IF (SELECT INDEXPROPERTY(object_id(N&apos;dbo.EPG_DELEGATES&apos;), N [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _02_PE_CRTINDS {
            get {
                return ResourceManager.GetString("_02_PE_CRTINDS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @createoralter varchar(10)
        ///if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = &apos;EPG_FN_charindex_ex&apos;)
        ///begin
        ///    Print &apos;Creating Function EPG_FN_charindex_ex&apos;
        ///    SET @createoralter = &apos;CREATE&apos;
        ///end
        ///else
        ///begin
        ///    Print &apos;Updating Function EPG_FN_charindex_ex&apos;
        ///    SET @createoralter = &apos;ALTER&apos;
        ///end
        ///exec(@createoralter + &apos; function dbo.EPG_FN_charindex_ex (@searchar nvarchar(1),@str ntext,@startloc int)
        ///returns int
        ///as
        ///begin
        ///   declare @curpos int, @strlen [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _04_PE_CRTSPS {
            get {
                return ResourceManager.GetString("_04_PE_CRTSPS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @createoralter varchar(10)
        /// 
        ///------------------------------View: EPG_VW_RPT_ListRoles---------------------------
        ///if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = &apos;EPG_VW_RPT_ListRoles&apos;)
        ///begin
        ///    Print &apos;Creating View EPG_VW_RPT_ListRoles&apos;
        ///    SET @createoralter = &apos;CREATE&apos;
        ///end
        ///else
        ///begin
        ///    Print &apos;Updating View EPG_VW_RPT_ListRoles&apos;
        ///    SET @createoralter = &apos;ALTER&apos;
        ///end
        ///exec(@createoralter + &apos; VIEW [dbo].[EPG_VW_RPT_ListRoles]
        ///AS
        ///SELECT     TOP (100) P [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _05_PE_CRTVWS {
            get {
                return ResourceManager.GetString("05_PE_CRTVWS", resourceCulture);
            }
        }
    }
}
