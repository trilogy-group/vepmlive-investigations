using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the global views.
        /// </summary>
        /// <param name="configWeb">The config web.</param>
        /// <returns></returns>
        public static IEnumerable<MyWorkGridView> GetGlobalViews(SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            try
            {
                using (configWeb)
                {
                    var serializedGlobalViews = CoreFunctions.getConfigSetting(configWeb, MyWorkGridGlobalViews);

                    if (!string.IsNullOrWhiteSpace(serializedGlobalViews))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(List<MyWorkGridView>));
                        return
                            (IEnumerable<MyWorkGridView>)
                            xmlSerializer.Deserialize(new StringReader(serializedGlobalViews));
                    }
                }

                return new List<MyWorkGridView>();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2081, exception.Message);
            }
        }

        /// <summary>
        ///     Saves the global views.
        /// </summary>
        /// <param name="myWorkGridView">My work grid view.</param>
        /// <param name="configWeb">The config web.</param>
        public static void SaveGlobalViews(MyWorkGridView myWorkGridView, SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(myWorkGridView, nameof(myWorkGridView));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            var myWorkGridViews = GetGlobalViews(configWeb).ToList();
            myWorkGridViews.RemoveAll(v => v.Id.Equals(myWorkGridView.Id));

            if (myWorkGridView.Default)
            {
                foreach (var gridView in myWorkGridViews)
                {
                    gridView.Default = false;
                }
            }

            myWorkGridViews.Add(myWorkGridView);
            SaveGlobalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Deletes the global view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="globalViews">The global views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void DeleteGlobalView(string viewId, bool isDefault, IEnumerable<MyWorkGridView> globalViews, SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(globalViews, nameof(globalViews));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            var myWorkGridViews = globalViews.ToList();
            myWorkGridViews.RemoveAll(v => v.Id.Equals(viewId));

            if (isDefault)
            {
                if (myWorkGridViews.FirstOrDefault(p => p.Id.Equals(Dv)) != null)
                {
                    myWorkGridViews.FirstOrDefault(p => p.Id.Equals(Dv)).Default = true;
                }
            }

            SaveGlobalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Renames the global view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="globalViews">The global views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void RenameGlobalView(
            string viewId,
            string viewName,
            IEnumerable<MyWorkGridView> globalViews,
            SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(globalViews, nameof(globalViews));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            var myWorkGridViews = globalViews.ToList();

            foreach (
                var myWorkGridView in
                myWorkGridViews.Where(myWorkGridView => myWorkGridView.Id.Equals(viewId)))
            {
                myWorkGridView.Name = viewName;
            }

            SaveGlobalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Saves the global views.
        /// </summary>
        /// <param name="myWorkGridViews">My work grid views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void SaveGlobalViews(IEnumerable<MyWorkGridView> myWorkGridViews, SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(myWorkGridViews, nameof(myWorkGridViews));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            try
            {
                var stringWriter = new StringWriter();
                var xmlSerializer = new XmlSerializer(typeof(List<MyWorkGridView>));
                xmlSerializer.Serialize(stringWriter, myWorkGridViews);
                stringWriter.Close();

                SPSecurity.RunWithElevatedPrivileges(
                    () =>
                    {
                        configWeb.AllowUnsafeUpdates = true;
                        CoreFunctions.setConfigSetting(
                            configWeb,
                            MyWorkGridGlobalViews,
                            stringWriter.ToString());
                        configWeb.AllowUnsafeUpdates = false;
                    });
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2094, exception.Message);
            }
        }
    }
}