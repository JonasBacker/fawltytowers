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
            ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
            Rooms.Add(new Room(1,2,true,false));
            Rooms.Add(new Room(2, 3, false, false));
            Rooms.Add(new Room(3, 2, true, true));
            Rooms.Add(new Room(4, 2, true, false));
            RoomGrid.DataContext = Rooms;
           
            
            
        }
    }
}
