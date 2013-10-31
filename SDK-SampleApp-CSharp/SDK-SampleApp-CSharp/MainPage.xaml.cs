using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Data.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SDK_SampleApp_CSharp
{
    /// <summary>
    /// Sample App using SendGid SDK
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
                JsonObject response = JsonObject.Parse(results);

                /* Parse response and show success or error message */
                if (response.GetNamedString("message") == "success")
                {
                    this._error.Visibility = Visibility.Collapsed;
                    this._success.Visibility = Visibility.Visible;
                }
                else
                {
                    this._error.Visibility = Visibility.Visible;
                    this._error.Text = response.GetNamedArray("errors").GetStringAt(0);
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
