using System;


public class Protocol
{
    private short code;

    private int length;

    private byte[] probuffer;

    public Protocol(short code, int length, byte[] probuffer)
    {
        this.code = code;
        this.length = length;
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
        byte[] bytes =new byte[6+Length];
        bytes[0] = (byte) (code >> 8 & 0xff);
        bytes[1] = (byte) (code & 0xff);
        for (int i = 0; i < 4; i++)
        {
            bytes[2 + i] = (byte) (length >> 8 * (3 - i));
        }
        if(length>=0) probuffer.CopyTo(bytes,6);
        return bytes;
    }

}