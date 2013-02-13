namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    //TODO: For the record I do not like this class or the design behind its usage. It is temporary and must be refactored when the entire chart control functionality is.
    
    /// <summary>
    /// This class is used for the bubble chart in order to figure out what columns are associated with what axis when doing a caml query.
    /// The reason is because if a user selects the same field for more than one axis, then that will only equate to one column in the results.
    /// That being the case, we need to know what axis use what columns.
    /// </summary>
    public class BubbleChartAxisToColumnMapping
    {
        public int XaxisColumnIndex { get; set; }
        public int YaxisColumnIndex { get; set; }
        public int ZaxisColumnIndex { get; set; }
        public int ZaxisColorColumnIndex { get; set; }
    }
}