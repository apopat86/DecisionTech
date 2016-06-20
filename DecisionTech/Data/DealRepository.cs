using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DecisionTech.Data.Contracts;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace DecisionTech.Data.Repositories
{
    public class DealRepository : IDealRepository
    {
        public ContentResult GetDeal()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.broadbandchoices.co.uk/api/v2/bestbuys?Authorization=eb45afb3-a7c2-4d6d-a62a-bb9a29a4fb2e");
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                WebResponse response = request.GetResponse();
                var serializer = new JsonSerializer();

                dynamic Bundles;
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        Bundles = serializer.Deserialize<dynamic>(jsonTextReader);
                    }
                }

                // Ensure we receive the bundles, and extract just the first deal
                if (Bundles.totalBundles > 0)
                {
                    return new ContentResult(){Content= JsonConvert.SerializeObject(Bundles.bundleList[0]), ContentType="application/json"  };
                }
                else
                    throw new Exception("There was an error whilst reading the deals");

            }
            catch
            {
                // Possibly log on server, before sending on the exception
                throw;
            }
            
        }
    }
}
