using System.Collections.Generic;
using System.Web;

public class MockHttpRequest : HttpRequestBase
{
    public Dictionary<string, string> Dictionary { get; set; }

    public new string this[string key] => Dictionary[key];
}