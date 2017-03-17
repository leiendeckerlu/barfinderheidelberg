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
    public partial class Sonderbar : PhoneApplicationPage
    {
        public Sonderbar()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Sonderbar_Loaded);
        }


        // wenn die Sonderbar geladen wird, wird folgendes getan:
        void Sonderbar_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Sonderbar = new Pushpin();
            Sonderbar.Location = new GeoCoordinate(49.41223, 8.70739);
            myMap.Center = Sonderbar.Location;
            Sonderbar.Background = new SolidColorBrush(Colors.Black);
            Sonderbar.Content = "Sonderbar";
            Sonderbar.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Sonderbar);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Sonderbar";
            phone.PhoneNumber = "+49622125200";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.heise.de/";
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