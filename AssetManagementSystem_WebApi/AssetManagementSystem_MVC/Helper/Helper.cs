
using System.Net.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace AssetManagementSystem_MVC.Helper
{
    public class BaseAddress
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7036");
            return client;
        }
    }
}
