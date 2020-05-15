using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class MainManager 
{
    // Start is called before the first frame update

    private static volatile MainManager _instance;
   
    private static  Object gameObject =new Object();

    private NetManager _netManager;

    private PlayerManager _playerManager;
    
    
    private int _state;

    public PlayerManager PlayerManager
    {
        get => _playerManager;
        set => _playerManager = value;
    }
    
    public int State
    {
        get => _state;
        set => _state = value;
    }
    
    public NetManager NetManager
    {
        get => _netManager;
        set => _netManager = value;
    }
    
    private UIMananger _uiMananger;

    public UIMananger UiMananger
    {
        get => _uiMananger;
        set => _uiMananger = value;
    }
    public static MainManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (gameObject)
                {
                    if (_instance == null) {
                        _instance=new MainManager();
                        return _instance;
                    }
                }
            }

            return _instance;
        }
    }
    
}
