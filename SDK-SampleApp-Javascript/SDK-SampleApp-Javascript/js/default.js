(function () {
    "use strict";

    var app = WinJS.Application;
    var SendGrid = new SendGridSDK.Mail("SENDGRID_USERNAME", "SENDGRID_PASSWORD");

    function sendMail() {
        /* Get value for inputs */
        var to = document.querySelector("#to").value,
            subject = document.querySelector("#subject").value,
            message = document.querySelector("#message").value;

        /* Validate */
        if (to == "" || subject == "" || message == "")
        {
            /* Show error message */
            document.querySelector("#success").style.display = "none";
            document.querySelector("#error").style.display = "block";
            return;
        }

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
        SendGrid.send().then(function (results) {
            /* Parse response and show success or error message */
            var response = JSON.parse(results);

            if (response.message == "success")
            {
                /* Show success message */
                document.querySelector("#error").style.display = "none";
                document.querySelector("#success").style.display = "block";
            }
            else
            {
                /* Show error message */
                document.querySelector("#error").innerHTML = response.errors;
                document.querySelector("#error").style.display = "block";
                document.querySelector("#success").style.display = "none";
            } 
        });
    }

    app.onactivated = function (args) {
        document.querySelector("#mailcontent").addEventListener("click", function (event) {
            if (event.target.tagName.toLowerCase() === "button") {
                switch (event.target.className) {
                    case "send":
                        sendMail();
                        break;
                    default:
                        break;
                }
            }
        });
    };

    app.start();
})();