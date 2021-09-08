using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ExampleAppMobileDev
{
    class RepositoryRestService : IRepositoryRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public RepositoryRestService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        //REST call to get all repositories
        public async Task<List<Repository>> GetRepositoriesAsync(string uri)
        {
            List<Repository> repositories = null;
            try
            {
                //call the REST url
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) //if  a successful response is returned
                {
                    string content = await response.Content.ReadAsStringAsync(); //retrive content from web response
                    repositories = JsonSerializer.Deserialize<List<Repository>>(content); //deserialize to a collection of repositories
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }
    }
}
