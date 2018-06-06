DateHelper = function() {
    function isLeapYear(year) {
        return (((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0));
    };

    function getDaysInMonth(year, month) {
        return [31, (isLeapYear(year) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][month];
    };

    function getDaysInMonthForDate(date) {
        return getDaysInMonth(date.getUTCFullYear(), date.getUTCMonth());
    };

    function formatDateInternal(year, month, day, format) {
        if (format === 'short') {
            year = year.toString().substr(2);
        } else {
            if (month.toString().length < 2) month = "0" + month;
            if (day.toString().length < 2) day = "0" + day;
        }

        if (format === "utc") {
            return [year, month, day].join("-") + "T00:00:00.000Z";
        } else {
            return [month, day, year].join("/");
        }
    }

    var addMonths = function(date, value, day) {
        var result = new Date(date);
        var n = day === undefined ? result.getUTCDate() : day;
        result.setUTCDate(1);
        result.setUTCMonth(result.getUTCMonth() + value);
        result.setUTCDate(Math.min(n, getDaysInMonthForDate(result)));
        return result;
    };

    var addDays = function(date, value) {
        var result = new Date(date);
        result.setUTCDate(result.getUTCDate() + value);
        return result;
    };

    var addWeeks = function(date, value) {
        var result = new Date(date);
        result.setUTCDate(result.getUTCDate() + value * 7);
        return result;
    };

    var getNextDayOfWeek = function (date, dayOfWeek) {
        if (dayOfWeek < 0 || dayOfWeek > 6) {
            return null;
        }

        if (date.getUTCDay() === dayOfWeek) {
            return date;
        }

        var resultDate = new Date(date.getTime());
        resultDate.setUTCDate(date.getUTCDate() + (7 + dayOfWeek - date.getUTCDay()) % 7);
        return resultDate;
    }

    var formatLocalDate = function(date, format) {
        var d = new Date(date);
        var month = (d.getMonth() + 1);
        var day = d.getDate();
        var year = d.getFullYear();

        return formatDateInternal(year, month, day, format);
    }

    var formatUtcDate = function (date, format) {
        var d = new Date(date);
        var month = (d.getUTCMonth() + 1);
        var day = d.getUTCDate();
        var year = d.getUTCFullYear();

        return formatDateInternal(year, month, day, format);
    }

    var convertToUtcDate = function (value) {
        return new Date(DateHelper.formatDate(value, 'utc'));
    }

    return {
        addDays: addDays,
        addMonths: addMonths,
        addWeeks: addWeeks,
        getNextDayOfWeek: getNextDayOfWeek,
        convertToUtcDate: convertToUtcDate,
        formatUtcDate: formatUtcDate,
        formatDate: formatLocalDate
    }
}();