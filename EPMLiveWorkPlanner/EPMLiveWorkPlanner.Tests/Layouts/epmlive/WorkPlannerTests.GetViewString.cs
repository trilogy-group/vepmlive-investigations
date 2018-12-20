using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    public partial class WorkPlannerTests
    {
        private const string AgileField = "bAgile";
        private const string GetViewStringMethod = "GetViewString";

        [TestMethod]
        public void GetViewString_OnValidCall_ConfirmResult()
        {
            // Arrange
            var properties = new string[] 
            {
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString
            };
            var agileProperties = new string[] 
            {
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString
            };
            privateObject.SetField(AgileField, true);

            // Act
            var stringBuilder = (StringBuilder)privateObject.Invoke(GetViewStringMethod, properties, agileProperties);

            // Assert
            var stringBuilderContents = stringBuilder.ToString();
            this.ShouldSatisfyAllConditions(
                () => stringBuilderContents.ShouldContain($"title: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",leftCols: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",cols: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",filters: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",grouping: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",sorting: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",gantt: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",details: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",assignments: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",summary: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",allocation: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",agileleft: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",agilecols: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",agilefilters: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",agilegrouping: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",agilesorting: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",agilegantt: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",backlog: \"{DummyString}\""),
                () => stringBuilderContents.ShouldContain($",folders: \"{DummyString}\""));
        }
    }
}
