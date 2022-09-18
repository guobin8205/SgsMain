using System;
using System.Runtime.CompilerServices;

namespace Common.Extensions.SpanExt
{
    public static partial class SpanUtilsExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(this Span<byte> span, out int length) => SpanUtils.ReadSByte(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadSByte(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(this Span<byte> span) => SpanUtils.ReadSByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte ReadSByte(this ReadOnlySpan<byte> span) => SpanUtils.ReadSByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(this Span<byte> span, out int length) => SpanUtils.ReadByte(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadByte(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(this Span<byte> span) => SpanUtils.ReadByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte ReadByte(this ReadOnlySpan<byte> span) => SpanUtils.ReadByte(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(this Span<byte> span, out int length) => SpanUtils.ReadUInt16(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadUInt16(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(this Span<byte> span) => SpanUtils.ReadUInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUInt16(this ReadOnlySpan<byte> span) => SpanUtils.ReadUInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(this Span<byte> span, out int length) => SpanUtils.ReadInt16(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadInt16(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(this Span<byte> span) => SpanUtils.ReadInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadInt16(this ReadOnlySpan<byte> span) => SpanUtils.ReadInt16(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(this Span<byte> span, out int length) => SpanUtils.ReadUInt32(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadUInt32(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(this Span<byte> span) => SpanUtils.ReadUInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt32(this ReadOnlySpan<byte> span) => SpanUtils.ReadUInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(this Span<byte> span, out int length) => SpanUtils.ReadInt32(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadInt32(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(this Span<byte> span) => SpanUtils.ReadInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt32(this ReadOnlySpan<byte> span) => SpanUtils.ReadInt32(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(this Span<byte> span, out int length) => SpanUtils.ReadUInt64(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadUInt64(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(this Span<byte> span) => SpanUtils.ReadUInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadUInt64(this ReadOnlySpan<byte> span) => SpanUtils.ReadUInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(this Span<byte> span, out int length) => SpanUtils.ReadInt64(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadInt64(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(this Span<byte> span) => SpanUtils.ReadInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadInt64(this ReadOnlySpan<byte> span) => SpanUtils.ReadInt64(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(this Span<byte> span, out int length) => SpanUtils.ReadSingle(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadSingle(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(this Span<byte> span) => SpanUtils.ReadSingle(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadSingle(this ReadOnlySpan<byte> span) => SpanUtils.ReadSingle(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(this Span<byte> span, out int length) => SpanUtils.ReadDouble(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadDouble(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(this Span<byte> span) => SpanUtils.ReadDouble(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double ReadDouble(this ReadOnlySpan<byte> span) => SpanUtils.ReadDouble(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(this Span<byte> span, out int length) => SpanUtils.ReadDecimal(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadDecimal(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(this Span<byte> span) => SpanUtils.ReadDecimal(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal ReadDecimal(this ReadOnlySpan<byte> span) => SpanUtils.ReadDecimal(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(this Span<byte> span, out int length) => SpanUtils.ReadBoolean(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadBoolean(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(this Span<byte> span) => SpanUtils.ReadBoolean(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBoolean(this ReadOnlySpan<byte> span) => SpanUtils.ReadBoolean(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(this Span<byte> span, out int length) => SpanUtils.ReadChar(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadChar(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(this Span<byte> span) => SpanUtils.ReadChar(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char ReadChar(this ReadOnlySpan<byte> span) => SpanUtils.ReadChar(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(this Span<byte> span, out int length) => SpanUtils.ReadFloat(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadFloat(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(this Span<byte> span) => SpanUtils.ReadFloat(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single ReadFloat(this ReadOnlySpan<byte> span) => SpanUtils.ReadFloat(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(this Span<byte> span, out int length) => SpanUtils.ReadShort(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadShort(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(this Span<byte> span) => SpanUtils.ReadShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 ReadShort(this ReadOnlySpan<byte> span) => SpanUtils.ReadShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(this Span<byte> span, out int length) => SpanUtils.ReadUShort(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadUShort(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(this Span<byte> span) => SpanUtils.ReadUShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 ReadUShort(this ReadOnlySpan<byte> span) => SpanUtils.ReadUShort(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(this Span<byte> span, out int length) => SpanUtils.ReadInt(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadInt(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(this Span<byte> span) => SpanUtils.ReadInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 ReadInt(this ReadOnlySpan<byte> span) => SpanUtils.ReadInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(this Span<byte> span, out int length) => SpanUtils.ReadUInt(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadUInt(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(this Span<byte> span) => SpanUtils.ReadUInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 ReadUInt(this ReadOnlySpan<byte> span) => SpanUtils.ReadUInt(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(this Span<byte> span, out int length) => SpanUtils.ReadLong(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadLong(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(this Span<byte> span) => SpanUtils.ReadLong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 ReadLong(this ReadOnlySpan<byte> span) => SpanUtils.ReadLong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(this Span<byte> span, out int length) => SpanUtils.ReadULong(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadULong(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(this Span<byte> span) => SpanUtils.ReadULong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 ReadULong(this ReadOnlySpan<byte> span) => SpanUtils.ReadULong(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(this Span<byte> span, out int length) => SpanUtils.ReadBool(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(this ReadOnlySpan<byte> span, out int length) => SpanUtils.ReadBool(span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(this Span<byte> span) => SpanUtils.ReadBool(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean ReadBool(this ReadOnlySpan<byte> span) => SpanUtils.ReadBool(span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] ReadBytes(this Span<byte> span, int length) => SpanUtils.ReadBytes(span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] ReadBytes(this ReadOnlySpan<byte> span, int length) => SpanUtils.ReadBytes(span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Span<byte> ReadSpan(this Span<byte> span, int length) => SpanUtils.ReadSpan(span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> ReadReadOnlySpan(this Span<byte> span, int length) => SpanUtils.ReadReadOnlySpan(span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> ReadReadOnlySpan(this ReadOnlySpan<byte> span, int length) => SpanUtils.ReadReadOnlySpan(span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Move(ref this Span<byte> span, int length) => span = span.Slice(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Move(ref this ReadOnlySpan<byte> span, int length) => span = span.Slice(length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref this Span<byte> span, out int length) => SpanUtils.MoveReadSByte(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadSByte(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref this Span<byte> span) => SpanUtils.MoveReadSByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe SByte MoveReadSByte(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadSByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref this Span<byte> span, out int length) => SpanUtils.MoveReadByte(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadByte(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref this Span<byte> span) => SpanUtils.MoveReadByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte MoveReadByte(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadByte(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref this Span<byte> span, out int length) => SpanUtils.MoveReadUInt16(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadUInt16(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref this Span<byte> span) => SpanUtils.MoveReadUInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUInt16(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref this Span<byte> span, out int length) => SpanUtils.MoveReadInt16(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadInt16(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref this Span<byte> span) => SpanUtils.MoveReadInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadInt16(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt16(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref this Span<byte> span, out int length) => SpanUtils.MoveReadUInt32(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadUInt32(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref this Span<byte> span) => SpanUtils.MoveReadUInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt32(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref this Span<byte> span, out int length) => SpanUtils.MoveReadInt32(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadInt32(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref this Span<byte> span) => SpanUtils.MoveReadInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt32(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt32(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref this Span<byte> span, out int length) => SpanUtils.MoveReadUInt64(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadUInt64(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref this Span<byte> span) => SpanUtils.MoveReadUInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadUInt64(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref this Span<byte> span, out int length) => SpanUtils.MoveReadInt64(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadInt64(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref this Span<byte> span) => SpanUtils.MoveReadInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadInt64(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt64(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref this Span<byte> span, out int length) => SpanUtils.MoveReadSingle(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadSingle(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref this Span<byte> span) => SpanUtils.MoveReadSingle(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadSingle(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadSingle(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref this Span<byte> span, out int length) => SpanUtils.MoveReadDouble(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadDouble(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref this Span<byte> span) => SpanUtils.MoveReadDouble(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Double MoveReadDouble(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadDouble(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref this Span<byte> span, out int length) => SpanUtils.MoveReadDecimal(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadDecimal(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref this Span<byte> span) => SpanUtils.MoveReadDecimal(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Decimal MoveReadDecimal(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadDecimal(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref this Span<byte> span, out int length) => SpanUtils.MoveReadBoolean(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadBoolean(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref this Span<byte> span) => SpanUtils.MoveReadBoolean(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBoolean(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadBoolean(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref this Span<byte> span, out int length) => SpanUtils.MoveReadChar(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadChar(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref this Span<byte> span) => SpanUtils.MoveReadChar(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Char MoveReadChar(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadChar(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref this Span<byte> span, out int length) => SpanUtils.MoveReadFloat(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadFloat(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref this Span<byte> span) => SpanUtils.MoveReadFloat(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Single MoveReadFloat(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadFloat(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref this Span<byte> span, out int length) => SpanUtils.MoveReadShort(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadShort(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref this Span<byte> span) => SpanUtils.MoveReadShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int16 MoveReadShort(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref this Span<byte> span, out int length) => SpanUtils.MoveReadUShort(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadUShort(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref this Span<byte> span) => SpanUtils.MoveReadUShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 MoveReadUShort(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadUShort(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref this Span<byte> span, out int length) => SpanUtils.MoveReadInt(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadInt(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref this Span<byte> span) => SpanUtils.MoveReadInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int32 MoveReadInt(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref this Span<byte> span, out int length) => SpanUtils.MoveReadUInt(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadUInt(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref this Span<byte> span) => SpanUtils.MoveReadUInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 MoveReadUInt(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadUInt(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref this Span<byte> span, out int length) => SpanUtils.MoveReadLong(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadLong(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref this Span<byte> span) => SpanUtils.MoveReadLong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Int64 MoveReadLong(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadLong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref this Span<byte> span, out int length) => SpanUtils.MoveReadULong(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadULong(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref this Span<byte> span) => SpanUtils.MoveReadULong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt64 MoveReadULong(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadULong(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref this Span<byte> span, out int length) => SpanUtils.MoveReadBool(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref this ReadOnlySpan<byte> span, out int length) => SpanUtils.MoveReadBool(ref span, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref this Span<byte> span) => SpanUtils.MoveReadBool(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Boolean MoveReadBool(ref this ReadOnlySpan<byte> span) => SpanUtils.MoveReadBool(ref span, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] MoveReadBytes(ref this Span<byte> span, int length) => SpanUtils.MoveReadBytes(ref span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte[] MoveReadBytes(ref this ReadOnlySpan<byte> span, int length) => SpanUtils.MoveReadBytes(ref span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Span<byte> MoveReadSpan(ref this Span<byte> span, int length) => SpanUtils.MoveReadSpan(ref span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> MoveReadReadOnlySpan(ref this Span<byte> span, int length) => SpanUtils.MoveReadReadOnlySpan(ref span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlySpan<byte> MoveReadReadOnlySpan(ref this ReadOnlySpan<byte> span, int length) => SpanUtils.MoveReadReadOnlySpan(ref span, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, SByte value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, SByte value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Byte value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Byte value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, UInt16 value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, UInt16 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Int16 value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Int16 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, UInt32 value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, UInt32 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Int32 value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Int32 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, UInt64 value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, UInt64 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Int64 value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Int64 value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Single value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Single value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Double value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Double value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Decimal value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Decimal value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Boolean value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Boolean value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Char value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Char value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Byte[] value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Byte[] value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Span<byte> value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, Span<byte> value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, ReadOnlySpan<byte> value, out int length) => SpanUtils.Write(span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write(this Span<byte> span, ReadOnlySpan<byte> value) => SpanUtils.Write(span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, SByte value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, SByte value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Byte value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Byte value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, UInt16 value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, UInt16 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Int16 value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Int16 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, UInt32 value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, UInt32 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Int32 value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Int32 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, UInt64 value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, UInt64 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Int64 value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Int64 value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Single value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Single value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Double value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Double value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Decimal value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Decimal value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Boolean value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Boolean value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Char value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Char value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Byte[] value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Byte[] value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Span<byte> value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, Span<byte> value) => SpanUtils.MoveWrite(ref span, value, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, ReadOnlySpan<byte> value, out int length) => SpanUtils.MoveWrite(ref span, value, out length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void MoveWrite(ref this Span<byte> span, ReadOnlySpan<byte> value) => SpanUtils.MoveWrite(ref span, value, out _);
    }
}

