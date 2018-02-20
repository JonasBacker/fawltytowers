using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model_DB;
using System.Data.Entity;
namespace DesktopApplication
{
    /// <summary>
    /// Interaction logic for EditResWindow.xaml
    /// </summary>
    public partial class EditResWindow : Window
    {
        dat154_18_2Entities db;
        private Booking bk;
        public EditResWindow(dat154_18_2Entities db, Booking bk)
        {
            InitializeComponent();
            this.db = db;
            this.bk = bk;

            resLabel.Content = this.bk.bookingID;
            kundeLabel.Content = this.bk.customerID;
            roomtype.SelectedIndex = this.bk.roomtype-1;
            innkalender.SelectedDate = this.bk.checkinDate;
            utkalender.SelectedDate = this.bk.checkoutDate;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.bk.roomtype = roomtype.SelectedIndex + 1;
            this.bk.checkinDate = (DateTime)innkalender.SelectedDate;
            this.bk.checkoutDate = (DateTime)utkalender.SelectedDate;
            db.SaveChanges();

            delegatClass.delegat.Invoke();
            //fyr delegat
            this.Close();
        }
    }
}
