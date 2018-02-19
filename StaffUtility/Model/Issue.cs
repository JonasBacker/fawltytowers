using System;

namespace StaffUtility
{
    public enum CompletionStatus { issued, inProgress, completed }
    public enum ServiceClass { cleaning, service, maintenance }

    public class Issue
    {
     
        public int IssueID { get; set; }
        public ServiceClass IssueClass { get; set; }
        public string IssueDesc { get; set; }
      
        public string Notis { get; set; }

        public CompletionStatus Status { get; set; }

        public DateTime TimeIssued { get; set; }
        public DateTime ? TimeCompleted { get; set; }

        public virtual Room Room { get; set; }


        public Issue()
        {

        }

        public class DefaultStateIssue: Issue
        {

        }

        public class SelectedStateIssue : Issue
        {

        }

        //public Issue RegisterNewIssue(int room, ServiceClass sc, string desc)
        //{
        //    // sette issuenr?
        //    RoomNr = room;
        //    IssueClass = sc;
        //    IssueDesc = desc;
        //    Status = CompletionStatus.issued;
        //    TimeIssued = DateTime.Now;

        //    // oppdater database
        //    return this;
        //}

        //public void RegisterInProgress()
        //{
        //    Status = CompletionStatus.inProgress;

        //    // oppdater database
        //}

        //public void RegisterCompleted()
        //{
        //    Status = CompletionStatus.completed;
        //    TimeCompleted = DateTime.Now;

        //    // oppdater database
        //}

    }
}

