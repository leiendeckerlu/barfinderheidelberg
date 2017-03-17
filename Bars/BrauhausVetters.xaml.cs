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
    public partial class BrauhausVetters : PhoneApplicationPage
    {
        public BrauhausVetters()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(BrauhausVetters_Loaded);
        }


        // wenn die BrauhausVetters geladen wird, wird folgendes getan:
        void BrauhausVetters_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin BrauhausVetters = new Pushpin();
            BrauhausVetters.Location = new GeoCoordinate(49.41254, 8.70971);
            myMap.Center = BrauhausVetters.Location;
            BrauhausVetters.Background = new SolidColorBrush(Colors.Black);
            BrauhausVetters.Content = "Brauhaus Vetter";
            BrauhausVetters.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(BrauhausVetters);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Brauhaus Vetter";
            phone.PhoneNumber = "+496221165850 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.Brauhaus-vetter.de";

            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "";
            email.To = "info@brauhaus-vetter.de ";
            email.Body = "";
            email.Show();
        }
    }
}