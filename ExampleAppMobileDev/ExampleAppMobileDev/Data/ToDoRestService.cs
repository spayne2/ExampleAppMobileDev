using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ExampleAppMobileDev
{
    public class ToDoRestService : IToDoRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public List<TodoItem> Items { get; private set; }

        public ToDoRestService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            Items = new List<TodoItem>();
            //construct the URI
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {//call the REST uri
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)//if  a successful response is returned
                {
                    string content = await response.Content.ReadAsStringAsync();//retrive content from web response
                    Items = JsonSerializer.Deserialize<List<TodoItem>>(content, serializerOptions);//deserialize to a collection of todoitems
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        { //call the REST url
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<TodoItem>(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem) //if the todoitem is a new item, then call POST async
                {
                    response = await client.PostAsync(uri, content);
                }
                else //otherwise call PUT with the item ID
                {
                    uri = new Uri(string.Format(Constants.RestUrl, item.ID)); //new URI is constructed for PUT to include the ID
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)//if  a successful response is returned
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        { 
            //construct the rest URI
            Uri uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {   
                //call the REST url
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)//if  a successful response is returned the item has been deleted
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


    }
}