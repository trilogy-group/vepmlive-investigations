using System;
using System.Collections.Generic;
using PortfolioEngineCore.Analyzers;

namespace ModelDataCache
{
    // (CC-76813, 2018-07-11) Had to make the class public in order to be able to test dependent methods. Test assembly is not strongly signed, therefore can not be used with InternalsVisibleTo attribute
    [Serializable()]
    public class DetailRowData : BaseDetailRowData
    {
        public int g1, g2, g3;
        public string sKey;

        public DetailRowData(int arraysize) : base(arraysize)
        {
            sKey = string.Empty;
        }

        public void CopyData(DetailRowData src)
        {
            base.CopyData(src);
            sKey = src.sKey;
        }

        public void CopyToTargetData(ref TargetRowData dest)
        {
            dest.CT_ID = CT_ID;

            dest.BC_UID = BC_UID;
            dest.BC_ROLE_UID = BC_ROLE_UID;
            dest.BC_SEQ = BC_SEQ;
            dest.MC_Val = MC_Val;
            dest.CAT_UID = CAT_UID;
            dest.CT_Name = CT_Name;
            dest.Cat_Name = Cat_Name;
            dest.Role_Name = Role_Name;
            dest.MC_Name = MC_Name;
            dest.FullCatName = FullCatName;
            dest.CC_Name = CC_Name;
            dest.FullCCName = FullCCName;

            dest.bGroupRow = false;
            dest.Grouping = string.Empty;

            dest.OCVal = OCVal;
            dest.Text_OCVal = Text_OCVal;
            dest.TXVal = TXVal;

            dest.zCost = new double[mxdim + 1];
            dest.zValue = new double[mxdim + 1];
            dest.zFTE = new double[mxdim + 1];

            for (var i = 1; i <= mxdim; i++)
            {
                dest.zCost[i] = zCost[i];
                dest.zValue[i] = zValue[i];
                dest.zFTE[i] = zFTE[i];
            }
        }

        public void AddToTargetData(ref TargetRowData dest)
        {
            for (int i = 1; i <= mxdim; i++)
            {

                dest.zCost[i] += zCost[i];
                dest.zValue[i] += zValue[i];
                dest.zFTE[i] += zFTE[i];
            }
        }

        public void SetSnGInd(int i, int lv)
        {
            switch (i)
            {
                case 0:
                    g1 = lv;
                    break;
                case 1:
                    g2 = lv;
                    break;
                case 2:
                    g3 = lv;
                    break;
            }
        }
        public void CaputureInitialData(IDictionary<int, PeriodData> clnPer)
        {
            bCapture = true;
            oDet_Start = Det_Start;
            oDet_Finish = Det_Finish;


            for (int i = 1; i <= mxdim; i++)
            {
                oCosts[i] = zCost[i];
                oUnits[i] = zValue[i];
                oFTE[i] = zFTE[i];
            }

            bUseCosts = (sUoM == string.Empty);


            CaptureBurnRates(clnPer);
        }

        public void RestoreInitialData(Dictionary<int, PeriodData> clnPer)
        {
            Det_Start = oDet_Start;
            Det_Finish = oDet_Finish;


            for (int i = 1; i <= mxdim; i++)
            {
                zCost[i] = oCosts[i];
                zValue[i] = oUnits[i];
                zFTE[i] = oFTE[i];
            }

            CaptureBurnRates(clnPer);
        }

        private void CaptureBurnRates(IDictionary<int, PeriodData> clnPer)
        {
            int i = 0;
            int lPerSpan = 0;

            foreach (PeriodData oPer in clnPer.Values)
            {
                ++i;
                lPerSpan = CalculateOverlapLocal(Det_Start, Det_Finish, oPer.StartDate, oPer.FinishDate);
                BurnDuration[i] = lPerSpan;

                if (bUseCosts)
                    Burnrate[i] = zCost[i];
                else
                    Burnrate[i] = zValue[i];

                if (Burnrate[i] != 0)
                {
                    if (lPerSpan == 0)
                        Burnrate[i] = 0;
                    else
                        Burnrate[i] = Burnrate[i] / (double)lPerSpan;
                }
            }

        }
    }
}
