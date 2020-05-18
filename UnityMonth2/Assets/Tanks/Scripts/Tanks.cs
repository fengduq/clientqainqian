using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Google.Protobuf;
using Move;
using UnityEngine;

public class Tanks : MonoBehaviour
{
    /*坦克移动
     
        WSAD的方式移动
        1:获取轴
        2:通过刚体的方式来进行移动(给刚体添加一个力)

    */

    public SpawnController spawnController;

    private ConcurrentQueue<SCPlayerMove> _SCPlayerQueue;

    public ConcurrentQueue<SCPlayerMove> SCPlayerQueue
    {
        get => _SCPlayerQueue;
        set => _SCPlayerQueue = value;
    }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        _SCPlayerQueue =new  ConcurrentQueue<SCPlayerMove>();
        spawnController = GetComponentInChildren<SpawnController>();
        //开始进行绑定当前的id
        Player player = new Player(gameObject);
        player.Tanks = this;
        MainManager.Instance.PlayerManager.Player.Add(id, player);
    }


    void Update()
    {
        //调用方法
        long playerId = MainManager.Instance.PlayerManager.PlayerId;
        float horizontal = Input.GetAxisRaw("Horizontal" + id);
        float vertical = Input.GetAxisRaw("Vertical" + id);

        if (id == playerId)
        {
            CSPlayerMove csPlayerMove = new CSPlayerMove();
            csPlayerMove.PlayerId = id;
            csPlayerMove.Move = new MoveInfo();
            csPlayerMove.Move.Ctime = 0;
            csPlayerMove.Move.Dir = vertical;
            csPlayerMove.Move.Spinning = horizontal;
            csPlayerMove.Move.Fire = "";
            csPlayerMove.Move.Stime = 0;
            byte[] bytes = csPlayerMove.ToByteArray();
            Protocol protocol = new Protocol((int) CodeNet.CSPlayerMove, bytes.Length, playerId, bytes);
            MainManager.Instance.NetManager.UdpManager.write(protocol);
        }

        //占时效果的代码
        int i = 0;
        while (!_SCPlayerQueue.IsEmpty)
        {
            SCPlayerMove playerMove;
            _SCPlayerQueue.TryDequeue(out playerMove);
            long playerid = playerMove.PlayerId;
            float horizontalc = playerMove.Move.Spinning;
            float verticalc = playerMove.Move.Dir;
            if (playerid == id)
            {
                rig.velocity = transform.forward * verticalc * speed;
                if (verticalc > 0)
                    rig.angularVelocity = transform.up * horizontalc * speed;
                else
                    rig.angularVelocity = transform.up * -horizontalc * speed;
            }
            //最多一次处理20次消息
            if (i == 20) {
                Debug.Log("当前服务器消息过多");
                break;
            }
            i++;
        }


        //Debug.Log(t);
        //TanksMove();
        //TanksAttack();
    }

    Rigidbody rig;

    //在面板当中可以记性数值的调整
    [SerializeField] int speed = 20, id;

    //坦克移动的方法 回调实现
//     private void TanksMove(Protocol protocol)
//     {
//         //移动方式一
//         //float horizontal = Input.GetAxis("Horizontal");
//         //rig.angularVelocity = transform.up * horizontal * speed;
//
//         //float vertical = Input.GetAxis("Vertical");
//         //rig.velocity = transform.forward * vertical * speed;
//
//         
//         //添加方法使
//         SCPlayerMove csPlayerMove=SCPlayerMove.Parser.ParseFrom(protocol.Probuffer);
//         long playerid=protocol.Pid;
//         float horizontalc=csPlayerMove.Move.Spinning;
//         float verticalc=csPlayerMove.Move.Spinning;
//
//         if (playerid == id)
//         {
//             rig.velocity = transform.forward * verticalc * speed;
//             if (verticalc > 0)
//                 rig.angularVelocity = transform.up * horizontalc * speed;
//             else
//                 rig.angularVelocity = transform.up * -horizontalc * speed;
//         }
//
//
//
//         //移动方式二
//         //GetAxisRaw(没有惯性)
// //        float horizontal = Input.GetAxisRaw("Horizontal"+id);
// //        float vertical = Input.GetAxisRaw("Vertical" + id);
// //        rig.velocity = transform.forward * vertical * speed;
// //        if (vertical > 0)
// //            rig.angularVelocity = transform.up * horizontal * speed;
// //        else
// //            rig.angularVelocity = transform.up * -horizontal * speed;
//     }

    public KeyCode AttackKey;

    private void TanksAttack()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            spawnController.ShellSpawn();
        }
    }
}