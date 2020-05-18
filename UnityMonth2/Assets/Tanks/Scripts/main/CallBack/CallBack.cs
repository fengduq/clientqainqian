using Login;
using Move;
using UnityEngine;

/**
 * @author  zsq
 * @version 1.0
 */
public class CallBack
{
    public  CallBack()
    {
        Do dele = SCPlayerLoginFun;
        MainManager.Instance.NetManager.Dictionary.Add((int) CodeNet.SCPlayerLogin, dele);
        
        dele = TanksMove;
        MainManager.Instance.NetManager.Dictionary.Add((int) CodeNet.SCPlayerMove, dele);
        
        dele = SCUDPFun;
        MainManager.Instance.NetManager.Dictionary.Add((int) CodeNet.SCUDP, dele);
        
        
    }

    public  void TanksMove(Protocol protocol)
    {
        //获取坦克的控制器
        SCPlayerMove scPlayerMove = SCPlayerMove.Parser.ParseFrom(protocol.Probuffer);
        foreach (long i in MainManager.Instance.PlayerManager.Player.Keys)
        {
            MainManager.Instance.PlayerManager.Player[i].Tanks.SCPlayerQueue.Enqueue(scPlayerMove);
        }
    }
    
    private void SCPlayerLoginFun(Protocol protocol)
    {
        Debug.Log("当前收到SCPlayerLogin");
        
        SCPlayerLogin scPlayerLogin = SCPlayerLogin.Parser.ParseFrom(protocol.Probuffer);
        long playerid = scPlayerLogin.PlayerId[0];
        MainManager.Instance.PlayerManager.PlayerId = playerid;

        NetManager udpManager = MainManager.Instance.NetManager;
        udpManager.UdpManager.UDPInit(udpManager.Udpip, udpManager.Udpport);
    }

    private void SCUDPFun(Protocol protocol)
    {
        Debug.Log("当前收到SCUDP");
        SCUDP scudp = SCUDP.Parser.ParseFrom(protocol.Probuffer);
        MainManager.Instance.PlayerManager.PlayerEnemy=new long[ scudp.PlayerId.Count-1];
        long playerid_first = scudp.PlayerId[0];
        long playerid_second = scudp.PlayerId[1];
        if (playerid_first == MainManager.Instance.PlayerManager.PlayerId){
            MainManager.Instance.PlayerManager.PlayerEnemy[0] = playerid_second;
        }
        else{
            MainManager.Instance.PlayerManager.PlayerEnemy[0] = playerid_first;
        }
        
        Debug.Log("初始化当前的场景");
        
        
        MainManager.Instance.PlayerManager.Scene = 1;
    }
    
}