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
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    /// 
    public delegate void updateDelegat();

    public static class delegatClass
    {
        public static updateDelegat delegat;
    }


    public partial class ReservationWindow : Window

        
    {
        dat154_18_2Entities db;
        
        public ReservationWindow(dat154_18_2Entities db)
        {
            InitializeComponent();
            this.db = db;
             
            delegatClass.delegat += updateView;
            

            db.Booking.Load();
            resList.DataContext = db.Booking.Local;

        }

        private void slettbutton_Click(object sender, RoutedEventArgs e)
        {
            if(resList.SelectedItem != null)
            {
                db.Booking.Remove((Booking)resList.SelectedItem);
                db.SaveChanges();
            }
        }

        private void endrebutton_Click(object sender, RoutedEventArgs e)
        {
            if (resList.SelectedItem != null)
            {
                EditResWindow w = new EditResWindow(db, (Booking)resList.SelectedItem);
                w.Activate();
                w.ShowDialog();
            }
        }

        private void updateView()
        {
            db.Booking.Load();
            resList.DataContext = db.Booking.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Room> l;
            Room rom;
            Booking book = (Booking)resList.SelectedItem;
            l = db.Room.Where(r => !r.opptatt && r.roomType == book.roomtype).ToList();
            if (l.Count > 0) { 
                rom = l.First();
                rom.opptatt = true;
                book.room = rom.roomID;
                db.SaveChanges();
                delegatClass.delegat.Invoke();
                MessageBoxResult m = MessageBox.Show("Rom nr " + rom.roomID +" er ledig","Rom Ledig", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (m == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBoxResult m = MessageBox.Show("Ingen rom med den beskrivelsen ledig!","404 not found", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (m == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Booking book = (Booking)resList.SelectedItem;
            if (book.Room1 != null)
            {
                book.Room1.opptatt = false;
                book.Room1.vasket = false;
                db.Issue.Add(new Issue { room = book.Room1.roomID, issueType = 1, issueDescription = "Vask rommet plz", note = "Pretty plz?", status = 0, timeIssued = DateTime.Now});
                db.Booking.Remove(book);
                db.SaveChanges();
                delegatClass.delegat.Invoke();
            }
        }
    }
}
