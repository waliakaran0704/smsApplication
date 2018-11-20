using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;

//In this project a SMS will be sent to the mobile.
namespace SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = new VoiceResponse();
            response.Say("Chapeau!", voice: "alice", language: "fr-FR");

            Console.WriteLine(response.ToString()); ;
            var accountSid = "AC90f1b74adee13df84fda357e2a018acc";
            var authToken = "04bfc292c899055811d29139a7e3b980";
            var client = new TwilioRestClient(accountSid, authToken);

            //Pass the client into the resource method
           var message = MessageResource.Create(
               to: new PhoneNumber("+16477398091"),
               from: new PhoneNumber("+16474921516"),
               body: "Hello from C#",
               client: client
               );

            Console.WriteLine(message);

        }


        public async Task<CallResource> PhoneHomeAsync()
        {
            var call = await CallResource.CreateAsync(
                to: new PhoneNumber("+16477398091"),
                from: new PhoneNumber("+16474921516"),
                url: new Uri("http://demo.twilio.com/docs/voice.xml")
            );
            return call;
        }
    }
}
