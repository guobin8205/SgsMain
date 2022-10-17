using Common.Helpers;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Common.Extensions.SpanExt
{
    public static partial class SpanUtils
    {
        public static Encoding EncodingGBK;
        static SpanUtils()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            EncodingGBK = Encoding.GetEncoding("GB18030");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(Span<byte> span) => SpanUtils.ReadSByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(ReadOnlySpan<byte> span) => SpanUtils.ReadSByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(Span<byte> span, out int length)
        {
            var ret = (SByte)span[0];
            length = sizeof(SByte);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(ReadOnlySpan<byte> span, out int length)
        {
            var ret = (SByte)span[0];
            length = sizeof(SByte);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(Span<byte> span) => SpanUtils.ReadByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(ReadOnlySpan<byte> span) => SpanUtils.ReadByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(Span<byte> span, out int length)
        {
            var ret = span[0];
            length = sizeof(Byte);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(ReadOnlySpan<byte> span, out int length)
        {
            var ret = span[0];
            length = sizeof(Byte);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(Span<byte> span) => SpanUtils.ReadUInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(ReadOnlySpan<byte> span) => SpanUtils.ReadUInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(Span<byte> span) => SpanUtils.ReadInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(ReadOnlySpan<byte> span) => SpanUtils.ReadInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(Span<byte> span) => SpanUtils.ReadUInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(ReadOnlySpan<byte> span) => SpanUtils.ReadUInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(Span<byte> span) => SpanUtils.ReadInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(ReadOnlySpan<byte> span) => SpanUtils.ReadInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);

            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(Span<byte> span) => SpanUtils.ReadUInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(ReadOnlySpan<byte> span) => SpanUtils.ReadUInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(Span<byte> span) => SpanUtils.ReadInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(ReadOnlySpan<byte> span) => SpanUtils.ReadInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(Span<byte> span) => SpanUtils.ReadSingle(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(ReadOnlySpan<byte> span) => SpanUtils.ReadSingle(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(Span<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(ReadOnlySpan<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(Span<byte> span) => SpanUtils.ReadDouble(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(ReadOnlySpan<byte> span) => SpanUtils.ReadDouble(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(Span<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverter.Int64BitsToDouble(SpanUtils.ReadInt64(span, out _));
#else
            var i = SpanUtils.ReadInt64(span, out _);
            var r = *(double*)(&i);
#endif
            length = sizeof(Double);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(ReadOnlySpan<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverter.Int64BitsToDouble(SpanUtils.ReadInt64(span, out _));
#else
            var i = SpanUtils.ReadInt64(span, out _);
            var r = *(double*)(&i);
#endif
            length = sizeof(Double);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(Span<byte> span) => SpanUtils.ReadDecimal(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(ReadOnlySpan<byte> span) => SpanUtils.ReadDecimal(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(Span<byte> span, out int length)
        {
            Span<decimal> a = stackalloc decimal[1];
            var ab = MemoryMarshal.Cast<decimal, byte>(a);
            span.Slice(0, sizeof(decimal)).CopyTo(ab);
            length = sizeof(Decimal);
            return a[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(ReadOnlySpan<byte> span, out int length)
        {
            Span<decimal> a = stackalloc decimal[1];
            var ab = MemoryMarshal.Cast<decimal, byte>(a);
            span.Slice(0, sizeof(decimal)).CopyTo(ab);
            length = sizeof(Decimal);
            return a[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(Span<byte> span) => SpanUtils.ReadBoolean(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(ReadOnlySpan<byte> span) => SpanUtils.ReadBoolean(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(Span<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(ReadOnlySpan<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(Span<byte> span) => SpanUtils.ReadChar(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(ReadOnlySpan<byte> span) => SpanUtils.ReadChar(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(Span<byte> span, out int length)
        {
            var r = MemoryMarshal.Read<Char>(span);
            length = sizeof(Char);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(ReadOnlySpan<byte> span, out int length)
        {
            var r = MemoryMarshal.Read<Char>(span);
            length = sizeof(Char);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(Span<byte> span) => SpanUtils.ReadFloat(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(ReadOnlySpan<byte> span) => SpanUtils.ReadFloat(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(Span<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(ReadOnlySpan<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(Span<byte> span) => SpanUtils.ReadShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(ReadOnlySpan<byte> span) => SpanUtils.ReadShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(Span<byte> span) => SpanUtils.ReadUShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(ReadOnlySpan<byte> span) => SpanUtils.ReadUShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(Span<byte> span) => SpanUtils.ReadInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(ReadOnlySpan<byte> span) => SpanUtils.ReadInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(Span<byte> span) => SpanUtils.ReadUInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(ReadOnlySpan<byte> span) => SpanUtils.ReadUInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(Span<byte> span) => SpanUtils.ReadLong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(ReadOnlySpan<byte> span) => SpanUtils.ReadLong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(Span<byte> span) => SpanUtils.ReadULong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(ReadOnlySpan<byte> span) => SpanUtils.ReadULong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);

            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);

            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(Span<byte> span) => SpanUtils.ReadBool(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(ReadOnlySpan<byte> span) => SpanUtils.ReadBool(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(Span<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);

            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(ReadOnlySpan<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);

            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] ReadBytes(Span<byte> span, int length)
        {
            var ret = span.Slice(0, length).ToArray();
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] ReadBytes(ReadOnlySpan<byte> span, int length)
        {
            var ret = span.Slice(0, length).ToArray();
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Span<byte> ReadSpan(Span<byte> span, int length)
        {
            var ret = span.Slice(0, length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> ReadReadOnlySpan(Span<byte> span, int length)
        {
            var ret = span.Slice(0, length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> ReadReadOnlySpan(ReadOnlySpan<byte> span, int length)
        {
            var ret = span.Slice(0, length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Move(ref Span<byte> span, int length) => span = span.Slice(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Move(ref ReadOnlySpan<byte> span, int length) => span = span.Slice(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref Span<byte> span) => SpanUtils.MoveReadSByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadSByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref Span<byte> span, out int length)
        {
            var ret = (SByte)span[0];
            length = sizeof(SByte);
            span = span.Slice(sizeof(SByte));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = (SByte)span[0];
            length = sizeof(SByte);
            span = span.Slice(sizeof(SByte));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref Span<byte> span) => SpanUtils.MoveReadByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref Span<byte> span, out int length)
        {
            var ret = span[0];
            length = sizeof(Byte);
            span = span.Slice(sizeof(Byte));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = span[0];
            length = sizeof(Byte);
            span = span.Slice(sizeof(Byte));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref Span<byte> span) => SpanUtils.MoveReadUInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            span = span.Slice(sizeof(UInt16));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            span = span.Slice(sizeof(UInt16));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref Span<byte> span) => SpanUtils.MoveReadInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            span = span.Slice(sizeof(Int16));
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            span = span.Slice(sizeof(Int16));
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref Span<byte> span) => SpanUtils.MoveReadUInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            span = span.Slice(sizeof(UInt32));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            span = span.Slice(sizeof(UInt32));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref Span<byte> span) => SpanUtils.MoveReadInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            span = span.Slice(sizeof(Int32));
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            span = span.Slice(sizeof(Int32));
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref Span<byte> span) => SpanUtils.MoveReadUInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);
            span = span.Slice(sizeof(UInt64));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);
            span = span.Slice(sizeof(UInt64));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref Span<byte> span) => SpanUtils.MoveReadInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            span = span.Slice(sizeof(Int64));
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            span = span.Slice(sizeof(Int64));
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref Span<byte> span) => SpanUtils.MoveReadSingle(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadSingle(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref Span<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            span = span.Slice(sizeof(Single));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref ReadOnlySpan<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            span = span.Slice(sizeof(Single));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref Span<byte> span) => SpanUtils.MoveReadDouble(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadDouble(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref Span<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverter.Int64BitsToDouble(SpanUtils.ReadInt64(span, out _));
#else
            var i = SpanUtils.ReadInt64(span, out _);
            var r = *(double*)(&i);
#endif
            length = sizeof(Double);
            span = span.Slice(sizeof(Double));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref ReadOnlySpan<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverter.Int64BitsToDouble(SpanUtils.ReadInt64(span, out _));
#else
            //Span<double> a = stackalloc double[1];
            //var ab = MemoryMarshal.Cast<double, byte>(a);
            //span.Slice(0, sizeof(double)).CopyTo(ab);
            //var r = a[0];
            var i = SpanUtils.ReadInt64(span, out _);
            var r = *(double*)(&i);
#endif
            length = sizeof(Double);
            span = span.Slice(sizeof(Double));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref Span<byte> span) => SpanUtils.MoveReadDecimal(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadDecimal(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref Span<byte> span, out int length)
        {
            Span<decimal> a = stackalloc decimal[1];
            var ab = MemoryMarshal.Cast<decimal, byte>(a);
            span.Slice(0, sizeof(decimal)).CopyTo(ab);
            length = sizeof(Decimal);
            span = span.Slice(sizeof(Decimal));
            return a[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref ReadOnlySpan<byte> span, out int length)
        {
            Span<decimal> a = stackalloc decimal[1];
            var ab = MemoryMarshal.Cast<decimal, byte>(a);
            span.Slice(0, sizeof(decimal)).CopyTo(ab);
            length = sizeof(Decimal);
            span = span.Slice(sizeof(Decimal));
            return a[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref Span<byte> span) => SpanUtils.MoveReadBoolean(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadBoolean(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref Span<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);
            span = span.Slice(sizeof(Boolean));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);
            span = span.Slice(sizeof(Boolean));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref Span<byte> span) => SpanUtils.MoveReadChar(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadChar(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref Span<byte> span, out int length)
        {
            var r = MemoryMarshal.Read<Char>(span);
            length = sizeof(Char);
            span = span.Slice(sizeof(Char));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref ReadOnlySpan<byte> span, out int length)
        {
            var r = MemoryMarshal.Read<Char>(span);
            length = sizeof(Char);
            span = span.Slice(sizeof(Char));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref Span<byte> span) => SpanUtils.MoveReadFloat(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadFloat(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref Span<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            span = span.Slice(sizeof(Single));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref ReadOnlySpan<byte> span, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            var r = BitConverterHelper.Int32BitsToSingle(SpanUtils.ReadInt32(span, out _));
#else
            var i = SpanUtils.ReadInt32(span, out _);
            var r = *(float*)(&i);
#endif
            length = sizeof(Single);
            span = span.Slice(sizeof(Single));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref Span<byte> span) => SpanUtils.MoveReadShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            span = span.Slice(sizeof(Int16));
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int16);
            span = span.Slice(sizeof(Int16));
            return (Int16)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref Span<byte> span) => SpanUtils.MoveReadUShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadUShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            span = span.Slice(sizeof(UInt16));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt16>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt16);
            span = span.Slice(sizeof(UInt16));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref Span<byte> span) => SpanUtils.MoveReadInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            span = span.Slice(sizeof(Int32));
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int32);
            span = span.Slice(sizeof(Int32));
            return (Int32)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref Span<byte> span) => SpanUtils.MoveReadUInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            span = span.Slice(sizeof(UInt32));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt32>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt32);
            span = span.Slice(sizeof(UInt32));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref Span<byte> span) => SpanUtils.MoveReadLong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadLong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            span = span.Slice(sizeof(Int64));
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(Int64);
            span = span.Slice(sizeof(Int64));
            return (Int64)ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref Span<byte> span) => SpanUtils.MoveReadULong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadULong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref Span<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);
            span = span.Slice(sizeof(UInt64));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = Unsafe.ReadUnaligned<UInt64>(ref MemoryMarshal.GetReference(span));
            length = sizeof(UInt64);
            span = span.Slice(sizeof(UInt64));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref Span<byte> span) => SpanUtils.MoveReadBool(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref ReadOnlySpan<byte> span) => SpanUtils.MoveReadBool(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref Span<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);
            span = span.Slice(sizeof(Boolean));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref ReadOnlySpan<byte> span, out int length)
        {
            var ret = span[0] != 0;
            length = sizeof(Boolean);
            span = span.Slice(sizeof(Boolean));
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] MoveReadBytes(ref Span<byte> span, int length)
        {
            var ret = span.Slice(0, length).ToArray();

            span = span.Slice(length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] MoveReadBytes(ref ReadOnlySpan<byte> span, int length)
        {
            var ret = span.Slice(0, length).ToArray();

            span = span.Slice(length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Span<byte> MoveReadSpan(ref Span<byte> span, int length)
        {
            var ret = span.Slice(0, length);

            span = span.Slice(length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> MoveReadReadOnlySpan(ref Span<byte> span, int length)
        {
            var ret = span.Slice(0, length);
            span = span.Slice(length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> MoveReadReadOnlySpan(ref ReadOnlySpan<byte> span, int length)
        {
            var ret = span.Slice(0, length);
            span = span.Slice(length);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe string MoveReadString(ref Span<byte> span, int lensize, Encoding enc, out int length)
        {
            int datalen = 0;
            switch (lensize)
            {
                case 2:
                    datalen = (int)SpanUtils.MoveReadShort(ref span, out _);
                    length = 2 + datalen;
                    break;
                case 4:
                    datalen = (int)SpanUtils.MoveReadInt(ref span, out _);
                    length = 4 + datalen;
                    break;
                case 1:
                default:
                    datalen = (int)SpanUtils.MoveReadSByte(ref span, out _);
                    length = 1 + datalen;
                    break;
            }
            var ret = span.Slice(0, datalen).ToArray();
            span = span.Slice(length);
            return enc.GetString(ret);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe string MoveReadString(ref ReadOnlySpan<byte> span, int lensize, Encoding enc, out int length)
        {
            switch (lensize)
            {
                case 2:
                    length = (int)SpanUtils.MoveReadShort(ref span, out _);
                    break;
                case 4:
                    length = (int)SpanUtils.MoveReadInt(ref span, out _);
                    break;
                case 1:
                default:
                    length = (int)SpanUtils.MoveReadSByte(ref span, out _);
                    break;
            }
            var ret = span.Slice(0, length).ToArray();
            span = span.Slice(length);
            return enc.GetString(ret);
        }

        public static unsafe string MoveReadFixedString(ref ReadOnlySpan<byte> span, int length, Encoding enc)
        {
            var ret = span.Slice(0, length).ToArray();
            span = span.Slice(length);
            return enc.GetString(ret);
        }

        public static unsafe string MoveReadFixedString(ref Span<byte> span, int length, Encoding enc)
        {
            var ret = span.Slice(0, length).ToArray();
            span = span.Slice(length);
            //enc.GetString(ret);
            return "";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, SByte value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, SByte value, out int length)
        {
            span[0] = (byte)value;
            length = sizeof(SByte);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Byte value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Byte value, out int length)
        {
            span[0] = value;
            length = sizeof(Byte);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, UInt16 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, UInt16 value, out int length)
        {
            if (span.Length < sizeof(UInt16))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(UInt16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Int16 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Int16 value, out int length)
        {
            if (span.Length < sizeof(UInt16))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(Int16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, UInt32 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, UInt32 value, out int length)
        {
            if (span.Length < sizeof(UInt32))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(UInt32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Int32 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Int32 value, out int length)
        {
            if (span.Length < sizeof(UInt32))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(Int32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, UInt64 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, UInt64 value, out int length)
        {
            if (span.Length < sizeof(UInt64))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(UInt64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Int64 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Int64 value, out int length)
        {
            if (span.Length < sizeof(UInt64))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(Int64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Single value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Single value, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            SpanUtils.Write(span, BitConverterHelper.SingleToInt32Bits(value), out _);
#else
            var i = *(int*)(&value);
            SpanUtils.Write(span, i, out _);
#endif
            length = sizeof(Single);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Double value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Double value, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            SpanUtils.Write(span, BitConverter.DoubleToInt64Bits(value), out _);
#else
            var i = *(long*)(&value);
            SpanUtils.Write(span, i, out _);
#endif
            length = sizeof(Double);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Decimal value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Decimal value, out int length)
        {
            Span<decimal> a = stackalloc decimal[1] { value };
            var ab = MemoryMarshal.Cast<decimal, byte>(a);
            ab.CopyTo(span);
            length = sizeof(Decimal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Boolean value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Boolean value, out int length)
        {
            span[0] = (byte)(value ? 1 : 0);
            length = sizeof(Boolean);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Char value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Char value, out int length)
        {
            MemoryMarshal.Write(span, ref value);
            length = sizeof(Char);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Byte[] value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Byte[] value, out int length)
        {
            value.CopyTo(span);
            length = value.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Span<byte> value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, Span<byte> value, out int length)
        {
            value.CopyTo(span);
            length = value.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, ReadOnlySpan<byte> value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(Span<byte> span, ReadOnlySpan<byte> value, out int length)
        {
            value.CopyTo(span);
            length = value.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, SByte value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, SByte value, out int length)
        {
            span[0] = (byte)value;
            length = sizeof(SByte);
            span = span.Slice(sizeof(SByte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Byte value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Byte value, out int length)
        {
            span[0] = value;
            length = sizeof(Byte);
            span = span.Slice(sizeof(Byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, UInt16 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, UInt16 value, out int length)
        {
            if (span.Length < sizeof(UInt16))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(UInt16);
            span = span.Slice(sizeof(UInt16));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Int16 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Int16 value, out int length)
        {
            if (span.Length < sizeof(UInt16))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(Int16);
            span = span.Slice(sizeof(Int16));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, UInt32 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, UInt32 value, out int length)
        {
            if (span.Length < sizeof(UInt32))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(UInt32);
            span = span.Slice(sizeof(UInt32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Int32 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Int32 value, out int length)
        {
            if (span.Length < sizeof(UInt32))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(Int32);
            span = span.Slice(sizeof(Int32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, UInt64 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, UInt64 value, out int length)
        {
            if (span.Length < sizeof(UInt64))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(UInt64);
            span = span.Slice(sizeof(UInt64));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Int64 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Int64 value, out int length)
        {
            if (span.Length < sizeof(UInt64))
                throw new ArgumentOutOfRangeException();
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
            length = sizeof(Int64);
            span = span.Slice(sizeof(Int64));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Single value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Single value, out int length)
        {
            
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            SpanUtils.Write(span, BitConverterHelper.SingleToInt32Bits(value), out _);
#else
            var i = *(int*)(&value);
            SpanUtils.Write(span, i, out _);
#endif
            length = sizeof(Single);
            span = span.Slice(sizeof(Single));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Double value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Double value, out int length)
        {
#if NETSTANDARD21 || !BEFORENETCOREAPP3
            SpanUtils.Write(span, BitConverter.DoubleToInt64Bits(value), out _);
#else
            var i = *(long*)(&value);
            SpanUtils.Write(span, i, out _);
#endif
            length = sizeof(Double);
            span = span.Slice(sizeof(Double));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Decimal value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Decimal value, out int length)
        {
            Span<decimal> a = stackalloc decimal[1] { value };
            var ab = MemoryMarshal.Cast<decimal, byte>(a);
            ab.CopyTo(span);
            length = sizeof(Decimal);
            span = span.Slice(sizeof(Decimal));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Boolean value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Boolean value, out int length)
        {
            span[0] = (byte)(value ? 1 : 0);
            length = sizeof(Boolean);
            span = span.Slice(sizeof(Boolean));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Char value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Char value, out int length)
        {
            MemoryMarshal.Write(span, ref value);
            length = sizeof(Char);
            span = span.Slice(sizeof(Char));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Byte[] value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Byte[] value, out int length)
        {
            value.CopyTo(span);
            length = value.Length;

            span = span.Slice(length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Span<byte> value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, Span<byte> value, out int length)
        {
            value.CopyTo(span);
            length = value.Length;

            span = span.Slice(length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWriteFixString(ref Span<byte> span, in string value, int length, Encoding enc)
        {
            Span<byte> buffer = stackalloc byte[length];
            buffer.Write(enc.GetBytes(value));
            span = span.Slice(length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, ReadOnlySpan<byte> value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref Span<byte> span, ReadOnlySpan<byte> value, out int length)
        {
            value.CopyTo(span);
            length = value.Length;

            span = span.Slice(length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T MoveReadStruct<T>(ref Span<byte> span) where T : struct => SpanUtils.MoveReadStruct<T>(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T MoveReadStruct<T>(ref Span<byte> span, out int length) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            length = size;
            if (span.Length < size)
            {
                return default(T);
            }
            var obj = MemoryMarshal.Read<T>(span);
            span = span.Slice(length);
            return obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T MoveReadStruct<T>(ref ReadOnlySpan<byte> span) where T : struct => SpanUtils.MoveReadStruct<T>(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T MoveReadStruct<T>(ref ReadOnlySpan<byte> span, out int length) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            length = size;
            if (span.Length < size)
            {
                return default(T);
            }
            var obj = MemoryMarshal.Read<T>(span);
            span = span.Slice(length);
            return obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite<T>(ref Span<byte> span, T obj) where T : struct => SpanUtils.MoveWrite(ref span, obj, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite<T>(ref Span<byte> span, T obj, out int length) where T : struct
        {
            T value = (T)obj;
            length = Marshal.SizeOf<T>();
            MemoryMarshal.Write<T>(span, ref value);
            span = span.Slice(length);
        }
    }
}

