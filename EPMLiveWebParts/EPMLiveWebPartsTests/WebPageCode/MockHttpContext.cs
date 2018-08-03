using System.Web;

public class MockHttpContext : HttpContextBase
{
    public MockHttpRequest MockRequest = new MockHttpRequest();
    public MockHttpResponse MockResponse = new MockHttpResponse();

    public override HttpRequestBase Request
    { get { return MockRequest; } }

    public override HttpResponseBase Response
    { get { return MockResponse; } }
}