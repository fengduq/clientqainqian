using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBegain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
       
    }

    private void Awake()
    {
        MainManager mainManager =MainManager.Instance;
        MainManager.Instance.State = (int)State.begain;
        mainManager.UiMananger=new UIMananger();
        mainManager.NetManager=new NetManager("192.168.1.11",12306,"192.168.1.11",12310);
        mainManager.PlayerManager=new PlayerManager(new Dictionary<long, Player>());
        mainManager.CallBack =new CallBack();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}