SendGrid SDK Sample Apps
======================

This git repository helps you to send emails quickly and easily through SendGrid on Windows Store Applications using C# or Javascript.


Running the sample apps
----------------------------

Create an SendGrid account at http://sendgrid.com/pricing.html

Install the SendGrid SDK which can be found here:

<pre>
    git clone https://github.com/sendgrid/visual_studio_sdk
</pre>

Clone SendGrid applications on your local machine

<pre>
    git clone https://github.com/sendgrid/visual_studio_sdk_sample_app
</pre>

###Configuration for C# App###

Add the Sendgrid SDK as a reference

Configure `SDK-SampleApp-CSharp\MainPage.xaml.cs` file with your information:

Update the *&lt;sendgrid_username&gt;* and *&lt;sendgrid_password&gt;* with your SendGrid credentials.
```C#
    var Sendgrid mail = new Sendgrid("SENDGRID_USERNAME","SENDGRID_PASSWORD");
```
Update the *&lt;from_address&gt;* with your email address
```C#
    .setFrom("example@example.com")
```


###Configuration for Javascript App###

Add the Sendgrid SDK as a reference

Configure `SDK-SampleApp-Javascript\js\default.js` file with your information:

Update the *&lt;sendgrid_username&gt;* and *&lt;sendgrid_password&gt;* with your SendGrid credentials.
```Javascript
    var Sendgrid mail = new Sendgrid("SENDGRID_USERNAME","SENDGRID_PASSWORD");
```
Update the *&lt;from_address&gt;* with your email address
```Javascript
    .setFrom("example@example.com")
```

That's it, you can now build and run your application on local machine.



