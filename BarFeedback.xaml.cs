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

namespace DatenErkundungen
{
    public partial class BarFeedback : PhoneApplicationPage
    {
        public BarFeedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask FeedbackEmail = new EmailComposeTask();
            FeedbackEmail.Subject = textBox2.Text; ;
            FeedbackEmail.Body = textBox1.Text;
            FeedbackEmail.To = "barfinderheidelberg@gmail.com";
            FeedbackEmail.Show();
        }

        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ihre Nachricht";
            }
        }

        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Betreff";
            }
        }
    }
}