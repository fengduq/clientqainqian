using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanks : MonoBehaviour
{

    /*坦克移动
     
        WSAD的方式移动
        1:获取轴
        2:通过刚体的方式来进行移动(给刚体添加一个力)

    */

    public SpawnController spawnController;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        spawnController = GetComponentInChildren<SpawnController>();
        Do dele = TanksMove;
        MainManager.Instance.NetManager.Dictionary.Add((int) CodeNet.SCPlayerMove, dele);

    }
    

    void Update()
    {
        //调用方法
        float t = Time.time;
        //Debug.Log(t);
        //TanksMove();
        TanksAttack();
    }

    Rigidbody rig;
    //在面板当中可以记性数值的调整
    [SerializeField]
    int speed = 20,id;

    //坦克移动的方法 回调实现
    private void TanksMove(Protocol protocol)
    {
        //移动方式一
        //float horizontal = Input.GetAxis("Horizontal");
        //rig.angularVelocity = transform.up * horizontal * speed;

        //float vertical = Input.GetAxis("Vertical");
        //rig.velocity = transform.forward * vertical * speed;

        
        //添加方法使
        
        
        
        //移动方式二
        //GetAxisRaw(没有惯性)
        float horizontal = Input.GetAxisRaw("Horizontal"+id);
        float vertical = Input.GetAxisRaw("Vertical" + id);
        rig.velocity = transform.forward * vertical * speed;
        if (vertical > 0)
            rig.angularVelocity = transform.up * horizontal * speed;
        else
            rig.angularVelocity = transform.up * -horizontal * speed;
    }

    public KeyCode AttackKey;

    private void TanksAttack()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            spawnController.ShellSpawn();
        }
    }

}
