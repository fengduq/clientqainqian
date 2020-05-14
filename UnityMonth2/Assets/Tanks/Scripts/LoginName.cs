using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginName : MonoBehaviour
{
    public Button close;
    // Start is called before the first frame update

    void closeCallback(){
        gameObject.SetActive(false);
    }
    

    void Start()
    {
       gameObject.SetActive(false);
       gameObject.GetComponent<Canvas>().sortingOrder = 1;
       UICallBack uiCallBack =new UICallBack();
       uiCallBack.GameObject = gameObject;
       MainManager.Instance.UiMananger.Dictionary.Add((int)CodeID.CCLoginName,uiCallBack);
       close.onClick.AddListener(closeCallback);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
