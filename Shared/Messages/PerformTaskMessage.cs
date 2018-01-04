using System;

namespace Shared.Messages
{
    public class PerformTaskMessage
    {
        public TimeSpan Durration { get; }

        public PerformTaskMessage(TimeSpan durration)
        {
            Durration = durration;
        }
    }
}