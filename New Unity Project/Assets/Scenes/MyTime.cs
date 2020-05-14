using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float nowTime =Time.time;
        float unscaledTime = Time.unscaledTime;
        float realTime = Time.realtimeSinceStartup;
        Debug.Log("nowTime:" + nowTime);
        Debug.Log("unscaledTime:" + unscaledTime);
        Debug.Log("realTime:" + realTime);

    }

    private void OnGUI()
    {
        if (GUILayout.Button("暂停游戏"))
        {
            Time.timeScale = 0;
        }
        if (GUILayout.Button("继续游戏"))
        {
            Time.timeScale = 1;
        }

    }


}
