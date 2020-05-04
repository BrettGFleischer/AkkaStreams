using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Origin.Messages
{
    public sealed class RequestLogs
    {
        public int StreamId { get; }

        public RequestLogs(int streamId)
        {
            StreamId = streamId;
        }
    }
}
