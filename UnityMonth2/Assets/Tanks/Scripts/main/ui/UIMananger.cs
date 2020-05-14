using System;
using System.Collections.Generic;

/**
 * @author  zsq
 * @version 1.0
 */
public class UIMananger
{
    private Dictionary<int, UICallBack> _dictionary;

    public Dictionary<int, UICallBack> Dictionary => _dictionary;
    
    public UIMananger(){
        _dictionary = new Dictionary<int, UICallBack>();
    }
}