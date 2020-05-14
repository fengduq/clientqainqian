using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mpyysics : MonoBehaviour
{
    // Start is called before the first frame update
    private bool first = false;
    private Vector3 vec ;
    void Start()
    {
        this.vec = this.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (first == false) 
        {
            vec = new Vector3(vec.x + 1, vec.y, vec.z);
            this.transform.rotation = Quaternion.Euler(vec);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.first = true;
    }



}
