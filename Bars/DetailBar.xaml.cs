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
    public partial class DetailBar : PhoneApplicationPage
    {
        public DetailBar()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(DetailBar_Loaded);
        }


        // wenn die detailbar geladen wird, wird folgendes getan:
        void DetailBar_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin DetailBar = new Pushpin();
            DetailBar.Location = new GeoCoordinate(49.40921, 8.69196);
            myMap.Center = DetailBar.Location;
            DetailBar.Background = new SolidColorBrush(Colors.Black);
            DetailBar.Content = "DetailBar";
            DetailBar.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(DetailBar);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "DetailBar";
            phone.PhoneNumber = "123456789";
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