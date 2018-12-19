using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.MyWork
{
    [TestClass, ExcludeFromCodeCoverage]
    public class MyPersonalizationTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string DummyResult = "DummyResult";
        private const string ExampleUrl = "http://example.com";
        private IDisposable _shimsContext;
        private bool _connectedToDb;
        private bool _unconnectedFromDb;
        private ShimSqlParameterCollection _commandParameters;
        private Dictionary<string, object> _parameters;
        private List<string> _sqlCommands;
        private bool _didExecuteNonQuery;
        private Guid _listId;
        private Guid _webId;
        private Guid _siteId;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            _connectedToDb = false;
            _unconnectedFromDb = false;
            _didExecuteNonQuery = false;
            _sqlCommands = new List<string>();
            _listId = Guid.NewGuid();
            _webId = Guid.NewGuid();
            _siteId = Guid.NewGuid();

            _parameters = new Dictionary<string, object>();
            _commandParameters = new ShimSqlParameterCollection
            {
                AddWithValueStringObject = (key, value) =>
                {
                    _parameters[key] = value;
                    return new SqlParameter();
                }
            };

            CreateSPContextShims();
            CreateSqlConnectionShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void SetPersonalizations_ContainsKeyValuePair_ExecutesUpdate()
        {
            // Arrange
            var keyValuePair = new Dictionary<string, string>
            {
                { DummyString, One }
            };

            // Act
            MyPersonalization.SetPersonalizations(keyValuePair, DummyString, Id, _listId, _webId, _siteId, ExampleUrl);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _connectedToDb.ShouldBeTrue(),
                () => _unconnectedFromDb.ShouldBeTrue(),
                () => _sqlCommands.Any(c => c.Contains("UPDATE PERSONALIZATIONS SET Value = @value WHERE [Key] = @key AND UserId = @username")).ShouldBeTrue(),
                () => _parameters.ShouldContainKey("@key"),
                () => _parameters.ShouldContainKey("@value"),
                () => _parameters.ShouldContainKey("@username"),
                () => _parameters.ShouldContainKey("@itemId"),
                () => _parameters.ShouldContainKey("@listId"),
                () => _parameters.ShouldContainKey("@webId"),
                () => _parameters.ShouldContainKey("@siteId"),
                () => _parameters["@key"].ShouldBe(DummyString),
                () => _parameters["@value"].ShouldBe(One),
                () => _parameters["@username"].ShouldBe(DummyString),
                () => _parameters["@itemId"].ShouldBe(Id),
                () => _parameters["@listId"].ShouldBe(_listId),
                () => _parameters["@webId"].ShouldBe(_webId),
                () => _parameters["@siteId"].ShouldBe(_siteId),
                () => _didExecuteNonQuery.ShouldBeTrue());
        }

        [TestMethod]
        public void SetPersonalizations_DoesNotContainKeyValuePair_ExecutesInsert()
        {
            // Arrange
            var keyValuePair = new Dictionary<string, string>
            {
                { One, One }
            };

            // Act
            MyPersonalization.SetPersonalizations(keyValuePair, DummyString, Id, _listId, _webId, _siteId, ExampleUrl);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _connectedToDb.ShouldBeTrue(),
                () => _unconnectedFromDb.ShouldBeTrue(),
                () => _sqlCommands.Any(c => c.Contains("INSERT INTO PERSONALIZATIONS ([Key], Value, UserId, ItemID, ListID, WebID, SiteID)")).ShouldBeTrue(),
                () => _didExecuteNonQuery.ShouldBeTrue());
        }

        [TestMethod]
        public void GetPersonalizationValue_Invoke_ExecutesSelectAndReturnsResult()
        {
            // Arrange
            var keyValuePair = new Dictionary<string, string>
            {
                { DummyString, One }
            };

            // Act
            var result = MyPersonalization.GetPersonalizationValue(DummyString, new ShimSPWeb(), new ShimSPList());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _connectedToDb.ShouldBeTrue(),
                () => _unconnectedFromDb.ShouldBeTrue(),
                () => _sqlCommands.ShouldContain("SELECT VALUE FROM PERSONALIZATIONS where userid=@userid and [key]=@key and listid=@listid"),
                () => _parameters.ShouldContainKey("@userid"),
                () => _parameters.ShouldContainKey("@key"),
                () => _parameters.ShouldContainKey("@listid"),
                () => _parameters["@userid"].ShouldBe(One),
                () => _parameters["@key"].ShouldBe(DummyString),
                () => _parameters["@listid"].ShouldBe(_listId),
                () => _didExecuteNonQuery.ShouldBeTrue(),
                () => result.ShouldBe(DummyResult));
        }

        [TestMethod]
        public void UpdatePersonalizationValue_Invoke_ExecutesUpdate()
        {
            // Arrange
            var keyValuePair = new Dictionary<string, string>
            {
                { DummyString, One }
            };

            // Act
            MyPersonalization.UpdatePersonalizationValue(keyValuePair, One, _listId, _webId, _siteId, ExampleUrl);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _connectedToDb.ShouldBeTrue(),
                () => _unconnectedFromDb.ShouldBeTrue(),
                () => _sqlCommands.ShouldContain("UPDATE PERSONALIZATIONS SET Value = @value WHERE [Key] = @key AND UserId = @userId AND ListId = @listId AND WebId = @webId AND SiteId = @siteId"),
                () => _parameters.ShouldContainKey("@key"),
                () => _parameters.ShouldContainKey("@value"),
                () => _parameters.ShouldContainKey("@listId"),
                () => _parameters.ShouldContainKey("@webId"),
                () => _parameters.ShouldContainKey("@siteId"),
                () => _parameters["@key"].ShouldBe(DummyString),
                () => _parameters["@value"].ShouldBe(One),
                () => _parameters["@listId"].ShouldBe(_listId),
                () => _parameters["@webId"].ShouldBe(_webId),
                () => _parameters["@siteId"].ShouldBe(_siteId),
                () => _didExecuteNonQuery.ShouldBeTrue());
        }

        [TestMethod]
        public void DeletePersonalization_Invoke_ExecutesDelete()
        {
            // Arrange
            var listId = Guid.NewGuid();
            var webId = Guid.NewGuid();
            var siteId = Guid.NewGuid();

            // Act
            MyPersonalization.DeletePersonalization(DummyString, One, listId, webId, siteId, ExampleUrl);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _connectedToDb.ShouldBeTrue(),
                () => _unconnectedFromDb.ShouldBeTrue(),
                () => _sqlCommands.ShouldContain("DELETE FROM PERSONALIZATIONS WHERE [Key] = @key AND UserId = @userId AND ListId = @listId AND WebId = @webId AND SiteId = @siteId"),
                () => _parameters.ShouldContainKey("@key"),
                () => _parameters.ShouldContainKey("@listId"),
                () => _parameters.ShouldContainKey("@webId"),
                () => _parameters.ShouldContainKey("@siteId"),
                () => _parameters["@key"].ShouldBe(DummyString),
                () => _parameters["@listId"].ShouldBe(listId),
                () => _parameters["@webId"].ShouldBe(webId),
                () => _parameters["@siteId"].ShouldBe(siteId),
                () => _didExecuteNonQuery.ShouldBeTrue());
        }

        [TestMethod]
        public void GetMyPersonalization_ValidateException_Throws()
        {
            // Arrange
            var data = GetXmlData();
            ShimUtils.ValidateItemListWebAndSiteXElement = _ => { throw new InvalidOperationException(DummyString); };

            // Act
            var action = new Action(() => MyPersonalization.GetMyPersonalization(data));

            // Assert
            var exception = action.ShouldThrow<APIException>();
            this.ShouldSatisfyAllConditions(
                () => exception.ExceptionNumber.ShouldBe(5005),
                () => exception.Message.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetMyPersonalization_Get_ReturnsXml()
        {
            // Arrange
            ShimUtils.ValidateItemListWebAndSiteXElement = _ => { };

            // Act
            var result = MyPersonalization.GetMyPersonalization(GetXmlData());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContainWithoutWhitespace("<MyPersonalization>"),
                () => result.ShouldContainWithoutWhitespace($"<Personalizations Username=\"{DummyResult}\" ItemID=\"{One}\" ListID=\"{_listId}\" WebID=\"{_webId}\" SiteID=\"{_siteId}\" SiteURL=\"{ExampleUrl}\""),
                () => result.ShouldContainWithoutWhitespace($"<Personalization ID=\"{One}\" Key=\"{DummyString}\" Value=\"0\" />"),
                () => result.ShouldContainWithoutWhitespace("</Personalizations>"),
                () => result.ShouldContainWithoutWhitespace("</MyPersonalization>"));
        }

        [TestMethod]
        public void SetMyPersonalization_Set_ReturnsXml()
        {
            // Arrange
            ShimUtils.ValidateItemListWebAndSiteXElement = _ => { };

            // Act
            var result = MyPersonalization.SetMyPersonalization(GetMyPersonalizationsXmlData());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe("<MyPersonalization />"));
        }

        private string GetXmlData()
        {
            return $@"<MyPersonalization>
                        <Keys>1,2,3</Keys>
                        <Item ID=""{Id}""></Item>
                        <List ID=""{_listId}""></List>
                        <Web ID=""{_webId}""></Web>
                        <Site ID=""{_siteId}"" URL=""{ExampleUrl}""></Site>
                    </MyPersonalization>";
        }

        private string GetMyPersonalizationsXmlData()
        {
            return $@"<MyPersonalization>
                        <Keys>1,2,3</Keys>
                        <Item ID=""{Id}""></Item>
                        <List ID=""{_listId}""></List>
                        <Web ID=""{_webId}""></Web>
                        <Site ID=""{_siteId}"" URL=""{ExampleUrl}""></Site>
                        <Personalizations>
                            <Personalization Key=""{One}"" Value=""{DummyResult}"">
                            </Personalization>
                        </Personalizations>
                    </MyPersonalization>";
        }

        private void CreateSqlConnectionShims()
        {
            var didRead = false;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => _connectedToDb = true;
            ShimSqlConnection.AllInstances.Close = _ => _unconnectedFromDb = true;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, command, __) => _sqlCommands.Add(command);
            ShimSqlCommand.AllInstances.ParametersGet = _ => _commandParameters;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _didExecuteNonQuery = true;
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                didRead = false;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (didRead)
                        {
                            return false;
                        }

                        didRead = true;
                        return true;
                    },
                    ItemGetInt32 = __ =>
                    {
                        switch (__)
                        {
                            case 0:
                                return One;
                            case 1:
                                return DummyString;
                            default:
                                return 0;
                        }
                    },
                    GetStringInt32 = __ => DummyResult
                };
            };
        }

        private void CreateSPContextShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();

            ShimSPUser.AllInstances.IDGet = _ => Id;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyResult;

            ShimSPList.AllInstances.IDGet = _ => _listId;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();

            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
        }
    }
}
