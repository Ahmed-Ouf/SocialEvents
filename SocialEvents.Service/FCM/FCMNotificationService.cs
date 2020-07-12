using FcmSharp;
using FcmSharp.Requests;
using FcmSharp.Settings;
using SocialEvents.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialEvents.Service
{


    public interface IFCMNotificationService
    {
        void Send(string tilte, string body);
    }
    public class FCMNotificationService : IFCMNotificationService
    {

        public void Send(string tilte, string body)
        {
            // Read the Credentials from a File, which is not under Version Control:
            var settings = FileBasedFcmClientSettings.CreateFromFile(ConfigrationHelper.FirebaseServiceFile);

            // Construct the Client:
            using (var client = new FcmClient(settings))
            {
                var notification = new Notification
                {
                    Title = tilte ?? "",
                    Body = $"تم اضافة فاعلية : {body}"
                };

                // The Message should be sent to the News Topic:
                var message = new FcmMessage()
                {
                    ValidateOnly = false,
                    Message = new Message
                    {
                        Condition = "!('anytopicyoudontwanttouse' in topics)",
                        Notification = notification,
                        ApnsConfig = new ApnsConfig
                        {
                            Payload = new ApnsConfigPayload
                            {

                                Aps = new Aps
                                {
                                    Sound = "default",
                                }
                            }
                        }

                    }
                };

                // Finally send the Message and wait for the Result:
                CancellationTokenSource cts = new CancellationTokenSource();

                // Send the Message and wait synchronously:
                var result = client.SendAsync(message, cts.Token).GetAwaiter().GetResult();

                //// Print the Result to the Console:
                //Console.WriteLine("Data Message ID = {0}", result.Name);

                //Console.WriteLine("Press Enter to exit ...");
                //Console.ReadLine();
            }
        }
    }
}
