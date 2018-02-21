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
    /// Interaction logic for IssueWindow.xaml
    /// </summary>
    public partial class IssueWindow : Window
    {
        dat154_18_2Entities db;
        Room rom;
        public IssueWindow(dat154_18_2Entities db, Room rom)
        {
            InitializeComponent();
            this.db = db;
            this.rom = rom;
            Romnr.Content = rom.roomID;
            ComboSak.SelectedIndex = 0;
        }

        private void OpprettSak_Click(object sender, RoutedEventArgs e)
        {
            int typesak = ComboSak.SelectedIndex;
            string description = Beskrivelse.Text;
            string note1 = Tilleggsinformasjon.Text;
            db.Issue.Add(new Issue { room = rom.roomID, issueType = typesak, issueDescription = description, note = note1, status = 0, timeIssued = DateTime.Now });
            db.SaveChanges();
            this.Close();


        }
    }
}
