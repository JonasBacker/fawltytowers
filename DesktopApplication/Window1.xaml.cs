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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Room room;
        public Window1(dat154_18_2Entities db , Room room)
        {
            InitializeComponent();
            this.room = room;
            
            romnr.Content = this.room.roomID;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new dat154_18_2Entities())
            {
                string name = textbox1.Text;
                Customer kunde = new Customer { navn = name, passord = "1234" };
                db.Customer.Add(kunde);
                db.SaveChanges();
                db.Customer.Load();

                DateTime from = (DateTime)FirstCal.SelectedDate;
                DateTime to = (DateTime)SecondCal.SelectedDate;
                Booking book = new Booking { checkinDate = from, checkoutDate = to, customerID = kunde.customerID, roomtype = (int)room.roomType};
                db.Booking.Add(book);
                db.SaveChanges();
                db.Booking.Load();
                MessageBoxResult m = MessageBox.Show("Bestilling fullført. \n KundeNr "+ kunde.customerID + "\n Passord " + kunde.passord + "\n BookingID " + book.bookingID +" \n ", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                if(m == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }


        }
    }
}
