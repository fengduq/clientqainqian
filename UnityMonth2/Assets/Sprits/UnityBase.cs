using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*GameObject游戏物体(对象)
       

    GameObject:代表某一个游戏对象
    gameObject:代表脚本自身所赋予的对象
    增
    new GameObject();
    Instantiate();
    删
    Destroy();
    禁用启用
    改
    修改对象数据(组件)
    查 
    Find的方式来查找
 
     */

/*Component组件
  
    添加组件的方式 (增)
    addComponent
    
    删除组件的个方式 (删除)
    Destroy();
    Destroy(gameObject.GetComponent<BoxCollider>());
    修改组件的方式 (改)
    方法() 属性=
    查找
    GetComponent<BoxCollider>()
 */

public class UnityBase : MonoBehaviour
{

    public GameObject obj;
    BoxCollider box;
    //开始游戏(加载内存)之前执行,只执行一次.
    void Start()
    {
        //动态创建
         new GameObject();
        // Destroy(gameObject);
        //GameObject.Find("游戏物体的名称");

        //组件添加
        gameObject.AddComponent<Light>();
        //删除
        //Destroy(gameObject.GetComponent<BoxCollider>());
        //修改
        GetComponent<BoxCollider>().isTrigger = true;
        //GetComponent<BoxCollider>().CompareTag();
        //查找
       box= GetComponent<BoxCollider>();
       // GetComponent<MeshRenderer>().enabled=false;
       
    }


    //开始游戏之后执行,并且每帧执行,时间约等于0.02秒
    void Update()
    {
        box.GetComponent<MeshRenderer>().enabled = true;
        box.gameObject.AddComponent<Rigidbody>();
        Instantiate(obj);
    }
}
