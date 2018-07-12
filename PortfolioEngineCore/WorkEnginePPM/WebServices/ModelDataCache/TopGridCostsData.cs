﻿using System;
using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TopGridCostsData : TopGridBase
    {
        public TopGridCostsData(bool useGrouping, bool showFTEs, bool showGantt, DateTime dateStart, DateTime dateEnd, IList<SortFieldDefn> sortFields, int detFreeze, bool useQuantity, bool useCost, bool roundCost, int fromPeriodIndex, int toPeriodIndex) 
            : base(useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, roundCost, fromPeriodIndex, toPeriodIndex)
        {
        }

        public override bool InitializeGridData()
        {
            var xCfg = Constructor.CreateSubStruct("Cfg");
            xCfg.CreateIntAttr("FilterEmpty", 1);

            var body = Constructor.CreateSubStruct("Body");
            var b = body.CreateSubStruct("B");
            var i = body.CreateSubStruct("I");

            i.CreateBooleanAttr("CanEdit", false);

            Level = 0;
            Levels[Level] = i;
            return true;
        }
    }
}
