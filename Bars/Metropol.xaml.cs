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
    public partial class Metropol : PhoneApplicationPage
    {
        public Metropol()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Metropol_Loaded);
        }


        // wenn die Metropol geladen wird, wird folgendes getan:
        void Metropol_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Metropol = new Pushpin();
            Metropol.Location = new GeoCoordinate(49.41070, 8.70879);
            myMap.Center = Metropol.Location;
            Metropol.Background = new SolidColorBrush(Colors.Black);
            Metropol.Content = "Metropol";
            Metropol.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Metropol);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Metropol";
            phone.PhoneNumber = "+4962214554050";
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