using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StaffUtility.Model
{
    class IssueGetter : INotifyPropertyChanged
    {
        static Uri apiUrl = new Uri("http://localhost:49799/");
        static HttpClient client;
        

        public IssueGetter()
        {
            client = new HttpClient();
            client.BaseAddress = apiUrl;
        }

        public ObservableCollection<Issue> LoadAll()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ObservableCollection<Issue> Issues = null;
            HttpResponseMessage response = client.GetAsync("api/Issues").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                Issues = response.Content.ReadAsAsync<ObservableCollection<Issue>>().GetAwaiter().GetResult();
            }
            return Issues;
        }

        public Issue Load(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Issue Issues = null;
            HttpResponseMessage response = client.GetAsync("api/Issues/"+ id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                Issues = response.Content.ReadAsAsync<Issue>().GetAwaiter().GetResult();
            }
            return Issues;
        }

        public Issue Update(Issue i)
        {
            HttpResponseMessage response = client.PutAsJsonAsync(
                $"api/Issues/{i.issueID}", i).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            i = response.Content.ReadAsAsync<Issue>().GetAwaiter().GetResult();
            return i;
        }

        public Uri Post(Issue i)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(
               "api/Issues", i).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }



        //public void LoadData()
        //{
        //    if (!this.isDataLoaded)

        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var response = "";
        //            Task task = Task.Run(async () =>
        //            {
        //                response = await client.GetStringAsync(apiUrl);

        //            });
        //            task.Wait(); // Wait
        //            Issues = JsonConvert.DeserializeObject<ObservableCollection<Issue>>(response);
        //        }
        //    }
        //}



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
