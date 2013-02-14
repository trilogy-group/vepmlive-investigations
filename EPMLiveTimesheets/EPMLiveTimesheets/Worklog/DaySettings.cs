using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public struct DaySetting
    {
        private readonly bool _allowed;
        private readonly int _max;
        private readonly int _min;
        private readonly bool _valid;

        public DaySetting(bool allowed, int min, int max)
        {
            _allowed = allowed;
            _min = min;
            _max = max;
            _valid = true;
        }

        public DaySetting(string allowed, string min, string max)
        {
            _allowed = false;
            _min = 0;
            _max = 0;
            _valid = bool.TryParse(allowed, out _allowed)
                     && int.TryParse(min, out _min)
                     && int.TryParse(max, out _max);
        }

        public bool Allowed
        {
            get { return _allowed; }
        }

        public int Min
        {
            get { return _min; }
        }

        public int Max
        {
            get { return _max; }
        }

        public bool Valid
        {
            get { return _valid; }
        }
    }

    public class DaySettings : List<DaySetting>
    {
        private bool _valid =  true;

        public DaySettings(SPWeb web)
        {
            string dayDef = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDaySettings");

            if (string.IsNullOrEmpty(dayDef))
                return;

            string[] daySettings = dayDef.Split('|');
            for (int i = 0; i < 21; i += 3)
            {
                var setting = new DaySetting(daySettings[i], daySettings[i + 1], daySettings[i + 2]);
                _valid = _valid && setting.Valid;
                Add(setting);
            }
        }

        public bool Valid
        {
            get { return _valid; }
        }

        public DaySetting GetDaySetting(DateTime date)
        {
            return this[(int) date.DayOfWeek];
        }
    }
}