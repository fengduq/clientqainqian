using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Error : MonoBehaviour
{
    // Start is called before the first frame update
    public Button close;
    public int i;
    
    void closeCallback(){
        gameObject.SetActive(false);
    }
    
    void Start()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<Canvas>().sortingOrder = 1;
        UICallBack uiCallBack =new UICallBack();
        uiCallBack.GameObject = gameObject;
        MainManager.Instance.UiMananger.Dictionary.Add(i,uiCallBack);
        close.onClick.AddListener(closeCallback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
