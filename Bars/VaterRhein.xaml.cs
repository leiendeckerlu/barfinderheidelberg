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
    public partial class VaterRhein : PhoneApplicationPage
    {
        public VaterRhein()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(VaterRhein_Loaded);
        }


        // wenn die VaterRhein geladen wird, wird folgendes getan:
        void VaterRhein_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin VaterRhein = new Pushpin();
            VaterRhein.Location = new GeoCoordinate(49.41182, 8.69749);
            myMap.Center = VaterRhein.Location;
            VaterRhein.Background = new SolidColorBrush(Colors.Black);
            VaterRhein.Content = "Vater Rhein";
            VaterRhein.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(VaterRhein);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Vater Rhein";
            phone.PhoneNumber = "+49622121371";
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