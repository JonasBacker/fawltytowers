using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StaffUtility
{
   public sealed class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultStateTemplate { get; set; }
        public DataTemplate SelectedStateItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item,
                                                           DependencyObject container)
        {
            Issue issue = (Issue)item;
            Issue selected = StaffPage.selectedIssue;
            if (selected != null && issue.IssueID == selected.IssueID)
                return SelectedStateItemTemplate;
            else
                    return DefaultStateTemplate;
            //return base.SelectTemplateCore(item, container);
        }
    }
}
