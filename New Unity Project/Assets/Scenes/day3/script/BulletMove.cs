using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec=this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(vec.x, vec.y, vec.z + Time.deltaTime);

    }
}
