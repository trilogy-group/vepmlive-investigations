using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class UploadProfilePicture : LayoutsPageBase
    {
        #region Fields (2) 

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";
        private const string PROFILE_PICTURE_LIBRARY_NAME = "User Profile Pictures";

        #endregion Fields 

        #region Methods (15) 

        // Protected Methods (3) 

        protected void OnSaveButtonClicked(object sender, EventArgs e)
        {
            SPUtility.ValidateFormDigest();

            byte[] pic;

            string resizeInfo = ResizeInfoField.Value;
            if (!string.IsNullOrEmpty(resizeInfo))
            {
                pic = ResizeImage(resizeInfo);
            }
            else
            {
                using (var fileStore = new EPMLiveFileStore(Web))
                {
                    pic = fileStore.Get(FileNameField.Value);
                }
            }

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(Web.ID))
                    {
                        using (var fileStore = new EPMLiveFileStore(spWeb))
                        {
                            fileStore.Delete(FileNameField.Value);
                        }
                    }
                }
            });

            SavePicture(pic);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string style in new[] {"Vendors/ImageAreaSelect/imgareaselect-default.min"})
            {
                SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "stylesheets/" + style + ".css");
            }
        }

        protected void UploadPictureButton_Click(object sender, EventArgs e)
        {
            if (!PictureFileUpload.HasFile) return;

            using (var fileStore = new EPMLiveFileStore(Web))
            {
                FileNameField.Value = fileStore.Add(PictureFileUpload.FileBytes,
                    Path.GetExtension(PictureFileUpload.FileName));
            }

            UploadPanel.Visible = false;
            ResizePanel.Visible = true;
        }

        // Private Methods (12) 

        private void CloseDialog(string pictureUrl)
        {
            if (ClientScript.IsStartupScriptRegistered("CloseDialog")) return;

            string javascript = @"
                                SP.SOD.executeFunc('sp.js', 'SP.ClientContext', closeModal);
                                
                                function closeModal(){                                
                                    var imageUrl = '#IMAGEURL#';
                                    parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, imageUrl);
                                }
                              ".Replace("#IMAGEURL#", pictureUrl);

            Page.ClientScript.RegisterStartupScript(GetType(), "CloseDialog", javascript, true);
        }

        private void DeleteExistingPicturesForUser(SPFolder pictureDocumentLibrary)
        {
            string userName = GetCleanUserName(SPContext.Current.Web.CurrentUser.LoginName);
            var picturesToDelete = new List<SPFile>();

            foreach (SPFile file in pictureDocumentLibrary.Files)
            {
                if (Path.GetFileNameWithoutExtension(file.Name) == userName) picturesToDelete.Add(file);
            }

            foreach (SPFile file in picturesToDelete)
            {
                file.Delete();
            }

            pictureDocumentLibrary.Update();
        }

        private string GetCleanUserName(string loginName)
        {
            int indexForGettingEverythingAfterPipe = loginName.IndexOf("|", StringComparison.Ordinal) + 1;
            string loginNameWithDomain = loginName.Mid(indexForGettingEverythingAfterPipe);

            int indexForGettingEverythingAfterDomain = loginNameWithDomain.IndexOf("\\", StringComparison.Ordinal) + 1;
            string loginNameWithoutDomain = loginNameWithDomain.Mid(indexForGettingEverythingAfterDomain);

            if (loginNameWithoutDomain.Contains("|"))
            {
                int indexForAdditionalPipe = loginNameWithoutDomain.IndexOf("|", StringComparison.Ordinal) + 1;
                string loginNameWithOutExtraPipe = loginNameWithoutDomain.Mid(indexForAdditionalPipe);
                loginNameWithoutDomain = loginNameWithOutExtraPipe;
            }

            return loginNameWithoutDomain;
        }

        private static SPFolder GetDocumentLibrary(string documentLibraryName)
        {
            SPFolder documentLibrary = null;
            SPWeb web = SPContext.Current.Site.RootWeb;
            SPUtility.ValidateFormDigest();
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                // This is creating a new site and web to operate on because the web variable 
                // using SPContext above wont elevate since the web object was already created.
                // Thus we have to create a new web object inside the elevated permission block
                // in order for it to run under elevated permissions.
                using (var site = new SPSite(web.Site.Url))
                {
                    using (SPWeb newWeb = site.OpenWeb())
                    {
                        try
                        {
                            documentLibrary = newWeb.Folders[documentLibraryName];
                        }
                        catch (ArgumentException)
                        {
                            newWeb.Lists.Add(PROFILE_PICTURE_LIBRARY_NAME, null, SPListTemplateType.PictureLibrary);

                            documentLibrary = newWeb.Folders[documentLibraryName];
                        }
                    }
                }
            });
            return documentLibrary;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
        }

        private string GetPictureFileName()
        {
            string loginName = GetCleanUserName(SPContext.Current.Web.CurrentUser.LoginName);
            return string.Format("{0}.png", loginName);
        }

        private static string GetPictureUrl(string fileName)
        {
            return string.Format("{0}/{1}/{2}", SPContext.Current.Site.RootWeb.Url, PROFILE_PICTURE_LIBRARY_NAME,
                fileName);
        }

        private byte[] ResizeImage(string resizeInfo)
        {
            string[] picInfo = resizeInfo.Split('|');

            int width = int.Parse(picInfo[0]);
            int height = int.Parse(picInfo[1]);
            int targetWidth = int.Parse(picInfo[2]);
            int targetHeight = int.Parse(picInfo[3]);
            int x = int.Parse(picInfo[4]);
            int y = int.Parse(picInfo[5]);

            using (var fileStore = new EPMLiveFileStore(Web))
            {
                using (var sourceImage = new Bitmap(fileStore.GetStream(FileNameField.Value)))
                {
                    using (var bitmap = new Bitmap(width, height))
                    {
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            graphics.SmoothingMode = SmoothingMode.HighQuality;

                            graphics.DrawImage(sourceImage, new Rectangle(0, 0, width, height));

                            using (var memoryStream = new MemoryStream())
                            {
                                bitmap.Save(memoryStream, ImageFormat.Png);

                                using (var bmp = new Bitmap(bitmap))
                                {
                                    using (var pic = bmp.Clone(new Rectangle(x, y, targetWidth, targetHeight),
                                        bitmap.PixelFormat))
                                    {
                                        using (var stream = new MemoryStream())
                                        {
                                            pic.Save(stream, ImageFormat.Png);
                                            return stream.ToArray();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SavePicture(byte[] pic)
        {
            string pictureFileName = GetPictureFileName();
            SPFolder pictureDocumentLibrary = GetDocumentLibrary("User Profile Pictures");
            if (pictureDocumentLibrary == null) return;

            string pictureUrl = GetPictureUrl(pictureFileName);

            DeleteExistingPicturesForUser(pictureDocumentLibrary);
            UploadPictureToDocumentLibrary(pictureDocumentLibrary, pictureFileName, pic);
            UpdatePictureUrlInSiteUserInfoList(pictureUrl);
            UpdatePictureUrlInUserProfile(pictureUrl);
            CloseDialog(pictureUrl);
        }

        private static void UpdatePictureUrlInSiteUserInfoList(string pictureUrl)
        {
            SPList userInformationList = SPContext.Current.Web.SiteUserInfoList;
            SPUser user = SPContext.Current.Web.CurrentUser;
            SPListItem userItem = userInformationList.GetItemById(user.ID);

            userItem["Picture"] = pictureUrl;
            userItem.Update();
        }

        /// <summary>
        ///     Reflection is being used in this method because this code may be run on an environment hosting Sharepoint
        ///     Foundation.
        ///     In that case, there will be no Profile, so by using Reflection we can check first to see if they have the DLLs
        ///     needed
        ///     to update the users Profile (meaning if those DLLs are present, then they have Sharepoint Server installed). If
        ///     they
        ///     are present, then we update the Profile image, otherwise we just ignore.
        /// </summary>
        /// <param name="pictureUrl"></param>
        private static void UpdatePictureUrlInUserProfile(string pictureUrl)
        {
            if (string.IsNullOrEmpty(pictureUrl)) return;

            Assembly userProfileAssembly;

            string windowsFolderPath = Environment.GetEnvironmentVariable("windir");
            string pathToServerAssembly =
                string.Format(
                    @"{0}\assembly\GAC_MSIL\Microsoft.Office.Server.UserProfiles\14.0.0.0__71e9bce111e9429c\Microsoft.Office.Server.UserProfiles.dll",
                    windowsFolderPath);

            try
            {
                userProfileAssembly = Assembly.LoadFrom(pathToServerAssembly);
            }
            catch (FileNotFoundException)
            {
                // Assembly wasn't found, so eject.
                return;
            }

            Type userProfileManagerClass =
                userProfileAssembly.GetType("Microsoft.Office.Server.UserProfiles.UserProfileManager");
            if (userProfileManagerClass == null) return;

            MethodInfo userExistsMethod = userProfileManagerClass.GetMethod("UserExists");
            if (userExistsMethod == null) return;

            MethodInfo getUserProfileMethod = userProfileManagerClass.GetMethod("GetUserProfile",
                new[] {typeof (string)});
            if (getUserProfileMethod == null) return;

            object instantiatedUserProfileManagerClass = Activator.CreateInstance(userProfileManagerClass);
            var userExists =
                (bool)
                    userExistsMethod.Invoke(instantiatedUserProfileManagerClass,
                        new object[] {SPContext.Current.Web.CurrentUser.LoginName});

            if (!userExists) return;

            Type userProfileClass = userProfileAssembly.GetType("Microsoft.Office.Server.UserProfiles.UserProfile");
            object userProfile = getUserProfileMethod.Invoke(instantiatedUserProfileManagerClass,
                new object[] {SPContext.Current.Web.CurrentUser.LoginName});

            PropertyInfo indexProperty = userProfileClass
                .GetProperties()
                .Single(
                    p =>
                        p.GetIndexParameters().Length == 1 && p.GetIndexParameters()[0].ParameterType == typeof (string));

            object collection = indexProperty.GetValue(userProfile, new object[] {"PictureUrl"});

            PropertyInfo valueProperty = collection.GetType().GetProperty("Value");
            valueProperty.SetValue(collection, pictureUrl, null);

            MethodInfo commitMethod = userProfileClass.GetMethod("Commit");
            commitMethod.Invoke(userProfile, null);
        }

        private static void UploadPictureToDocumentLibrary(SPFolder pictureDocumentLibrary, string pictureFileName,
            byte[] pictureFileBytes)
        {
            pictureDocumentLibrary.Files.Add(pictureFileName, pictureFileBytes, true);
            pictureDocumentLibrary.Update();
        }

        #endregion Methods 
    }
}