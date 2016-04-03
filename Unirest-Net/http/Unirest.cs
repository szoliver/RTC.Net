using System.Net.Http;

using unirest_net.request;

namespace unirest_net.http
{
    public class Unirest
    {
        // Should add overload that takes URL object
        public static HttpRequest get(string url, long timeout = 30)
        {
            return new HttpRequest(HttpMethod.Get, url, timeout);
        }

        public static HttpRequest post(string url, long timeout = 30)
        {
            return new HttpRequest(HttpMethod.Post, url, timeout);
        }

        public static HttpRequest delete(string url, long timeout = 30)
        {
            return new HttpRequest(HttpMethod.Delete, url, timeout);
        }

        public static HttpRequest patch(string url, long timeout = 30)
        {
            return new HttpRequest(new HttpMethod("PATCH"), url, timeout);
        }

        public static HttpRequest put(string url, long timeout = 30)
        {
            return new HttpRequest(HttpMethod.Put, url, timeout);
        }
    }
}
