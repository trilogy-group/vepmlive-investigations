using System;
using System.Collections.Generic;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public partial class ListDisplaySettingIteratorTests
    {
        private IDisposable _shimsContext;
        private AdoShims _adoShims;
        private SharepointShims _sharepointShims;
        private PrivateObject _privateObject;
        private ListDisplaySettingIterator _listDisplaySettingIterator;
        private HtmlTextWriterShims _htmlWriterShims;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _htmlWriterShims =  HtmlTextWriterShims.ShimHtmlTextWriterCalls();
            _listDisplaySettingIterator = new ListDisplaySettingIterator();
            _privateObject = new PrivateObject(_listDisplaySettingIterator);

            ArrangeShims();
        }

        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine(_htmlWriterShims.Contents.Values.Count);
            
            foreach(var sb in _htmlWriterShims.Contents.Values)
            {
                Console.WriteLine("<--");
                Console.WriteLine(sb.ToString());
                Console.WriteLine("-->");
            }
            _shimsContext.Dispose();
        }

        private void ArrangeShims()
        {
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.ListGet= _ => new ShimSPList();
            ShimSPContext.AllInstances.FormContextGet = _ => new ShimSPFormContext();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimGridGanttSettings.ConstructorSPList = (a,b) => { };
            ShimGridGanttSettings.AllInstances.DisplaySettingsGet = _ => "boo";
            ShimGridGanttSettings.AllInstances.EnableWorkListGet = _ => true;

            ShimSPSite.ConstructorGuid = (a, b) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.IDGet = _ => Guid.Empty;
            ShimSPSite.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();

            ShimSPWeb.AllInstances.IDGet = _ => Guid.Empty;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();

            ShimSPUser.AllInstances.LoginNameGet = _ => "LoginName";

            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();

            ShimControl.AllInstances.PageGet = _ => new ShimPage();

            ShimPage.AllInstances.RequestGet = page => new HttpRequest(string.Empty, "http://site.com", string.Empty);

            ShimFormComponent.AllInstances.ControlModeGet = _ => SPControlMode.Invalid;
            ShimFormComponent.AllInstances.ListGet = _ => new ShimSPList();
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimFormComponent.AllInstances.ListIdGet = _ => Guid.Empty;
            ShimFormComponent.AllInstances.ItemIdGet = _ => 123;
            
            ShimSPListItem.AllInstances.TitleGet = _ => "title";
            ShimSPListItem.AllInstances.ItemGetGuid = (a, b) => "item";

            ShimListDisplayUtils.ConvertFromStringString = _ => new Dictionary<string, Dictionary<string, string>>();

            ShimSPPageContentManager.RegisterClientScriptIncludeControlTypeStringString = (a, b, c, d) => { };

            ShimSPList.AllInstances.TitleGet = _ => "Resources";
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DocumentLibrary;

            ShimSqlDataReader.AllInstances.Read = _ => true;

            ShimDataRowCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimDataRow();

            ShimTemplateBasedControl.AllInstances.WebGet = _ => new ShimSPWeb();
            
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => "url";

            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => true;
            ShimCoreFunctions.GetScheduleStatusFieldSPListItem = _ => string.Empty;

            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (a, b) => new ShimSPForm();

            ShimSPForm.AllInstances.UrlGet = _ => "url";

            ShimHttpContext.CurrentGet = () => new ShimHttpContext();

            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();

            ShimHttpRequest.AllInstances.UrlGet = _ => new Uri("http://site.com");

            ShimTemplateBasedControl.AllInstances.ControlsGet = _ => new ShimControlCollection();

            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection();            

            ShimControlCollection.AllInstances.GetEnumerator = _ =>
            {
                var list = new List<Control>
                {
                    new ShimControl().Instance
                };
                return list.GetEnumerator();
            };
            ShimControlCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimControl();
            ShimControlCollection.AllInstances.CountGet = _ => 1;

            ShimFieldMetadata.AllInstances.FieldGet = _ => new ShimSPField();

            ShimSPField.AllInstances.InternalNameGet = _ => "name";
            ShimSPField.AllInstances.RequiredGet = _ => true;
            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (a, b) => "picture.jpg";

            ShimListDisplaySettingIteratorHelpers.GetCompositeFieldControlInt32 = (a, b) => new ShimCompositeField();
            ShimListDisplaySettingIteratorHelpers.GetFieldLabelControlInt32 = (a, b) => new ShimFieldLabel();
            ShimListDisplaySettingIteratorHelpers.GetFieldLabelControlInt32Int32Int32= (a, b, c, d) => new ShimFieldLabel();
            ShimListDisplaySettingIteratorHelpers.GetFormFieldControlInt32  = (a, b) => new ShimFormField();
            ShimListDisplaySettingIteratorHelpers.GetControlTypeControlInt32 = (a, b) => "Microsoft.SharePoint.WebControls.FormField";

            ShimBaseFieldControl.AllInstances.ItemFieldValueGet = _ => "fieldValue";
        }
    }
}