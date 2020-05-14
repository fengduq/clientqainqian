using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;


public class NetManager
{
    private String ip;
    private int port;
    private String _udpip;
    private int _udpport;
    private TcpManager _tcpManager;
    private UdpManager _udpManager;

    private Dictionary<int, Do> _dictionary;


    public string Udpip
    {
        get => _udpip;
        set => _udpip = value;
    }

    public int Udpport
    {
        get => _udpport;
        set => _udpport = value;
    }


    public Dictionary<int, Do> Dictionary
    {
        get => _dictionary;
        set => _dictionary = value;
    }

    public TcpManager TcpManager
    {
        get => _tcpManager;
    }

    public UdpManager UdpManager
    {
        get => _udpManager;
    }


    public NetManager(string ip, int port, string udpip, int udpport)
    {
        this.ip = ip;
        this.port = port;
        this._udpip = udpip;
        this._udpport = udpport;
        Init();
    }

    public void Init()
    {
        _tcpManager = new TcpManager();
        _tcpManager.TCPInit(ip, port);
        _udpManager = new UdpManager();
        // _udpManager.UDPInit(_udpip,_udpport);

        _dictionary = new Dictionary<int, Do>();
        //创建一个线程用于处理消息
        Thread theadTcp = new Thread(TickTcp);
        theadTcp.Start();
        
        Thread theadUdp = new Thread(TickUdp);
        theadUdp.Start();
        
    }

    private void TickTcp()
    {
        ConcurrentQueue<Protocol> queue = _tcpManager.List;
        while (true)
        {
            if (!queue.IsEmpty)
            {
                Protocol protocol;
                queue.TryDequeue(out protocol);
                int code = protocol.Code;
                _dictionary[code]();
            }
        }
    }
    
    private void TickUdp()
    {
        ConcurrentQueue<Protocol> queue = _udpManager.List;
        while (true)
        {
            if (!queue.IsEmpty)
            {
                Protocol protocol;
                queue.TryDequeue(out protocol);
                int code = protocol.Code;
                _dictionary[code]();
            }
        }
    }

    


    public static Protocol ProtocolParse(byte[] data)
    {
        short code = BitConverter.ToInt16(data, 0);
        int len = BitConverter.ToInt32(data, 2);
        byte[] newCache = new byte[len];
        for (int i = 0; i < len; i++)
        {
            newCache[i] = data[6 + i];
        }
        Protocol protocal = new Protocol(code, len, newCache);
        return protocal;
    }
}