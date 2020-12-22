using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GarnerLifeAppRevised.DAL
{
    public class Events
    {
        public String EventTitle { get; set; }
        public String EventDescription { get; set; }
        public String EventDateAndTime { get; set; }
        public String EventPosterImageURL { get; set; }
        public string EventDetails { get { return EventTitle + "\n" + EventDescription + "\n" + EventDateAndTime + "\n" + EventPosterImageURL; } }
       
    }
    class EventsDAL
    {
        
        public EventsDAL()
        {

        }

        public List<Events> GetAllEvents()
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/json");
                List<Events> events = new List<Events>();

                var response = client.GetAsync("https://app.garnerlife.com/umbraco/surface/appcontent/events").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    events = JsonConvert.DeserializeObject<List<Events>>(content);
                    
                }

                return events;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }

    
}
