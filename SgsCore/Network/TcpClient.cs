using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SgsCore.Network
{
    public class TcpClient : IDisposable
    {
        public TcpClient(IPAddress address, int port) : this(new IPEndPoint(address, port)) { }

        public TcpClient(string address, int port) : this(new IPEndPoint(IPAddress.Parse(address), port)) { }
        
        public TcpClient(DnsEndPoint endpoint) : this(endpoint as EndPoint, endpoint.Host, endpoint.Port) { }
       
        public TcpClient(IPEndPoint endpoint) : this(endpoint as EndPoint, endpoint.Address.ToString(), endpoint.Port) { }
        
        private TcpClient(EndPoint endpoint, string address, int port)
        {
            Id = Guid.NewGuid();
            Address = address;
            Port = port;
            Endpoint = endpoint;
        }

        public Guid Id { get; }

        public string Address { get; }
        
        public int Port { get; }
       
        public EndPoint Endpoint { get; private set; }
        
        public Socket Socket { get; private set; }

        /// <summary>
        /// 待发送字节数
        /// </summary>
        public long BytesPending { get; private set; }
        /// <summary>
        /// 正在发生字节数
        /// </summary>
        public long BytesSending { get; private set; }
        /// <summary>
        /// 已发送字节数
        /// </summary>
        public long BytesSent { get; private set; }
        /// <summary>
        /// 接收字节数
        /// </summary>
        public long BytesReceived { get; private set; }

        /// <summary>
        /// 选项： 是否用于IPv4 和 IPv6 的双模式套接字
        /// </summary>
        public bool OptionDualMode { get; set; }

        /// <summary>
        /// 选项: 保持连接
        /// </summary>
        public bool OptionKeepAlive { get; set; }

        /// <summary>
        /// 选项: 启用禁用 Nagle 算法
        /// </summary>
        public bool OptionNoDelay { get; set; }

        /// <summary>
        /// 选项: 设置接收缓存限制，0不限制
        /// </summary>
        public int OptionReceiveBufferLimit { get; set; } = 0;
        /// <summary>
        /// 选项: 接收缓存大小
        /// </summary>
        public int OptionReceiveBufferSize { get; set; } = 8192;
        /// <summary>
        /// 选项: 发送缓存限制，0不限制
        /// </summary>
        public int OptionSendBufferLimit { get; set; } = 0;
        /// <summary>
        /// 选项: 发送缓存大小
        /// </summary>
        public int OptionSendBufferSize { get; set; } = 8192;

        #region Connect/Disconnect client

        private SocketAsyncEventArgs _connectEventArg;

        /// <summary>
        /// 是否正在连接
        /// </summary>
        public bool IsConnecting { get; private set; }
        /// <summary>
        /// 是否已连接
        /// </summary>
        public bool IsConnected { get; private set; }

        protected virtual Socket CreateSocket()
        {
            return new Socket(Endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 同步方式连接
        /// </summary>
        public virtual bool Connect()
        {
            if (IsConnected || IsConnecting)
                return false;

            // 初始化
            _receiveBuffer = new Buffer();
            _sendBufferMain = new Buffer();
            _sendBufferFlush = new Buffer();

            // 事件参数
            _connectEventArg = new SocketAsyncEventArgs();
            _connectEventArg.RemoteEndPoint = Endpoint;
            _connectEventArg.Completed += OnAsyncCompleted;
            _receiveEventArg = new SocketAsyncEventArgs();
            _receiveEventArg.Completed += OnAsyncCompleted;
            _sendEventArg = new SocketAsyncEventArgs();
            _sendEventArg.Completed += OnAsyncCompleted;

            // 创建Socket
            Socket = CreateSocket();

            // Socket销毁标记
            IsSocketDisposed = false;

            // 设置双模式
            if (Socket.AddressFamily == AddressFamily.InterNetworkV6)
                Socket.DualMode = OptionDualMode;

            //正在连接事件
            OnConnecting();

            try
            {
                Socket.Connect(Endpoint);
            }
            catch (SocketException ex)
            {
                // Error事件
                SendError(ex.SocketErrorCode);

                // 重置回调事件参数
                _connectEventArg.Completed -= OnAsyncCompleted;
                _receiveEventArg.Completed -= OnAsyncCompleted;
                _sendEventArg.Completed -= OnAsyncCompleted;

                // 正在关闭事件
                OnDisconnecting();

                Socket.Close();
                Socket.Dispose();

                // 销毁事件参数
                _connectEventArg.Dispose();
                _receiveEventArg.Dispose();
                _sendEventArg.Dispose();

                // 已关闭事件
                OnDisconnected();

                return false;
            }

            // 设置参数
            if (OptionKeepAlive)
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            if (OptionNoDelay)
                Socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

            // 设置缓存大小
            _receiveBuffer.Reserve(OptionReceiveBufferSize);
            _sendBufferMain.Reserve(OptionSendBufferSize);
            _sendBufferFlush.Reserve(OptionSendBufferSize);

            // 重置统计
            BytesPending = 0;
            BytesSending = 0;
            BytesSent = 0;
            BytesReceived = 0;

            // 更新连接状态
            IsConnected = true;

            // 连接成功事件
            OnConnected();

            // Call the empty send buffer handler
            if (_sendBufferMain.IsEmpty)
                OnEmpty();

            return true;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns>返回false表示已断开连接</returns>
        public virtual bool Disconnect()
        {
            if (!IsConnected && !IsConnecting)
                return false;

            // 如果正在登录，取消登录
            if (IsConnecting)
                Socket.CancelConnectAsync(_connectEventArg);

            // 取消事件
            _connectEventArg.Completed -= OnAsyncCompleted;
            _receiveEventArg.Completed -= OnAsyncCompleted;
            _sendEventArg.Completed -= OnAsyncCompleted;

            OnDisconnecting();

            try
            {
                try
                {
                    // 禁用Socket上的发送和接收状态
                    Socket.Shutdown(SocketShutdown.Both);
                }
                catch (SocketException) { }

                // 关闭Socket
                Socket.Close();
                Socket.Dispose();

                // 销毁事件
                _connectEventArg.Dispose();
                _receiveEventArg.Dispose();
                _sendEventArg.Dispose();

                // 更新销毁状态
                IsSocketDisposed = true;
            }
            catch (ObjectDisposedException) { }

            // 更新连接状态
            IsConnected = false;

            // 更新发送状态
            _receiving = false;
            _sending = false;

            // 清理缓存对象
            ClearBuffers();

            // 调用连接断开事件
            OnDisconnected();

            return true;
        }

        /// <summary>
        /// 重连
        /// </summary>
        public virtual bool Reconnect()
        {
            if (!Disconnect())
                return false;

            return Connect();
        }

        /// <summary>
        /// 异步连接
        /// </summary>
        public virtual bool ConnectAsync()
        {
            if (IsConnected || IsConnecting)
                return false;

            // 设置缓存
            _receiveBuffer = new Buffer();
            _sendBufferMain = new Buffer();
            _sendBufferFlush = new Buffer();

            // 设置Socket事件
            _connectEventArg = new SocketAsyncEventArgs();
            _connectEventArg.RemoteEndPoint = Endpoint;
            _connectEventArg.Completed += OnAsyncCompleted;
            _receiveEventArg = new SocketAsyncEventArgs();
            _receiveEventArg.Completed += OnAsyncCompleted;
            _sendEventArg = new SocketAsyncEventArgs();
            _sendEventArg.Completed += OnAsyncCompleted;

            // 创建Socket
            Socket = CreateSocket();

            //更新销毁标记
            IsSocketDisposed = false;

            // 设置 IPv4 和 IPv6 的 Socket 双模式套接字
            if (Socket.AddressFamily == AddressFamily.InterNetworkV6)
                Socket.DualMode = OptionDualMode;

            // 更新连接状态
            IsConnecting = true;

            // 正在连接事件
            OnConnecting();

            // 异步连接
            if (!Socket.ConnectAsync(_connectEventArg))
                ProcessConnect(_connectEventArg);

            return true;
        }

        public virtual bool DisconnectAsync() => Disconnect();

        public virtual bool ReconnectAsync()
        {
            if (!DisconnectAsync())
                return false;

            //直到关闭完成
            while (IsConnected)
                Thread.Yield();

            return ConnectAsync();
        }

        #endregion

        #region 收发数据

        // 接收数据
        private bool _receiving;
        private Buffer _receiveBuffer;
        private SocketAsyncEventArgs _receiveEventArg;
        // 发送数据
        private readonly object _sendLock = new object();
        private bool _sending;
        private Buffer _sendBufferMain;
        private Buffer _sendBufferFlush;
        private SocketAsyncEventArgs _sendEventArg;
        private long _sendBufferFlushOffset;

        /// <summary>
        /// 同步发送数据
        /// </summary>
        public virtual long Send(byte[] buffer) => Send(buffer, 0, buffer.Length);

        public virtual long Send(byte[] buffer, int offset, int size)
        {
            if (!IsConnected)
                return 0;

            if (buffer == null || buffer.Length == 0 || size == 0)
                return 0;

            // 发送数据
            int sent = Socket.Send(buffer, offset, size, SocketFlags.None, out SocketError ec);

            if (sent > 0)
            {
                // 更新统计数据
                BytesSent += sent;
                // 发送事件
                OnSent(sent, BytesPending + BytesSending);
            }

            // 检查发送错误状态
            if (ec != SocketError.Success)
            {
                SendError(ec);
                Disconnect();
            }

            return sent;
        }

        /// <summary>
        /// 异步发送数据
        /// </summary>
        public virtual bool SendAsync(byte[] buffer) => SendAsync(buffer.AsSpan());

        public virtual bool SendAsync(byte[] buffer, long offset, long size) => SendAsync(buffer.AsSpan((int)offset, (int)size));

        public virtual bool SendAsync(ReadOnlySpan<byte> buffer)
        {
            if (!IsConnected)
                return false;

            if (buffer.IsEmpty)
                return true;

            lock (_sendLock)
            {
                // 检查发送缓存限制
                if (((_sendBufferMain.Size + buffer.Length) > OptionSendBufferLimit) && (OptionSendBufferLimit > 0))
                {
                    SendError(SocketError.NoBufferSpaceAvailable);
                    return false;
                }

                // 添加到要发送的缓存
                _sendBufferMain.Append(buffer);

                // 更新待发送
                BytesPending = _sendBufferMain.Size;

                // 如果已在发送无需重复调用
                if (_sending)
                    return true;
                else
                    _sending = true;

                // 具体发送操作
                TrySend();
            }

            return true;
        }

        public virtual bool SendAsync(string text) => SendAsync(Encoding.UTF8.GetBytes(text));

        public virtual bool SendAsync(ReadOnlySpan<char> text) => SendAsync(Encoding.UTF8.GetBytes(text.ToArray()));

        public virtual long Receive(byte[] buffer) { return Receive(buffer, 0, buffer.Length); }

        public virtual long Receive(byte[] buffer, long offset, long size)
        {
            if (!IsConnected)
                return 0;

            if (size == 0)
                return 0;

            // 接收发送数据
            long received = Socket.Receive(buffer, (int)offset, (int)size, SocketFlags.None, out SocketError ec);
           
            if (received > 0)
            { 
                // 更新统计信息
                BytesReceived += received;
                // 接收事件
                OnReceived(buffer, 0, received);
            }

            // 检查发送状态
            if (ec != SocketError.Success)
            {
                SendError(ec);
                Disconnect();
            }

            return received;
        }

        public virtual string Receive(long size)
        {
            var buffer = new byte[size];
            var length = Receive(buffer);
            return Encoding.UTF8.GetString(buffer, 0, (int)length);
        }

        public virtual void ReceiveAsync()
        {
            // 尝试接收数据
            TryReceive();
        }

        private void TryReceive()
        {
            if (_receiving)
                return;

            if (!IsConnected)
                return;

            //正在尝试接收数据
            bool process = true;

            while (process)
            {
                process = false;
                try
                {
                    // 从异步事件中接收数据
                    _receiving = true;
                    _receiveEventArg.SetBuffer(_receiveBuffer.Data, 0, (int)_receiveBuffer.Capacity);
                    if (!Socket.ReceiveAsync(_receiveEventArg))
                        process = ProcessReceive(_receiveEventArg);
                }
                catch (ObjectDisposedException) { }
            }
        }

        private void TrySend()
        {
            if (!IsConnected)
                return;

            bool empty = false;
            bool process = true;
            while (process)
            {
                process = false;
                lock (_sendLock)
                {
                    // 上次的发送已处理完
                    if (_sendBufferFlush.IsEmpty)
                    {
                        // 通过交换方式刷入待发送数据
                        _sendBufferFlush = Interlocked.Exchange(ref _sendBufferMain, _sendBufferFlush);
                        _sendBufferFlushOffset = 0;

                        // 更新统计
                        BytesPending = 0;
                        BytesSending += _sendBufferFlush.Size;

                        // 数据发送完结束发送
                        if (_sendBufferFlush.IsEmpty)
                        {
                            empty = true;
                            _sending = false;
                        }
                    }
                    else
                        return;
                }

                // 数据发送空闲事件
                if (empty)
                {
                    OnEmpty();
                    return;
                }

                try
                {
                    // 通过Socket事件发送数据
                    _sendEventArg.SetBuffer(_sendBufferFlush.Data, (int)_sendBufferFlushOffset, (int)(_sendBufferFlush.Size - _sendBufferFlushOffset));
                    if (!Socket.SendAsync(_sendEventArg))
                        process = ProcessSend(_sendEventArg);
                }
                catch (ObjectDisposedException) { }
            }
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        private void ClearBuffers()
        {
            lock (_sendLock)
            {
                _sendBufferMain.Clear();
                _sendBufferFlush.Clear();
                _sendBufferFlushOffset = 0;

                // 统计
                BytesPending = 0;
                BytesSending = 0;
            }
        }

        #endregion

        #region IO 处理事件

        /// <summary>
        /// 当Socket完成一次连接，数据发送或接收完成时回调
        /// </summary>
        private void OnAsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (IsSocketDisposed)
                return;

            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    ProcessConnect(e);
                    break;
                case SocketAsyncOperation.Receive:
                    if (ProcessReceive(e))
                        TryReceive();
                    break;
                case SocketAsyncOperation.Send:
                    if (ProcessSend(e))
                        TrySend();
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }

        }

        private void ProcessConnect(SocketAsyncEventArgs e)
        {
            IsConnecting = false;

            if (e.SocketError == SocketError.Success)
            {
                if (OptionKeepAlive)
                    Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                if (OptionNoDelay)
                    Socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

                // 设置发送接收缓存大小
                _receiveBuffer.Reserve(OptionReceiveBufferSize);
                _sendBufferMain.Reserve(OptionSendBufferSize);
                _sendBufferFlush.Reserve(OptionSendBufferSize);

                // 重置数据
                BytesPending = 0;
                BytesSending = 0;
                BytesSent = 0;
                BytesReceived = 0;

                // 更新连接状态
                IsConnected = true;

                // 尝试接收数据
                TryReceive();

                // 有可能在刚连上时就被销毁
                if (IsSocketDisposed)
                    return;

                // 回调已连接
                OnConnected();

                // 发送已准备好，可发送
                if (_sendBufferMain.IsEmpty)
                    OnEmpty();
            }
            else
            {
                // 连接失败操作
                SendError(e.SocketError);
                OnDisconnected();
            }
        }

        private bool ProcessReceive(SocketAsyncEventArgs e)
        {
            if (!IsConnected)
                return false;

            // 有数据接收
            long size = e.BytesTransferred;
            if (size > 0)
            {
                // 更新统计
                BytesReceived += size;

                // 调用数据接收回调
                OnReceived(_receiveBuffer.Data, 0, size);

                // 接收缓存大小检测
                if (_receiveBuffer.Capacity == size)
                {
                    // 检查异步接收缓存
                    if (((2 * size) > OptionReceiveBufferLimit) && (OptionReceiveBufferLimit > 0))
                    {
                        SendError(SocketError.NoBufferSpaceAvailable);
                        DisconnectAsync();
                        return false;
                    }

                    _receiveBuffer.Reserve(2 * size);
                }
            }

            _receiving = false;

            // 如果连接是正常，重复接收数据
            if (e.SocketError == SocketError.Success)
            {
                // 如果回调接收数据是0说明服务器已经关闭连接
                if (size > 0)
                    return true;
                else
                    DisconnectAsync();
            }
            else
            {
                SendError(e.SocketError);
                DisconnectAsync();
            }

            return false;
        }

        private bool ProcessSend(SocketAsyncEventArgs e)
        {
            if (!IsConnected)
                return false;

            long size = e.BytesTransferred;
            if (size > 0)
            {
                // 更新统计
                BytesSending -= size;
                BytesSent += size;

                // 更新发送缓存偏移，如果数据已发送清理
                _sendBufferFlushOffset += size;
                if (_sendBufferFlushOffset == _sendBufferFlush.Size)
                {
                    _sendBufferFlush.Clear();
                    _sendBufferFlushOffset = 0;
                }

                // 发送回调
                OnSent(size, BytesPending + BytesSending);
            }

            if (e.SocketError == SocketError.Success)
                return true;
            else
            {
                SendError(e.SocketError);
                DisconnectAsync();
                return false;
            }
        }

        #endregion

        #region 连接回调处理方法

        /// <summary>
        /// 正在连接回调
        /// </summary>
        protected virtual void OnConnecting() { }
        /// <summary>
        /// 连接完成回调
        /// </summary>
        protected virtual void OnConnected() { }
        /// <summary>
        /// 正在断开回调
        /// </summary>
        protected virtual void OnDisconnecting() { }
        /// <summary>
        /// 连接已断开回调
        /// </summary>
        protected virtual void OnDisconnected() { }

        /// <summary>
        /// 数据接收回调
        /// </summary>
        protected virtual void OnReceived(ReadOnlySpan<byte> buffer, long offset, long size) { }

        /// <summary>
        /// 数据发送回调
        /// </summary>
        protected virtual void OnSent(long sent, long pending) { }

        /// <summary>
        /// 发送空闲回调
        /// </summary>
        protected virtual void OnEmpty() { }

        /// <summary>
        /// 错误回调
        /// </summary>
        protected virtual void OnError(SocketError error) { }

        #endregion

        #region 错误处理

        private void SendError(SocketError error)
        {
            // Skip disconnect errors
            if ((error == SocketError.ConnectionAborted) ||
                (error == SocketError.ConnectionRefused) ||
                (error == SocketError.ConnectionReset) ||
                (error == SocketError.OperationAborted) ||
                (error == SocketError.Shutdown))
                return;

            OnError(error);
        }

        #endregion

        #region IDisposable 实现

        public bool IsDisposed { get; private set; }

        public bool IsSocketDisposed { get; private set; } = true;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposingManagedResources)
        {
            if (!IsDisposed)
            {
                if (disposingManagedResources)
                {
                    DisconnectAsync();
                }

                IsDisposed = true;
            }
        }

        #endregion
    }
}
