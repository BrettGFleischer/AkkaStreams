using Akka;
using Akka.Actor;
using Akka.Streams;
using Akka.Streams.Dsl;
using AkkaStreams.Common.Helpers;
using AkkaStreams.Common.Messages;
using AkkaStreams.Origin.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Origin.Actors
{
    public class DataSource : ReceiveActor
    {
        public static IActorRef DataReceiverActorRef { get; set; }

        private static readonly string serverURL = ConfigurationManager.AppSettings.Get("ServerUrl");
        private readonly string serverPort = ConfigurationManager.AppSettings.Get("ServerPort");
        public DataSource()
        {
            TimeSpan throttle = TimeSpan.FromMilliseconds(1);

            string RegistryConnectionString = "akka.tcp://ReceiverActorSystem@" + serverURL + ":" + serverPort + "/user/DataReceiverActor";

            ColourConsole.WriteLineMagenta("Sending ConnectMessage");
            ConnectMessage requestAccess = Context.ActorSelection(RegistryConnectionString).Ask<ConnectMessage>(new ConnectMessage(Self)).Result;//Changes

            DataReceiverActorRef = requestAccess.ActorRef;
           
            Receive<RequestLogs>(request =>
            {
                ColourConsole.WriteLineMagenta("Sending RequestLogs");
                // create a source
                StreamLogs(request.StreamId)
                    //Throttle outbound stream
                    .Throttle(1, throttle, 1, ThrottleMode.Shaping)
                    // materialize it using stream refs
                    .RunWith(StreamRefs.SourceRef<string>(), Context.System.Materializer())
                    // and send to sink
                    .PipeTo(DataReceiverActorRef, success: sourceRef => new LogsOffer(request.StreamId, sourceRef));//DataReceiverActorRef was Sender
            });
        }

        private Source<string, NotUsed> StreamLogs(int streamId) =>
            Source.From(Enumerable.Range(1, 100)).Select(i => i.ToString());
    }
}
