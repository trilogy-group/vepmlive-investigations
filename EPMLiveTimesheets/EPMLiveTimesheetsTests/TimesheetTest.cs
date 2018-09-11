using System;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web.UI;
using EPMLive.TestFakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets;
using Shouldly;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Web.UI.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using System.Web;
using Microsoft.SharePoint.WebPartPages.Fakes;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using SystemWebPartsFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPart;

namespace EPMLiveTimesheets.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TimesheetTest : TestClassInitializer<TimeSheet>
    {
        private const string DummyUrl = "http://dummy.url";
        private HttpContext _httpContext;

        [TestInitialize]
        public new void TestInitialize()
        {
            ShimObject = ShimsContext.Create();
            ShimWebPart.AllInstances.ZoneIDGet = _ => DummyString;
            SystemWebPartsFakes.AllInstances.ZoneIndexGet = _ => DummyInt;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            TestEntity = new TimeSheet();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(TimeSheet));
            InitializeAllControls();
        }

        [TestMethod]
        public void RenderGrid_OnValidCall_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderGrid(false, "100", true);
        }

        [TestMethod]
        public void RenderGrid_OnImpersonateIsTrue_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderGrid(true, string.Empty, false);
        }

        private void TestRenderGrid(bool impersonate, string height, bool inEditMode)
        {
            // Arrange
            var stringWriter = new StringWriter();
            TestEntity.ID = DummyString;
            TestEntity.ZoneID = DummyString;
            SetupShimsForSqlClient();
            PrivateObject.SetField("list", new ShimSPList().Instance);
            PrivateObject.SetField("view", new ShimSPView().Instance);
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPView.AllInstances.TitleGet = _ => DummyString;
            ShimSPView.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPBaseCollection.AllInstances.GetEnumerator = instance =>
            {
                if (instance.GetType() == typeof(ShimSPFieldCollection)
                || instance.GetType() == typeof(SPFieldCollection))
                {
                    return new List<SPField>
                    {
                        new ShimSPField()
                    }.GetEnumerator();
                }
                if (instance.GetType() == typeof(ShimSPViewFieldCollection)
                || instance.GetType() == typeof(SPViewFieldCollection))
                {
                    return new List<string>
                    {
                        DummyString
                    }.GetEnumerator();
                }
                return new List<SPForm>
                {
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_DISPLAYFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_EDITFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_NEWFORM }
                }.GetEnumerator();
            };
            ShimSPField.AllInstances.ReorderableGet = _ => true;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimTemplateControl.AllInstances.LoadControlString = (_, name) =>
            {
                if (name.Contains("ToolBarButton.ascx"))
                {
                    return new ToolBarButtonFake();
                }
                return new Control();
            };
            PrivateObject.SetField("impersonate", impersonate);
            PrivateObject.SetField("username", DummyString);
            PrivateObject.SetField("editEvents", bool.FalseString.ToLower());
            PrivateObject.SetField("status", "New");
            PrivateObject.SetField("inEditMode", inEditMode);
            PrivateObject.SetField("worktoolbar", new ToolBarFake());
            ShimToolBar.AllInstances.ButtonsGet = _ => new RepeatedControls();
            ShimToolBar.AllInstances.RightButtonsGet = _ => new RepeatedControls();
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;
            ShimControl.AllInstances.RenderControlHtmlTextWriter = (_, __) => { };
            ShimHttpUtility.UrlEncodeString = str => str;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.LanguageGet = _ => DummyInt;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
             {
                 if (name.Equals("EPMLiveTSAllowNotes"))
                 {
                     return bool.TrueString;
                 }
                 if (name.Equals("EPMLiveDaySettings"))
                 {
                     return string.Join("|", Enumerable.Repeat<string>(bool.TrueString, 30));
                 }
                 return DummyString;
             };
            var request = new HttpRequest(DummyString, DummyUrl, DummyString);
            var response = new HttpResponse(TextWriter.Null);
            _httpContext = new HttpContext(request, response);
            ShimHttpContext.CurrentGet = () => _httpContext;
            ShimWebPart.AllInstances.HeightGet = _ => height;
            ShimWebPart.AllInstances.QualifierGet = _ => DummyString;

            // Act
            using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
                PrivateObject.Invoke("renderGrid", htmlTextWriter, new ShimSPWeb().Instance, new ShimSqlConnection().Instance);
            }
            var actualResult = stringWriter.ToString();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldContain("<style>"),
                () => actualResult.ShouldContain(DummyString),
                () => actualResult.ShouldContain(DummyUrl),
                () => actualResult.ShouldContain(".grid_hover { border: 10px solid #91CDF2; background-color: #F2FAFF }"),
                () => actualResult.ShouldContain("attachEvent(\"onXLE\",disableCells"),
                () => actualResult.ShouldContain("attachEvent(\"onXLE\",setAllUpdated"),
                () => actualResult.ShouldContain("LabelText='Default Display Form'"),
                () => actualResult.ShouldContain("LabelText='Default Edit Form'"),
                () => actualResult.ShouldContain("LabelText='Default New Form'"),
                () =>
                {
                    if (impersonate)
                    {
                        actualResult.ShouldContain($"allowOther={DummyString}&duser={DummyString}\";");
                    }
                    else
                    {
                        actualResult.ShouldContain($"allowOther={DummyString}\";");
                    }
                },
                () =>
                {
                    if (inEditMode)
                    {
                        actualResult.ShouldContain("var cols = 2;");
                    }
                    else
                    {
                        actualResult.ShouldContain("var cols = 1;");
                    }
                },
                () =>
                {
                    if (string.IsNullOrEmpty(height))
                    {
                        actualResult.ShouldContain(".enableAutoHeight(true)");
                    }
                    else
                    {
                        actualResult.ShouldContain(".enableAutoHeight(true,70,true);");
                    }
                });
        }

        private static void SetupShimsForSqlClient()
        {
            var readCount = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }
                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
        }
    }

    public class ToolBarButtonFake : ToolBarButton
    { }

    public class ToolBarFake: ToolBar
    { }
}
