using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI.WebControls;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveCore
{
    public static class ExtensionMethods
    {
        #region String Extensions

        /// <summary>
        ///     Compresses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string Compress(this string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            byte[] compressedData;
            using (var memoryStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gZipStream.Write(buffer, 0, buffer.Length);
                }

                memoryStream.Position = 0;

                compressedData = new byte[memoryStream.Length];
                memoryStream.Read(compressedData, 0, compressedData.Length);
            }

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);

            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        ///     Decodes to base64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string DecodeToBase64(this string value)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(value));
        }

        /// <summary>
        ///     Decompresses the specified compressed text.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        public static string Decompress(this string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        /// <summary>
        ///     Encodes to base64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(value));
        }

        /// <summary>
        ///     Determines whether the specified possible GUID is GUID.
        /// </summary>
        /// <param name="possibleGuid">The possible GUID.</param>
        /// <returns>
        ///     <c>true</c> if the specified possible GUID is GUID; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGuid(this string possibleGuid)
        {
            try
            {
                var gid = new Guid(possibleGuid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Generates MD5 hash for the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Md5(this string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(data);

            return hashData.Aggregate(String.Empty, (current, b) => current + b.ToString("X2"));
        }

        /// <summary>
        ///     Removes the accent.
        /// </summary>
        /// <param name="txt">The TXT.</param>
        /// <returns></returns>
        public static string RemoveAccent(this string txt)
        {
            return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(txt));
        }

        /// <summary>
        ///     Generates SHA1 hash for the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Sha1(this string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            byte[] hashData = new SHA1Managed().ComputeHash(data);

            return hashData.Aggregate(String.Empty, (current, b) => current + b.ToString("X2"));
        }

        /// <summary>
        ///     Slugifies the specified STR.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public static string Slugify(this string str)
        {
            str = str.RemoveAccent().ToPrettierName();
            return Regex.Replace(str, @"[^a-zA-Z0-9]", String.Empty).Trim(); // keep only numbers and latters
        }

        /// <summary>
        ///     Returns prettier name of the field.
        /// </summary>
        /// <param name="internalName">Name of the internal.</param>
        /// <returns></returns>
        public static string ToPrettierName(this string internalName)
        {
            #region Character Map

            var charMap = new Dictionary<string, string>
            {
                {" ", "_x0020_"},
                {"`", "_x0060_"},
                {"/", "_x002f_"},
                {".", "_x002e_"},
                {",", "_x002c_"},
                {"?", "_x003f_"},
                {">", "_x003e_"},
                {"<", "_x003c_"},
                {"\\", "_x005c_"},
                {"'", "_x0027_"},
                {";", "_x003b_"},
                {"|", "_x007c_"},
                {"\"", "_x0022_"},
                {":", "_x003a_"},
                {"}", "_x007d_"},
                {"{", "_x007b_"},
                {"=", "_x003d_"},
                {"-", "_x002d_"},
                {"+", "_x002b_"},
                {")", "_x0029_"},
                {"(", "_x0028_"},
                {"*", "_x002a_"},
                {"&", "_x0026_"},
                {"^", "_x005e_"},
                {"%", "_x0025_"},
                {"$", "_x0024_"},
                {"#", "_x0023_"},
                {"@", "_x0040_"},
                {"!", "_x0021_"},
                {"~", "_x007e_"}
            };

            #endregion

            internalName = charMap.Aggregate(internalName,
                (current, pair) => current.Replace(pair.Value, pair.Key.ToString()));
            internalName = Regex.Replace(Regex.Replace(internalName, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"),
                @"(\p{Ll})(\P{Ll})", "$1 $2");

            var regex = new Regex(@"[ ]{2,}", RegexOptions.None);

            return regex.Replace(internalName, @" ");
        }

        /// <summary>
        ///     Toes the name of the prettier.
        /// </summary>
        /// <param name="internalName">Name of the internal.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string ToPrettierName(this string internalName, SPWeb spWeb)
        {
            SPList spList = spWeb.Site.RootWeb.Lists.TryGetList("My Work");

            if (spList != null)
            {
                return spList.Fields.ContainsFieldWithInternalName(internalName)
                    ? spList.Fields.GetFieldByInternalName(internalName).Title
                    : ToPrettierName(internalName);
            }

            return ToPrettierName(internalName);
        }

        /// <summary>
        ///     Returns the left part of a string.
        /// </summary>
        /// <param name="param">The string to get the Left of.</param>
        /// <param name="length">The length of characters to return from the Left of the string.</param>
        /// <returns>The left part of the string for the specified amount of characters.</returns>
        public static string Left(this string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }

        /// <summary>
        ///     Returns the right part of a string.
        /// </summary>
        /// <param name="param">The string to get the Right of.</param>
        /// <param name="length">The length of characters to return from the Right of the string.</param>
        /// <returns>The Right part of the string for the specified amount of characters.</returns>
        public static string Right(this string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }

        /// <summary>
        ///     Returns the characters from the start index through to the specified length.
        /// </summary>
        /// <param name="param">The string to retrieve characters from.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length of characters to return.</param>
        /// <returns>The part of the string from the start index through to the specified length.</returns>
        public static string Mid(this string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        /// <summary>
        ///     Returns the characters from the start index through the end of the string.
        /// </summary>
        /// <param name="param">The string to retrieve characters from.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>The part of the string from the start index through the end of the string.</returns>
        public static string Mid(this string param, int startIndex)
        {
            string result = param.Substring(startIndex);
            return result;
        }

        /// <summary>
        ///     Object to bool converter.
        /// </summary>
        /// <returns>Returns false if value is null, false, no or 0. Returns true for everything else.</returns>
        public static bool ToBool(this object value)
        {
            if (value == null) return false;

            string val = value.ToString().Trim().ToLower();

            return val != "false" && val != "no" && val != "0";
        }

        #endregion

        #region SPFile Extensions

        /// <summary>
        ///     Gets the contents of a file.
        /// </summary>
        /// <param name="viewAspxFile">The view aspx file to obtain the contents from.</param>
        /// <returns></returns>
        public static string GetContents(this SPFile viewAspxFile)
        {
            string fileContents;

            using (Stream fileStream = viewAspxFile.OpenBinaryStream())
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    fileContents = streamReader.ReadToEnd();
                }
            }
            return fileContents;
        }

        /// <summary>
        ///     Updates the contents of a file then saves it to its respective document library.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="fileContents"></param>
        public static void UpdateContentsAndSave(this SPFile file, string fileContents)
        {
            byte[] htmlAsByteArray = new ASCIIEncoding().GetBytes(fileContents);
            file.ParentFolder.Files.Add(file.Url, htmlAsByteArray, true);
        }

        #endregion

        #region SPList Extensions

        /// <summary>
        ///     Gets the view's aspx file.
        /// </summary>
        /// <param name="listToCreateViewOn">The list to create view on.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static SPFile GetViewFile(this SPList listToCreateViewOn, SPView view)
        {
            return listToCreateViewOn.ParentWeb.GetFile(view.Url);
        }

        #endregion

        #region SPWeb Extensions

        /// <summary>
        ///     Gets the list by template id.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="templateId">The template id.</param>
        /// <returns></returns>
        public static IEnumerable<SPList> GetListByTemplateId(this SPWeb spWeb, int templateId)
        {
            IEnumerable<SPList> spLists =
                spWeb.Lists.Cast<SPList>().Where(spList => spList.BaseTemplate == (SPListTemplateType) templateId);

            if (spLists.Any()) return spLists;

            try
            {
                MemberInfo[] memberInfos = typeof (EPMLiveLists).GetMember(((EPMLiveLists) templateId).ToString());
                object[] customAttributes = memberInfos[0].GetCustomAttributes(typeof (ListAttribute), false);
                string listName = ((ListAttribute) customAttributes[0]).Name;

                SPList spList = spWeb.Lists.TryGetList(listName);

                return spList != null ? new List<SPList> {spList} : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     Gets the safe the server relative URL.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string SafeServerRelativeUrl(this SPWeb spWeb)
        {
            return (spWeb.ServerRelativeUrl.Equals("/")) ? String.Empty : spWeb.ServerRelativeUrl;
        }

        /// <summary>
        ///     Returns the list of web tree
        /// </summary>
        /// <param name="web">The web.</param>
        /// <returns></returns>
        public static List<Guid> ToTreeList(this SPWeb web)
        {
            var treeList = new List<Guid>();

            GetWebTree(web.ID, web.Site.Url, ref treeList);

            return treeList;
        }

        #endregion

        #region Web Control Extensions

        /// <summary>
        ///     Sorts the specified list box.
        /// </summary>
        /// <param name="listBox">The list box.</param>
        public static void Sort(this ListBox listBox)
        {
            var list = new List<ListItem>(listBox.Items.Cast<ListItem>());
            list = list.OrderBy(li => li.Text).ToList();
            listBox.Items.Clear();
            listBox.Items.AddRange(list.ToArray<ListItem>());
        }

        public static void Sort(this ListControl listControl)
        {
            var list = new List<ListItem>(listControl.Items.Cast<ListItem>());
            list = list.OrderBy(li => li.Text).ToList();
            listControl.Items.Clear();
            listControl.Items.AddRange(list.ToArray<ListItem>());
        }

        #endregion

        #region DateTime Extensions

        /// <summary>
        ///     Gets the start of the week
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dateTime)
        {
            return
                DateTime.Today.AddDays(
                    -(DateTime.Today.DayOfWeek - Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek));
        }

        /// <summary>
        ///     Converts the date to the friendly date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToFriendlyDate(this DateTime dateTime)
        {
            string friendlyDate;

            DateTime now = DateTime.Today;

            DateTime thisWeek = now.StartOfWeek();
            DateTime lastWeek = thisWeek.AddDays(-7);
            DateTime nextWeek = thisWeek.AddDays(7);

            TimeSpan timeSpan = now - dateTime;

            switch (timeSpan.Days)
            {
                case 1:
                    friendlyDate = "Yesterday";
                    break;
                case 0:
                    friendlyDate = "Today";
                    break;
                case -1:
                    friendlyDate = "Tomorrow";
                    break;
                default:
                {
                    TimeSpan lastWeekTimeSpan = lastWeek - dateTime;

                    if (lastWeekTimeSpan.Days > 0) friendlyDate = dateTime.ToString("MMM d");
                    else
                    {
                        TimeSpan thisWeekTimeSpan = thisWeek - dateTime;

                        if (lastWeekTimeSpan.Days <= 0 && thisWeekTimeSpan.Days > 0)
                            friendlyDate = "Last " + dateTime.DayOfWeek;
                        else
                        {
                            TimeSpan nowTimeSpan = now - dateTime;

                            if (nowTimeSpan.Days > 0 && thisWeekTimeSpan.Days <= 0)
                                friendlyDate = dateTime.DayOfWeek.ToString();
                            else
                            {
                                TimeSpan nextWeekTimeSpan = nextWeek - dateTime;

                                //if (nowTimeSpan.Days < 0 && nextWeekTimeSpan.Days > 0)
                                if (dateTime > now && dateTime <= now.AddDays(7))
                                    friendlyDate = "This " + dateTime.DayOfWeek;
                                else if (nextWeekTimeSpan.Days <= 0 && (nextWeek.AddDays(7) - dateTime).Days > 0)
                                    friendlyDate = "Next " + dateTime.DayOfWeek;
                                else friendlyDate = dateTime.ToString("MMM d");
                            }
                        }
                    }
                }
                    break;
            }

            return friendlyDate;
        }

        /// <summary>
        ///     Converts the date to the friendly date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToFriendlyDateAndTime(this DateTime dateTime)
        {
            string friendlyDate;

            DateTime now = DateTime.Today;

            DateTime thisWeek = now.StartOfWeek();
            DateTime lastWeek = thisWeek.AddDays(-7);
            DateTime nextWeek = thisWeek.AddDays(7);

            int days = now.Day - dateTime.Day;

            switch (days)
            {
                case 1:
                    friendlyDate = "Yesterday at " + new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                    break;
                case 0:
                    friendlyDate = "Today at " + new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                    break;
                case -1:
                    friendlyDate = "Tomorrow at " + new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                    break;
                default:
                {
                    TimeSpan lastWeekTimeSpan = lastWeek - dateTime;

                    if (lastWeekTimeSpan.Days > 0)
                        friendlyDate = dateTime.ToString("M/dd/yyyy") + " at " + dateTime.ToString("hh:mm:ss tt");
                    else
                    {
                        TimeSpan thisWeekTimeSpan = thisWeek - dateTime;

                        if (lastWeekTimeSpan.Days <= 0 && thisWeekTimeSpan.Days > 0)
                            friendlyDate = "Last " + dateTime.DayOfWeek + " at " +
                                           new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                        else
                        {
                            TimeSpan nowTimeSpan = now - dateTime;

                            if (nowTimeSpan.Days > 0 && thisWeekTimeSpan.Days <= 0)
                                friendlyDate = dateTime.DayOfWeek + " at " +
                                               new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                            else
                            {
                                TimeSpan nextWeekTimeSpan = nextWeek - dateTime;

                                //if (nowTimeSpan.Days < 0 && nextWeekTimeSpan.Days > 0)
                                if (dateTime > now && dateTime <= now.AddDays(7))
                                    friendlyDate = "This " + dateTime.DayOfWeek + " at " +
                                                   new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                                else if (nextWeekTimeSpan.Days <= 0 && (nextWeek.AddDays(7) - dateTime).Days > 0)
                                    friendlyDate = "Next " + dateTime.DayOfWeek + " at " +
                                                   new DateTime(dateTime.TimeOfDay.Ticks).ToString("hh:mm:ss tt");
                                else
                                    friendlyDate = dateTime.ToString("M/dd/yyyy") + " at " +
                                                   dateTime.ToString("hh:mm:ss tt");
                            }
                        }
                    }
                }
                    break;
            }

            return friendlyDate;
        }

        /// <summary>
        ///     Toes the regional date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string ToRegionalDateTime(this DateTime dateTime, SPWeb spWeb)
        {
            using (var spSite = new SPSite(spWeb.Site.ID))
            {
                using (SPWeb web = spSite.OpenWeb(spWeb.ID))
                {
                    SPUser user = web.CurrentUser;

                    SPRegionalSettings spRegionalSettings = user.RegionalSettings ?? web.RegionalSettings;

                    return dateTime != DateTime.MinValue
                        ? spRegionalSettings.TimeZone.UTCToLocalTime(dateTime.ToUniversalTime()).ToString(
                            new CultureInfo((int) spRegionalSettings.LocaleId))
                        : String.Empty;
                }
            }
        }

        /// <summary>
        ///     Converts the UNIX time to DateTime
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
        }

        /// <summary>
        ///     Converts the DateTime to UNIX time
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime dateTime)
        {
            return Convert.ToInt64((dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
        }

        #endregion

        #region SPListItemCollection Extensions

        /// <summary>
        ///     Determines whether the specified sp list item collection has items.
        /// </summary>
        /// <param name="spListItemCollection">The sp list item collection.</param>
        /// <returns>
        ///     <c>true</c> if the specified sp list item collection has items; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasItems(this SPListItemCollection spListItemCollection)
        {
            try
            {
                return spListItemCollection.Count > 0;
            }
            catch { }

            return false;
        }

        #endregion

        #region SPFieldCollection Extensions

        /// <summary>
        ///     Determines whether [the specified sp field collection] [contains field with internal name].
        /// </summary>
        /// <param name="spFieldCollection">The sp field collection.</param>
        /// <param name="spFieldInternalName">Name of the sp field internal.</param>
        /// <returns>
        ///     <c>true</c> if [the specified sp field collection] [contains field with internal name]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsFieldWithInternalName(this SPFieldCollection spFieldCollection,
            string spFieldInternalName)
        {
            try
            {
                spFieldCollection.GetFieldByInternalName(spFieldInternalName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Byte Array Extensions

        /// <summary>
        ///     Decompresses the SP compressed string.
        /// </summary>
        /// <param name="compressedBytesBuffer">The compressed bytes buffer.</param>
        /// <returns></returns>
        public static string SpDecompress(this byte[] compressedBytesBuffer)
        {
            string uncompressedString;

            using (var compressedMemoryStream = new MemoryStream(compressedBytesBuffer))
            {
                compressedMemoryStream.Position += 12; // Compress Structure Header according to [MS -WSSFO2].
                compressedMemoryStream.Position += 2; // Zlib header.

                using (var deflateStream = new DeflateStream(compressedMemoryStream, CompressionMode.Decompress))
                {
                    using (var uncompressedMemoryStream = new MemoryStream())
                    {
                        deflateStream.CopyStream(uncompressedMemoryStream);

                        uncompressedMemoryStream.Position = 0;

                        using (var streamReader = new StreamReader(uncompressedMemoryStream))
                        {
                            uncompressedString = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return uncompressedString;
        }

        #endregion

        #region Stream Extensions

        /// <summary>
        ///     Copies the stream.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        private static void CopyStream(this Stream input, Stream output)
        {
            var buffer = new byte[32768];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0) return;
                output.Write(buffer, 0, read);
            }
        }

        #endregion

        #region Generic List Extensions

        /// <summary>
        ///     Creates a comma separated string from the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string AsDelimitedString(this IEnumerable<string> list, string delimiter)
        {
            return String.Join(delimiter, list.Select(x => x.ToString()).ToArray());
        }

        /// <summary>
        ///     Populates the list from a comma separated string.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="stringToSeparate">The string to separate.</param>
        public static void PopulateFromCommaSeparatedString(this List<string> list, string stringToSeparate)
        {
            string[] separatedString = stringToSeparate.Split(new[] {','});
            list.AddRange(separatedString);
        }

        #endregion

        #region SPUser Extensions

        /// <summary>
        ///     Gets the ext id.
        /// </summary>
        /// <param name="spUser">The sp user.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static int GetExtId(this SPUser spUser, SPWeb spWeb)
        {
            SPList spList = spWeb.Lists.TryGetList("Resources");

            if (spList == null) return -1;

            SPListItemCollection spListItemCollection = spList.GetItems(new SPQuery
            {
                Query =
                    @"<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='Integer'><UserID/></Value></Eq></Where>"
            });

            if (spListItemCollection.Count > 0)
            {
                try
                {
                    return int.Parse(spListItemCollection[0]["EXTID"].ToString());
                }
                catch (Exception)
                {
                    return -3;
                }
            }

            return -2;
        }

        /// <summary>
        ///     Gets the resource pool id.
        /// </summary>
        /// <param name="spUser">The sp user.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static int GetResourcePoolId(this SPUser spUser, SPWeb spWeb)
        {
            SPList spList = spWeb.Lists.TryGetList("Resources");

            if (spList == null) return -1;

            SPListItemCollection spListItemCollection = spList.GetItems(new SPQuery
            {
                Query =
                    @"<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='Integer'><UserID/></Value></Eq></Where>"
            });

            if (spListItemCollection.Count > 0)
            {
                return spListItemCollection[0].ID;
            }

            return -2;
        }

        #endregion

        #region SPLimitedWebPartExtensions

        /// <summary>
        ///     Gets the name of the web part by type.
        /// </summary>
        /// <param name="webPartManager">The web part manager.</param>
        /// <param name="webPartType">The web part type.</param>
        /// <returns></returns>
        public static WebPart GetWebPartByTypeName(this SPLimitedWebPartManager webPartManager, string webPartType)
        {
            return
                webPartManager.WebParts.Cast<WebPart>()
                    .FirstOrDefault(webPart => webPart.GetType().ToString().ToLower().Contains(webPartType.ToLower()));
        }

        #endregion

        #region TreeView Extensions

        public static void Sort(this TreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;

            var nodeCollection = new TreeNode[nodes.Count];
            nodes.CopyTo(nodeCollection, 0);

            Array.Sort(nodeCollection, new TreeNodeComparer());

            nodes.Clear();
            foreach (TreeNode node in nodeCollection)
            {
                nodes.Add(node);
            }
        }

        public class TreeNodeComparer : IComparer
        {
            #region Implementation of IComparer

            public int Compare(object x, object y)
            {
                return String.CompareOrdinal(((TreeNode) x).Text, ((TreeNode) y).Text);
            }

            #endregion
        }

        #endregion

        #region Object Extensions

        public static long GetSize(this object obj)
        {
            long size = 0L;

            if (obj == null || obj == DBNull.Value) return size;

            Type t = obj.GetType();

            Type baseType = t.BaseType;
            string typeName = t.FullName;

            if (baseType != null && baseType.FullName.Equals("System.ValueType"))
            {
                size += GetTypeSize(typeName);
            }
            else if (baseType != null && baseType.FullName.Equals("System.Array"))
            {
                size += GetTypeSizeArray(typeName, obj);
            }
            else if (baseType != null && baseType.FullName.Equals("System.Enum"))
            {
                size += Marshal.SizeOf(Enum.GetUnderlyingType(t));
            }
            else if (typeName.Equals("System.String"))
            {
                size += obj.ToString().Length*sizeof (Char);
            }
            else if (typeName.Equals("System.DateTime"))
            {
                size += 8;
            }
            else
            {
                IEnumerable<FieldInfo> fields = GetFields(t);

                size += (from fieldInfo in fields
                    select fieldInfo.GetValue(obj)
                    into subObj
                    where subObj != obj
                    where subObj != null
                    select GetSize(subObj)).Sum();
            }

            return size;
        }

        private static IEnumerable<FieldInfo> GetFields(Type type)
        {
            List<FieldInfo> fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                    BindingFlags.Instance | BindingFlags.Static).ToList();

            Type baseType = type.BaseType;
            if (baseType == null) return fields;

            if (baseType != type)
            {
                fields.AddRange(GetFields(baseType));
            }

            return fields;
        }

        private static long GetTypeSizeArray(string typeName, object objValue)
        {
            switch (typeName)
            {
                case "System.Double[]":
                    return sizeof (Double)*((Double[]) objValue).Length;
                case "System.Single[]":
                    return sizeof (Single)*((Single[]) objValue).Length;
                case "System.Char[]":
                    return sizeof (Char)*((Char[]) objValue).Length;
                case "System.Int16[]":
                    return sizeof (Int16)*((Int16[]) objValue).Length;
                case "System.Int32[]":
                    return sizeof (Int32)*((Int32[]) objValue).Length;
                case "System.Int64[]":
                    return sizeof (Int64)*((Int64[]) objValue).Length;
                case "System.UInt16[]":
                    return sizeof (UInt16)*((UInt16[]) objValue).Length;
                case "System.UInt32[]":
                    return sizeof (UInt32)*((UInt32[]) objValue).Length;
                case "System.UInt64[]":
                    return sizeof (UInt64)*((UInt64[]) objValue).Length;
                case "System.Decimal[]":
                    return sizeof (Decimal)*((Decimal[]) objValue).Length;
                case "System.Byte[]":
                    return sizeof (Byte)*((Byte[]) objValue).Length;
                case "System.SByte[]":
                    return sizeof (SByte)*((SByte[]) objValue).Length;
                case "System.Boolean":
                    return sizeof (Boolean)*((Boolean[]) objValue).Length;
                default:
                    var enumerable = objValue as IEnumerable;

                    if (enumerable == null) return 0L;

                    long size = 0;
                    foreach (object obj in enumerable)
                    {
                        if (obj != null) size += obj.GetSize();
                    }

                    return size;
            }
        }

        private static long GetTypeSize(string typeName)
        {
            switch (typeName)
            {
                case "System.Double":
                    return sizeof (Double);
                case "System.Single":
                    return sizeof (Single);
                case "System.Char":
                    return sizeof (Char);
                case "System.Int16":
                    return sizeof (Int16);
                case "System.Int32":
                    return sizeof (Int32);
                case "System.Int64":
                    return sizeof (Int64);
                case "System.UInt16":
                    return sizeof (UInt16);
                case "System.UInt32":
                    return sizeof (UInt32);
                case "System.UInt64":
                    return sizeof (UInt64);
                case "System.Decimal":
                    return sizeof (Decimal);
                case "System.Byte":
                    return sizeof (Byte);
                case "System.SByte":
                    return sizeof (SByte);
                case "System.Boolean":
                    return sizeof (Boolean);
                default:
                    return 0;
            }
        }

        #endregion

        #region Private Helpers

        /// <summary>
        ///     Gets the web tree.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <param name="tree">The tree.</param>
        private static void GetWebTree(Guid id, string siteUrl, ref List<Guid> tree)
        {
            tree.Add(id);

            using (var spSite = new SPSite(siteUrl))
            {
                using (SPWeb spWeb = spSite.OpenWeb(id))
                {
                    if (spWeb.Webs.Count == 0) return;

                    SPWebCollection spWebCollection = spWeb.Webs;
                    for (int i = 0; i < spWebCollection.Count; i++)
                    {
                        using (SPWeb web = spWebCollection[i])
                        {
                            GetWebTree(web.ID, siteUrl, ref tree);
                        }
                    }
                }
            }
        }

        #endregion
    }
}