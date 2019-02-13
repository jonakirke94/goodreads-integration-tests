using GTL_Integration.Library;
using GTL_Integration.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTL_Integration.API
{
    public class GoodReadsClient : IBookProvider
    {
        private readonly string key;
        private readonly string baseUrl;
        private readonly RestClient client;

        public GoodReadsClient(IConfiguration config)
        {
            key = config.GetSection("GoodReadsConfig")["GoodReads"];
            baseUrl = config.GetSection("GoodReadsConfig")["Url"];
            client = new RestClient(baseUrl);
        }

        public Review GetBookReview(int reviewId)
        {
            var request = new RestRequest("review/show.xml", Method.GET);

            request.AddQueryParameter("id", reviewId.ToString());
            request.AddQueryParameter("key", key);
            var test = client.Execute<Review>(request);
            var restResponse = client.Execute<Review>(request).Data;

            return restResponse;
        }
    }
}
