using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using WorkEnginePPM.Tests.Testables;

namespace WorkEnginePPM.Tests
{
    [TestClass]
    public class DataCacheBaseTest
    {
        private const string _dataItemName = "test-name";

        private DataCacheBaseTestable _testable;
        private IDictionary<int, DataItem> _codesDictionary;
        private IDictionary<int, DataItem> _resesDictionary;
        private IDictionary<int, DataItem> _stagesDictionary;

        private int _formatExtraDisplayInputInt;
        private string FormatExtraDisplayInputIntString => _formatExtraDisplayInputInt.ToString();

        private double _formatExtraDisplayInputDouble;
        private string FormatExtraDisplayInputDoubleString => _formatExtraDisplayInputDouble.ToString();

        private int _formatExtraDisplayType;

        private CustomFieldData _customFieldData;

        [TestInitialize]
        public void SetUp()
        {
            _formatExtraDisplayInputInt = 1;
            _formatExtraDisplayInputDouble = 1.1d;

            _codesDictionary = new Dictionary<int, DataItem>
            {
                { _formatExtraDisplayInputInt, new DataItem { Name = _dataItemName } }
            };
            _resesDictionary = new Dictionary<int, DataItem>()
            {
                { _formatExtraDisplayInputInt, new DataItem { Name = _dataItemName } }
            };
            _stagesDictionary = new Dictionary<int, DataItem>()
            {
                { _formatExtraDisplayInputInt, new DataItem { Name = _dataItemName } }
            };

            _customFieldData = new CustomFieldData
            {
                ListItems = new Dictionary<int, ListItemData>()
            };
            for (var i = 0; i < 5; i++)
            {
                _customFieldData.ListItems.Add(i, new ListItemData
                {
                    ID = i,
                    UID = 10 + i,
                    FullName = "test-fullname-" + i,
                    Name = "test-name-" + i,
                    InActive = true,
                    Level = 1
                });
            }

            _testable = new DataCacheBaseTestable(_codesDictionary, _resesDictionary, _stagesDictionary);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputInt_ParsesAndUsesParsed()
        {
            // Arrange
            var expectedValue = FormatExtraDisplayInputIntString;
            _formatExtraDisplayType = 2;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputIntString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputDouble_ParsesAndUsesParsed()
        {
            // Arrange
            var expectedValue = FormatExtraDisplayInputDoubleString;
            _formatExtraDisplayType = 3;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputDoubleString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputMoney_ParsesAndUsesParsed()
        {
            // Arrange
            var expectedValue = _formatExtraDisplayInputDouble.ToString("$#,##0.00");
            _formatExtraDisplayType = 8;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputDoubleString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputDateTimeFormat1_ParsesAndUsesParsed()
        {
            // Arrange
            var dateTimeValue = new DateTime(2018, 01, 01);
            var inputString = dateTimeValue.ToString("yyyyMMdd");
            var expectedValue = dateTimeValue.ToString("MM/dd/yyyy");
            _formatExtraDisplayType = 1;

            // Act
            var result = _testable.FormatExtraDisplay(inputString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputDateTimeFormat2_ParsesAndUsesParsed()
        {
            // Arrange
            var dateTimeValue = new DateTime(2018, 01, 01);
            var inputString = dateTimeValue.ToString("yyyyMMddHHmm");
            var expectedValue = dateTimeValue.ToString("MM/dd/yyyy");
            _formatExtraDisplayType = 1;

            // Act
            var result = _testable.FormatExtraDisplay(inputString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputBool1_ParsesAndUsesParsed()
        {
            // Arrange
            var inputString = "1";
            var expectedValue = "Yes";
            _formatExtraDisplayType = 13;

            // Act
            var result = _testable.FormatExtraDisplay(inputString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputBool0_ParsesAndUsesParsed()
        {
            // Arrange
            var inputString = "0";
            var expectedValue = "No";
            _formatExtraDisplayType = 13;

            // Act
            var result = _testable.FormatExtraDisplay(inputString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputCodesKeyExists_UsesDataItemName()
        {
            // Arrange
            _formatExtraDisplayType = 4;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputIntString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(_dataItemName, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputResesKeyExists_UsesDataItemName()
        {
            // Arrange
            _formatExtraDisplayType = 7;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputIntString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(_dataItemName, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputStagesKeyExists_UsesDataItemName()
        {
            // Arrange
            _formatExtraDisplayType = 9911;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputIntString, _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(_dataItemName, result);
        }

        [TestMethod]
        public void FormatExtraDisplay_InputStagesKeyNotFound_ReturnsEmptyString()
        {
            // Arrange
            _formatExtraDisplayType = 9911;

            // Act
            var result = _testable.FormatExtraDisplay(FormatExtraDisplayInputIntString + "test", _formatExtraDisplayType);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildCustFieldJSon_NullCustomFieldData_Throws()
        {
            // Arrange
            _customFieldData = null;

            // Act
            _testable.BuildCustFieldJSon(_customFieldData, 0, 0);

            // Assert
            // ExpectedException - ArgumentNullException
        }

        [TestMethod]
        public void BuildCustFieldJSon_MaxIndexLessThan0_ReturnsEmptyString()
        {
            // Arrange
            const int index = 0;
            const int maxIndex = -1;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void BuildCustFieldJSon_IndexGreaterThanMaxIndex_ReturnsEmptyString()
        {
            // Arrange
            const int index = 2;
            const int maxIndex = 1;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void BuildCustFieldJSon_MultipleRecordsAffected_SeparatedByComma()
        {
            // Arrange
            const int index = 1;
            const int maxIndex = 2;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.IsTrue(result.Contains("},{"));
        }

        [TestMethod]
        public void BuildCustFieldJSon_SingleRecordAffected_NoSeparationByComma()
        {
            // Arrange
            const int index = 1;
            const int maxIndex = 1;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.IsFalse(result.Contains("},{"));
        }

        [TestMethod]
        public void BuildCustFieldJSon_SingleRecordAffectedUseFullName_GeneratesJSONBasedOnRightData()
        {
            // Arrange
            const int index = 1;
            const int maxIndex = 1;
            _customFieldData.UseFullName = 1;
            var listItemData = _customFieldData.ListItems.ElementAt(index).Value;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.AreEqual(string.Format("{{Name:'{0}',Text:'{1}',Value:'{2}'}}",
                listItemData.ID,
                listItemData.FullName,
                listItemData.UID), result);
        }

        [TestMethod]
        public void BuildCustFieldJSon_SingleRecordAffectedNotUseFullName_GeneratesJSONBasedOnRightData()
        {
            // Arrange
            const int index = 1;
            const int maxIndex = 1;
            _customFieldData.UseFullName = 0;
            var listItemData = _customFieldData.ListItems.ElementAt(index).Value;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.AreEqual(string.Format("{{Name:'{0}',Text:'{1}',Value:'{2}'}}",
                listItemData.ID,
                listItemData.Name,
                listItemData.UID), result);
        }

        [TestMethod]
        public void BuildCustFieldJSon_NextItemLevelGreaterThenPrev_AppendsBranchRecord()
        {
            // Arrange
            const int index = 1;
            const int maxIndex = 2;
            _customFieldData.ListItems[1].Level = 1;
            _customFieldData.ListItems[2].Level = 2;

            // Act
            var result = _testable.BuildCustFieldJSon(_customFieldData, index, maxIndex);

            // Assert
            Assert.IsTrue(result.Contains("Expanded:-1,"));
        }
    }
}
