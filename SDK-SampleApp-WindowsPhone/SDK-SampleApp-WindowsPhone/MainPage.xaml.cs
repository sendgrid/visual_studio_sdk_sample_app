using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json.Linq;
using SDK_SampleApp_WindowsPhone.Resources;

namespace SDK_SampleApp_WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        /// <summary>
        /// Calls the SendGrid SDK to send email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnSendClick(object sender, RoutedEventArgs e)
        {
            try
            {
                /* Get value for inputs */
                string to = this._to.Text;
                string subject = this._subject.Text;
                string message = this._message.Text;

                /* Validate */
                if (to == "" || subject == "" || message == "" || to == "Email" || subject == "Subject" || message == "Message")
                {
                    /* Show error message */
                    this._error.Visibility = Visibility.Visible;
                    this._error.Text = "All inputs are required!";
                    this._success.Visibility = Visibility.Collapsed;
                    return;
                }

                SendGridSDK.Mail SendGrid = new SendGridSDK.Mail("SENDGRID_USERNAME", "SENDGRID_PASSWORD");

                /* Set Subject */
                SendGrid.setSubject(subject);
                /* Set From */
                SendGrid.setFrom("example@example.com");
                SendGrid.setFromName("VisualStudio SDK Sample App");
                /* Add To */
                SendGrid.addTo(to);
                /* Set email text */
                SendGrid.setText(message);
                /* Send email */
                String results = await SendGrid.send();
                JObject response = JObject.Parse(results);

                /* Parse response and show success or error message */
                if ((String)response.GetValue("message") == "success")
                {
                    this._error.Visibility = Visibility.Collapsed;
                    this._success.Visibility = Visibility.Visible;
                }
                else
                {
                    this._error.Visibility = Visibility.Visible;
                    this._error.Text = response.GetValue("errors")[0].ToString();
                    this._success.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                this._error.Visibility = Visibility.Visible;
                this._success.Visibility = Visibility.Collapsed;
            }
        }
    }
}