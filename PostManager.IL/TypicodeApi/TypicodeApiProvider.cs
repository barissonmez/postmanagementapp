using Newtonsoft.Json;
using Polly;
using PostManager.Common.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace PostManager.IL.TypicodeApi
{
    public sealed class TypicodeApiProvider : ITypicodeApiProvider
    {
        private readonly string _baseUrl = ConfigurationSettings.AppSettings.Get("API_Base_URL");
        private readonly string _postUri = ConfigurationSettings.AppSettings.Get("API_POST_URI");

        public IList<PostDTO> GetPosts()
        {
            return GetPostsFromApi().Result;
        }

        public async Task<IList<PostDTO>> GetPostsFromApi()
        {

            var posts = new List<PostDTO>();

            var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetry(4, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var result = await client.GetAsync(_postUri);

                if (result.IsSuccessStatusCode)
                {
                    var response = result.Content.ReadAsStringAsync().Result;

                    posts = JsonConvert.DeserializeObject<List<PostDTO>>(response);
                }
            }

            return posts;

        }

    }
}
