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
    public partial class Gekco : PhoneApplicationPage
    {
        public Gekco()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Gekco_Loaded);
        }


        // wenn die Gekco geladen wird, wird folgendes getan:
        void Gekco_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Gekco = new Pushpin();
            Gekco.Location = new GeoCoordinate(49.40921, 8.69196);
            myMap.Center = Gekco.Location;
            Gekco.Background = new SolidColorBrush(Colors.Black);
            Gekco.Content = "Gekco";
            Gekco.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Gekco);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Gekco";
            phone.PhoneNumber = "+496221604520 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.cafegekco.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@cafe-gekco.de";
            email.Body = "";
            email.Show();
        }
    }
}