using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormDome : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transformChild; 
    private float speed = 0;
    private float speed2 = 0f;
    [System.Obsolete]
    void Start()
    {
        transformChild=transform.Find("Main_Rotor");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.speed > 100)
        {
           // Vector3 vec=transform.position;
           // transform.position = new Vector3(vec.x, vec.y + 1, vec.z);
        }
        Vector3 vector = this.transform.rotation.eulerAngles;
        speed2 = speed2 + 0.01f;
        if (speed > 100)
        {
            speed = 0;
            speed2 = 30;
        }
        speed = speed + speed2;
     
        vector = new Vector3(vector.x, vector.y+ speed, vector.z);
        transformChild.transform.rotation = Quaternion.Euler(vector);
    }
}
