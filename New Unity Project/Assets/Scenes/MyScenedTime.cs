using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScenedTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float first;
    void Start()
    {
        first = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - first > 110 && Time.realtimeSinceStartup - first <= 120)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        Debug.Log("realtimeSinceStartup:"+Time.realtimeSinceStartup);
    }
}
