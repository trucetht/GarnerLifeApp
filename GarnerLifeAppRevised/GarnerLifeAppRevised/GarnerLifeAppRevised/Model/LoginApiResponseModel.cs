using System;
using System.Collections.Generic;
using System.Text;

namespace GarnerLifeAppRevised
{
    public class User
    {
        public string userId { get; set; }
    }
    class LoginApiResponseModel
    {
        public string authenticationToken { get; set; }
        public User user { get; set; }
    }
}
