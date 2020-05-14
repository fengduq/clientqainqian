using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormDemo : MonoBehaviour
{


    //常用功能:位置角度大小修改,获取子级的个数,注释目标,设置子级,返回根节点.


    //需求:让飞机可以动起来.
    //1:首先,让螺旋桨先动起来.(脑袋和屁股)
    //2:当你的直升机转速够多少的时候,直升机起飞
    //3:飞机上升(Y轴的变化)
    //4:WS移动 AD旋转

    GameObject mainRotor;
    AudioSource audios;
    void Start()
    {
        //先找到游戏物体
        mainRotor = GameObject.Find("Main_Rotor");
        audios = GetComponent<AudioSource>();
        audios.pitch = 0;
    }

    float speed = 1, height = 0;
    void Update1()
    {

        //效果值的累加
        if (speed < 1000)
            speed += 5;

        if (audios.pitch <= 1)
            audios.pitch += 0.05f;
        //螺旋桨的旋转
        mainRotor.transform.Rotate(Vector3.up, speed * Time.deltaTime);
        print(speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && speed > 500)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
            height++;
        }

        //判断当直升机到达一定高度之后
        if (height > 55)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 55);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * 55);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * -Time.deltaTime * 55);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 55);
            }
        }
    }


    //Fixed
    private void Update()
    {
        /*Time类

        //只读
        Time.deltaTime:从上一帧到当前帧的时间,是秒为单位
        Time.time:表示从游戏开始到当前的时间,会着游戏暂时,而停止计算
        Time.fixedTime:游戏开始之后按照秒计算的时间
        Time.fixedDeltaTime: 在物理和其他的固定帧进行更新
        Time.realtimeSinceStartup:开始游戏之后即便暂停也会继续累加时间.

        //可读可写
         Time.timeScale:时间缩放(暂停)  0停止  1默认  >1加速
         */



        /*Input类
         
         基于Unity所有的输入输入操作(物理)
         PC-
         键盘:按下 抬起 持续按下
         Input.GetKey  
         鼠标:按下 抬起 持续按下
         Input.GetMouseButton(?)
         */

        if (Input.GetMouseButton(0))
        {
            print(1111111111111);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h, 0, v);
    }
}
