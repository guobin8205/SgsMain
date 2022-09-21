using System;
using System.Text;
using Common.Extensions.SpanExt;
using SgsCore.Managers.Record;
using SgsCore.Network.ProtocolsNew;

namespace SgsCore.Managers
{
    public static class RecordMgr
    {
        public static async ValueTask<ReadOnlyMemory<byte>> LoadFileAsync(string filename)
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
            recordData.Decode(ref buff);
        }

        public static void Write()
        {
            var mem = new byte[1000];
            Span<byte> buff = new Span<byte>(mem);
            ProtocolHeader h1 = new ProtocolHeader();
            h1.id = 333;
            h1.size = 444;
            h1.userId = 300;
            buff.MoveWrite<ProtocolHeader>(h1);
            Span<byte> buffData = new Span<byte>(mem, 0, mem.Length - buff.ToArray().Length);
            var head = buffData.MoveReadStruct<ProtocolHeader>();
            Console.WriteLine(buffData.Length);
            Console.WriteLine(Encoding.UTF8.GetString(buffData.ToArray()));
        }
    }
}

