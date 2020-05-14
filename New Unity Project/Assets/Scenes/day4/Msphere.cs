using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Msphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(0, 0, 1);
        this.GetComponent<Rigidbody>().AddForce(vec*500);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Door")
        {
            collision.rigidbody.AddForce(new Vector3(0, 0, 1) * 50);
        }
    }

}
