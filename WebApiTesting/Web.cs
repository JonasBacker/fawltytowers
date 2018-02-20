using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiTesting;

namespace HttpClientSample
{
    
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowIssue(Issue issue)
        {
            Console.WriteLine($"Room: {issue.Room.RoomID.ToString()}");
        }

        static async Task<Uri> CreateProductAsync(Issue issue)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Issues", issue);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Issue> GetProductAsync(string path)
        {
            Issue issue = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                issue = await response.Content.ReadAsAsync<Issue>();
            }
            return issue;
        }

        static async Task<Issue> UpdateIssueAsync(Issue issue)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Issues/{issue.IssueID}", issue);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            issue = await response.Content.ReadAsAsync<Issue>();
            return issue;
        }

        static async Task<HttpStatusCode> DeleteIssueAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Issues/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            Console.ReadLine();
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:49799/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                Issue iss = new Issue
                {
                iss.IssueID = 12;
                Room room = new Room(RoomType.enkeltrom, false, false);
                room.RoomID = 1 * 100 + i;
                iss.Room = room;
                iss.IssueDesc = "Clean the room";

                if (i % 3 == 0)
                    iss.Status = CompletionStatus.inProgress;
                else
                    iss.Status = CompletionStatus.issued;

                if (i == 5)
                    iss.IssueDesc = "Clean the damn room or there'll be a lot of trouble young man";
                iss.IssueClass = ServiceClass.cleaning;
                iss.TimeIssued = DateTime.Now;
                iss.TimeCompleted = null;

            };

                var url = await CreateProductAsync(issue);
                Console.WriteLine($"Created at {url}");

                // Get the product
                issue = await GetProductAsync(url.PathAndQuery);
                ShowIssue(issue);

                // Update the product
                Console.WriteLine("Updating price...");
                issue.Status = CompletionStatus.inProgress;
                await UpdateIssueAsync(issue);

                // Get the updated product
                issue = await GetProductAsync(url.PathAndQuery);
                ShowIssue(issue);

                // Delete the product
                var statusCode = await DeleteIssueAsync(issue.IssueID.ToString());
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}