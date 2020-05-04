using Akka.Actor;
using Akka.Streams;
using AkkaStreams.Common.Helpers;
using AkkaStreams.Common.Messages;
using AkkaStreams.Origin.Actors;
using AkkaStreams.Origin.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Origin
{
    class Program
    {
        static void Main(string[] args)
        {
            ColourConsole.WriteLineYellow("Creating DataSourceActorSystem");
            ActorSystem system = ActorSystem.Create("DataSourceActorSystem");

            ColourConsole.WriteLineYellow("Creating DataSourceActor");
            IActorRef sourceActor = system.ActorOf(Props.Create<DataSource>(), "DataSourceActor");


            ActorMaterializer materializer = system.Materializer();

            using (system)
            {
                using (materializer)
                {
                    LogsOffer offer = sourceActor.Ask<LogsOffer>(new RequestLogs(1337)).Result;
                }
            }

            Console.ReadLine();
        }
    }
}
