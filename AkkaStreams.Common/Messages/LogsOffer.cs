using Akka.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Common.Messages
{
    public sealed class LogsOffer
    {
        public int StreamId { get; }
        public ISourceRef<string> SourceRef { get; }

        public LogsOffer(int streamId, ISourceRef<string> sourceRef)
        {
            StreamId = streamId;
            SourceRef = sourceRef;
        }
    }
}
