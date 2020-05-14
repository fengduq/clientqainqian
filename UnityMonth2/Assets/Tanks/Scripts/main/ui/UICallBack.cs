using UnityEngine;

/**
 * @author  zsq
 * @version 1.0
 */
public class UICallBack : CallBack
{
    private GameObject _gameObject;

    public GameObject GameObject
    {
        get => _gameObject;
        set => _gameObject = value;
    }
}