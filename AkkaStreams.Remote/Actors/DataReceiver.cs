using Akka.Actor;
using Akka.Streams;
using Akka.Streams.Dsl;
using AkkaStreams.Common.Helpers;
using AkkaStreams.Common.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Remote.Actors
{
    public class DataReceiver : ReceiveActor
    {
        public static IActorRef DataSourceActorRef { get; set; }
        public DataReceiver()
        {
            TimeSpan throttle = TimeSpan.FromMilliseconds(100);

            Receive<ConnectMessage>(request =>
            {
                ColourConsole.WriteLineMagenta("Received ConnectMessage");
                DataSourceActorRef = Sender;
                request.ActorRef = Self;
                Sender.Tell(request);

            });

            Receive<LogsOffer>(request =>
            {
                ColourConsole.WriteLineMagenta("Received LogsOffer");

                request.SourceRef.Source
                //Throttle outbound stream
                .Throttle(1, throttle, 1, ThrottleMode.Shaping)
                //State what the sink must do
                .RunForeach(Console.WriteLine, Context.System.Materializer()).Wait();
                Sender.Tell(request);
            });
        }
    }
}
