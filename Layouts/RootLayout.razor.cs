using Microsoft.AspNetCore.Components;

using System;
using System.Linq;
using System.Net.Http;

namespace OriinDic.Layouts
{
    public partial class RootLayout
    {
        private readonly HttpClient Http;

        public RootLayout()
        {
        }

        public RootLayout(HttpClient httpClient) : this()
        {
            Http = httpClient;
        }
    }
}