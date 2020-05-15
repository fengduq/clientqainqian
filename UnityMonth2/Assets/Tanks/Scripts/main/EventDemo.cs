using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf;
using Login;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public delegate void Do(Protocol protocol);

public class EventDemo : MonoBehaviour
{
    //名字的回调
    public Button bu;

    public Button login;


    //收到连接成功的消息
    private bool _enter = false;

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
        _enter = true;
    }

    
    
    
//Test
    public void Active()
    {
        if (!MainManager.Instance.UiMananger.Dictionary[(int) CodeID.CCLoginName].GameObject.activeSelf)
        {
            MainManager.Instance.UiMananger.Dictionary[(int) CodeID.CCLoginName].GameObject.SetActive(true);
        }
    }

    public void GameBegain()
    {
        //获取一下 当前的file
        GameObject gameObject = MainManager.Instance.UiMananger.Dictionary[(int) CodeID.CCLoginName].GameObject;
        InputField transform = gameObject.transform.Find("InputField").gameObject.GetComponent<InputField>();
        if (transform.text == "")
        {
            MainManager.Instance.UiMananger.Dictionary[(int) CodeID.CCLoginClose].GameObject.SetActive(true);
        }
        CSPlayerLogin csPlayerLogin = new CSPlayerLogin();
        csPlayerLogin.Uid = transform.text;
        csPlayerLogin.Password = 1111;
        byte[] bytes = csPlayerLogin.ToByteArray();
        Protocol protocol = new Protocol((int) CodeNet.CSPlayerLogin, bytes.Length,0,bytes);
        MainManager.Instance.NetManager.TcpManager.Write(protocol);
        //SceneManager.LoadScene("TankScene");
    }


    
    
    
    // Start is called before the first frame update

    void Start()
    {
        bu.onClick.AddListener(Active);
        login.onClick.AddListener(GameBegain);
        
        
        //配套SCPlayerLogin 监听
        Do dele = SCPlayerLoginFun;
        MainManager.Instance.NetManager.Dictionary.Add((int) CodeNet.SCPlayerLogin, dele);
        
        //监听
        dele = SCUDPFun;
        MainManager.Instance.NetManager.Dictionary.Add((int) CodeNet.SCUDP, dele);
        
//        UICallBack uiCallBack =new UICallBack();
//        uiCallBack.GameObject = gameObject;
//        MainManager.Instance.UiMananger.Dictionary.Add((int)CodeID.CCLoginName,uiCallBack);
    }


    // Update is called once per frame
    void Update()
    {
        if (_enter){
            SceneManager.LoadScene("TankScene");
            _enter = false;
        }
        
    }
}