using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model_DB;
using System.Data.Entity;


namespace DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

        

    public partial class MainWindow : Window
    {
        dat154_18_2Entities db;
        public MainWindow()
        {
           
            InitializeComponent();
            db = new dat154_18_2Entities();

            var room = new Room { roomType = 2, ledigTil = new DateTime(2018, 07, 15), vasket = false, opptatt = false };
            db.Room.Add(room);
            db.SaveChanges();

            db.Room.Load();
            romList.DataContext = romtypeCombo.DataContext = db.Room.Local;
            romtypeCombo.SelectedIndex = 0;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (romList.SelectedItem != null)
            {

                {
                    Room selected = (Room)romList.SelectedItem;
                    Room rom = db.Room.Where(r => r.roomID == selected.roomID).First();

                    if (((Button)sender).Name.Equals("VasketButton"))
                    {
                        if (rom.vasket)
                            rom.vasket = false;
                        else
                            rom.vasket = true;
                    }
                    else
                    {
                        if (rom.opptatt)
                            rom.opptatt = false;
                        else
                            rom.opptatt = true;
                    }

                    db.SaveChanges();

                    db.Room.Load();


                   
                    romtypeCombo_SelectionChanged(null, null);
                }
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (romList.SelectedItem != null) {
                using (var db = new dat154_18_2Entities())
                {
                    Room selected = (Room)romList.SelectedItem;
                    Window w = new Window1(db, selected);
                    w.Activate();
                    w.ShowDialog();
                }

            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReservationWindow w = new ReservationWindow(db);
            w.Activate();
            w.ShowDialog();
        }

        private void VasketCheck_Checked(object sender, RoutedEventArgs e)
        {
            List<Room> l;
            if ((LedigCheck.IsChecked ?? false) && romtypeCombo.SelectedIndex!=0)
                l = db.Room.Where(r => r.vasket && !r.opptatt && r.roomType==romtypeCombo.SelectedIndex).ToList();
            else if (LedigCheck.IsChecked ?? false)
                l = db.Room.Where(r => r.vasket && !r.opptatt).ToList();
            else if (romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => r.vasket && r.roomType == romtypeCombo.SelectedIndex).ToList();
            else
                l = db.Room.Where(r => r.vasket).ToList();
            romList.DataContext = l;
        }

        private void VasketCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Room> l;
            if((LedigCheck.IsChecked ?? false) && romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => !r.opptatt && r.roomType == romtypeCombo.SelectedIndex).ToList();
            else if (LedigCheck.IsChecked ?? false)
                l = db.Room.Where(r => !r.opptatt).ToList();
            else if (romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => r.roomType == romtypeCombo.SelectedIndex).ToList();
            else
                l = db.Room.ToList();
            
            romList.DataContext = l;
        }

        private void LedigCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Room> l;
            if ((VasketCheck.IsChecked ?? false) && romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => r.vasket && r.roomType == romtypeCombo.SelectedIndex).ToList();
            else if (VasketCheck.IsChecked ?? false)
                l = db.Room.Where(r => r.vasket).ToList();
            else if (romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => r.roomType == romtypeCombo.SelectedIndex).ToList();
            else
                l = db.Room.ToList();

            romList.DataContext = l;
        }

        private void LedigCheck_Checked(object sender, RoutedEventArgs e)
        {
            List<Room> l;
            if ((VasketCheck.IsChecked ?? false) && romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => r.vasket && !r.opptatt && r.roomType == romtypeCombo.SelectedIndex).ToList();
            else if (VasketCheck.IsChecked ?? false)
                l = db.Room.Where(r => r.vasket && !r.opptatt).ToList();
            else if (romtypeCombo.SelectedIndex != 0)
                l = db.Room.Where(r => !r.opptatt && r.roomType == romtypeCombo.SelectedIndex).ToList();
            else
                l = db.Room.Where(r => !r.opptatt).ToList();
            romList.DataContext = l;
        }

        private void romtypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (romtypeCombo.SelectedIndex == 0)
            {
                if (LedigCheck.IsChecked ?? false)
                    LedigCheck_Checked(null, null);
                else if (VasketCheck.IsChecked ?? false)
                    VasketCheck_Checked(null, null);
                else
                    romList.DataContext = db.Room.ToList();
            }else 
            {
                List<Room> l;
                if((VasketCheck.IsChecked ?? false) && (LedigCheck.IsChecked ?? false))
                {
                    l = db.Room.Where(r => !r.opptatt && r.vasket && r.roomType == romtypeCombo.SelectedIndex).ToList();
                }else if(VasketCheck.IsChecked ?? false)
                {
                    l = db.Room.Where(r =>  r.vasket && r.roomType == romtypeCombo.SelectedIndex).ToList();
                }else if(LedigCheck.IsChecked ?? false)
                {
                    l = db.Room.Where(r => !r.opptatt && r.roomType == romtypeCombo.SelectedIndex).ToList();
                }
                else
                {
                    l = db.Room.Where(r =>  r.roomType == romtypeCombo.SelectedIndex).ToList();
                    
                }
                romList.DataContext = l;
            }
        }
    }
}
