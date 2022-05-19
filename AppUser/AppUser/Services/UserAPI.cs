using AppUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppUser.Services
{
    public class UserAPI
    {
        const string URL = "https://192.168.1.103:8001/api/users";

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler Handler = new HttpClientHandler();
            Handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return Handler;
        }
        private HttpClient GetClient()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();

            HttpClient client = new HttpClient(insecureHandler);
            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            
            return client;
        }

        public async Task CreateUser(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(URL, content);
        }
    }
}
