using System;


public class Protocol
{
    private short code;

    private int length;

    private long pid;
    
    private byte[] probuffer;

    public Protocol(short code, int length, long pid ,byte[] probuffer)
    {
        this.code = code;
        this.length = length;
        this.pid = pid;
        this.probuffer = probuffer;
    }

    public short Code
    {
        get => code;
        set => code = value;
    }

    public int Length
    {
        get => length;
        set => length = value;
    }

    public long Pid
    {
        get => pid;
        set => pid = value;
    }
    

    public byte[] Probuffer
    {
        get => probuffer;
        set => probuffer = value;
    }

    /**
     * 处理消息流
     */
    public byte[] toArray()
    {
        byte[] bytes =new byte[6+8+Length];
        bytes[0] = (byte) (code >> 8 & 0xff);
        bytes[1] = (byte) (code & 0xff);
        for (int i = 0; i < 4; i++)
        {
            bytes[2 + i] = (byte) (length >> 8 * (3 - i));
        }
        
        for (int i = 0; i < 8; i++)
        {
            bytes[6 + i] = (byte) (pid >> 8 * (7 - i));
        }
        
        if(length>=0) probuffer.CopyTo(bytes,14);
        return bytes;
    }

}