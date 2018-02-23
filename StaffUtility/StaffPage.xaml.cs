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


        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            il.Remove(selectedIssue);
            selectedIssue.status = CompletionStatus.completed;
            selectedIssue.timeCompleted = DateTime.Now;
            ig.Update(selectedIssue);
            issue_list.DataContext = il;
        }

        private void Progress_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject btn = (DependencyObject)sender;

            Image img = (Image)FindChild(btn, typeof(Image));

            if (selectedIssue.status == CompletionStatus.issued)
            {
                if (img != null)
                    img.Opacity = 1;
                selectedIssue.status = CompletionStatus.inProgress;
                ig.Update(selectedIssue);
            }
            else
            {
                if (img != null)
                    img.Opacity = 0.3;
                selectedIssue.status = CompletionStatus.issued;
                ig.Update(selectedIssue);
            }
            issue_list.DataContext = il;

        }

        // Hjelpemetode for å finne child av et element i XAML etter type
        public DependencyObject FindChild(DependencyObject parent, Type childType)
        {

            if (parent == null) return null;

            DependencyObject foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child.GetType().Equals(childType))
                {
                    foundChild = child;
                    break;
                } else {
                    foundChild = FindChild(child, childType);
                    if (foundChild != null) break;
                }

            }
            return foundChild;

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
