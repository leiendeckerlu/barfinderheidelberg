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
    public partial class ExtrablattMarkt : PhoneApplicationPage
    {
        public ExtrablattMarkt()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(ExtrablattMarkt_Loaded);
        }


        // wenn die ExtrablattMarkt geladen wird, wird folgendes getan:
        void ExtrablattMarkt_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin ExtrablattMarkt = new Pushpin();
            ExtrablattMarkt.Location = new GeoCoordinate(49.41178, 8.70830);
            myMap.Center = ExtrablattMarkt.Location;
            ExtrablattMarkt.Background = new SolidColorBrush(Colors.Black);
            ExtrablattMarkt.Content = "Extrablatt Markt";
            ExtrablattMarkt.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(ExtrablattMarkt);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Extrablatt Markt";
            phone.PhoneNumber = "+496221161712 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.cafe-extrablatt.com/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "heidelberg-markt@cafe-extrablatt.de  ";
            email.Body = "";
            email.Show();
        }
    }
}