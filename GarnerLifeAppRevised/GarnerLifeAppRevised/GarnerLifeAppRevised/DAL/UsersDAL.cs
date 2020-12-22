using GarnerLifeAppRevised.ViewModels;
using MagicGradients.Renderers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GarnerLifeAppRevised.DAL
{
    public class Users
    {

        public String username { get; set; }

        public String password { get; set; }
        public string UsersRegistered { get { return username + password; } }
    }
    class UsersDAL
    {
        public bool AuthenticateUser(string username, string password)
        {
            
            var u = new Uri("https://app.garnerlife.com/umbraco/surface/appmembership/loginuser");
            var payload = new Login()
            {
                username = username,
                password = password
            };
            
            HttpContent c = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            APIResponse response;
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(u, c).Result;
                if (result.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(result.Content.ReadAsStringAsync().Result);
                    
                    if(response.Status == "Success")
                    {
                        return true;
                    }
                }
            }
            // check the response
            return false;
        }
    }
   
}
