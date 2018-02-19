using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace StaffUtility.Model
{
    class IssueGetter : INotifyPropertyChanged
    {
        const string apiUrl = "http://localhost:49799/Issues";
        public ObservableCollection<Issue> Issues { get; private set; }
        public bool isDataLoaded { get; private set; } = false;

        public IssueGetter()
        {
            this.Issues = new ObservableCollection<Issue>();
        }



        public void LoadData()
        {
            if (!this.isDataLoaded)

            { using (var client = new HttpClient()) {
                    var response = "";
                    Task task = Task.Run(async () =>
                    {
                    response = await client.GetStringAsync(new Uri(apiUrl));
    
                    });
                    task.Wait(); // Wait
                    Issues = JsonConvert.DeserializeObject<ObservableCollection<Issue>>(response);
                } }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
