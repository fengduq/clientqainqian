/**
 * @author  zsq
 * @version 1.0
 */

using UnityEngine;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
//tcp就到这

/**
 * 确保没有分片 udp的消息一定要小
 */
public class UdpManager
{
    private Socket socket;

    private int _cacheLenth;

    private ConcurrentQueue<Protocol> _list;
    //创建的发送消息的 
    private IPEndPoint sEndPoint;
    
    UdpClient udpClient ;

    public ConcurrentQueue<Protocol> List => _list;
    
    //创建的发送消息的 
    //private IPEndPoint recivePoint;
    
    
    public void UDPInit(String ip, int port)
    {
        socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
        _list =new ConcurrentQueue<Protocol>();
        sEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        udpClient =new UdpClient(0);
        //创建一个接收线程 这块位置是创建一个连接 能够让服务器知道这个channel 存在 不然服务器不知道这个channel是否存在
        connnect();
        Thread thread =new Thread(ReciveMethod);
        thread.Start();
    }
    
    
    
    
    public void connnect()
    {
        udpClient =new UdpClient(0);
        byte[] bytes =new byte[1024];
        bytes=Encoding.UTF8.GetBytes("connect");
        udpClient.Send(bytes, bytes.Length, sEndPoint);
    }


    public void ReciveMethod()
    {
        while (true)
        {
            //发送数据
            var receiveBuffer = new byte[1024];
            IPEndPoint recivePoint =new IPEndPoint(IPAddress.Any, 0);
            receiveBuffer=udpClient.Receive(ref recivePoint);
            //string str = Encoding.UTF8.GetString(receiveBuffer,0,receiveBuffer.Length);
            Protocol protocol=NetManager.ProtocolParse(receiveBuffer);
            _list.Enqueue(protocol);
        }
    }

    public void write()
    {
        socket.SendTo(Encoding.ASCII.GetBytes("当前"), sEndPoint);
    }


}