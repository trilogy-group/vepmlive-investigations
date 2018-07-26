using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using EPMLiveCore;
using PortfolioEngineCore;

namespace CADataCache
{
    internal abstract class CADataCacheGridBase : ADataCacheGridBase<clsPeriodData, clsDetailRowData>
    {
        protected readonly bool _showFTEs;
        protected readonly bool _useQuantity;
        protected readonly bool _useCost;
        protected readonly bool _showCostDetailed;
        protected readonly int _pmoAdmin;
        protected readonly IList<CATGRow> _displayList;
        protected readonly IList<clsColDisp> _columns;

        protected CStruct MiddleCols;

        protected CStruct Definitions;
        protected CStruct DefinitionRight;
        protected CStruct DefinitionLeaf;

        public CADataCacheGridBase(
            bool showFTEs, 
            bool useQuantity,
            bool useCost, 
            bool showCostDetailed, 
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns)
        {
            _showFTEs = showFTEs;
            _useQuantity = useQuantity;
            _useCost = useCost;
            _showCostDetailed = showCostDetailed;
            _displayList = displayList;
            _columns = columns;
            _pmoAdmin = pmoAdmin;
        }

        protected string CleanUpString(string input)
        {
            return RemoveCharacters(input, "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\");
        }

        // (CC-76588, 2018-07-26) It's actually a copy of ModelDataCacheGridBase method, 
        // we can not unify them because they use different enums (enums fully match in keys and values, but logically they are different entities and the enum values could change)
        protected bool TryGetDataFromDetailRowDataField(clsDetailRowData detailRowData, int fid, out string value)
        {
            var result = true;
            value = null;

            switch (fid)
            {
                case (int)FieldIDs.SD_FID:
                    if (detailRowData.Det_Start != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Start.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FD_FID:
                    if (detailRowData.Det_Finish != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Finish.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FTOT_FID:
                    value = detailRowData.m_tot1.ToString();
                    break;
                case (int)FieldIDs.DTOT_FID:
                    value = detailRowData.m_tot2.ToString();
                    break;
                case (int)FieldIDs.PI_FID:
                    value = detailRowData.PI_Name;
                    break;
                case (int)FieldIDs.CT_FID:
                    value = detailRowData.CT_Name;
                    break;
                case (int)FieldIDs.SCEN_FID:
                    value = detailRowData.Scen_Name;
                    break;
                case (int)FieldIDs.BC_FID:
                    value = detailRowData.Cat_Name;
                    break;
                case (int)FieldIDs.FULLC_FID:
                    value = detailRowData.FullCatName;
                    break;
                case (int)FieldIDs.CAT_FID:
                    value = detailRowData.CC_Name;
                    break;
                case (int)FieldIDs.FULLCAT_FID:
                    value = detailRowData.FullCCName;
                    break;
                case (int)FieldIDs.BC_ROLE:
                    value = detailRowData.Role_Name;
                    break;
                case (int)FieldIDs.MC_FID:
                    value = detailRowData.MC_Name;
                    break;
                default:
                    if (fid >= 11801 && fid <= 11805)
                    {
                        value = detailRowData.Text_OCVal[fid - 11800];
                    }
                    else if (fid >= 11811 && fid <= 11815)
                    {
                        value = detailRowData.TXVal[fid - 11810];
                    }
                    else
                    {
                        value = GlobalConstants.Whitespace;
                    }
                    break;
            }

            return result;
        }

        protected override int CalculateInternalPeriodMin(clsDetailRowData detailRowData)
        {
            for (int i = 1; i <= detailRowData.zFTE.Length - 1; i++)
            {
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        if (_useQuantity
                            && detailRowData.zValue[i] != double.MinValue
                            && detailRowData.zValue[i] != 0)
                        {
                            return i;
                        }

                        if (_showFTEs
                            && detailRowData.zFTE[i] != double.MinValue
                            && detailRowData.zFTE[i] != 0)
                        {
                            return i;
                        }

                        if (_useCost
                            && detailRowData.zCost[i] != 0)
                        {
                            return i;
                        }
                    }
                }
            }

            return 0;
        }

        protected override int CalculateInternalPeriodMax(clsDetailRowData detailRowData)
        {
            for (int i = detailRowData.zFTE.Length - 1; i > 1; i--)
            {
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        if (_useQuantity
                            && detailRowData.zValue[i] != double.MinValue
                            && detailRowData.zValue[i] != 0)
                        {
                            return i;
                        }

                        if (_showFTEs
                            && detailRowData.zFTE[i] != double.MinValue
                            && detailRowData.zFTE[i] != 0)
                        {
                            return i;
                        }

                        if (_useCost
                            && detailRowData.zCost[i] != 0)
                        {
                            return i;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
