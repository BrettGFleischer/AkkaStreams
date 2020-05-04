using Akka.Actor;
using AkkaStreams.Common.Helpers;
using AkkaStreams.Remote.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Remote
{
    class Program
    {
        static void Main(string[] args)
        {
            ColourConsole.WriteLineYellow("Creating ReceiverActorSystem");
            ActorSystem system = ActorSystem.Create("ReceiverActorSystem");

            ColourConsole.WriteLineYellow("Creating DataReceiverActor");
            IActorRef receiver = system.ActorOf(Props.Create<DataReceiver>(), "DataReceiverActor");

            Console.ReadLine();
        }
    }
}
