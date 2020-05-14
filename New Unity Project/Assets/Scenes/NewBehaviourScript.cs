using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int x;
    public NewBehaviourScript()
    {
        Debug.Log("当前 NewBehaviourScript");
    }
    void Start()
    {
        Debug.Log("当前 Start");
        GameObject obj = gameObject;
        //gameObject.transform.position=new Vector3(10.0F, 10.0F, 10.0F);
        //GameObject firstObj = new GameObject();
        
        NewBehaviourScript that =this.GetComponent<NewBehaviourScript>();
        //that.x = 10;
        MeshRenderer mesh = this.GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
        Debug.Log("当前 10,10,10");
        Debug.Log(mesh.name);
        //Component  component= firstObj.GetComponent(mesh.name);
        //Debug.Log(component.name);
    }
    private void OnEnable()
    {
        Debug.Log("当前 OnEnable");
    }
    //******物理阶段********//
    //默认0.02 秒执行一次 
    //针对一些物理操作适用于物理运动
    private void FixedUpdate()
    {
        //Debug.Log("fixedUpdate");
    }
    //
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }


    private void Awake()
    {
        Debug.Log("当前 Awake");
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }
    //处理跟随
    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }
    private void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible");
    }

}
