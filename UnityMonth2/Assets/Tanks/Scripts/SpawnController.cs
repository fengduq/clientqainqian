using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ShellSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int speed;

    public GameObject shell;
    public void ShellSpawn()
    {
        shell =Instantiate(Resources.Load("shell"), transform.position,transform.rotation) as GameObject;
        shell.GetComponent<Rigidbody>().velocity = transform.forward*speed;
    }
}
