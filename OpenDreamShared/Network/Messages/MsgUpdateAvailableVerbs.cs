using System;
using System.Collections.Generic;
using Lidgren.Network;
using Robust.Shared.Network;

namespace OpenDreamShared.Network.Messages
{
    public sealed class MsgUpdateAvailableVerbs : NetMessage
    {
        public override MsgGroups MsgGroup => MsgGroups.EntityEvent;

        public (string, string, string)[] AvailableVerbs;

        public override void ReadFromBuffer(NetIncomingMessage buffer)
        {
            var count = buffer.ReadVariableInt32();
            (string, string, string)[] verbs = new (string, string, string)[count];

            for (var i = 0; i < count; i++)
            {
                verbs[i] = (buffer.ReadString(), buffer.ReadString(), buffer.ReadString());
            }

            AvailableVerbs = verbs;
        }

        public override void WriteToBuffer(NetOutgoingMessage buffer)
        {
            buffer.WriteVariableInt32(AvailableVerbs.Length);

            foreach (var verb in AvailableVerbs)
            {
                buffer.Write(verb.Item1);
                buffer.Write(verb.Item2);
                buffer.Write(verb.Item3);
            }
        }
    }
}
