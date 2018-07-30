using System;
using System.Collections.Generic;
using PortfolioEngineCore.Analyzers;

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


        CaptureBurnRates(clnPer.Values);
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

        CaptureBurnRates(clnPer.Values);
    }
    
    private double AFiddler(double f)
    {
        return double.Parse(f.ToString("0.00"));
    }
        
    public void DragBar(DateTime[] dtPeriodStart, DateTime[] dtPeriodFinish, int[] PeriodMode, int minp, int maxp)
    {
        //  Input data
        // dtPeriodStart(num_periods)  - start date of each period
        // dtPeriodFinish(num_periods)  - finish date of each period
        // PeriodMode(num_periods)  - true if this period should be included in the calc.

        double per_span;
        double per_offset;
        int xtraburn;
        int amt;
        double useamt;

        double useadj;
        double mvtotal;

        double span1, span2;

        // useadj is used to apportion the burn rate - handling the expand and compress affect

        span1 = oDet_Finish.Subtract(oDet_Start).Days;
        span2 = Det_Finish.Subtract(Det_Start).Days;

        if (span1 <= 0)
            useadj = 1;
        else
            useadj = span2 / span1;


        if (useadj == 0)
            useadj = 0.00001;

        mvtotal = 0;

        for (int per = 1; per <= mxdim; per++)
        {
            // only perform these calculations if this period "visible" in the Analyzer view.

            if (PeriodMode[per] != 0)
            {
                mvtotal = mvtotal + (bUseCosts ? zCost[per] : zValue[per]);
                Budget[per] = 0;
                OutsideAdj[per] = 0;
                UseBurnrate[per] = Burnrate[per];

            }
            else
            {
                OutsideAdj[per] = (bUseCosts ? zCost[per] : zValue[per]);
                Budget[per] = 0;
                UseBurnrate[per] = 0;
            }
        }
            
        for (int per = 1; per <= mxdim; per++)
        {
            // only perform these calculations if this period "visible" in the Analyzer view.

            if (PeriodMode[per] != 0)
            {
                // For each period - calculate the overlap (in days) between the period and the new start and finish dates
                if (per == 6)
                {
                    per_span = 1;
                }

                per_span = CalculateOverlapLocal(Det_Start, Det_Finish, dtPeriodStart[per], dtPeriodFinish[per]);

                // we should never get a -ve value but its always worth checking.....
                if (per_span < 0)
                {
                    per_span = 0;
                }

                // map this span into expanded or compressed amount
                per_span = per_span / useadj;

                if (per_span != 0)
                {
                    // OK there is some overlap - so now calculate where this overlap starts wrt the new startdate
                    per_offset = dtPeriodStart[per].Subtract(Det_Start).Days;

                    if (per_offset < 0)
                    {
                        // well the new start is after the period start - so the offest must be 0
                        per_offset = 0;
                    }

                    // so now find where this offset starts in the burn duration list....
                    // and map the period offest into expanded/compressed offsets as well

                    per_offset = per_offset / useadj;

                    for (int burn = 1; burn <= mxdim; burn++)
                    {
                        if (per_offset - BurnDuration[burn] < 0)
                        {
                            // OK this offset starts in this burn period - so calc how many days left in this burn
                            amt = BurnDuration[burn] - (int)(per_offset + 0.5);
                            xtraburn = 0;

                            while (per_span > 0)
                            {
                                if (amt > per_span)
                                    useamt = per_span;
                                else
                                    useamt = amt;

                                // apply this amts burn to this period

                                Budget[per] = Budget[per] + AFiddler(useamt * UseBurnrate[burn + xtraburn]);

                                per_span = per_span - useamt;
                                if (per_span > 0)
                                {
                                    // step onto the next burn .... if not off the end - other wise use the last periods burn...
                                    if (burn + xtraburn < mxdim)
                                        xtraburn = xtraburn + 1;
                                    else
                                        break;
                                        
                                    amt = BurnDuration[burn + xtraburn];
                                }
                            }
                        }

                        else
                            per_offset = per_offset - BurnDuration[burn];
                    }
                }
            }
        }

        // dump overflow into start or end buckets

        for (int per = 1; per < minp; per++)
        {
            Budget[minp] = Budget[minp] + Budget[per];
            Budget[per] = 0;
        }

        for (int per = maxp + 1; per < mxdim; per++)
        {
            Budget[maxp] = Budget[maxp] + Budget[per];
            Budget[per] = 0;
        }
            
        double fnTot = 0;

        for (int per = minp; per <= maxp; per++)
        {
            fnTot += Budget[per];
        }

        mvtotal = mvtotal - fnTot;

        if (Det_Start < oDet_Start)
            Budget[minp] = Budget[minp] + mvtotal;
        else
            Budget[maxp] = Budget[maxp] + mvtotal;

        for (var per = 1; per <= mxdim; per++)
        {
            if (bUseCosts)
                zCost[per] = Budget[per] + OutsideAdj[per];
            else
                zValue[per] = Budget[per] + OutsideAdj[per];
        }
    }
}