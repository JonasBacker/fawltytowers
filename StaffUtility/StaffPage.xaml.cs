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
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reflection;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StaffUtility
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StaffPage : Page
    {
        public ObservableCollection<Issue> il;
        public static Issue selectedIssue { get; set; }

        public string testString { get; set; } = "teststring";
        private Model.IssueGetter ig = new Model.IssueGetter();
        public ServiceClass serviceclass { get; set; }
        public StaffPage()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            var parameter = e.Parameter;
            serviceclass = (ServiceClass)parameter;

            il = new ObservableCollection<Issue>();
            selectedIssue = null;

            page_header.Text = serviceclass.ToString();


            il = ig.LoadUncompleted(serviceclass);
            
            issue_list.DataContext = il;
            this.InitializeComponent();

        }
        private void service_go_home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        private void Finish_PointerPressed(object sender, RoutedEventArgs e)
        {
            il.Remove(selectedIssue);
            selectedIssue.status = CompletionStatus.completed;
            selectedIssue.timeCompleted = DateTime.Now;
            ig.Update(selectedIssue);
            //il = ig.LoadUncompleted(serviceclass);
            issue_list.DataContext = il;
        }

        private void Progress_ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Image img = new Image();


            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(btn); i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(btn, i);
                if ((current.GetType()).Equals(typeof(Image)))
                {
                    img = (Image) current;
                }

                if (selectedIssue.status == CompletionStatus.issued)
                {
                    img.Opacity = 1;
                    selectedIssue.status = CompletionStatus.inProgress;
                    ig.Update(selectedIssue);
                }
                else
                {
                    img.Opacity = 0.3;
                    selectedIssue.status = CompletionStatus.issued;
                    ig.Update(selectedIssue);
                }
                //il = ig.LoadUncompleted(serviceclass);
                issue_list.DataContext = il;

            }

        }

            

        private void issue_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count != 0)
            {
                selectedIssue = (Issue)e.AddedItems.First();
            }

            foreach (var item in e.AddedItems)
            {
                ListViewItem lvi = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                lvi.ContentTemplate = (DataTemplate)this.Resources["selectedState"];
            }

            foreach (var item in e.RemovedItems)
            {
                ListViewItem lvi = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                lvi.ContentTemplate = (DataTemplate)this.Resources["defaultState"];
            }


        }

        private void Note_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            save_note.Visibility = Visibility.Visible;
        }

        private void save_note_Click(object sender, RoutedEventArgs e)
        {
            selectedIssue.note = note.Text;
            ig.Update(selectedIssue);
            issue_list.DataContext = il;
        }

        private void Flyout_Opened(object sender, object e)
        {
            note.Focus(FocusState.Programmatic);
        }
    }
}
