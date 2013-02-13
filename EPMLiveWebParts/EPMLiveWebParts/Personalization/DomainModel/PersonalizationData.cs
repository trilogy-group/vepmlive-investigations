using System;
using System.Data;

namespace EPMLiveWebParts.Personalization.DomainModel
{
    public class PersonalizationData
    {
        public Guid? ForeignKey { get; set; }
        public string UserId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? WebId { get; set; }
        public Guid? ListId { get; set; }
        public int? ItemId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public void Hydrate(IDataReader reader)
        {
            if (reader.Read() == false) return;

            if (reader["FK"] != DBNull.Value) ForeignKey = new Guid(reader["FK"].ToString());
            if (reader["SiteId"] != DBNull.Value) SiteId = new Guid(reader["SiteId"].ToString());
            if (reader["WebId"] != DBNull.Value) WebId = new Guid(reader["WebId"].ToString());
            if (reader["UserId"] != DBNull.Value) UserId = reader["UserId"].ToString();
            if (reader["ListId"] != DBNull.Value) ListId = new Guid(reader["ListId"].ToString());
            if (reader["Key"] != DBNull.Value) Key = reader["Key"].ToString();
            if (reader["Value"] != DBNull.Value) Value = reader["Value"].ToString();

            if (reader["ItemId"] == DBNull.Value) return;
            
            int tryParseInt;
            Int32.TryParse(reader["ItemId"].ToString(), out tryParseInt);
            if (tryParseInt != 0) ItemId = tryParseInt;
        }
    }
}