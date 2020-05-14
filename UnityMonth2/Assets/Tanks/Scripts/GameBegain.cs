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
        mainManager.NetManager=new NetManager("192.168.1.9",12306,"192.168.1.9",12310);

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
