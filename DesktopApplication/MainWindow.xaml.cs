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
using Model;
using System.Data.Entity;
using ClassLibrary1;

namespace DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();

            using(var db = new dat154_18_2Entities())
            {
                var room = new Room { roomType = 1, ledigTil = new DateTime(2018,07,15) , vasket = false, opptatt = false };
                db.Room.Add(room);
                db.SaveChanges();

                db.Room.Load();
                romList.DataContext = db.Room.Local;

               
                
                //RoomGrid.ItemsSource = db.Room.Local;
            }
            //ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
            //Rooms.Add(new Room(RoomType.dobbeltrom,true,false));
            //Rooms.Add(new Room(RoomType.enkeltrom, false, false));
            //Rooms.Add(new Room(RoomType.enkeltrom, true, true));
            //Rooms.Add(new Room(RoomType.familierom, true, false));
           // RoomGrid.ItemsSource = Rooms;
           
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (romList.SelectedItem != null)
            {
                using (var db = new dat154_18_2Entities())
                {
                    Room selected = (Room)romList.SelectedItem;
                    Room rom = db.Room.Where(r => r.roomID == selected.roomID).First();
                    if (rom.vasket)
                        rom.vasket = false;
                    else
                        rom.vasket = true;

                    db.SaveChanges();

                    db.Room.Load();
                    romList.DataContext = db.Room.Local;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (romList.SelectedItem != null)
            {
                using (var db = new dat154_18_2Entities())
                {
                    Room selected = (Room)romList.SelectedItem;
                    Room rom = db.Room.Where(r => r.roomID == selected.roomID).First();
                    if (rom.opptatt)
                        rom.opptatt = false;
                    else
                        rom.opptatt = true;

                    db.SaveChanges();

                    db.Room.Load();
                    romList.DataContext = db.Room.Local;
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
                    w.ShowDialog();
                }

            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }



    }
}
