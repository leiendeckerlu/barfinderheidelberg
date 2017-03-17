using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;

namespace DatenErkundungen
{
    public partial class Medocs : PhoneApplicationPage
    {
        public Medocs()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Medocs_Loaded);
        }


        // wenn die Medocs geladen wird, wird folgendes getan:
        void Medocs_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Medocs = new Pushpin();
            Medocs.Location = new GeoCoordinate(49.41032, 8.69351);
            myMap.Center = Medocs.Location;
            Medocs.Background = new SolidColorBrush(Colors.Black);
            Medocs.Content = "MEDOCS";
            Medocs.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Medocs);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "MEDOCS";
            phone.PhoneNumber = "+49622120468";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.Medocs-cafe.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "blabla@blabla.com";
            email.Body = "";
            email.Show();
        }
    }
}