﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AwesomeTexter.Models
{
    public class Message
    {
        public Message()
        {
            From = "+12013714641";
        }
        public string To { get; set; }
        public string From { get;}
        public string Body { get; set; }
        public string Status { get; set; }
        public bool IsChecked { get; set; }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariable.AccountSid + "/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariable.AccountSid, EnvironmentVariable.AuthToken);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse["messages"].ToString());
            return messageList;
        }

        public void Send(List<Contact> contacts)
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariable.AccountSid + "/Messages", Method.POST);

            foreach (var contact in contacts)
            {

                request.AddParameter("To", contact.PhoneNumber);
                request.AddParameter("From", From);
                request.AddParameter("Body", Body);
                client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariable.AccountSid, EnvironmentVariable.AuthToken);
                client.ExecuteAsync(request, response => {
                    Console.WriteLine(response.Content);
                });
             
            }


        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
