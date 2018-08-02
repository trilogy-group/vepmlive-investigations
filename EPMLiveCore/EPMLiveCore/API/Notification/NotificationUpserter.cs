using System;
using System.Data.SqlClient;

namespace EPMLiveCore.API
{
    public class NotificationUpserter
    {
        private const int _defaultUserId = 1073741823;

        public NotificationUpserter() {}

        public SqlConnection Connection { get; set; }
        public string Id { get; set; }
        public int TemplateId { get; set; }
        public int CurUserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool ForceNewEntry { get; set; }
        public bool HideFrom { get; set; }
        public bool DoNotEmail { get; set; }
        public Guid SiteId { get; set; }
        public Guid WebId { get; set; }
        public object ListItemParentListID { get; set; }
        public object ListItemId { get; set; }

        public void Upsert()
        {
            using (var upsertNotificationCommand = new SqlCommand())
            {
                upsertNotificationCommand.Connection = Connection;
                if (Id == null || ForceNewEntry)
                {
                    Id = Guid.NewGuid().ToString();
                }
                upsertNotificationCommand.CommandText = GenerateUpsertSql(ForceNewEntry, Id);

                upsertNotificationCommand.Parameters.AddWithValue("@id", Id);
                upsertNotificationCommand.Parameters.AddWithValue("@title", Subject);
                upsertNotificationCommand.Parameters.AddWithValue("@message", Body);
                upsertNotificationCommand.Parameters.AddWithValue("@type", TemplateId);
                if (HideFrom)
                {
                    upsertNotificationCommand.Parameters.AddWithValue("@createdby", _defaultUserId);
                }
                else
                {
                    upsertNotificationCommand.Parameters.AddWithValue("@createdby", CurUserId);
                }
                upsertNotificationCommand.Parameters.AddWithValue("@siteid", SiteId);
                upsertNotificationCommand.Parameters.AddWithValue("@webid", WebId);
                upsertNotificationCommand.Parameters.AddWithValue("@listid", ListItemParentListID);
                upsertNotificationCommand.Parameters.AddWithValue("@itemid", ListItemId);
                upsertNotificationCommand.Parameters.AddWithValue("@emailed", DoNotEmail);
                upsertNotificationCommand.ExecuteNonQuery();
            }
        }

        private static string GenerateUpsertSql(bool forceNewEntry, string id)
        {
            string commandText;
            if (id == null || forceNewEntry)
            {
                commandText =
                    "INSERT INTO NOTIFICATIONS (id, title, message, type, createdby, createdat, " +
                    "siteid, webid, listid, itemid, emailed) VALUES (@id, @title, @message, @type, " +
                    "@createdby, GETDATE(), @siteid, @webid, @listid, @itemid, @emailed)";
            }
            else
            {
                commandText =
                    "UPDATE NOTIFICATIONS set title=@title, message=@message, type=@type, " +
                    "createdby=@createdby, siteid=@siteid, webid=@webid, listid=@listid, " +
                    "emailed=@emailed, itemid=@itemid where id=@id";
            }
            return commandText;
        }
    }
}
