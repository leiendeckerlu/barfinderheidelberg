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
    public partial class HardRockCafe : PhoneApplicationPage
    {
        public HardRockCafe()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(HardRockCafe_Loaded);
        }


        // wenn die HardRockCafe geladen wird, wird folgendes getan:
        void HardRockCafe_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin HardRockCafe = new Pushpin();
            HardRockCafe.Location = new GeoCoordinate(49.41163, 8.70707);
            myMap.Center = HardRockCafe.Location;
            HardRockCafe.Background = new SolidColorBrush(Colors.Black);
            HardRockCafe.Content = "Hard Rock Café";
            HardRockCafe.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(HardRockCafe);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Hard Rock Café";
            phone.PhoneNumber = "+49622122819";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.hard-rockcafe.de/index_hardrock.php/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@hard-rockcafe.de";
            email.Body = "";
            email.Show();
        }
    }
}