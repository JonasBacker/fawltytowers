using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum CompletionStatus { issued, inProgress, completed }
    public enum ServiceClass { cleaning, service, maintenance }

    public class Issue
    {
        // issuenr?
        
        public ServiceClass IssueServiceClass { get; set; }
        public string IssueDesc { get; set; }
        public int RoomNr { get; set; }
        public CompletionStatus Status { get; set; }

        DateTime TimeIssued { get; set; }
        DateTime TimeCompleted { get; set; }
        
        public Issue()
        {

        }

        public void RegisterNewIssue(int room, ServiceClass sc, string desc)
        {
            // sette issuenr?
            RoomNr = room;
            IssueServiceClass = sc;
            IssueDesc = desc;
            Status = CompletionStatus.issued;
            TimeIssued = DateTime.Now;

            // oppdater database
        }

        public void RegisterInProgress()
        {
            Status = CompletionStatus.inProgress;

            // oppdater database
        }

        public void RegisterCompleted()
        {
            Status = CompletionStatus.completed;
            TimeCompleted = DateTime.Now;

            // oppdater database
        }




    }
}

