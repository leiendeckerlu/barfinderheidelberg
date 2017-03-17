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
    public partial class Villa : PhoneApplicationPage
    {
        public Villa()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Villa_Loaded);
        }


        // wenn die Villa geladen wird, wird folgendes getan:
        void Villa_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Villa = new Pushpin();
            Villa.Location = new GeoCoordinate(49.41193, 8.70898);
            myMap.Center = Villa.Location;
            Villa.Background = new SolidColorBrush(Colors.Black);
            Villa.Content = "Café Villa";
            Villa.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Villa);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Café Villa";
            phone.PhoneNumber = "+4962214332867";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.hard-rockcafe.de/index_villalounge.php";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@cafevilla.de ";
            email.Body = "";
            email.Show();
        }
    }
}