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
        public Issue selectedIssue { get; set; }
        public CleaningPage()
        {
            this.InitializeComponent();
            il = new ObservableCollection<Issue>();
            selectedIssue = null;
            for (int i = 1; i <= 9; i++)
            {
                //Issue iss = new Issue().RegisterNewIssue(i, ServiceClass.cleaning, "Clean the room");
                Issue iss = new Issue();
                iss.IssueID = i;
                Room room = new Room(RoomType.enkeltrom, false, false);
                room.RoomID = i * 100 + i;
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
                il.Add(iss);
            }
            issue_list.DataContext = il;

        }

        private void service_go_home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //private void vacuumIcon_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Image image = sender as Image;
        //    if (image.Name.Equals("inProgress"))
        //        image.Visibility = Visibility.Visible;
        //}

        private void Finish_PointerPressed(object sender, RoutedEventArgs e)
        {
            il.Remove(selectedIssue);
            issue_list.DataContext = il;
        }

        private void issue_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                selectedIssue = (Issue)e.AddedItems.First();
                selectedItem.Text = selectedIssue.IssueID.ToString();
            }
                
            
        }


    }
}
