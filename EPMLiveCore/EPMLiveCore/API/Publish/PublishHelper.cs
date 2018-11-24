using System.Data.SqlClient;

namespace EPMLiveCore.API
{
    public class PublishHelper
    {
        public static string ParseResults(SqlCommand command, string showResults)
        {
            string message;
            using (var dataReader = command.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    var status = string.Empty;
                    var result = (dataReader.IsDBNull(3))
                        ? string.Empty
                        : dataReader.GetString(3);
                    var resultText = (dataReader.IsDBNull(4))
                        ? string.Empty
                        : dataReader.GetString(4);
                    var finishDate = (dataReader.IsDBNull(2))
                        ? string.Empty
                        : dataReader.GetDateTime(2).ToString();

                    switch (dataReader.GetInt32(1))
                    {
                        case 0:
                            status = "Queued";
                            break;
                        case 1:
                            status = "Processing";
                            break;
                        case 2:
                            status = "Complete";
                            break;
                        default:
                            status = string.Empty;
                            break;
                    }

                    bool parseResult;
                    if (bool.TryParse(showResults, out parseResult) && parseResult)
                    {
                        message = string.Format(
                            "<PublishStatus Status=\"{0}\" PercentComplete=\"{1}\" TimeFinished=\"{2}\" Result=\"{3}\"><![CDATA[{4}]]></PublishStatus>",
                            status,
                            dataReader.GetInt32(0),
                            finishDate,
                            result,
                            resultText);
                    }
                    else
                    {
                        message = string.Format(
                            "<PublishStatus Status=\"{0}\" PercentComplete=\"{1}\" TimeFinished=\"{2}\" Result=\"{3}\"/>",
                            status,
                            dataReader.GetInt32(0),
                            finishDate,
                            result);
                    }
                }
                else
                {
                    message = "<PublishStatus/>";
                }
            }
            return message;
        }
    }
}