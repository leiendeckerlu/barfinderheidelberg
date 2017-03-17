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
    public partial class Destille : PhoneApplicationPage
    {
        public Destille()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Destille_Loaded);
        }


        // wenn die Destille geladen wird, wird folgendes getan:
        void Destille_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Destille = new Pushpin();
            Destille.Location = new GeoCoordinate(49.41209, 8.70748);
            myMap.Center = Destille.Location;
            Destille.Background = new SolidColorBrush(Colors.Black);
            Destille.Content = "Destille";
            Destille.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Destille);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Destille";
            phone.PhoneNumber = "+49622122808";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.destilleonline.de/";
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