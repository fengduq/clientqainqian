/**
 * @author  zsq
 * @version 1.0
 */
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerManager
{
    private long _playerId;

    private long[] _playerEnemy;

    private Dictionary<long,Player> _player;
/// <summary>
/// 当前界面是属于0的枚举 接下来切换场景是战斗的场景是1  
/// </summary>
    private int _scene;

    public int Scene
    {
        get => _scene;
        set => _scene = value;
    }
    
    
    public PlayerManager(Dictionary<long, Player> player)
    {
        _player = player;
        //初始化场景
        _scene = 0;
    }

    public Dictionary<long, Player> Player
    {
        get => _player;
        set => _player = value;
    }    
    
    public long PlayerId
    {
        get => _playerId;
        set => _playerId = value;
    }

    public long[] PlayerEnemy
    {
        get => _playerEnemy;
        set => _playerEnemy = value;
    }
}
