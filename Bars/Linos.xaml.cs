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
    public partial class Linos : PhoneApplicationPage
    {
        public Linos()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Linos_Loaded);
        }


        // wenn die Linos geladen wird, wird folgendes getan:
        void Linos_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Linos = new Pushpin();
            Linos.Location = new GeoCoordinate(49.40860, 08.6903);
            myMap.Center = Linos.Location;
            Linos.Background = new SolidColorBrush(Colors.Black);
            Linos.Content = "Lino's";
            Linos.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Linos);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Lino's";
            phone.PhoneNumber = "+4962217257750";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.linos-bar.de";
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