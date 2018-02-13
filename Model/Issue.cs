using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Issue
    {
        enum CompletionStatus { issued, inProgress, completed }
        enum IssueClass { cleaning, service, maintenance }

        public IssueClass issueClass { get; set; }
        public string IssueDesc { get; set; }
        public int RoomNr { get; set; }
        public IssueStatus status { get; set; }

        DateTime timeIssued;
        // DateTime timeInProgress; // trolig unødvendig
        DateTime timeCompleted;

        CompletionStatus status;

        public Issue()
        {
            
        }

        public void registerNewIssue(int room, IssueClass ic, string desc)
        {
            this.RoomNr = room;
            this.issueClass = ic;
            this.IssueDesc = desc;
            this.status = CompletionStatus.issued;
            this.issued = DateTime.Now();
        }


    }
}
