using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network
{
    /// <summary>
    /// 动态缓存组件
    /// </summary>
    public class Buffer
    {
        private byte[] _data;
        private int _size;
        private int _offset;

        /// <summary>
        /// 缓存为空
        /// </summary>
        public bool IsEmpty => (_data == null) || (_size == 0);
        /// <summary>
        /// 缓存数据
        /// </summary>
        public byte[] Data => _data;
        /// <summary>
        /// 缓存容量
        /// </summary>
        public int Capacity => _data.Length;
        /// <summary>
        /// 缓存数据大小
        /// </summary>
        public int Size => _size;
        /// <summary>
        /// 缓存偏移值
        /// </summary>
        public int Offset => _offset;

        public int FreeCapacity => _data.Length - this._offset;

        /// <summary>
        /// 索引操作实现
        /// </summary>
        public byte this[long index] => _data[index];

        /// <summary>
        /// 创建空容量的缓存对象
        /// </summary>
        public Buffer() { _data = new byte[0]; _size = 0; _offset = 0; }
        /// <summary>
        /// 创建指定容量空数据的缓存对象
        /// </summary>
        public Buffer(long capacity) { _data = new byte[capacity]; _size = 0; _offset = 0; }

        #region 缓存操作方法
        /// <summary>
        /// 转换Span对象
        /// </summary>
        public Span<byte> AsSpan()
        {
            return new Span<byte>(_data, 0, (int)_size);
        }
        public ReadOnlySpan<byte> AsReadOnlySpan()
        {
            return new ReadOnlySpan<byte>(_data, 0, (int)_size);
        }
        public ReadOnlySpan<byte> AsReadOnlySpan(int offset, int size)
        {
            return new ReadOnlySpan<byte>(_data, offset, size);
        }

        public override string ToString()
        {
            return ExtractString(0, _size);
        }

        public void Clear()
        {
            _size = 0;
            _offset = 0;
        }

        public string ExtractString(long offset, long size)
        {
            Debug.Assert(((offset + size) <= Size), "Invalid offset & size!");
            if ((offset + size) > Size)
                throw new ArgumentException("Invalid offset & size!", nameof(offset));

            return Encoding.UTF8.GetString(_data, (int)offset, (int)size);
        }

        public void Remove(int offset, int size)
        {
            Debug.Assert(((offset + size) <= Size), "Invalid offset & size!");
            if ((offset + size) > Size)
                throw new ArgumentException("Invalid offset & size!", nameof(offset));

            //Array.Copy(_data, offset + size, _data, offset, _size - size - offset);
            Array.Clear(_data, (int)offset, (int)size);
            _size -= size;
            if (_offset >= (offset + size))
                _offset -= size;
            else if (_offset >= offset)
            {
                _offset -= _offset - offset;
                if (_offset > Size)
                    _offset = Size;
            }
        }

        /// <summary>
        /// 动态扩展容量
        /// </summary>
        public void Reserve(long capacity)
        {
            Debug.Assert((capacity >= 0), "Invalid reserve capacity!");
            if (capacity < 0)
                throw new ArgumentException("Invalid reserve capacity!", nameof(capacity));

            if (capacity > Capacity)
            {
                byte[] data = new byte[Math.Max(capacity, 2 * Capacity)];
                Array.Copy(_data, 0, data, 0, _size);
                _data = data;
            }
        }

        public void Resize(int size)
        {
            Reserve(size);
            _size = size;
            if (_offset > _size)
                _offset = _size;
        }

        // 调整游标
        public void AddSize(int size) { _size += size; }
        public void SubSize(int size) { _size -= size; }

        // 调整游标
        public void Shift(int offset) { _offset += offset; }
        public void Unshift(int offset) { _offset -= offset; }


        public void InsertAndAdjust(int srcoffset, int srclen, byte[] dst, int dstoffset, int dstlen)
        {
            if(srclen != dstlen)
            {
                System.Buffer.BlockCopy(_data, srcoffset + dstlen, _data, srcoffset + srclen, _size - srcoffset - srclen);
            }
            System.Buffer.BlockCopy(dst, 0, _data, srcoffset, dstlen);
            _size = _size + dstlen - srclen;
        }

        public void RemoveAndAdjust(int offset, int size)
        {
            if ((offset + size) > Size)
                throw new ArgumentException("Invalid offset & size!", nameof(offset));

            Array.Clear(_data, offset, size);
            if (_size - size > 0)
            {
                System.Buffer.BlockCopy(_data, offset + size, _data, offset, _size - size);
            }
            _size -= size;
        }

        public long Append(byte value)
        {
            Reserve(_size + 1);
            _data[_size] = value;
            _size += 1;
            return 1;
        }

        public long Append(byte[] buffer)
        {
            Reserve(_size + buffer.Length);
            Array.Copy(buffer, 0, _data, _size, buffer.Length);
            _size += buffer.Length;
            return buffer.Length;
        }

        public long Append(byte[] buffer, int offset, int size)
        {
            Reserve(_size + size);
            Array.Copy(buffer, offset, _data, _size, size);
            _size += size;
            return size;
        }

        public long Append(ReadOnlySpan<byte> buffer)
        {
            Reserve(_size + buffer.Length);
            buffer.CopyTo(new Span<byte>(_data, (int)_size, buffer.Length));
            _size += buffer.Length;
            return buffer.Length;
        }

        public long Append(Buffer buffer) => Append(buffer.AsSpan());

        #endregion
    }
}
