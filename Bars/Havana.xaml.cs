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
    public partial class Havana : PhoneApplicationPage
    {
        public Havana()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Havana_Loaded);
        }


        // wenn die Havana geladen wird, wird folgendes getan:
        void Havana_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Havana = new Pushpin();
            Havana.Location = new GeoCoordinate(49.41259, 8.7003);
            myMap.Center = Havana.Location;
            Havana.Background = new SolidColorBrush(Colors.Black);
            Havana.Content = "Havana";
            Havana.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Havana);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Havana";
            phone.PhoneNumber = "+4962213893430 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "www.havana-heidelberg.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "heidelberg@havanarestaurants.de";
            email.Body = "";
            email.Show();
        }
    }
}