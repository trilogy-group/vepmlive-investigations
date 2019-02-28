function AnalyzerHelper() {
    AnalyzerHelper.prototype.ApplyRowFilters = function(grid, hideRowsWithAllZeros) {
        var dataColumns = new Array();
        if (hideRowsWithAllZeros) {
            var allColumns = grid.GetCols();
            var visibleColumns = {};
            var tmpArray = grid.GetCols('Visible');
            var hadFirstPeriod = false;

            // build visible columns array
            for (var j = 0; j <= tmpArray.length; j++) {
                visibleColumns[tmpArray[j]] = true;
            }

            // get visible data columns
            for (var i = 0; i < allColumns.length; i++) {
                var columnName = allColumns[i];
                if (columnName === "P1C1")
                    hadFirstPeriod = true;

                if (hadFirstPeriod && visibleColumns[columnName]) {
                    var columnNameSubstring = columnName.substr(1, columnName.length - 2);

                    if (columnName.charAt(0) === "P" && columnNameSubstring.indexOf("C") !== -1) {
                        dataColumns.push(columnName);
                    }
                }
            }
        }

        // update row visibility (client side part)
        for (var rowId in grid.Rows) {
            if (grid.Rows.hasOwnProperty(rowId)) {
                var row = grid.Rows[rowId];
                if (row.Kind === "Data") {
                    var hideRow = hideRowsWithAllZeros;
                    if (hideRow) {
                        for (var index = 0; index < dataColumns.length; index++) {
                            if (row[dataColumns[index]]) {
                                hideRow = false;
                                break;
                            }
                        }
                    }

                    if (hideRow) {
                        grid.HideRow(row);
                        row.hiddenByZeroValueRowsFilter = true;
                    } else if (row.hiddenByZeroValueRowsFilter) {
                        grid.ShowRow(row);
                        row.hiddenByZeroValueRowsFilter = false;
                    }
                }
            }
        }
    }
}