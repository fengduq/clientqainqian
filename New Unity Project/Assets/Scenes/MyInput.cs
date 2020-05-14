using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        
        bool key = Input.GetKeyDown(KeyCode.Space);
        if (key)
        {
            
            Instantiate(obj, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
        }


    }
}
