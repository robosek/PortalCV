using Newtonsoft.Json.Linq;
using OnlineStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStoreMVC.Controllers
{
    public class StatisticsController : ApiController
    {
        EntityDbContext db = new EntityDbContext();
        public JObject Get()
        {
            //get languages grouped by language name
            var languages = (from m in db.Languages 
                            group m by m.LanguageName into gr
                            select new  { Key= gr.Key, Value= gr.Count()})
                            .ToDictionary( t => t.Key, t => t.Value);

            var languageLevels = (from m in db.Languages
                             group m by m.LanguageSpeakLevel into gr
                             select new { Key = gr.Key, Value = gr.Count() })
                            .ToDictionary(t => t.Key, t => t.Value);
            var educationTypes = (from m in db.Educations
                             group m by m.TypeOfSchool into gr
                             select new { Key = gr.Key, Value = gr.Count() })
                            .ToDictionary(t => t.Key, t => t.Value);
            var userTimeSeries = from m in db.Users
                                 orderby m.Created
                                 select m.Created;
            int count = 0;
            JArray dates = new JArray("x");
            JArray numUsers = new JArray("Liczba Użytkowników");
            foreach(var date in userTimeSeries){
                count++;
                if (!dates.Last.Equals(date))
                {
                    dates.Add(date.Split(' ')[0]);
                    numUsers.Add(count);
                }
            }
            //build JSON in required format
            JObject result = new JObject(
                new JProperty("statistics",
                new JArray(
                    new JObject(
                        new JProperty("data", buildJsonArray(languages)),
                        new JProperty("chartType", "pie")
                        ),
                    new JObject(
                        new JProperty("data", buildJsonArray(languageLevels)),
                        new JProperty("chartType", "pie")
                        ),
                    new JObject(
                        new JProperty("data", buildJsonArray(educationTypes)),
                        new JProperty("chartType", "pie")
                        ),
                    new JObject(
                        new JProperty("data", new JArray(dates, numUsers)),
                        new JProperty("chartType", "timeseries")
                        )
                )));
            return result;
        }
        private JArray buildJsonArray(Dictionary<string, int> dict)
        {
            JArray array = new JArray();
            JArray element;
            foreach (var key in dict)
            {
                element = new JArray();
                element.Add(key.Key); element.Add(key.Value);
                array.Add(element);
            }
            return array;
        }

    }
}
