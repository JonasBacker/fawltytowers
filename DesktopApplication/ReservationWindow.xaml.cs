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
    }
}
