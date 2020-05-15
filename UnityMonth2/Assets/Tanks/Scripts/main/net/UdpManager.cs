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
using Google.Protobuf;
using Login;

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

    public UdpManager()
    {
        _list =new ConcurrentQueue<Protocol>();
    }

    public ConcurrentQueue<Protocol> List => _list;
    
    //创建的发送消息的 
    //private IPEndPoint recivePoint;
    
    
    
    
    public void UDPInit(String ip, int port)
    {
        socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
        sEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        udpClient =new UdpClient(0);
        //创建一个接收线程 这块位置是创建一个连接 能够让服务器知道这个channel 存在 不然服务器不知道这个channel是否存在
        Connnect();
        Thread thread =new Thread(ReciveMethod);
        thread.Start();
    }
    
    
    
    
    public void Connnect()
    {
        udpClient =new UdpClient(0);
        CSUDP csudp=new CSUDP();
        csudp.PlayerId = MainManager.Instance.PlayerManager.PlayerId;
        byte[] bytes = csudp.ToByteArray();
        Protocol protocol =new Protocol((int)CodeNet.CSUDP,bytes.Length,csudp.PlayerId,bytes);
        udpClient.Send(protocol.toArray(), protocol.toArray().Length, sEndPoint);
        Debug.Log("connect 发送");
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
            Protocol protocol=NetManager.ProtocolUDPParse(receiveBuffer);
            _list.Enqueue(protocol);
        }
    }

    public void write(Protocol protocol)
    {
        udpClient.Send(protocol.toArray(), protocol.toArray().Length, sEndPoint);
    }


}