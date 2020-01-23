using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Internet
{
   
    class Program
    {
        private const string Url = "https:www.baidu.com";
        static void Main(string[] args)
        {
        }

        public static async Task GetDataWithHeadersAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    ShowHeader("Request Headers:", client.DefaultRequestHeaders);
                    HttpResponseMessage response = await  client.GetAsync(Url);
                    //如果response 的IsSuccessStatusCode=false 就抛出异常
                    response.EnsureSuccessStatusCode();
                    ShowHeader("Response Headers:", response.Headers);
                    if (response.IsSuccessStatusCode)
                    {
                        //response.ReasonPhrase 获取的是和状态码对应的短语  如 200 对应Ok
                        Console.WriteLine($"Respone Status Code:{(int)response.StatusCode}{response.ReasonPhrase}");//Respone Status Code: 200OK
                        string responseBodyText = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Recevide payload of{responseBodyText.Length} characters");
                        Console.WriteLine(responseBodyText);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowHeader(string title,HttpHeaders httpHeaders)
        {
            Console.WriteLine(title);
            foreach (var header in httpHeaders)
            {
                string value = string.Join(" ", header.Value);
                Console.WriteLine($"Header:{header.Key} Values:{value}");

            }
        } 

        private async Task GetDateSimpleAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    
                    HttpResponseMessage response = await client.GetAsync(Url);
                    //如果response 的IsSuccessStatusCode=false 就抛出异常
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        //response.ReasonPhrase 获取的是和状态码对应的短语  如 200 对应Ok
                        Console.WriteLine($"Respone Status Code:{(int)response.StatusCode}{response.ReasonPhrase}");//Respone Status Code: 200OK
                        string responseBodyText = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Recevide payload of{responseBodyText.Length} characters");
                        Console.WriteLine(responseBodyText);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
