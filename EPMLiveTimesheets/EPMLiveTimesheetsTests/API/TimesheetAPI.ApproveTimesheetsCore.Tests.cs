using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIApproveTimesheetsCoreTests : SheetTestBase
    {
        private const string XmlSample = "<root ApproveStatus=\"2\"><TS id=\"253\">TS Text</TS></root>";
        private const int UserId = 23;
        private const int StatusId = 3;
        private const int PictureId = 7;
        private const int ApprovalStatusId = 9;
        private static readonly Guid Guid1 = new Guid("BA04FE65-C83E-41D8-B81B-2172E35F585B");

        [TestMethod]
        public void ApproveTimesheetsCore_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.ApproveTimesheetsCore(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                "<Result Status=\"0\"><Approve><TS id='253' Status=\"0\"/></Approve></Result>",
                message);
            Assert.AreEqual(3, _adoShims.ConnectionsDisposed.Count());
            Assert.AreEqual(8, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(5, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            var readNum = -1;
            ShimSqlDataReader.AllInstances.Read = instance =>
            {
                readNum++;
                return readNum < 5;
            };

            ShimSqlDataReader.AllInstances.GetInt32Int32 = (instance, num) =>
            {
                if (readNum == 0)
                {
                    if (num == 0)
                    {
                        return StatusId;
                    }
                    else if (num == 1)
                    {
                        return PictureId;
                    }
                }
                else if (readNum == 1)
                {
                    if (num == 0)
                    {
                        return ApprovalStatusId;
                    }
                }
                throw new Exception("Unexpected call to GetInt32.");
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (instance, column) => 
            {
                if (column == "RESOURCENAME")
                {
                    return "ResourceSample";
                }
                else if (column == "TSUSER_UID")
                {
                    return Guid1;
                }
                else if (column == "USER_ID")
                {
                    return UserId;
                }
                else if (column == "Email")
                {
                    return "fake@fake.com";
                }
                else if (column == "Title")
                {
                    return "Title sample";
                }

                throw new ArgumentOutOfRangeException(string.Format("Unexpected column name '{0}'.", column));
            };

            ShimAPIEmail.sendEmailInt32HashtableListOfStringStringSPWebBoolean =
                (int templateID,
                Hashtable additionalParams,
                List<string> emailTo,
                string emailFrom,
                SPWeb oWeb,
                bool hideFrom) => { };

            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => false.ToString();
        }
    }
}