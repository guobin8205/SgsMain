using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions.SpanExt;
using SgsCore.Managers.Record;
using SgsCore.Network.ProtocolsNew;

namespace SgsCore.Managers
{
    public static class RecordMgr
    {
        public static async Task<ReadOnlyMemory<byte>> LoadFileAsync(string filename)
        {
            byte[] buffer;
            using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                {
                buffer = new byte[SourceStream.Length];
                int bytesRead = await SourceStream.ReadAsync(buffer,0,buffer.Length);
            }
            return new ReadOnlyMemory<byte>(buffer);
        }

        public static void ReadRecord(ReadOnlySpan<byte> buff)
        {
            RecordData recordData = new RecordData();
            recordData.Decode(buff);
        }
    }
}

