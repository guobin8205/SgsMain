using System;
using System.Text;
using Common.Extensions.SpanExt;

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
            sbyte len = buff.MoveReadSByte();

            Console.WriteLine(len);

            Console.WriteLine((Encoding.UTF8.GetString(buff.MoveReadBytes((int)len))));
            ReadRecord2(buff);
        }

        public static void ReadRecord2(ReadOnlySpan<byte> buff)
        {

            sbyte len = buff.MoveReadSByte();

            Console.WriteLine(len);

            Console.WriteLine((Encoding.UTF8.GetString(buff.MoveReadBytes((int)len))));
        }

        public static void Write()
        {
            var mem = new byte[1000];
            Span<byte> buff = new Span<byte>(mem);
            buff.MoveWrite(13);
            buff.MoveWrite(12);
            buff.MoveWrite(11);
            Console.WriteLine(Encoding.UTF8.GetString(buff.ToArray()));
        }
    }
}

