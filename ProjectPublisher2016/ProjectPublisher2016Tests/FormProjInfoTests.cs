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

        [TestMethod]
        public void FormProjInfoTest_FailedTest()
        {
            var textBox = new TextBox();
            textBox.Text = "Test";
            textBox.Tag = 0;
            textBox.Visible = true;

            string shownMessage = GetMessageValue(textBox);
            Assert.AreEqual(shownMessage, "The value for 'PercentComplete' is not a valid number.");
        }

        [TestMethod]
        public void FormProjInfoTest_ComboBox_RequiredField_Failed()
        {
            var comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;            
            comboBox.Tag = 0;
            comboBox.Visible = true;

            string shownMessage = GetMessageValue(comboBox);
            Assert.AreEqual(shownMessage, "You must select a value for 'State'");
        }

        [TestMethod]
        public void FormProjInfoTest_ComboBox_RequiredField_Passed()
        {
            var comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.Add("Test");
            comboBox.SelectedIndex = 0;
            comboBox.Tag = 0;
            comboBox.Visible = true;

            string shownMessage = GetMessageValue(comboBox);
            Assert.AreEqual(shownMessage, string.Empty);
        }

        [TestMethod]
        public void FormProjInfoTest_CehckBox_RequiredField_Passed()
        {
            var lstChkBox = new CheckedListBox();
            lstChkBox.Items.Add("A");
            lstChkBox.Items.Add("B");
            lstChkBox.SetItemChecked(0, true);            
            lstChkBox.Tag = 0;
            lstChkBox.Visible = true;

            string shownMessage = GetMessageValue(lstChkBox);
            Assert.AreEqual(shownMessage, string.Empty);
        }

        [TestMethod]
        public void FormProjInfoTest_CehckBox_RequiredField_Failed()
        {
            var lstChkBox = new CheckedListBox();
            lstChkBox.Items.Add("A");
            lstChkBox.Tag = 0;
            lstChkBox.Visible = true;

            string shownMessage = GetMessageValue(lstChkBox);
            Assert.AreEqual(shownMessage, "You must select a value for 'CHK'");
        }

        private string GetMessageValue(Object obj)
        {
            FormProjInfo instanse = new FormProjInfo();
            string shownMessage = string.Empty;

            //initialize textBox here            
            ListViewItem li = new ListViewItem(new string[] { "", "" });
            if (obj.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox txt = (TextBox)obj;
                string xNode = @"<Field Version='1' RowOrdinal='0' ColName='float22' Name='PercentComplete0' StaticName='PercentComplete0' SourceID = '{dcf0b347-4565-4b4b-b1ea-7cd706399a0a}' ID = '{b37fab34-554a-4aec-a63d-f4ed5aeda371}' Decimals='0' Percentage='TRUE' Max='1.00' Min='.00' Indexed='FALSE' EnforceUniqueValues='FALSE' Required='TRUE' DisplayName='PercentComplete' Type='Number'><Default>'1.00'</Default></Field>";                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xNode);
                XmlNode xmlNode = doc.DocumentElement;
                li.Tag = xmlNode;
                instanse.listView1.Items.Add(li);

                instanse.listView1.Controls.Add(txt);

                //initialize instanse.listView1 here
                using (ShimsContext.Create())
                {
                    ShimMessageBox.ShowString = (message) =>
                    {
                        shownMessage = message;
                        return DialogResult.OK;
                    };
                    instanse.button1Click(null, null);
                }
                
            }
            if (obj.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox cbo = (ComboBox)obj;
                string xNode = @"<Field Type='Choice' DisplayName='State' Required='TRUE' EnforceUniqueValues='FALSE' Indexed='FALSE' Format='Dropdown' FillInChoice='FALSE' ID = '{9602a7d9-37b9-4c13-b279-a52cf3ce9325}' SourceID = '{9291a3b8-f72c-4800-ba7a-ae735b1d2902}' StaticName ='State' Name='State' ColName='nvarchar4' RowOrdinal='0' ShowInNewForm='TRUE' AllowDeletion='FALSE' ShowInDisplayForm='TRUE' ShowInEditForm='TRUE' Sealed='FALSE'><Default>'(2) Active'</Default><CHOICES><CHOICE>'(1) Proposed'</CHOICE><CHOICE>'(2) Active'</CHOICE><CHOICE>'(3) Closed'</CHOICE></CHOICES></Field>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xNode);
                XmlNode xmlNode = doc.DocumentElement;
                li.Tag = xmlNode;
                instanse.listView1.Items.Add(li);

                instanse.listView1.Controls.Add(cbo);

                //initialize instanse.listView1 here
                
                using (ShimsContext.Create())
                {
                    ShimMessageBox.ShowString = (message) =>
                    {
                        shownMessage = message;
                        return DialogResult.OK;
                    };
                    instanse.button1Click(null, null);
                }
                
            }
            if (obj.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
            {
                CheckedListBox lstCheckbox = (CheckedListBox)obj;
                string xNode = @"<Field Type='MultiChoice' DisplayName='CHK' Required='TRUE' EnforceUniqueValues='FALSE' Indexed='FALSE' FillInChoice='FALSE' ID='{ cb8e8087 - 1113 - 4a89 - 991f - 490b95c785df}' SourceID='{ dcf0b347 - 4565 - 4b4b - b1ea - 7cd706399a0a}' StaticName='CHK' Name='CHK' ColName='ntext6' RowOrdinal='0' Version='1' xmlns='http://schemas.microsoft.com/sharepoint/soap/'><Default>'A'</Default><CHOICES><CHOICE>'A'</CHOICE><CHOICE>'B'</CHOICE><CHOICE>'C'</CHOICE></CHOICES></Field>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xNode);
                XmlNode xmlNode = doc.DocumentElement;
                li.Tag = xmlNode;
                instanse.listView1.Items.Add(li);

                instanse.listView1.Controls.Add(lstCheckbox);

                //initialize instanse.listView1 here
                
                using (ShimsContext.Create())
                {
                    ShimMessageBox.ShowString = (message) =>
                    {
                        shownMessage = message;
                        return DialogResult.OK;
                    };
                    instanse.button1Click(null, null);
                }                
            }
            return shownMessage;
        }
        
    }
}