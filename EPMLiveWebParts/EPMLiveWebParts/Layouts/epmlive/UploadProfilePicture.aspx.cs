using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class UploadProfilePicture : LayoutsPageBase
    {
        private const string ProfilePictureLibraryName = "User Profile Pictures";
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadPictureButton_Click(object sender, EventArgs e)
        {
            if (!PictureFileUpload.HasFile) return;

            var pictureFileBytes = PictureFileUpload.FileBytes;
            var pictureFileName = GetPictureFileName();
            var pictureDocumentLibrary = GetDocumentLibrary("User Profile Pictures");
            if (pictureDocumentLibrary == null) return;

            var pictureUrl = GetPictureUrl(pictureFileName);

            DeleteExistingPicturesForUser(pictureDocumentLibrary);
            UploadPictureToDocumentLibrary(pictureDocumentLibrary, pictureFileName, pictureFileBytes);
            UpdatePictureUrlInSiteUserInfoList(pictureUrl);
            UpdatePictureUrlInUserProfile(pictureUrl);
            CloseDialog(pictureUrl);
        }

        private void CloseDialog(string pictureUrl)
        {
            if (ClientScript.IsStartupScriptRegistered("CloseDialog")) return;
            
            var javascript = @"
                                ExecuteOrDelayUntilScriptLoaded(closeModal, ""sp.js"");                                

                                function closeModal(){                                
                                    var imageUrl = '#IMAGEURL#';
                                    SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, imageUrl);
                                }
                              ".Replace("#IMAGEURL#", pictureUrl);

            Page.ClientScript.RegisterStartupScript(GetType(), "CloseDialog", javascript, true);
        }

        private string GetPictureFileName()
        {
            var loginName = EPMLiveCore.CoreFunctions.GetCleanUserName(SPContext.Current.Web.CurrentUser.LoginName, SPContext.Current.Site);
            return string.Format("{0}{1}", loginName, Path.GetExtension(PictureFileUpload.FileName));
        }

        private static SPFolder GetDocumentLibrary(string documentLibraryName)
        {
            SPFolder documentLibrary = null;
            var web = SPContext.Current.Site.RootWeb;
            SPUtility.ValidateFormDigest();
            SPSecurity.RunWithElevatedPrivileges(delegate
                                                     {
                                                         // This is creating a new site and web to operate on because the web variable 
                                                         // using SPContext above wont elevate since the web object was already created.
                                                         // Thus we have to create a new web object inside the elevated permission block
                                                         // in order for it to run under elevated permissions.
                                                         using (var site = new SPSite(web.Site.Url))
                                                         {
                                                             using (var newWeb = site.OpenWeb())
                                                             {
                                                                 try
                                                                 {
                                                                     documentLibrary = newWeb.Folders[documentLibraryName];
                                                                 }
                                                                 catch (ArgumentException)
                                                                 {
                                                                     newWeb.Lists.Add(ProfilePictureLibraryName, null, SPListTemplateType.PictureLibrary);

                                                                     documentLibrary = newWeb.Folders[documentLibraryName];
                                                                 }
                                                             }
                                                         }
                                                     });
            return documentLibrary;
        }

        private static void UploadPictureToDocumentLibrary(SPFolder pictureDocumentLibrary, string pictureFileName, byte[] pictureFileBytes)
        {
            pictureDocumentLibrary.Files.Add(pictureFileName, pictureFileBytes, true);
            pictureDocumentLibrary.Update();
        }

        //private static string GetLoginNameWithoutDomain()
        //{
        //    var loginName = SPContext.Current.Web.CurrentUser.LoginName;
        //    var stop = loginName.IndexOf("\\");
        //    return (stop > -1) ? loginName.Substring(stop + 1, loginName.Length - stop - 1) : loginName;
        //}

        private static void UpdatePictureUrlInSiteUserInfoList(string pictureUrl)
        {
            var userInformationList = SPContext.Current.Web.SiteUserInfoList;
            var user = SPContext.Current.Web.CurrentUser;
            var userItem = userInformationList.GetItemById(user.ID);

            userItem["Picture"] = pictureUrl;
            userItem.Update();
        }

        /// <summary>
        /// Reflection is being used in this method because this code may be run on an environment hosting Sharepoint Foundation.
        /// In that case, there will be no Profile, so by using Reflection we can check first to see if they have the DLLs needed
        /// to update the users Profile (meaning if those DLLs are present, then they have Sharepoint Server installed). If they
        /// are present, then we update the Profile image, otherwise we just ignore.
        /// </summary>
        /// <param name="pictureUrl"></param>
        private static void UpdatePictureUrlInUserProfile(string pictureUrl)
        {
            if (string.IsNullOrEmpty(pictureUrl)) return;
            
            Assembly userProfileAssembly;

            var windowsFolderPath = Environment.GetEnvironmentVariable("windir");
            var pathToServerAssembly = string.Format(@"{0}\assembly\GAC_MSIL\Microsoft.Office.Server.UserProfiles\14.0.0.0__71e9bce111e9429c\Microsoft.Office.Server.UserProfiles.dll", windowsFolderPath);

            try
            {
                userProfileAssembly = Assembly.LoadFrom(pathToServerAssembly);
            }
            catch (FileNotFoundException)
            {
                // Assembly wasn't found, so eject.
                return;
            }

            var userProfileManagerClass = userProfileAssembly.GetType("Microsoft.Office.Server.UserProfiles.UserProfileManager");
            if (userProfileManagerClass == null) return;
            
            var userExistsMethod = userProfileManagerClass.GetMethod("UserExists");
            if (userExistsMethod == null) return;
            
            var getUserProfileMethod = userProfileManagerClass.GetMethod("GetUserProfile", new[]{typeof(string)});
            if (getUserProfileMethod == null) return;
            
            var instantiatedUserProfileManagerClass = Activator.CreateInstance(userProfileManagerClass);
            var userExists = (bool)userExistsMethod.Invoke(instantiatedUserProfileManagerClass, new object[] { SPContext.Current.Web.CurrentUser.LoginName });

            if (!userExists) return;
            
            var userProfileClass = userProfileAssembly.GetType("Microsoft.Office.Server.UserProfiles.UserProfile");
            var userProfile = getUserProfileMethod.Invoke(instantiatedUserProfileManagerClass, new object[] { SPContext.Current.Web.CurrentUser.LoginName });

            var indexProperty = userProfileClass
                                .GetProperties()
                                .Single(p => p.GetIndexParameters().Length == 1 && p.GetIndexParameters()[0].ParameterType == typeof(string));

            var collection = indexProperty.GetValue(userProfile, new object[] { "PictureUrl" });

            var valueProperty = collection.GetType().GetProperty("Value");
            valueProperty.SetValue(collection, pictureUrl, null);

            var commitMethod = userProfileClass.GetMethod("Commit");
            commitMethod.Invoke(userProfile, null);
        }

        private static string GetPictureUrl(string fileName)
        {
            return string.Format("{0}/{1}/{2}", SPContext.Current.Site.RootWeb.Url, ProfilePictureLibraryName, fileName);
        }

        private static void DeleteExistingPicturesForUser(SPFolder pictureDocumentLibrary)
        {
            var userName = EPMLiveCore.CoreFunctions.GetCleanUserName(SPContext.Current.Web.CurrentUser.LoginName, SPContext.Current.Site);
            var picturesToDelete = new List<SPFile>();
            
            foreach (SPFile file in pictureDocumentLibrary.Files)
            {
                if (Path.GetFileNameWithoutExtension(file.Name) == userName) picturesToDelete.Add(file);
            }
            
            foreach(var file in picturesToDelete)
            {
                file.Delete();
            }

            pictureDocumentLibrary.Update();
        }

    }
}
