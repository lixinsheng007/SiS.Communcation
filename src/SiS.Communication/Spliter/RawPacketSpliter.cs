﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SiS.Communication.Spliter
{
    /// <summary>
    /// Represents an object that implements interface of IPacketSpliter, 
    /// which transmit all data with doing nothing.
    /// |  Raw Data Stream |
    /// </summary>
    public class RawPacketSpliter : IPacketSpliter
    {
        /// <summary>
        /// The static default instance of SiS.Communication.Spliter.RawPacketSpliter
        /// </summary>
        public static RawPacketSpliter Default { get; private set; } = new RawPacketSpliter();

        #region Public Functions

        /// <summary>
        /// Get packets from a buffer directly.
        /// </summary>
        /// <param name="streamBuffer">The source buffer to create packets.</param>
        /// <param name="offset">The starting offset of the buffer to create packets.</param>
        /// <param name="count">The count of the data to create packets.</param>
        /// <param name="endPos">When this method returns, contains the buffer ending position.</param>
        /// <returns>The packets list that contains input buffer.</returns>
        public List<ArraySegment<byte>> GetPackets(byte[] streamBuffer, int offset, int count, out int endPos)
        {
            endPos = Math.Min(streamBuffer.Length, offset + count);
            return new List<ArraySegment<byte>>() { new ArraySegment<byte>(streamBuffer, offset, count) };
        }

        /// <summary>
        /// Make a message into packet with doing nothing.
        /// </summary>
        /// <param name="messageData">The message data to convert.</param>
        /// <param name="offset">The offset of the message data.</param>
        /// <param name="count">The count of bytes to convert.</param>
        /// <returns>The same packet data as input.</returns>
        public byte[] MakePacket(byte[] messageData, int offset, int count)
        {
            if (offset == 0 && count == messageData.Length)
            {
                return messageData;
            }
            return new ArraySegment<byte>(messageData, offset, count).ToArray();
        }

        #endregion
    }
}
