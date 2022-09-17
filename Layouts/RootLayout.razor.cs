using System.Net.Http;

namespace OriinDic.Layouts
{
    public partial class RootLayout
    {
        private readonly HttpClient Http = new HttpClient();

        public RootLayout()
        {
        }

        public RootLayout(HttpClient httpClient) : this()
        {
            Http = httpClient;
        }
    }
}