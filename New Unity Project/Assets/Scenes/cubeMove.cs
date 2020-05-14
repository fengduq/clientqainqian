using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector= this.transform.position;

        //float z = vector.z + 0.01f;
        this.transform.position = new Vector3(vector.x, vector.y, (vector.z + 0.01f));
    }
}
