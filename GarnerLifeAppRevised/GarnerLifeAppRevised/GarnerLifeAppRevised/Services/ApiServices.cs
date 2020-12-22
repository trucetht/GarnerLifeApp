using GarnerLifeAppRevised.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GarnerLifeAppRevised.Services
{
    class ApiServices
    {
        private static ApiServices _ServiceClientInstance;

        public static ApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServices();
                return _ServiceClientInstance;
            }
        }

        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;

        public ApiServices()
        {
            client = new HttpClient();
            //Change your base address here
            client.BaseAddress = new Uri("https://app.garnerlife.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginApiResponseModel> AuthenticateUserAsync(string phonenumber, string password)
        {
            try
            {
                LoginApiRequestModel loginRequestModel = new LoginApiRequestModel()
                {
                    UserName = phonenumber,
                    Password = password

                };
                var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");
                //Change your base address tail part here and post it. 
                var response = await client.PostAsync("umbraco/surface/appmembership/loginuser", content);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serializer.Deserialize<LoginApiResponseModel>(json);
                    
                    return jsoncontent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
