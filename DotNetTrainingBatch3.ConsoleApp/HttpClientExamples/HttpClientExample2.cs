
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DotNetTrainingBatch3.ConsoleApp.Models;


namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample2
    {
        public async Task Run() {
            await Read();
        }

        private async Task Read() //if we wanna return 0, then write ....Task<int>
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://local:7131/api/Blog");
            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync(); // change into String
                Console.WriteLine(jsonStr);

               // JsonConvert.SerializeObject(); // C# object to JSON
               // JsonConvert.DeserializeObject() //JSON to C# object

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                lst.Add(new BlogModel()
                {

                });

                BlogModel[] lst2 = JsonConvert.DeserializeObject<BlogModel[]>(jsonStr)!;
                // lst2[0] = 
                foreach (BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }

                foreach (BlogModel item in lst2)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }
    }
}
