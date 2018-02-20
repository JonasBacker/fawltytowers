using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace WebApiTesting
{
    public enum ServiceClass { cleaning, service, maintenance }
    public enum CompletionStatus { issued, inProgress, completed }

    class Program
    {

        static HttpClient client = new HttpClient();

        static void ShowProduct(Issue issue)
        {
            Console.WriteLine($"Name: {issue.Notis}");
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
    }
    public class Issue
    {

        public int IssueID { get; set; }
        public ServiceClass IssueClass { get; set; }
        public string IssueDesc { get; set; }

        public string Notis { get; set; }

        public CompletionStatus Status { get; set; }

        public DateTime TimeIssued { get; set; }
        public DateTime? TimeCompleted { get; set; }

        public virtual Room Room { get; set; }


        public Issue()
        {

        }

    }
    public enum RoomType { enkeltrom, dobbeltrom, familierom }
    public class Room
    {

        public int RoomID { get; set; }
        public RoomType Type { get; set; }
        public bool Vasket { get; set; }
        public bool Opptatt { get; set; }

        public Room(RoomType type, bool vasket, bool Opptatt)
        {
            this.Type = type;
            this.Vasket = vasket;
            this.Opptatt = Opptatt;
        }
    }
}
