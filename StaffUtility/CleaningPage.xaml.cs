using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Model;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StaffUtility
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CleaningPage : Page
    {
        public ObservableCollection<Issue> il;
        public CleaningPage()
        {
            this.InitializeComponent();
            il = new ObservableCollection<Issue>();
            for (int i = 1; i <= 10; i++)
            {
                //Issue iss = new Issue().RegisterNewIssue(i, ServiceClass.cleaning, "Clean the room");
                Issue iss = new Issue();
                iss.RoomNr = i;
                iss.IssueDesc = "Clean the room";
                iss.IssueClass = ServiceClass.cleaning;
                iss.TimeIssued = DateTime.Now;
                iss.TimeCompleted = null;
                il.Add(iss);
            }
            issue_list.DataContext = il;

        }

        private void service_go_home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

    }
}
