using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Common.Messages
{
    public class ConnectMessage
    {
        public IActorRef ActorRef { get; set; }
        public ConnectMessage(IActorRef actorRef = null)
        {
            ActorRef = actorRef;
        }
    }
}
