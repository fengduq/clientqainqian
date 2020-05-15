using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using UnityEngine;


public class TcpManager 
{
    private Socket socket;

    
    //用局部变量去缓存数据
    private byte[] _cacheData=null;
    
    private int _cacheLenth;

    private ConcurrentQueue<Protocol> _list;

    
    public ConcurrentQueue<Protocol> List
    {
        get => _list;
    }
    /**
     * 初始化当前的的ip和端口
     */
    public void TCPInit(String ip, int port)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _list =new ConcurrentQueue<Protocol>();
        socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
        //创建一个输入线程
        ReciveAsync();
        
        
        
    }
    //接收消息的位置
    private void ReciveAsync()
    {
        if (socket == null || !socket.Connected)
        {
            return;
        }
        var buff = new byte[1024];
        socket.BeginReceive(buff, 0, 1024, SocketFlags.None, OnReceived, buff);
    }

    private void OnReceived(IAsyncResult result)
    {
        if (socket == null || !socket.Connected)
        {
            Debug.Log("当前断开连接");
            return;
        }

        //表示不需要进行字符串拼接 
        byte[] data = (byte[]) result.AsyncState;
        int len;
        long pid;
        if (_cacheData == null){
            Array.Reverse(data, 0, 2);
            short code = BitConverter.ToInt16(data, 0);
            Array.Reverse(data, 2, 4);
            len = BitConverter.ToInt32(data, 2);
            Array.Reverse(data, 6, 8);
            pid = BitConverter.ToInt64(data, 6);
            
            
            //如果说len大于了1018表示应该分片 表示数据超过了一个分片
            if (len > 1010){
                _cacheData=new byte[len+14];
                data.CopyTo(_cacheData,0);
                _cacheLenth = 1024;
                int count = 0;
                while (count!=_cacheData.Length-1024)
                {    
                    
                    byte[] bytes=new byte[_cacheData.Length-(count+1024)];
                    int i=socket.Receive(bytes,0,_cacheData.Length-(count+1024),0);
                    Array.Copy(bytes,0,_cacheData,_cacheLenth+count,i );
                    count = count + i;
                }
                bigReceive();
                return;
            }
            //nowData 表示当前的数据 
            Protocol protocol =NetManager.ProtocolParse(data);
            _list.Enqueue(protocol);
            ReciveAsync();
        }
    }
    


    private void bigReceive()
    {
        //表示需字符串拼接了
       // int len=BitConverter.ToInt16(_cacheData, 2);
        //表示已经全部都获取了数据
        short code = BitConverter.ToInt16(_cacheData, 0);
        int len = BitConverter.ToInt32(_cacheData, 2);
        long pid = BitConverter.ToInt64(_cacheData, 6);
        
        
        byte[] newCache =new byte[len];
        Array.Copy(_cacheData,14,newCache,0,_cacheData.Length-14);
        Protocol protocol =new Protocol(code,len,pid,newCache);
        _cacheData = null;
        _cacheLenth = 0;
        _list.Enqueue(protocol);
        ReciveAsync();
    }

    public void Write(Protocol protocol)
    {
        if (socket != null && socket.Connected){
            byte[] buff = protocol.toArray();
            socket.Send(buff);
        }
    }
}




