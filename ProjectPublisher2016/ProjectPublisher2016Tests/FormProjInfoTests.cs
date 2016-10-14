using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectPublisher2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;

namespace ProjectPublisher2016.Tests
{
    [TestClass()]
    public class FormProjInfoTests
    {
        [TestMethod()]
        public void FormProjInfoTest()
        {
            FormProjInfo instanse = new FormProjInfo();
            var textBox = new TextBox();

            //initialize textBox here
            instanse.listView1.Controls.AddRange(new Control[] { textBox });

            //initialize instanse.listView1 here

            string shownMessage = string.Empty;
            ShimMessageBox.ShowString = (message) =>
            {
                shownMessage = message;
                return DialogResult.OK;
            };

            instanse.button1Click(null, null);

            Assert.AreEqual(shownMessage, "You must enter a value for bla bla");
        }
    }
}