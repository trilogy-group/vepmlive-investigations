using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptmizerDataCache;
using PortfolioEngineCore;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OptGridsTests
    {
        private OptTopGrid _testEntity;
        private PrivateObject _privateObject;

        private const string DummyString = "DummyString";
        private const string DummyName = "DummyName";
        private static readonly DateTime DummyDateTime = new DateTime(2018, 1, 1, 0, 0, 0);
        private const int DummyInt = 1;
        private const int DummyId = 10;

        [TestInitialize]
        public void TestInitialize()
        {
            _testEntity = new OptTopGrid();

            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void InitializeGridLayout_PosDigitsZero_FillProperties()
        {
            // Arrange
            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = "Name",
                    ftype = 2
                },
                new clsOptFieldDelf()
                {
                    fname = "Budget",
                    ftype = 3
                },
                new clsOptFieldDelf()
                {
                    fname = "Price",
                    ftype = 8
                },
                new clsOptFieldDelf()
                {
                    fname = "Summary",
                    ftype = 4
                }
            };

            var currentPos = 0;
            var currentDigits = 0;
            var currentSym = string.Empty;

            var expectedCustomHeader = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXName", "Name"),
                new Tuple<string, string>("zXBudget", "Budget"),
                new Tuple<string, string>("zXSummary", "Summary")
            };

            var expectedCustomDefTree = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXNameCanDrag", "0"),
                new Tuple<string, string>("zXNameHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXNameHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXBudgetCanDrag", "0"),
                new Tuple<string, string>("zXBudgetHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXBudgetHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXBudgetFormula", "(Row.id == 'Filter' ? '' : sum())"),
                new Tuple<string, string>("zXBudgetFormat", ",0.##"),
                new Tuple<string, string>("zXPriceFormat", ",0"),
                new Tuple<string, string>("zXSummaryCanDrag", "0"),
                new Tuple<string, string>("zXSummaryHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXSummaryHtmlPostfix", "</B>")
            };

            var expectedCustomDefNode = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXNameCanDrag", "0"),
                new Tuple<string, string>("zXNameHtmlPrefix", string.Empty),
                new Tuple<string, string>("zXNameHtmlPostfix", string.Empty),
                new Tuple<string, string>("zXBudgetCanDrag", "0"),
                new Tuple<string, string>("zXBudgetHtmlPrefix", string.Empty),
                new Tuple<string, string>("zXBudgetHtmlPostfix", string.Empty),
                new Tuple<string, string>("zXBudgetFormula", string.Empty),
                new Tuple<string, string>("zXSummaryCanDrag", "0"),
                new Tuple<string, string>("zXSummaryHtmlPrefix", string.Empty),
                new Tuple<string, string>("zXSummaryHtmlPostfix", string.Empty)
            };

            var expectedCustomDef = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXNameCanDrag", "0"),
                new Tuple<string, string>("zXNameHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXNameHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXBudgetCanDrag", "0"),
                new Tuple<string, string>("zXBudgetHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXBudgetHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXBudgetFormula", "(Row.id == 'Filter' ? '' : sum())"),
                new Tuple<string, string>("zXBudgetFormat", ",0.##"),
                new Tuple<string, string>("zXPriceFormat", ",0"),
                new Tuple<string, string>("zXSummaryCanDrag", "0"),
                new Tuple<string, string>("zXSummaryHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXSummaryHtmlPostfix", "</B>")
            };

            // Act
            _testEntity.InitializeGridLayout(fieldDef, currentPos, currentDigits, currentSym);

            // Assert
            var nodeHeader1 = ((CStruct)_privateObject.GetField("m_xHeader1")).GetXMLNode();
            var nodeDefTree = ((CStruct)_privateObject.GetField("m_xDefTree")).GetXMLNode();
            var nodeDefNode = ((CStruct)_privateObject.GetField("m_xDefNode")).GetXMLNode();
            var nodeDef = ((CStruct)_privateObject.GetField("m_xDef")).GetXMLNode();
            var nodeMiddleCols = ((CStruct)_privateObject.GetField("m_xMiddleCols")).GetXMLNode();

            this.ShouldSatisfyAllConditions(
                () => ExpectedDefaultHeader().ForEach(content => nodeHeader1.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomHeader.ForEach(content => nodeHeader1.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefTree().ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDefTree.ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefNode().ForEach(content => nodeDefNode.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDefNode.ForEach(content => nodeDefNode.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDef().ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDef.ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultMiddleCols().ForEach(content => nodeMiddleCols.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)));
        }

        [TestMethod]
        public void InitializeGridLayout_PosDigitsOne_FillProperties()
        {
            // Arrange
            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = "Price",
                    ftype = 8
                }
            };

            var currentPos = 1;
            var currentDigits = 1;
            var currentSym = string.Empty;

            var expectedCustomDefTree = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXPriceFormat", ",0.0")
            };

            var expectedCustomDef = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXPriceFormat", ",0.0")
            };

            // Act
            _testEntity.InitializeGridLayout(fieldDef, currentPos, currentDigits, currentSym);

            // Assert
            var nodeHeader1 = ((CStruct)_privateObject.GetField("m_xHeader1")).GetXMLNode();
            var nodeDefTree = ((CStruct)_privateObject.GetField("m_xDefTree")).GetXMLNode();
            var nodeDefNode = ((CStruct)_privateObject.GetField("m_xDefNode")).GetXMLNode();
            var nodeDef = ((CStruct)_privateObject.GetField("m_xDef")).GetXMLNode();
            var nodeMiddleCols = ((CStruct)_privateObject.GetField("m_xMiddleCols")).GetXMLNode();

            this.ShouldSatisfyAllConditions(
                () => ExpectedDefaultHeader().ForEach(content => nodeHeader1.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefTree().ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDefTree.ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefNode().ForEach(content => nodeDefNode.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDef().ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDef.ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultMiddleCols().ForEach(content => nodeMiddleCols.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)));
        }

        [TestMethod]
        public void InitializeGridLayout_PosDigitsTwoSymFilled_FillProperties()
        {
            // Arrange
            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = "Price",
                    ftype = 8
                }
            };

            var currentPos = 2;
            var currentDigits = 2;
            var currentSym = "DummyString";

            var expectedCustomDefTree = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXPriceFormat", $"{DummyString} ,0.00")
            };

            var expectedCustomDef = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXPriceFormat", $"{DummyString} ,0.00")
            };

            // Act
            _testEntity.InitializeGridLayout(fieldDef, currentPos, currentDigits, currentSym);

            // Assert
            var nodeHeader1 = ((CStruct)_privateObject.GetField("m_xHeader1")).GetXMLNode();
            var nodeDefTree = ((CStruct)_privateObject.GetField("m_xDefTree")).GetXMLNode();
            var nodeDefNode = ((CStruct)_privateObject.GetField("m_xDefNode")).GetXMLNode();
            var nodeDef = ((CStruct)_privateObject.GetField("m_xDef")).GetXMLNode();
            var nodeMiddleCols = ((CStruct)_privateObject.GetField("m_xMiddleCols")).GetXMLNode();

            this.ShouldSatisfyAllConditions(
                () => ExpectedDefaultHeader().ForEach(content => nodeHeader1.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefTree().ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDefTree.ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefNode().ForEach(content => nodeDefNode.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDef().ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDef.ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultMiddleCols().ForEach(content => nodeMiddleCols.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)));
        }

        [TestMethod]
        public void InitializeGridLayout_PosDigitsThree_FillProperties()
        {
            // Arrange
            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = "Price",
                    ftype = 8
                }
            };

            var currentPos = 3;
            var currentDigits = 3;
            var currentSym = string.Empty;

            var expectedCustomDefTree = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXPriceFormat", ",0.000 ")
            };

            var expectedCustomDef = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("zXPriceFormat", ",0.000 ")
            };

            // Act
            _testEntity.InitializeGridLayout(fieldDef, currentPos, currentDigits, currentSym);

            // Assert
            var nodeHeader1 = ((CStruct)_privateObject.GetField("m_xHeader1")).GetXMLNode();
            var nodeDefTree = ((CStruct)_privateObject.GetField("m_xDefTree")).GetXMLNode();
            var nodeDefNode = ((CStruct)_privateObject.GetField("m_xDefNode")).GetXMLNode();
            var nodeDef = ((CStruct)_privateObject.GetField("m_xDef")).GetXMLNode();
            var nodeMiddleCols = ((CStruct)_privateObject.GetField("m_xMiddleCols")).GetXMLNode();

            this.ShouldSatisfyAllConditions(
                () => ExpectedDefaultHeader().ForEach(content => nodeHeader1.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefTree().ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDefTree.ForEach(content => nodeDefTree.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDefNode().ForEach(content => nodeDefNode.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultDef().ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => expectedCustomDef.ForEach(content => nodeDef.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)),
                () => ExpectedDefaultMiddleCols().ForEach(content => nodeMiddleCols.FirstChild.Attributes[content.Item1].Value.ShouldBe(content.Item2)));
        }

        [TestMethod]
        public void InitializeGridData_Should_FillXLevels()
        {
            // Arrange
            _testEntity.InitializeGridLayout(new List<clsOptFieldDelf>(), 0, 0, string.Empty);

            // Act
            var actualResult = _testEntity.InitializeGridData();

            // Assert
            var structLevel0 = ((CStruct[])_privateObject.GetField("m_xLevels"))[0];
            var structLevel1 = ((CStruct[])_privateObject.GetField("m_xLevels"))[1];
            var structLevel2 = ((CStruct[])_privateObject.GetField("m_xLevels"))[2];

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => structLevel0.XML().ShouldBe("<I CanEdit=\"0\"><I PISelected=\"Selected\" rowid=\"rselected\" pid=\"-1\" /><I PISelected=\"Unselected\" rowid=\"runselected\" pid=\"-2\" /></I>"),
                () => structLevel1.XML().ShouldBe("<I PISelected=\"Selected\" rowid=\"rselected\" pid=\"-1\" />"),
                () => structLevel2.XML().ShouldBe("<I PISelected=\"Unselected\" rowid=\"runselected\" pid=\"-2\" />"));
        }

        [TestMethod]
        public void AddDetailRow_PiModeOneSelectZero_FillProperties()
        {
            // Arrange
            _testEntity.InitializeGridLayout(new List<clsOptFieldDelf>(), 0, 0, string.Empty);
            _testEntity.InitializeGridData();

            var optimizeData = new clsOptPIData()
            {
                PI_Selected = 0,
                PI_ID = DummyId,
                PI_Name = DummyName,
                PI_Mode = 1,
                StartDate = DateTime.MinValue,
                FinishDate = DateTime.MinValue,
                m_PI_Extra_data = new List<string>() { DummyString }
            };
            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = DummyName
                }
            };

            // Act
            _testEntity.AddDetailRow(optimizeData, DummyId, fieldDef);

            // Assert
            var structLevel2 = ((CStruct[])_privateObject.GetField("m_xLevels"))[2];

            structLevel2.GetXMLNode().InnerXml.ShouldBe($"<I id=\"{DummyId}\" rowid=\"r{DummyId}\" pid=\"{DummyId}\" Color=\"white\" Def=\"Leaf\" NoColorState=\"1\" CanEdit=\"0\" PIName=\"{DummyName}\" PIStatus=\"In\" PISelected=\" \" PIStatusButton=\"Defaults\" PIStart=\"\" PIFinish=\"\" zXDummyName=\"{DummyString}\" />");
        }

        [TestMethod]
        public void AddDetailRow_PiModeTwoSelectOne_FillProperties()
        {
            // Arrange
            _testEntity.InitializeGridLayout(new List<clsOptFieldDelf>(), 0, 0, string.Empty);
            _testEntity.InitializeGridData();

            var optimizeData = new clsOptPIData()
            {
                PI_Selected = 1,
                PI_ID = DummyId,
                PI_Name = DummyName,
                PI_Mode = 2,
                StartDate = DummyDateTime,
                FinishDate = DummyDateTime,
                m_PI_Extra_data = new List<string>() { DummyString }
            };
            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = DummyName
                }
            };

            // Act
            _testEntity.AddDetailRow(optimizeData, DummyId, fieldDef);

            // Assert
            var structLevel1 = ((CStruct[])_privateObject.GetField("m_xLevels"))[1];

            structLevel1.GetXMLNode().InnerXml.ShouldBe($"<I id=\"{DummyId}\" rowid=\"r{DummyId}\" pid=\"{DummyId}\" Color=\"white\" Def=\"Leaf\" NoColorState=\"1\" CanEdit=\"0\" PIName=\"{DummyName}\" PIStatus=\"Out\" PISelected=\" \" PIStatusButton=\"Defaults\" PIStart=\"{DummyDateTime.ToString("MM/dd/yyyy")}\" PIFinish=\"{DummyDateTime.ToString("MM/dd/yyyy")}\" zXDummyName=\"{DummyString}\" />");
        }

        [TestMethod]
        public void AddDetailRow_PiModeThreeSelectOne_FillProperties()
        {
            // Arrange
            _testEntity.InitializeGridLayout(new List<clsOptFieldDelf>(), 0, 0, string.Empty);
            _testEntity.InitializeGridData();

            var optimizeData = new clsOptPIData()
            {
                PI_Selected = 1,
                PI_ID = DummyId,
                PI_Name = DummyName,
                PI_Mode = 3,
                StartDate = DummyDateTime,
                FinishDate = DummyDateTime
            };

            var fieldDef = new List<clsOptFieldDelf>()
            {
                new clsOptFieldDelf()
                {
                    fname = DummyName
                }
            };

            // Act
            _testEntity.AddDetailRow(optimizeData, DummyId, fieldDef);

            // Assert
            var structLevel1 = ((CStruct[])_privateObject.GetField("m_xLevels"))[1];

            structLevel1.GetXMLNode().InnerXml.ShouldBe($"<I id=\"{DummyId}\" rowid=\"r{DummyId}\" pid=\"{DummyId}\" Color=\"white\" Def=\"Leaf\" NoColorState=\"1\" CanEdit=\"0\" PIName=\"{DummyName}\" PIStatus=\"Auto\" PISelected=\" \" PIStatusButton=\"Defaults\" PIStart=\"{DummyDateTime.ToString("MM/dd/yyyy")}\" PIFinish=\"{DummyDateTime.ToString("MM/dd/yyyy")}\" />");
        }

        private static List<Tuple<string, string>> ExpectedDefaultHeader()
        {
            return new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Spanned", "1"),
                new Tuple<string, string>("SortIcons", "2"),
                new Tuple<string, string>("HoverCell", "Color"),
                new Tuple<string, string>("HoverRow", string.Empty),
                new Tuple<string, string>("PISelected", "Selected"),
                new Tuple<string, string>("PIName", "Item Name"),
                new Tuple<string, string>("PIStatus", "Selection"),
                new Tuple<string, string>("PIStart", "Start"),
                new Tuple<string, string>("PIFinish", "Finish"),
                new Tuple<string, string>("zXPrice", "Price")
            };
        }

        private static List<Tuple<string, string>> ExpectedDefaultDefTree()
        {
            return new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Name", "R"),
                new Tuple<string, string>("Calculated", "1"),
                new Tuple<string, string>("HoverCell", "Color"),
                new Tuple<string, string>("HoverRow", "Color"),
                new Tuple<string, string>("FocusCell", string.Empty),
                new Tuple<string, string>("NoColorState", "1"),
                new Tuple<string, string>("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)"),
                new Tuple<string, string>("ReCalc", "256"),
                new Tuple<string, string>("rowid", string.Empty),
                new Tuple<string, string>("pid", string.Empty),
                new Tuple<string, string>("PISelectedHtmlPrefix", "<B>"),
                new Tuple<string, string>("PISelectedHtmlPostfix", "</B>"),
                new Tuple<string, string>("PINameHtmlPrefix", "<B>"),
                new Tuple<string, string>("PINameHtmlPostfix", "</B>"),
                new Tuple<string, string>("PIStatusHtmlPrefix", "<B>"),
                new Tuple<string, string>("PIStatusHtmlPostfix", "</B>"),
                new Tuple<string, string>("PIStartHtmlPrefix", "<B>"),
                new Tuple<string, string>("PIStartHtmlPostfix", "</B>"),
                new Tuple<string, string>("PIFinishHtmlPrefix", "<B>"),
                new Tuple<string, string>("PIFinishHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXPriceCanDrag", "0"),
                new Tuple<string, string>("zXPriceHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXPriceHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXPriceFormula", "(Row.id == 'Filter' ? '' : sum())"),
            };
        }

        private static List<Tuple<string, string>> ExpectedDefaultDefNode()
        {
            return new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Name", "Leaf"),
                new Tuple<string, string>("Calculated", "0"),
                new Tuple<string, string>("HoverCell", "Color"),
                new Tuple<string, string>("HoverRow", "Color"),
                new Tuple<string, string>("FocusCell", string.Empty),
                new Tuple<string, string>("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)"),
                new Tuple<string, string>("NoColorState", "1"),
                new Tuple<string, string>("ReCalc", "256"),
                new Tuple<string, string>("PISelectedHtmlPrefix", string.Empty),
                new Tuple<string, string>("PISelectedHtmlPostfix", string.Empty),
                new Tuple<string, string>("PINameHtmlPrefix", string.Empty),
                new Tuple<string, string>("PINameHtmlPostfix", string.Empty),
                new Tuple<string, string>("PIStatusHtmlPrefix", string.Empty),
                new Tuple<string, string>("PIStatusHtmlPostfix", string.Empty),
                new Tuple<string, string>("PIStartHtmlPrefix", string.Empty),
                new Tuple<string, string>("PIStartHtmlPostfix", string.Empty),
                new Tuple<string, string>("PIFinishHtmlPrefix", string.Empty),
                new Tuple<string, string>("PIFinishHtmlPostfix", string.Empty),
                new Tuple<string, string>("zXPriceCanDrag", "0"),
                new Tuple<string, string>("zXPriceHtmlPrefix", string.Empty),
                new Tuple<string, string>("zXPriceHtmlPostfix", string.Empty),
                new Tuple<string, string>("zXPriceFormula", string.Empty)
            };
        }

        private static List<Tuple<string, string>> ExpectedDefaultDef()
        {
            return new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Name", "R"),
                new Tuple<string, string>("Calculated", "1"),
                new Tuple<string, string>("HoverCell", "Color"),
                new Tuple<string, string>("HoverRow", "Color"),
                new Tuple<string, string>("FocusCell", string.Empty),
                new Tuple<string, string>("NoColorState", "1"),
                new Tuple<string, string>("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)"),
                new Tuple<string, string>("ReCalc", "256"),
                new Tuple<string, string>("rowid", string.Empty),
                new Tuple<string, string>("pid", string.Empty),
                new Tuple<string, string>("PISelectedHtmlPrefix", "<B>"),
                new Tuple<string, string>("PISelectedHtmlPostfix", "</B>"),
                new Tuple<string, string>("PINameHtmlPrefix", "<B>"),
                new Tuple<string, string>("PINameHtmlPostfix", "</B>"),
                new Tuple<string, string>("PIStatusHtmlPrefix", "<B>"),
                new Tuple<string, string>("PIStatusHtmlPostfix", "</B>"),
                new Tuple<string, string>("PIStartHtmlPrefix", "<B>"),
                new Tuple<string, string>("PIStartHtmlPostfix", "</B>"),
                new Tuple<string, string>("PIFinishHtmlPrefix", "<B>"),
                new Tuple<string, string>("PIFinishHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXPriceCanDrag", "0"),
                new Tuple<string, string>("zXPriceHtmlPrefix", "<B>"),
                new Tuple<string, string>("zXPriceHtmlPostfix", "</B>"),
                new Tuple<string, string>("zXPriceFormula", "(Row.id == 'Filter' ? '' : sum())")
            };
        }

        private static List<Tuple<string, string>> ExpectedDefaultMiddleCols()
        {
            return new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Name", "PISelected"),
                new Tuple<string, string>("Class", "GMCellMain"),
                new Tuple<string, string>("ShowHint", "0"),
                new Tuple<string, string>("Width", "120"),
                new Tuple<string, string>("CaseSensitive", "0"),
                new Tuple<string, string>("OnDragCell", "Focus,DragCell"),
                new Tuple<string, string>("Type", "Text"),
                new Tuple<string, string>("CanHide", "0")
            };
        }
    }
}
