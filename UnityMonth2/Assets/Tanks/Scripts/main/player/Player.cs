using System;
using UnityEngine;


//玩家类 //保存玩家的基础脚本
public class Player
{
    private GameObject _gameObject;
    //将坦克的脚本添加进来
    private Tanks _tanks;

    public Tanks Tanks
    {
        get => _tanks;
        set => _tanks = value;
    }
    
    public GameObject GameObject
    {
        get => _gameObject;
        set => _gameObject = value;
    }
    public Player(GameObject gameObject)
    {
        _gameObject = gameObject;
    }
}