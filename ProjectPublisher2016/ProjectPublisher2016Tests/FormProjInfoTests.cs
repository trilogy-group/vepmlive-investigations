using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectPublisher2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;
using System.Xml;

namespace ProjectPublisher2016.Tests
{
    [TestClass()]
    public class FormProjInfoTests
    {
        [TestMethod()]
        public void FormProjInfoTest()
        {
            var textBox = new TextBox();
            textBox.Text = "50";
            textBox.Tag = 0;
            textBox.Visible = true;

            string shownMessage = GetMessageValue(textBox);
            Assert.AreEqual(shownMessage, string.Empty);
        }
        
        [TestMethod]
        public void FormProjInfoTest_MaxValue()
        {
            var textBox = new TextBox();
            textBox.Text = "101";
            textBox.Tag = 0;
            textBox.Visible = true;

            string shownMessage = GetMessageValue(textBox);
            Assert.AreEqual(shownMessage, "The value for 'PercentComplete' must be less than 1.00.");
        }


        [TestMethod]
        public void FormProjInfoTest_MinValue()
        {            
            var textBox = new TextBox();
            textBox.Text = "-1";
            textBox.Tag = 0;
            textBox.Visible = true;
            
            string shownMessage = GetMessageValue(textBox);
            Assert.AreEqual(shownMessage, "The value for 'PercentComplete' must be greater than .00.");
        }

        [TestMethod]
        public void FormProjInfoTest_RequiredValue()
        {            
            var textBox = new TextBox();
            textBox.Text = "";
            textBox.Tag = 0;
            textBox.Visible = true;
            
            string shownMessage = GetMessageValue(textBox);
            Assert.AreEqual(shownMessage, "You must enter a value for 'PercentComplete'");
        }

        private string GetMessageValue(TextBox textBox)
        {
            FormProjInfo instanse = new FormProjInfo();

            //initialize textBox here            
            ListViewItem li = new ListViewItem(new string[] { "", "" });
            string xNode = @"<Field Version='1' RowOrdinal='0' ColName='float22' Name='PercentComplete0' StaticName='PercentComplete0' SourceID = '{dcf0b347-4565-4b4b-b1ea-7cd706399a0a}' ID = '{b37fab34-554a-4aec-a63d-f4ed5aeda371}' Decimals='0' Percentage='TRUE' Max='1.00' Min='.00' Indexed='FALSE' EnforceUniqueValues='FALSE' Required='TRUE' DisplayName='PercentComplete' Type='Number'><Default>'1.00'</Default></Field>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xNode);
            XmlNode xmlNode = doc.DocumentElement;
            li.Tag = xmlNode;
            instanse.listView1.Items.Add(li);

            instanse.listView1.Controls.Add(textBox);

            //initialize instanse.listView1 here

            string shownMessage = string.Empty;
            using (ShimsContext.Create())
            {
                ShimMessageBox.ShowString = (message) =>
                {
                    shownMessage = message;
                    return DialogResult.OK;
                };
                instanse.button1Click(null, null);
            }

            return shownMessage;
        }
    }
}