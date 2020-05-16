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

        //监听
    
        
//        UICallBack uiCallBack =new UICallBack();
//        uiCallBack.GameObject = gameObject;
//        MainManager.Instance.UiMananger.Dictionary.Add((int)CodeID.CCLoginName,uiCallBack);
    }


    // Update is called once per frame
    void Update()
    {
        if ( MainManager.Instance.PlayerManager.Scene ==1){
            SceneManager.LoadScene("TankScene");
            MainManager.Instance.PlayerManager.Scene = -1;
        }
        
    }
}