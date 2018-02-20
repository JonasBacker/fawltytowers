using System;

namespace StaffUtility
{
    public enum CompletionStatus { issued, inProgress, completed }
    public enum ServiceClass { cleaning, service, maintenance }

    public class Issue
    {
     
        public int issueID { get; set; }
        public ServiceClass issueClass { get; set; }
        public string issueDescription { get; set; }
      
        public string note { get; set; }

        public CompletionStatus ? status { get; set; }

        public DateTime ? timeIssued { get; set; }
        public DateTime ? timeCompleted { get; set; }

        public int room { get; set; }


        public Issue()
        {

        }

        public class DefaultStateIssue: Issue
        {

        }

        public class SelectedStateIssue : Issue
        {

        }
    }
}

