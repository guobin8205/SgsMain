using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    internal class BitConverterHelper
    {
        [SecuritySafeCritical]
        public static unsafe int SingleToInt32Bits(float value)
        {
            return *(int*)(&value);
        }

        [SecuritySafeCritical]
        public static unsafe float Int32BitsToSingle(int value)
        {
            return *(float*)(&value);
        }


    }

    public static class FastBitConverter
    {
#if ( NETCOREAPP3_1 || NET5_0 || NETCOREAPP3_0_OR_GREATER) && !BIGENDIAN
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void GetBytes<T>(byte[] bytes, int startIndex, T value) where T : unmanaged
        {
            int size = sizeof(T);
            if (bytes.Length < startIndex + size)
                ThrowIndexOutOfRangeException();
#if LITENETLIB_UNSAFELIB || NETCOREAPP3_1 || NET5_0 || NETCOREAPP3_0_OR_GREATER
            Unsafe.As<byte, T>(ref bytes[startIndex]) = value;
#else
            fixed (byte* ptr = &bytes[startIndex])
            {
#if UNITY_ANDROID
                T* valueBuffer = stackalloc T[1] { value };
                UnsafeUtility.MemCpy(ptr, valueBuffer, size);
#else
                *(T*)ptr = value;
#endif
            }
#endif
        }

        private static void ThrowIndexOutOfRangeException() => throw new IndexOutOfRangeException();
#else
        [StructLayout(LayoutKind.Explicit)]
        private struct ConverterHelperDouble
        {
            [FieldOffset(0)]
            public ulong Along;

            [FieldOffset(0)]
            public double Adouble;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct ConverterHelperFloat
        {
            [FieldOffset(0)]
            public int Aint;

            [FieldOffset(0)]
            public float Afloat;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteLittleEndian(byte[] buffer, int offset, ulong data)
        {
#if BIGENDIAN
            buffer[offset + 7] = (byte)(data);
            buffer[offset + 6] = (byte)(data >> 8);
            buffer[offset + 5] = (byte)(data >> 16);
            buffer[offset + 4] = (byte)(data >> 24);
            buffer[offset + 3] = (byte)(data >> 32);
            buffer[offset + 2] = (byte)(data >> 40);
            buffer[offset + 1] = (byte)(data >> 48);
            buffer[offset    ] = (byte)(data >> 56);
#else
            buffer[offset] = (byte)(data);
            buffer[offset + 1] = (byte)(data >> 8);
            buffer[offset + 2] = (byte)(data >> 16);
            buffer[offset + 3] = (byte)(data >> 24);
            buffer[offset + 4] = (byte)(data >> 32);
            buffer[offset + 5] = (byte)(data >> 40);
            buffer[offset + 6] = (byte)(data >> 48);
            buffer[offset + 7] = (byte)(data >> 56);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteLittleEndian(byte[] buffer, int offset, int data)
        {
#if BIGENDIAN
            buffer[offset + 3] = (byte)(data);
            buffer[offset + 2] = (byte)(data >> 8);
            buffer[offset + 1] = (byte)(data >> 16);
            buffer[offset    ] = (byte)(data >> 24);
#else
            buffer[offset] = (byte)(data);
            buffer[offset + 1] = (byte)(data >> 8);
            buffer[offset + 2] = (byte)(data >> 16);
            buffer[offset + 3] = (byte)(data >> 24);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteLittleEndian(byte[] buffer, int offset, short data)
        {
#if BIGENDIAN
            buffer[offset + 1] = (byte)(data);
            buffer[offset    ] = (byte)(data >> 8);
#else
            buffer[offset] = (byte)(data);
            buffer[offset + 1] = (byte)(data >> 8);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, double value)
        {
            ConverterHelperDouble ch = new ConverterHelperDouble { Adouble = value };
            WriteLittleEndian(bytes, startIndex, ch.Along);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, float value)
        {
            ConverterHelperFloat ch = new ConverterHelperFloat { Afloat = value };
            WriteLittleEndian(bytes, startIndex, ch.Aint);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, short value)
        {
            WriteLittleEndian(bytes, startIndex, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, ushort value)
        {
            WriteLittleEndian(bytes, startIndex, (short)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, int value)
        {
            WriteLittleEndian(bytes, startIndex, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, uint value)
        {
            WriteLittleEndian(bytes, startIndex, (int)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, long value)
        {
            WriteLittleEndian(bytes, startIndex, (ulong)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBytes(byte[] bytes, int startIndex, ulong value)
        {
            WriteLittleEndian(bytes, startIndex, value);
        }
#endif
    }
}
