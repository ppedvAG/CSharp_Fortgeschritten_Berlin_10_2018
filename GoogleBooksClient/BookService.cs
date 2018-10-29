using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient
{
    public class BookSearchService
    {
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects
        };
       
        public static Book[] SearchBooks(string searchTerm)
        {
            HttpClient client = new HttpClient();
            string jsonReponse = client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={searchTerm}").Result;
            var result =  JsonConvert.DeserializeObject<BookSearchResult>(jsonReponse, JsonSettings);
            return result.Books;
        }
    }
}
