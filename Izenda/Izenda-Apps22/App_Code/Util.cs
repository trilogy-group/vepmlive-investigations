using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net;

public class Util
{
  public static string Md5(string password)
  {
    return Md5(ASCIIEncoding.ASCII.GetBytes(password));
  }

  public static string Md5(byte[] binaryData)
  {
    byte[] hash = new MD5CryptoServiceProvider().ComputeHash(binaryData);
    StringBuilder output = new StringBuilder();
    for (int i = 0; i < hash.Length; i++)
      output.Append(hash[i].ToString("x2"));
    return output.ToString();
  }

  public static void ExecuteNonQuery(string sql,string SqlConnectionString)
  {
    SqlConnection conn = new SqlConnection(SqlConnectionString);
    SqlCommand cmd = new SqlCommand(sql, conn);
    try {
      conn.Open();
      cmd.ExecuteNonQuery();
    }
    catch {
    }
    finally {
      conn.Close();
    }
  }

  public static DataSet ExecuteDataSet(string sql, string sqlConnectionString)
  {
    SqlConnection conn = new SqlConnection(sqlConnectionString);
    SqlCommand cmd = new SqlCommand(sql, conn);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    try {
      conn.Open();
      da.SelectCommand = cmd;
      da.Fill(ds, "Data");
    }
    catch {
    }
    finally {
      conn.Close();
    }
    return ds;
  }

  public static string GetGoogleTracker()
  {
    StringBuilder sb = new StringBuilder();
    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.googleadservices.com/pagead/conversion.js");
    string html = (new StreamReader(wr.GetResponse().GetResponseStream())).ReadToEnd();
    sb.Append("var google_conversion_id = 1071792817; ");
    sb.Append("var google_conversion_language = \"en\"; ");
    sb.Append("var google_conversion_format = \"1\"; ");
    sb.Append("var google_conversion_color = \"ffffff\"; ");
    sb.Append("var google_conversion_label = \"pageview\"; ");
    sb.Append(html);
    return sb.ToString();
  }
}
